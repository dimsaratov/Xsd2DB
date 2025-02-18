namespace Xsd2dbForm
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.chkForse = new System.Windows.Forms.CheckBox();
            this.ofbSchema = new ExtControlsCS.OpenFileBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mHost = new ExtControlsCS.ExtTextBox();
            this.mUser = new ExtControlsCS.ExtTextBox();
            this.mPass = new ExtControlsCS.ExtTextBox();
            this.cbType = new ExtControlsCS.ExtComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.mPrefix = new ExtControlsCS.ExtTextBox();
            this.mOwner = new ExtControlsCS.ExtTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mCatalog = new ExtControlsCS.ExtTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.popUpMessage1 = new ExtControlsCS.PopUpMessage(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.chkImportData = new System.Windows.Forms.CheckBox();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numTimeout = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numCommandTimeout = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mConsole = new System.Windows.Forms.Label();
            this.mSchemaName = new ExtControlsCS.ExtTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listParameter = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.mParameterName = new ExtControlsCS.ExtTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.itemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ofbSchema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCommandTimeout)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин:";
            // 
            // chkForse
            // 
            this.chkForse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkForse.AutoSize = true;
            this.chkForse.Location = new System.Drawing.Point(6, 335);
            this.chkForse.Name = "chkForse";
            this.chkForse.Size = new System.Drawing.Size(245, 17);
            this.chkForse.TabIndex = 1;
            this.chkForse.Text = "Удалить базу данных если она существует";
            this.chkForse.UseVisualStyleBackColor = true;
            // 
            // ofbSchema
            // 
            this.ofbSchema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ofbSchema.BackColor = System.Drawing.SystemColors.Window;
            this.ofbSchema.CheckFileExists = true;
            this.ofbSchema.DefaultExt = "";
            this.ofbSchema.FileName = "";
            this.ofbSchema.Filter = "Файл схемы XSD|*.xsd|Файл XML|*.xml";
            this.ofbSchema.FilterIndex = 1;
            this.ofbSchema.FontMark = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ofbSchema.IsFile = true;
            this.ofbSchema.Location = new System.Drawing.Point(12, 580);
            this.ofbSchema.Name = "ofbSchema";
            this.ofbSchema.Path = "";
            this.ofbSchema.Size = new System.Drawing.Size(406, 23);
            this.ofbSchema.TabIndex = 2;
            this.ofbSchema.TextHelpMark = "Файл схемы XSD";
            this.ofbSchema.TitleFileDialog = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Сервер базы данных:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Пароль:";
            // 
            // mHost
            // 
            this.mHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mHost.FontMark = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.mHost.FontMarkDefault = false;
            this.mHost.ForeMarkAllign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mHost.ForeMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.mHost.Location = new System.Drawing.Point(127, 46);
            this.mHost.Name = "mHost";
            this.mHost.Size = new System.Drawing.Size(239, 20);
            this.mHost.TabIndex = 3;
            this.mHost.TextHelpMark = "Хост сервера";
            // 
            // mUser
            // 
            this.mUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mUser.FontMark = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.mUser.FontMarkDefault = false;
            this.mUser.ForeMarkAllign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mUser.ForeMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.mUser.Location = new System.Drawing.Point(127, 176);
            this.mUser.Name = "mUser";
            this.mUser.Size = new System.Drawing.Size(239, 20);
            this.mUser.TabIndex = 3;
            this.mUser.Tag = "";
            this.mUser.TextHelpMark = "Логин пользователя";
            // 
            // mPass
            // 
            this.mPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mPass.FontMark = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.mPass.FontMarkDefault = false;
            this.mPass.ForeMarkAllign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mPass.ForeMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.mPass.Location = new System.Drawing.Point(127, 202);
            this.mPass.Name = "mPass";
            this.mPass.Size = new System.Drawing.Size(239, 20);
            this.mPass.TabIndex = 3;
            this.mPass.TextHelpMark = "Пароль пользователя";
            // 
            // cbType
            // 
            this.cbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbType.Location = new System.Drawing.Point(127, 19);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(239, 21);
            this.cbType.TabIndex = 9;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.CbType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Тип базы данных";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Владелец:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Префикс:";
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(425, 580);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(159, 23);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Загрузить схему";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // mPrefix
            // 
            this.mPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mPrefix.FontMark = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.mPrefix.FontMarkDefault = false;
            this.mPrefix.ForeMarkAllign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mPrefix.ForeMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.mPrefix.Location = new System.Drawing.Point(127, 280);
            this.mPrefix.Name = "mPrefix";
            this.mPrefix.Size = new System.Drawing.Size(239, 20);
            this.mPrefix.TabIndex = 3;
            this.mPrefix.TextHelpMark = "Префикс наименования таблицы";
            // 
            // mOwner
            // 
            this.mOwner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mOwner.FontMark = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.mOwner.FontMarkDefault = false;
            this.mOwner.ForeMarkAllign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mOwner.ForeMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.mOwner.Location = new System.Drawing.Point(127, 254);
            this.mOwner.Name = "mOwner";
            this.mOwner.Size = new System.Drawing.Size(239, 20);
            this.mOwner.TabIndex = 3;
            this.mOwner.TextHelpMark = "Владелец БД";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "База данных:";
            // 
            // mCatalog
            // 
            this.mCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mCatalog.FontMark = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.mCatalog.FontMarkDefault = false;
            this.mCatalog.ForeMarkAllign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mCatalog.ForeMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.mCatalog.Location = new System.Drawing.Point(127, 150);
            this.mCatalog.Name = "mCatalog";
            this.mCatalog.Size = new System.Drawing.Size(239, 20);
            this.mCatalog.TabIndex = 3;
            this.mCatalog.TextHelpMark = "Initial catalog";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(290, 331);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // popUpMessage1
            // 
            this.popUpMessage1.AttachAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.popUpMessage1.AutoHide = false;
            this.popUpMessage1.ContainerControl = this;
            this.popUpMessage1.DockControl = this;
            this.popUpMessage1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            // 
            // 
            // 
            this.popUpMessage1.Indicator.AnimationSpeed = 78;
            this.popUpMessage1.Indicator.Location = new System.Drawing.Point(0, 0);
            this.popUpMessage1.Indicator.Name = "indicator";
            this.popUpMessage1.Indicator.PercentFormat = "0";
            this.popUpMessage1.Indicator.ShowPercentage = false;
            this.popUpMessage1.Indicator.Size = new System.Drawing.Size(75, 75);
            this.popUpMessage1.Indicator.Step = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.popUpMessage1.Indicator.TabIndex = 0;
            this.popUpMessage1.Indicator.TextDisplay = ExtControlsCS.TextDisplayModes.None;
            this.popUpMessage1.Text = null;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(591, 580);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // chkImportData
            // 
            this.chkImportData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkImportData.AutoSize = true;
            this.chkImportData.Location = new System.Drawing.Point(6, 312);
            this.chkImportData.Name = "chkImportData";
            this.chkImportData.Size = new System.Drawing.Size(147, 17);
            this.chkImportData.TabIndex = 12;
            this.chkImportData.Text = "Импортировать данные";
            this.chkImportData.UseVisualStyleBackColor = true;
            // 
            // numPort
            // 
            this.numPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numPort.Location = new System.Drawing.Point(127, 72);
            this.numPort.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(239, 20);
            this.numPort.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Входящий порт:";
            // 
            // numTimeout
            // 
            this.numTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numTimeout.Location = new System.Drawing.Point(126, 98);
            this.numTimeout.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numTimeout.Name = "numTimeout";
            this.numTimeout.Size = new System.Drawing.Size(239, 20);
            this.numTimeout.TabIndex = 13;
            this.numTimeout.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(71, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Timeout:";
            // 
            // numCommandTimeout
            // 
            this.numCommandTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numCommandTimeout.Location = new System.Drawing.Point(126, 124);
            this.numCommandTimeout.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numCommandTimeout.Name = "numCommandTimeout";
            this.numCommandTimeout.Size = new System.Drawing.Size(239, 20);
            this.numCommandTimeout.TabIndex = 13;
            this.numCommandTimeout.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "CommandTimeout:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.mConsole);
            this.groupBox1.Location = new System.Drawing.Point(6, 404);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 130);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Строка подключения";
            // 
            // mConsole
            // 
            this.mConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mConsole.Location = new System.Drawing.Point(3, 16);
            this.mConsole.Name = "mConsole";
            this.mConsole.Size = new System.Drawing.Size(363, 111);
            this.mConsole.TabIndex = 0;
            // 
            // mSchemaName
            // 
            this.mSchemaName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mSchemaName.FontMark = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.mSchemaName.FontMarkDefault = false;
            this.mSchemaName.ForeMarkAllign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mSchemaName.ForeMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.mSchemaName.Location = new System.Drawing.Point(126, 228);
            this.mSchemaName.Name = "mSchemaName";
            this.mSchemaName.Size = new System.Drawing.Size(239, 20);
            this.mSchemaName.TabIndex = 3;
            this.mSchemaName.TextHelpMark = "Пространство имен";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 233);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Пространство имен:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 32);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listParameter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label12);
            this.splitContainer1.Panel2.Controls.Add(this.mParameterName);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(654, 542);
            this.splitContainer1.SplitterDistance = 267;
            this.splitContainer1.TabIndex = 17;
            // 
            // listParameter
            // 
            this.listParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listParameter.FormattingEnabled = true;
            this.listParameter.Location = new System.Drawing.Point(0, 0);
            this.listParameter.Name = "listParameter";
            this.listParameter.Size = new System.Drawing.Size(267, 542);
            this.listParameter.TabIndex = 0;
            this.listParameter.SelectedIndexChanged += new System.EventHandler(this.ListParameter_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Псевдоним БД:";
            // 
            // mParameterName
            // 
            this.mParameterName.FontMark = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.mParameterName.FontMarkDefault = false;
            this.mParameterName.ForeMarkAllign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mParameterName.ForeMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.mParameterName.Location = new System.Drawing.Point(129, 7);
            this.mParameterName.Name = "mParameterName";
            this.mParameterName.Size = new System.Drawing.Size(245, 20);
            this.mParameterName.TabIndex = 18;
            this.mParameterName.TextHelpMark = "Псевдоним:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkImportData);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.chkForse);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numTimeout);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.mSchemaName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numPort);
            this.groupBox2.Controls.Add(this.numCommandTimeout);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.mPrefix);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.mOwner);
            this.groupBox2.Controls.Add(this.mPass);
            this.groupBox2.Controls.Add(this.mUser);
            this.groupBox2.Controls.Add(this.cbType);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.mHost);
            this.groupBox2.Controls.Add(this.mCatalog);
            this.groupBox2.Location = new System.Drawing.Point(3, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 361);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройки подключения к БД";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemSave,
            this.itemAdd,
            this.itemDelete});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(677, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // itemSave
            // 
            this.itemSave.Name = "itemSave";
            this.itemSave.Size = new System.Drawing.Size(78, 20);
            this.itemSave.Text = "Сохранить";
            this.itemSave.Click += new System.EventHandler(this.ItemSave_Click);
            // 
            // itemAdd
            // 
            this.itemAdd.Name = "itemAdd";
            this.itemAdd.Size = new System.Drawing.Size(71, 20);
            this.itemAdd.Text = "Добавить";
            this.itemAdd.Click += new System.EventHandler(this.ItemAdd_Click);
            // 
            // itemDelete
            // 
            this.itemDelete.Name = "itemDelete";
            this.itemDelete.Size = new System.Drawing.Size(63, 20);
            this.itemDelete.Text = "Удалить";
            this.itemDelete.Click += new System.EventHandler(this.ItemDelete_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 608);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.ofbSchema);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Импорт схемы XSD";
            ((System.ComponentModel.ISupportInitialize)(this.ofbSchema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCommandTimeout)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkForse;
        private ExtControlsCS.OpenFileBox ofbSchema;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ExtControlsCS.ExtTextBox mHost;
        private ExtControlsCS.ExtTextBox mUser;
        private ExtControlsCS.ExtTextBox mPass;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private ExtControlsCS.ExtTextBox mPrefix;
        private ExtControlsCS.ExtTextBox mOwner;
        private System.Windows.Forms.Label label6;
        private ExtControlsCS.ExtTextBox mCatalog;
        private ExtControlsCS.ExtComboBox cbType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClear;
        private ExtControlsCS.PopUpMessage popUpMessage1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkImportData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numCommandTimeout;
        private System.Windows.Forms.NumericUpDown numTimeout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label mConsole;
        private System.Windows.Forms.Label label11;
        private ExtControlsCS.ExtTextBox mSchemaName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listParameter;
        private System.Windows.Forms.Label label12;
        private ExtControlsCS.ExtTextBox mParameterName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem itemAdd;
        private System.Windows.Forms.ToolStripMenuItem itemDelete;
        private System.Windows.Forms.ToolStripMenuItem itemSave;
    }
}