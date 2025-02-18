using System;
using System.Data;
using static Xsd2Db.Data.Enums;

namespace Xsd2Db.Data
{
    /// <summary>
    /// Importing a dataset obtained from an XSD schema
    /// </summary>
    public static class CreatorSchema 
    {
        /// <summary>
        /// Procedure for importing a dataset obtained from an XSD schema
        /// </summary>
        /// <param name="param"></param>
        public static string Create(Parameter param)
        {
            try
            {
                DataSet Schema = new DataSet();
                IDataSchemaAdapter adapter = Creator(param);
                adapter.ConnectionChanged += Adapter_ConnectionChanged;
                Schema.ReadXml(param.SchemaFile);
                param.Schema = Schema;
                param.DataSetName = Schema.DataSetName;

                if (string.IsNullOrWhiteSpace(param.InitialCatalog)) param.InitialCatalog = Schema.DataSetName;
                string result = adapter.Create();
                if (result.Length > 0)
                {
                    return result;
                }
                if (param.ImportData) adapter.SaveToDB();
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static void Adapter_ConnectionChanged(object sender, ConnectionStringEventArgs e)
        {
            OnConnectionChanged((IDataSchemaAdapter) sender, e);
        }

        static IDataSchemaAdapter Creator(Parameter param)
        {
            switch (param.Type)
            {
                default:
                case DatabaseType.Sql:
                    return new SqlDataSchemaAdapter(param);
                case DatabaseType.NpgSql:
                    return new NpgSqlDataSchemaAdapter(param);

            }
        }

        #region  Events

        private static event EventHandler<ConnectionStringEventArgs> InternalConnectionChanged;
        private static void OnConnectionChanged(IDataSchemaAdapter sender, ConnectionStringEventArgs e)
        {
            InternalConnectionChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Event that occurs when changes are made to the database connection
        /// </summary>
        public static event EventHandler<ConnectionStringEventArgs> ConnectionChanged
        {
            add { InternalConnectionChanged += value; }
            remove { InternalConnectionChanged -= value; }
        }

        #endregion

    }
}

