using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Xsd2Db.Data.Enums;

namespace Xsd2Db.Data
{
    /// <summary>
    /// Parameters import XSD
    /// </summary>
    [Serializable]
    public class Parameter : INotifyPropertyChanged
    {

        #region Variable

        bool m_force         = false;
        bool m_importData    = false;
        DatabaseType m_type  = DatabaseType.NoDefine;
        [NonSerialized]
        DataSet m_schema;
        int m_commandTimeout = 100;
        int m_port;
        int m_timeout = 10;
        string m_dataSetName = string.Empty;
        string m_dbOwner;
        string m_host = string.Empty;
        string m_initialCatalog = string.Empty;
        string m_parameterName = string.Empty;
        string m_password = string.Empty;
        [NonSerialized]
        string m_schemaFile = string.Empty;
        string m_schemaName = "dbo";
        string m_tablePrefix = string.Empty;
        string m_user = string.Empty;

        #endregion


        /// <summary>
        /// The dataset obtained from the XSD schema
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataSet Schema
        {
            get { return m_schema; }
            set
            {
                m_schema = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Schema"));
            }
        }
        /// <summary>
        /// The name of the database to be created
        /// </summary>       
        public string InitialCatalog
        {
            get
            { return m_initialCatalog; }
            set
            {
                m_initialCatalog = value;
                OnPropertyChanged(new PropertyChangedEventArgs("InitialCatalog"));
            }
        }

        /// <summary>
        /// This optional property stores the owner that will be assigned to each table.
        /// </summary>
        public string DbOwner
        {
            get { return m_dbOwner; }
            set
            {
                m_dbOwner = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DbOwner"));
            }
        }

        /// <summary>
        /// This property stores the optional table prefix that will be given to each table
        /// </summary>
        public string TablePrefix
        {
            get { return m_tablePrefix; }
            set
            {
                m_tablePrefix = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TablePrefix"));
            }
        }

        /// <summary>
        /// The property denotes the source XSD file provided by the user.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SchemaFile
        { 
            get { return m_schemaFile; }
            set {
                m_schemaFile = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SchemaFile"));
            }
        }

        /// <summary>
        /// TableName
        /// </summary>
        public string DataSetName
        {
            get { return m_dataSetName; }
            set
            {
                m_dataSetName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DataSetName"));
            }
        }
        /// <summary>
        /// Table schema name
        /// </summary>
        public string SchemaName
        {
            get { return m_schemaName; }
            set
            {
               m_schemaName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SchemaName"));
            }
        }

        /// <summary>
        /// The type of database specified by the user.
        /// </summary>
        public DatabaseType Type
        {
            get { return m_type; }
            set
            {
                m_type= value;
                OnPropertyChanged(new PropertyChangedEventArgs("Type"));
            }
        }

        /// <summary>
        /// The property denotes the database host if SQL server is used.
        /// </summary>
        public string Host
        {
            get { return m_host; }
            set
            {
                m_host= value;
                OnPropertyChanged(new PropertyChangedEventArgs("Host"));
            }
        }
        /// <summary>
        /// This procedure sets or gets the port number to connect to the database
        /// </summary>
        public int Port
        {
            get { return m_port; }
            set
            {
                m_port = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Port"));
            }
        }

        /// <summary>
        /// This property indicates whether or not the user has requested
        /// that any existing database be overwritten from the schema.  This
        /// option should be used with extreme care.
        /// </summary>       
        public bool Force
        {
            get { return m_force; }
            set
            {
                m_force= value;
                OnPropertyChanged(new PropertyChangedEventArgs("Force"));
            }
        }

        /// <summary>
        /// This procedure sets or gets a sign of the need to import Dataset data
        /// </summary>
        public bool ImportData
        {
            get { return m_importData; }
            set
            {
                m_importData= value;
                OnPropertyChanged(new PropertyChangedEventArgs("ImportData"));
            }
        }


        /// <summary>
        /// This property stores the name of the database user to connect to
        /// </summary>
        public string User
        {
            get { return m_user; }
            set
            {
                m_user= value;
                OnPropertyChanged(new PropertyChangedEventArgs("User"));
            }
        }

        /// <summary>
        /// This property stores the password of the user to connect to the database
        /// </summary>       
        public string Password
        {
            get { return m_password; }
            set
            {
                m_password= value;
                OnPropertyChanged(new PropertyChangedEventArgs("Password"));
            }
        }
        /// <summary>
        /// Timeout connect database
        /// </summary>
        public int Timeout
        {
            get { return m_timeout; }
            set
            {
                m_timeout= value;
                OnPropertyChanged(new PropertyChangedEventArgs("Timeout"));
            }
        }
        /// <summary>
        /// Command timeout
        /// </summary>
        public int CommandTimeout
        {
            get { return m_commandTimeout; }
            set
            {
                m_commandTimeout= value;
                OnPropertyChanged(new PropertyChangedEventArgs("CommandTimeout"));
            }
        }

        /// <summary>
        /// Alias of XSD/XML import settings
        /// </summary>
        public string ParameterName
        {
            get { return m_parameterName; }
            set
            {
                m_parameterName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ParameterName"));
            }
        }

        public override string ToString()
        {
            return m_parameterName;
        }


        #region Events
        /// <summary>
        /// Property Change Event
        /// </summary>
        private PropertyChangedEventHandler onPropertyChanged = null;
        /// <summary>
        /// Property Change Event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        { onPropertyChanged?.Invoke(this, e); }

        /// <summary>
        /// Property Change Event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged
        {
            add { onPropertyChanged += value; }
            remove { onPropertyChanged -= value; }
        }
        #endregion
    }
}
