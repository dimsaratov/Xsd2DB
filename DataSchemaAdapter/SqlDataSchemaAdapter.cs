using ADOX;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Text;

namespace Xsd2Db.Data
{
	/// <summary>
	/// A class which generates creation scripts which are compatible
	/// with Microsoft SQL Server 2000.
	/// </summary>
	public class SqlDataSchemaAdapter : ScriptBasedDataSchemaAdapter
	{
		/// <summary>
		/// A map between a data type name and a database type template
		/// </summary>
		internal static readonly Hashtable TypeMap;
        /// <summary>
        /// Parameters import XSD
        /// </summary>
        public override Parameter Param { get; set;}

        /// <summary>
        /// Creates a new SqlScriptGenerator instance.
        /// </summary>
        /// <param name="param">the database host to connect to</param>
        public SqlDataSchemaAdapter(Parameter param)
		{
			this.Param = param;
		}

		/// <summary>
		/// 
		/// </summary>
		static SqlDataSchemaAdapter()
		{
            Hashtable typeMap = new Hashtable
            {
                [typeof(UInt64)] = "bigint {1}NULL",
                [typeof(Int64)] = "bigint {1}NULL",
                [typeof(Boolean)] = "bit {1}NULL",
                [typeof(Char)] = "char {1}NULL",
                [typeof(DateTime)] = "datetime {1}NULL",
                [typeof(Double)] = "float {1}NULL",
                [typeof(UInt32)] = "int {1}NULL",
                [typeof(Int32)] = "int {1}NULL",
                [typeof(Guid)] = "uniqueidentifier {1}NULL",
                [typeof(UInt16)] = "smallint {1}NULL",
                [typeof(Int16)] = "smallint {1}NULL",
                [typeof(Decimal)] = "real {1}NULL",
                [typeof(Byte)] = "tinyint {1}NULL",
                [typeof(String)] = "varchar({0}) {1}NULL",
                [typeof(TimeSpan)] = "int {1}NULL",
                [typeof(Byte[])] = "varbinary {1}NULL"
            };

            SqlDataSchemaAdapter.TypeMap = typeMap;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Return IDbConnection</returns>
        protected override IDbConnection GetConnection()
        {
            return GetConnection(null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Return IDbConnection</returns>
        protected override IDbConnection GetConnection(string catalog)
        {
            SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder
            {
                DataSource = this.Param.Host,
                IntegratedSecurity = true,
                Pooling = false,
            };

            if (this.Param.Port != 1433) connectionString.DataSource += "," + this.Param.Port;
            if (catalog != null) connectionString.InitialCatalog = catalog;
            if (this.Param.User != null && this.Param.User.Length > 0) connectionString.UserID = this.Param.User;
            if (this.Param.Password != null && this.Param.Password.Length > 0) connectionString.Password = this.Param.Password;

            SqlConnection connection = new SqlConnection(connectionString.ToString());
            OnConnectionChanged(new ConnectionStringEventArgs(connection));
            return connection;
        }


        /// <summary>
        /// Returns a script which creates a database table that
        /// corresponds to <paramref name="table"/>.
        /// </summary>
        /// <param name="table"></param>
        /// <returns>the script which creates a table corresponding to <paramref name="table"/></returns>
        internal override string MakeTable(DataTable table)
        {
            StringBuilder command = new StringBuilder();

            string tableName =MakeSafe(Param.SchemaName) +  "." + MakeSafe(Param.TablePrefix + table.TableName);
            string tableColumns = MakeList(table.Columns);
            command.AppendFormat("if exists (select * from dbo.sysobjects where id = object_id(N'{0}') and OBJECTPROPERTY(id, N'IsUserTable') = 1) DROP TABLE {0}\n", tableName);
            command.AppendFormat("CREATE TABLE {0}\n\t({1});\n", tableName, tableColumns);

            return command.ToString();
        }

        /// <summary>
        /// SQL Server names to be more than 128 characters long.
        /// This function trims the given name and returns at
        /// most the first 128 characters.  It also wraps the name
        /// in square brackets (i.e., '[' and ']').
        /// </summary>
        /// <param name="inputValue">Original Name</param>
        /// <returns>Converted name</returns>
        protected override string MakeSafe(string inputValue)
		{
			String text = inputValue.Trim();
			return String.Format("[{0}]", text.Substring(0, Math.Min(128, text.Length)));
		}

		/// <summary>
		/// Returns the type descriptor corresponding to
		/// <paramref name="column"/>.
		/// </summary>
		/// <param name="column">the DataColumn for which the type is desired</param>
		/// <returns>the type descriptor corresponding to
		/// <paramref name="column"/></returns>
		protected override string GetTypeFor(DataColumn column)
		{
			string template = (string) TypeMap[column.DataType];

			if ((column.DataType == typeof (String)) && (column.MaxLength < 0))	template = "text";
			

			if (template == null)			
				throw new NotSupportedException(String.Format("No type mapping is provided for {0}",
												column.DataType.Name));			

			return String.Format(template, column.MaxLength, (column.AllowDBNull ? String.Empty : "NOT "));
		}
        /// <summary>
        /// Import data from DataTable in SqlServer DataBase
        /// </summary>
        public override void SaveToDB(DataTable table)
        {
            using (var conn = GetConnection() as SqlConnection)
            {
                conn.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName = MakeSafe(Param.SchemaName) + "." + MakeSafe(table.TableName);
                    try
                    {
                        bulkCopy.WriteToServer(table);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Returns a script which creates an empty database having the given name.
        /// </summary>
        /// <returns>the script required to create an empty database having the given name</returns>
        internal string GetCreateScript()
        {
            if (string.IsNullOrWhiteSpace(Param.InitialCatalog))
            {
                throw new ArgumentException(String.Format("The database name passed is {0}",
                                            ((Param.InitialCatalog == null) ? "null" : "empty")),
                                            "InitialCatalog");
            }

            StringBuilder command = new StringBuilder();

            if (Param.Force)
            {
                command.AppendFormat("IF(db_id(N'{0}') IS NOT NULL)\n" +
                                     "DROP DATABASE {1};\n" +
                                     "CREATE DATABASE {1};\n",
                                     Param.InitialCatalog, MakeSafe(Param.InitialCatalog));
            }
            else
            {
                command.AppendFormat("IF(db_id(N'{0}') IS NULL)\n" +
                                     "CREATE DATABASE {1};\n",
                                     Param.InitialCatalog, MakeSafe(Param.InitialCatalog));
            }
            return command.ToString();
        }

        /// <summary>
        /// Import data from DataSet in Postgres DataBase
        /// </summary>
        public override void SaveToDB()
        {
            using (var conn = GetConnection(Param.InitialCatalog) as SqlConnection)
            {
                conn.Open();

                foreach (DataTable table in this.Param.Schema.Tables)
                {
                    if (table.Rows.Count > 0)
                    {
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                        {
                            bulkCopy.DestinationTableName = MakeSafe(Param.SchemaName) + "." + MakeSafe(table.TableName);
                            try
                            {
                                bulkCopy.WriteToServer(table);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Returns a script which creates an empty database having the given name.
        /// </summary>
        /// <returns>the script required to create an empty database having the given name</returns>
        protected override string GetCreateDBScript()
        {
            if (string.IsNullOrWhiteSpace(Param.InitialCatalog))
            {
                throw new ArgumentException(String.Format("The database name passed is {0}",
                                            ((Param.InitialCatalog == null) ? "null" : "empty")),
                                            "InitialCatalog");
            }

            StringBuilder command = new StringBuilder();

            string safeName = MakeSafe(Param.InitialCatalog);

            if (Param.Force)
            {
                command.AppendFormat("IF(db_id(N'{0}') IS NOT NULL)", Param.InitialCatalog);
                command.AppendLine("BEGIN");
                command.AppendFormat("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;\n", safeName);
                command.AppendLine("DROP DATABASE " + MakeSafe(Param.InitialCatalog) + ";\n");
                command.AppendLine("END\n");
                command.AppendLine("CREATE DATABASE " + MakeSafe(Param.InitialCatalog) + "; ");                                 
            }
            else
            {
                command.AppendFormat("IF(db_id(N'{0}') IS NULL)\n", Param.InitialCatalog);
                command.AppendLine("CREATE DATABASE " + MakeSafe(Param.InitialCatalog) + ";");
            }
            return command.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        protected override string MakeConstraint(DataTable table)
        {
            string tableName = MakeSafe(Param.SchemaName) + "." + MakeSafe(Param.TablePrefix + table.TableName);
            string primaryKeyName = MakeSafe("PK_" + Param.TablePrefix + table.TableName);
            string primaryKeyList = MakeList(table.PrimaryKey);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ALTER TABLE " + tableName) ;
            sb.AppendLine("\tWITH NOCHECK");
            sb.AppendLine("\tADD CONSTRAINT " + primaryKeyName);
            sb.AppendFormat("\tPRIMARY KEY CLUSTERED ({0});", primaryKeyList);
            return sb.ToString();
        }

        internal override string[] MakeSchema()
        {
            List<string> list = new List<string>();
            if (Param.SchemaName != "dbo")
            {
                string user = "[" + Param.User + "]";
                string schema =  "[" + Param.SchemaName + "]";
                list.Add(string.Format("CREATE USER {0} FOR LOGIN {0}", user));
                list.Add(string.Format("CREATE SCHEMA {0} AUTHORIZATION{1}", schema, user));
            }
            return list.ToArray();
        }
    }
}