using System;
using System.Data;

namespace Xsd2Db.Data
{
    /// <summary>
    /// Application Enumerations
    /// </summary>
    public static class Enums
    {
         /// <summary>
         /// Enumeration of supported database types
         /// </summary>         
        public enum DatabaseType
        {
            /// <summary>
            /// The database type is undefined
            /// </summary>
            NoDefine,
            /// <summary>
            /// Database Sql Server 14
            /// </summary>
            Sql,
            /// <summary>
            /// Database Postgres Server 15.1
            /// </summary>
            NpgSql
        }
    }
    /// <summary>
    /// Arguments of the event that occurs when changes are made to the database connection
    /// </summary>
    public class ConnectionStringEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public IDbConnection DataConnection { get; private set; }
        /// <summary>
        /// Constructor of arguments for a new event that occurs 
        /// when changes are made to the database connection
        /// </summary>
        /// <param name="dbConnection"></param>
        public ConnectionStringEventArgs(IDbConnection dbConnection)
        {
            DataConnection= dbConnection;
        }
    }

}
