using ADOX;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Channels;

namespace Xsd2Db.Data
{
    /// <summary>
    /// This abstract class implements most of the functionality required
    /// to map an XSD schema (represented with a DataSet) to an SQL creation
    /// script.
    /// </summary>
    public abstract class ScriptBasedDataSchemaAdapter : IDataSchemaAdapter
    {
        /// <summary>
        ///  Parameters import XSD
        /// </summary>
        public abstract Parameter Param { get; set;}

        /// <summary>
        ///  Import data from DataTable in DataBase
        /// </summary>
        public abstract void SaveToDB(DataTable table);

        /// <summary>
        /// Import data from DataSet in Postgres DataBase
        /// </summary>
        public abstract void SaveToDB();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract string GetCreateDBScript();
        /// <summary>
        /// Child classes should provice an implementation which returns a
        /// connection to the server on which to create the new database.
        /// The returned connection must be bound to the context of the
        /// catalog/database given as a parameter (by name).
        /// </summary>
        /// <returns>an unopened connection to the server.</returns>
        protected abstract IDbConnection GetConnection();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
        protected abstract IDbConnection GetConnection(string catalog);
        /// <summary>
        /// Create a new database conforming to the passed schema.
        /// </summary>
        string IDataSchemaAdapter.Create()
        {
           return Create();
        }
        /// <summary>
        /// The function returns a string DataTable value as XML
        /// </summary>
        /// <param name="dtData"></param>
        /// <returns></returns>
        public string ConvertDataTableToXML(DataTable dtData)
        {
            DataSet dsData = new DataSet();
            StringBuilder sbSQL;
            StringWriter swSQL;
            string XMLformat;
            try
            {
                sbSQL = new StringBuilder();
                swSQL = new StringWriter(sbSQL);
                dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
                foreach (DataColumn col in dtData.Columns)
                {
                    col.ColumnMapping = MappingType.Attribute;
                }
                dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
                XMLformat = sbSQL.ToString();
                return XMLformat;
            }
            catch (Exception sysException)
            {
                throw sysException;
            }
        }



        /// <summary>
        /// Create a new database conforming to the passed schema.
        /// </summary>
        public string Create()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    //
                    // Create the database
                    //
                    string script = GetCreateDBScript();
                    using (IDbCommand cmd = conn.CreateCommand())
                    {
                        Debug.Assert(script.Length > 0);
                        cmd.CommandText = script;
                        string result = cmd.ExecuteScalar() as string;
                        if (!string.IsNullOrEmpty(result))
                        {
                            cmd.CommandText = result;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                using (IDbConnection conn = GetConnection(this.Param.InitialCatalog))
                {
                    conn.Open();

                    //
                    // Set up the schema
                    //
                    string[] script = GetSchemaScript(this.Param.Schema);
                    if (script.Length > 0)
                    {
                        using (IDbCommand cmd = conn.CreateCommand())
                        {
                            foreach (string query in script)
                            {
                                cmd.CommandText = query;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }
       

        /// <summary>
        /// Returns the type description for the column given.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        protected abstract string GetTypeFor(DataColumn column);

        /// <summary>
        /// Returns a safe version of the given name.
        /// </summary>
        /// <param name="inputValue">Original Name</param>
        /// <returns>Converted name</returns>
        protected abstract string MakeSafe(string inputValue);
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract string MakeConstraint(DataTable table);
        
        /// <summary>
        /// Returns the creation script which corresponds to the schema
        /// contained in the .xsd file which is passed as a parameter.
        /// </summary>
        /// <exception cref="ArgumentException">This method does not support
        /// the creation of a schema containing tables that have zero (0)
        /// columns.  Nor does is support relations where one (or both) sides
        /// of the relationship is defined by zero (0) columns.</exception>
        /// <exception cref="NotSupportedException">May be thrown if the
        /// method is unable to determine the database type for a column
        /// </exception>
        /// <param name="dataSet">the DataSet containing the database schema
        /// to be created.
        /// </param>
        /// <returns>An SQL creation script corresponding to the schema of
        /// the passed DataSet.</returns>
        internal string[] GetSchemaScript(DataSet dataSet)
        {
            if (dataSet == null)
            {
                throw new ArgumentException("null is not a valid parameter value", "dataSet");
            }

            List<string> result = new List<string>();


            StringBuilder command = new StringBuilder();

            result.AddRange(MakeSchema());

            Debug.WriteLine(command.ToString());

            foreach (DataTable table in dataSet.Tables)
            {
                if (table.Columns.Count == 0) continue;
                try
                {
                    string s = MakeTable(table);
                    command.Append(s);
                }
                catch (ArgumentException exception)
                {
                    throw new ArgumentException("Table does not contain any columns", table.TableName, exception);
                }
            }

            foreach (DataTable table in dataSet.Tables)
                if (table.PrimaryKey.Length > 0)
                {             
                    string constraint = MakeConstraint(table);
                    command.AppendLine(constraint);
                }

            foreach (DataRelation relation in dataSet.Relations)
                try
                {
                    command.Append(MakeRelation(relation));
                }
                catch (ArgumentException exception)
                {
                    throw new ArgumentException("Relationship has an empty column list", relation.RelationName, exception);
                }

            result.Add(command.ToString());

            return result.ToArray();
        }

        internal abstract string[] MakeSchema();

        internal abstract string MakeTable(DataTable table);

        /// <summary>
        /// Returns the names of the columns in <paramref name="columns"/>.
        /// </summary>
        /// <param name="columns">the collection of columns to be put in the list</param>
        /// <returns>the names of the columns in a comma separated list</returns>
        /// <exception cref="System.ArgumentException">This is thrown if
        /// <paramref name="columns"/> is empty or null</exception>
         internal string MakeList(DataColumn[] columns)
        {
            if (columns == null)
            {
                throw new ArgumentException("Invalid column list!", "columns");
            }

            List<string> list = new List<string>();
            foreach (DataColumn c in columns) list.Add(MakeSafe(c.ColumnName));
            return string.Join(",\n", list.ToArray());
        }      

        /// <summary>
        /// Returns the names of the columns in <paramref name="columns"/>.
        /// </summary>
        /// <param name="columns">the collection of columns to be put in the list</param>
        /// <returns>the names of the columns in a comma separated list</returns>
        /// <exception cref="System.ArgumentException">This is thrown if
        /// <paramref name="columns"/> is empty or null</exception>
        internal string MakeList(DataColumnCollection columns)
        {
            if (columns == null)
            {
                throw new ArgumentException("Invalid column list!", "columns");
            }

            List<string> list = new List<string>();
            foreach (DataColumn c in columns) list.Add(MakeSafe(c.ColumnName) + " " + GetTypeFor(c));

            return string.Join(",\n\t", list.ToArray());
        }

        /// <summary>
        /// Returns a script which will create a database relations
        /// corresponding to the passed DataRelation.
        /// </summary>
        /// <param name="relation">the DataRelation to be scripted</param>
        /// <returns>the script to create the relation</returns>
        /// <exception cref="System.ArgumentException">This is thrown if
        /// <paramref name="relation"/> is null or any of the
        /// key sets in the relation are empty</exception>
        private string MakeRelation(DataRelation relation)
        {
            if (relation == null)
            {
                throw new ArgumentException("Invalid argument value (null)", "relation");
            }

            StringBuilder command = new StringBuilder();
            string childTable = MakeSafe(Param.TablePrefix + relation.ChildTable.TableName);
            string parentTable = MakeSafe(Param.TablePrefix + relation.ParentTable.TableName);
            string relationName = MakeSafe(relation.RelationName);
            string childColumns = MakeList(relation.ChildColumns);
            string parentColumns = MakeList(relation.ParentColumns);
            command.AppendFormat("ALTER TABLE {0} ADD CONSTRAINT {1} FOREIGN KEY ({2}) REFERENCES {3} ({4});\n", childTable, relationName, childColumns, parentTable, parentColumns);
            return command.ToString();
        }



        #region  Events
        /// <summary>
        ///  Event that occurs when changes are made to the database connection
        /// </summary>
        private event EventHandler<ConnectionStringEventArgs> InternalConnectionChanged;
        
        /// <summary>
        /// Event that occurs when changes are made to the database connection
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnConnectionChanged(ConnectionStringEventArgs e)
        {
            InternalConnectionChanged?.Invoke(this, e);
        }
        /// <summary>
        /// Event that occurs when changes are made to the database connection
        /// </summary>
        public event EventHandler<ConnectionStringEventArgs> ConnectionChanged
        {
            add { InternalConnectionChanged += value; }
            remove { InternalConnectionChanged -= value; }
        }

        #endregion
    }
}