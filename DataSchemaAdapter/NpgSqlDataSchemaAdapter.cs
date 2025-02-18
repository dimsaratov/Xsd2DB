using ADODB;
using ADOX;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;
using System.Text;

namespace Xsd2Db.Data
{
	/// <summary>
	/// A class which generates creation scripts which are compatible
	/// with Postgres SQL Server 15.1
	/// </summary>
	public class NpgSqlDataSchemaAdapter : ScriptBasedDataSchemaAdapter
	{
		internal static readonly Hashtable TypeMap;

		/// <summary>
		/// Parameters import XSD
		/// </summary>
		public override Parameter Param { get; set; }

		/// <summary>
		/// Adapter for writing an XSD schema to a PostgresSQL database
		/// </summary>
		/// <param name="param">XSD Schema Export Parameters</param>
		public NpgSqlDataSchemaAdapter(Parameter param)
		{
			this.Param = param;			
		}

		/// <summary>
		/// 
		/// </summary>
		static NpgSqlDataSchemaAdapter()
		{
			Hashtable typeMap = new Hashtable
			{
				[typeof(UInt64)] = "bigint {1}NULL",
				[typeof(Int64)] = "bigint {1}NULL",
				[typeof(Boolean)] = "boolean {1}NULL",
				[typeof(Char)] = "text {1}NULL",
				[typeof(DateTime)] = "timestamp {1}NULL",
				[typeof(Double)] = "double precision {1}NULL",
				[typeof(UInt32)] = "int {1}NULL",
				[typeof(Int32)] = "int {1}NULL",
				[typeof(Guid)] = "uuid {1}NULL",
				[typeof(UInt16)] = "smallint {1}NULL",
				[typeof(Int16)] = "smallint {1}NULL",
				[typeof(Decimal)] = "decimal {1}NULL",
				[typeof(Byte)] = "smallint {1}NULL",
				[typeof(String)] = "text {1}NULL",
				[typeof(TimeSpan)] = "int {1}NULL",
				[typeof(Byte[])] = "bytea {1}NULL"
			};

			NpgSqlDataSchemaAdapter.TypeMap = typeMap;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected override IDbConnection GetConnection()
		{
			return GetConnection(null);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="catalog"></param>
		/// <returns></returns>
		protected override IDbConnection GetConnection(string catalog)
		{
			NpgsqlConnectionStringBuilder connectionString = new NpgsqlConnectionStringBuilder()
			{
				Host = this.Param.Host,
				Port = this.Param.Port,
				Pooling = false,
				Database = catalog == null ? "postgres" : Param.InitialCatalog,
				Timeout = this.Param.Timeout,
				CommandTimeout = this.Param.CommandTimeout
			};

			if (this.Param.User != null && this.Param.User.Length > 0) connectionString.Username = this.Param.User;
			if (this.Param.Password != null && this.Param.Password.Length > 0) { connectionString.Password = this.Param.Password; }

			NpgsqlConnection connection = new NpgsqlConnection(connectionString.ConnectionString);
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

			string tableName = Param.SchemaName + "." + MakeSafe(Param.TablePrefix + table.TableName);
			string tableColumns = MakeList(table.Columns);
			command.AppendFormat("DROP TABLE IF EXISTS {0};\n", tableName);
			command.AppendFormat("CREATE TABLE {0}\n\t({1});\n",  tableName, tableColumns);
			command.AppendFormat("GRANT ALL ON TABLE {0} TO \"{1}\";\n", tableName, Param.User);

			return command.ToString();
		}

		/// <summary>
		/// Postgres Server names to be more than 128 characters long.
		/// This function trims the given name and returns at
		/// most the first 128 characters.  It also wraps the name
		/// in square brackets (i.e., '"' and '"').
		/// </summary>
		/// <param name="inputValue">Original Name</param>
		/// <returns>Converted name</returns>
		protected override string MakeSafe(string inputValue)
		{
			String text = inputValue.Trim();
			return String.Format("\"{0}\"", text.Substring(0, Math.Min(128, text.Length)));
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
			string template = (string)TypeMap[column.DataType];

			if ((column.DataType == typeof(String)) && (column.MaxLength < 0))
				template = "text";

			if (template == null)
			{
				throw new NotSupportedException(
					String.Format("No type mapping is provided for {0}",
								  column.DataType.Name));
			}

			return String.Format(
				template,
				column.MaxLength,
				(column.AllowDBNull ? String.Empty : "NOT "));
		}
		/// <summary>
		/// Import data from DataSet in Postgres DataBase
		/// </summary>
		public override void SaveToDB()
		{
			using (var conn = GetConnection(Param.InitialCatalog) as NpgsqlConnection)
			{
				conn.Open();

				foreach (DataTable table in this.Param.Schema.Tables)
				{
					if (table.Rows.Count > 0)
					{
						NpgSqlBulk.WriteToServer(Param.SchemaName, table, conn);
					}
				}
			}
		}

		/// <summary>
		/// Import data from DataTable in DataBase
		/// </summary>
		/// <param name="table">DataTable</param>
		public override void SaveToDB(DataTable table)
		{
			using (var conn = GetConnection(Param.InitialCatalog) as NpgsqlConnection)
			{
				conn.Open();
				NpgSqlBulk.WriteToServer(Param.SchemaName, table, conn);
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

			if (Param.Force)
			{
				command.AppendFormat("DROP DATABASE IF EXISTS {0};\n" +
									 "CREATE DATABASE {0}\n" +
									 "WITH OWNER = \"{1}\"\n" +
									 "ENCODING = 'UTF8'\n" +
									 "LC_COLLATE = 'Russian_Russia.1251'\n" +
									 "LC_CTYPE = 'Russian_Russia.1251'" +
									 "TABLESPACE = pg_default\n" +
									 "CONNECTION LIMIT = -1\n" +
									 "IS_TEMPLATE = False;",
									 MakeSafe(Param.InitialCatalog), Param.User);
			}
			else
			{
				command.AppendFormat("SELECT 'CREATE DATABASE \"{0}\"\n" +
									 "WITH OWNER = \"{1}\"\n" +
									 "ENCODING = ''UTF8''\n" +
									 "LC_COLLATE = ''Russian_Russia.1251''\n" +
									 "LC_CTYPE = ''Russian_Russia.1251''\n" +
									 "TABLESPACE = pg_default\n" +
									 "CONNECTION LIMIT = -1\n" +
									 "IS_TEMPLATE = False;'\n" +
                                     "WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = '{0}');", 
									 Param.InitialCatalog, Param.User); ;
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
			string tableName = Param.SchemaName + "." + MakeSafe(Param.TablePrefix + table.TableName);
			string primaryKeyName = MakeSafe("PK_" + Param.TablePrefix + table.TableName);
			string primaryKeyList = MakeList(table.PrimaryKey);

			StringBuilder sb = new StringBuilder();
			foreach (DataColumn c in table.PrimaryKey)
			{
				sb.Append("CREATE UNIQUE INDEX idx_" + table.TableName + "_" + c.ColumnName);
				sb.AppendFormat(" ON {0} USING btree", tableName);
				sb.AppendFormat("({0} ASC NULLS LAST);\n", c.ColumnName);
			}
			sb.AppendLine("\nALTER TABLE " + tableName);
			sb.AppendLine("\tADD CONSTRAINT " + primaryKeyName);
			sb.Append("\tPRIMARY KEY (" + primaryKeyList + ");");
			return sb.ToString();
		}

        internal override string[] MakeSchema()
        {	
			StringBuilder command = new StringBuilder();
			string user = "\"" + Param.User + "\"";
			string schemaName = "\"" + Param.SchemaName + "\"";
            command.AppendFormat("CREATE SCHEMA IF NOT EXISTS {0}\r\nAUTHORIZATION {1};\n" +
                                 "ALTER DEFAULT PRIVILEGES FOR ROLE {1} IN SCHEMA {0}\n" +
                                 "GRANT ALL ON TABLES TO {1};\n",
                                  schemaName, user);
			return new string[] { command.ToString() };
        }
    }
}