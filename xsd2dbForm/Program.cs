using System;
using System.Windows.Forms;
using Xsd2Db.Data;

namespace Xsd2dbForm
{
    internal static class Program
    {

        internal static ParameterCollection Parameters;       
        static string path = System.IO.Path.Combine(Application.StartupPath, "Data", "params.json");
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string dataFolder = System.IO.Path.GetDirectoryName(path);
            if (!System.IO.Directory.Exists(dataFolder)) System.IO.Directory.CreateDirectory(dataFolder);
            if (!ParameterCollection.LoadFromFile(path, out Parameters)) return;
            Application.Run(new FrmMain());
        }

        public static void Save()
        {
            Parameters.Save(path);
        }

    }
}
