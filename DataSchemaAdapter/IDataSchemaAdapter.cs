using System;
using System.Data;

namespace Xsd2Db.Data
{
	/// <summary>
	/// Summary description for DataSchemaAdapter.
	/// </summary>
	public interface IDataSchemaAdapter
	{
		/// <summary>
		///  Parameters import XSD
		/// </summary>
		Parameter Param { get; set; }
		/// <summary>
		/// Create a new database conforming to the passed schema.
		/// </summary>
		/// 
		string Create();

		/// <summary>
		/// Import data from DataTable in DataBase
		/// </summary>
		void SaveToDB(DataTable table);
		/// <summary>
		///  Import data from DataSet in DataBase
		/// </summary>
		void SaveToDB();

        /// <summary>
        /// Event that occurs when changes are made to the database connection
        /// </summary>
        event EventHandler<ConnectionStringEventArgs> ConnectionChanged;
    }
}