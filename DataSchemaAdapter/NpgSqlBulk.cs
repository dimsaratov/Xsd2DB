using Npgsql;
using NpgsqlTypes;
using System;
using System.Data;
using System.Text;

namespace Xsd2Db.Data
{
    internal static class NpgSqlBulk
    {

        public static void WriteToServer(string schemaName, DataTable dataTable, NpgsqlConnection conn)
        {
            try
            {
                string tableName = schemaName + ".\"" + dataTable.TableName + "\"" ;

                int colCount = dataTable.Columns.Count;

                NpgsqlDbType[] types = new NpgsqlDbType[colCount];
                int[] lengths = new int[colCount];
                string[] fieldNames = new string[colCount];
                string q ="SELECT * FROM " + tableName + " LIMIT 1";
                using (var cmd = new NpgsqlCommand(q , conn))
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.FieldCount != colCount)
                        {
                            throw new ArgumentOutOfRangeException("dataTable", "Column count in Destination Table does not match column count in source table.");
                        }
                        var columns = rdr.GetColumnSchema();
                        for (int i = 0; i < colCount; i++)
                        {
                            types[i] = (NpgsqlDbType)columns[i].NpgsqlDbType;
                            lengths[i] = columns[i].ColumnSize == null ? 0 : (int)columns[i].ColumnSize;
                            fieldNames[i] = columns[i].ColumnName;
                        }
                    }

                }
                var sB = new StringBuilder(fieldNames[0]);
                for (int p = 1; p < colCount; p++)
                {
                    sB.Append(", " + fieldNames[p]);
                }
                using (var writer = conn.BeginBinaryImport("COPY " + tableName + " (" + sB.ToString() + ") FROM STDIN (FORMAT BINARY)"))
                {
                    for (int j = 0; j < dataTable.Rows.Count; j++)
                    {
                        DataRow dR = dataTable.Rows[j];
                        writer.StartRow();

                        for (int i = 0; i < colCount; i++)
                        {
                            if (dR[i] == DBNull.Value)
                            {
                                writer.WriteNull();
                            }
                            else
                            {
                                object v = GetValue(dR[i], types[i], lengths[i]);
                                writer.Write(v, types[i]);
                            }
                        }
                    }
                    writer.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing NpgSqlBulkCopy.WriteToServer().  See inner exception for details", ex);
            }
        }

      static object GetValue(object value, NpgsqlDbType type, int size)
        {
            switch (type)
            {
                case NpgsqlDbType.Bigint:
                    return (long)type;

                case NpgsqlDbType.Bit:
                    if (size > 1)
                        return (byte[])value;
                    else
                        return (byte)type;
                case NpgsqlDbType.Boolean:
                    return (bool)value;
                case NpgsqlDbType.Bytea:
                    return (byte[])value;
                case NpgsqlDbType.Char:
                    if (value is string @string)
                        return @string;
                    else if (value is Guid)
                        return value.ToString();
                    else if (size > 1)
                        return (char[])value;
                    else
                        return ((string)value.ToString()).ToCharArray();
                case NpgsqlDbType.Time:
                case NpgsqlDbType.Timestamp:
                case NpgsqlDbType.TimestampTz:
                case NpgsqlDbType.Date:
                    return (DateTime)value;
                case NpgsqlDbType.Double:
                    return (double)value;
                case NpgsqlDbType.Integer:
                    if (value is int @int)
                        return @int;
                    else if (value is string v)
                        return Convert.ToInt32(v);
                    return (object)value;
                case NpgsqlDbType.Interval:
                    return (TimeSpan)value;
                case NpgsqlDbType.Numeric:
                case NpgsqlDbType.Money:
                    return (decimal)value;
                case NpgsqlDbType.Real:
                    return (Single)value;
                case NpgsqlDbType.Smallint:
                    if (value is byte)
                        return Convert.ToInt16(value);
                    else
                        return (short)value;
                case NpgsqlDbType.Varchar:
                case NpgsqlDbType.Text:
                    return (string)value;
                case NpgsqlDbType.Uuid:
                    return (Guid)value;
                case NpgsqlDbType.Xml:
                    return (string)value;
                default:
                    return (object)value;
            }
        }
    }
}
