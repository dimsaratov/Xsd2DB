using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace Xsd2Db.Data
{
    /// <summary>
    /// Collection of XSD/XML schema import settings
    /// </summary>
    public class ParameterCollection : BindingList<Parameter>
    {
        /// <summary>
        /// Constructor of the XSD/XML Import Settings collection
        /// </summary>
        public ParameterCollection()
        { }

        #region Update
        public string ConvertToJSonString()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                Culture = System.Globalization.CultureInfo.CurrentCulture,
                MaxDepth = 6
            };
            string str = JsonConvert.SerializeObject(this, settings);
            return str;
        }

        public bool Save(string filePath)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.UTF8))
            {
                string str = this.ConvertToJSonString();
                writer.Write(str);
                return true;
            }
        }

        public static ParameterCollection Parse(string jsonString)
        {
            try
            {
                ParameterCollection collection = JsonConvert.DeserializeObject<ParameterCollection>(jsonString);
                return collection;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                return null;
            }
        }


        public static bool LoadFromFile(string filePath, out ParameterCollection collection)
        {
            collection = null;
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath, System.Text.Encoding.UTF8))
                    {
                        string jsonString = reader.ReadToEnd();
                        collection = JsonConvert.DeserializeObject<ParameterCollection>(jsonString);
                    }
                    return true;
                }
                else
                {
                    collection = new ParameterCollection();
                    collection.Save(filePath);
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
            return false;
        }
    }
    #endregion
}