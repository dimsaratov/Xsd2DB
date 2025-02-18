
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xsd2Db.Data;
using static Xsd2Db.Data.Enums;

namespace Xsd2dbForm
{
    public partial class FrmMain : Form
    {

        public FrmMain()
        {
            InitializeComponent();
            cbType.DataSource = Enum.GetValues(typeof(DatabaseType));
            listParameter.DisplayMember = "ParameterName";
            listParameter.DataSource = Program.Parameters;
            Xsd2Db.Data.CreatorSchema.ConnectionChanged += CreatorSchema_ConnectionChanged;
        }


        private void CreatorSchema_ConnectionChanged(object sender, ConnectionStringEventArgs e)
        {
            mConsole.BeginInvoke(new MethodInvoker(() => mConsole.Text = e.DataConnection.ConnectionString));
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (IsCorrect() is Parameter param)
            {
                param.SchemaFile = ofbSchema.Path;
                Task<string> t = new Task<string>(() => Xsd2Db.Data.CreatorSchema.Create(param));
                popUpMessage1.ShowDialog("Импорт схемы XSD", t);
                if (t.Result.Length > 0) MessageBox.Show(t.Result);
            }
        }

        Parameter IsCorrect()
        {
            int i = 0;
            if (!ofbSchema.Exists())
            {
                i++;
                ofbSchema.LimeLight();
            }
            if (mHost.TextLength == 0)
            {
                i++;
                mHost.LimeLight();
            }

            if (cbType.SelectedItem == null)
            {
                i++;
                cbType.LimeLight();
            }

            if (i > 0) return null;

            return listParameter.SelectedItem as Parameter;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            mConsole.Text = string.Empty;
            mParameterName.Text = string.Empty;
            mHost.Clear();
            mCatalog.Clear();
            mPass.Clear();
            mUser.Clear();
            mOwner.Clear();
            mPrefix.Clear();
            mSchemaName.Clear();
            numPort.Value = 0;
            numTimeout.Value = 10;
            numCommandTimeout.Value = 100;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((DatabaseType)cbType.SelectedValue)
            {
                case DatabaseType.Sql:
                    numPort.Value = 1433;
                    break;
                case DatabaseType.NpgSql:
                    numPort.Value = 5432;
                    break;
                default:
                    numPort.Value = 0;
                    break;
            }
        }

        private void ListParameter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listParameter.SelectedItem is Parameter p)
            {
                mParameterName.DataBindings.Clear();
                mOwner.DataBindings.Clear();
                chkForse.DataBindings.Clear();
                chkImportData.DataBindings.Clear();
                mHost.DataBindings.Clear();
                numPort.DataBindings.Clear();
                mCatalog.DataBindings.Clear();
                mSchemaName.DataBindings.Clear();
                mUser.DataBindings.Clear();
                mPass.DataBindings.Clear();
                mPrefix.DataBindings.Clear();
                cbType.DataBindings.Clear();
                numTimeout.DataBindings.Clear();
                numCommandTimeout.DataBindings.Clear();

                mParameterName.DataBindings.Add("Text", p, "ParameterName");
                mOwner.DataBindings.Add("Text", p, "DbOwner");
                chkForse.DataBindings.Add("Checked", p, "Force");
                chkImportData.DataBindings.Add("Checked", p, "ImportData");
                mHost.DataBindings.Add("Text", p, "Host");
                numPort.DataBindings.Add("Text", p, "Port");
                mCatalog.DataBindings.Add("Text", p, "InitialCatalog");
                mSchemaName.DataBindings.Add("Text", p, "SchemaName");
                mUser.DataBindings.Add("Text", p, "User");
                mPass.DataBindings.Add("Text", p, "Password");
                mPrefix.DataBindings.Add("Text", p, "TablePrefix");
                cbType.DataBindings.Add("SelectedItem", p, "Type");
                numTimeout.DataBindings.Add("Value", p, "Timeout");
                numCommandTimeout.DataBindings.Add("Value", p, "CommandTimeout");
            }
        }

        private void ItemAdd_Click(object sender, EventArgs e)
        {
            Parameter p = new Parameter();
            Program.Parameters.Add(p);
            listParameter.SelectedItem = p;
        }

        private void ItemDelete_Click(object sender, EventArgs e)
        {
            if (listParameter.SelectedItem is Parameter p)
            {
                if (MessageBox.Show("Удалить настройку " + p.ParameterName)== DialogResult.OK)
                {
                    Program.Parameters.Remove(p);
                }
            }    
        }

        private void ItemSave_Click(object sender, EventArgs e)
        {
            Program.Save();
        }
    }
}
