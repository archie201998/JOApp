namespace JOMonitoringApp.Views.JobOrder
{
    partial class ucJoborder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtORNumber = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.gbAccountDetails = new System.Windows.Forms.GroupBox();
            this.cbxNA = new System.Windows.Forms.CheckBox();
            this.txtAcc4 = new System.Windows.Forms.TextBox();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtAcc3 = new System.Windows.Forms.TextBox();
            this.txtAcc2 = new System.Windows.Forms.TextBox();
            this.txtAcc1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gbJODetails = new System.Windows.Forms.GroupBox();
            this.clBoxParticulars = new System.Windows.Forms.CheckedListBox();
            this.txtWARNumber = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMRSNumber = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMRISNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtJONumber = new System.Windows.Forms.TextBox();
            this.cmbxMaterialsIssuedBy = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.gbIssuanceAndAssignment = new System.Windows.Forms.GroupBox();
            this.cmbxAccomplishedBy = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.radAccomplished = new System.Windows.Forms.RadioButton();
            this.radCancel = new System.Windows.Forms.RadioButton();
            this.radProcessing = new System.Windows.Forms.RadioButton();
            this.radPending = new System.Windows.Forms.RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.gbAccountDetails.SuspendLayout();
            this.gbJODetails.SuspendLayout();
            this.gbIssuanceAndAssignment.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ACCOUNT NAME";
            // 
            // txtORNumber
            // 
            this.txtORNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtORNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtORNumber.Location = new System.Drawing.Point(155, 260);
            this.txtORNumber.Name = "txtORNumber";
            this.txtORNumber.Size = new System.Drawing.Size(200, 21);
            this.txtORNumber.TabIndex = 5;
            this.txtORNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOnly);
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(155, 182);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(198, 21);
            this.dtpDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "PARTICULARS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "DATE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "OR NUMBER";
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAmount.Location = new System.Drawing.Point(155, 286);
            this.nudAmount.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(200, 21);
            this.nudAmount.TabIndex = 6;
            this.nudAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAmount.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "AMOUNT";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "ACCOUNT NUMBER";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAccountNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNumber.Location = new System.Drawing.Point(478, 161);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(136, 21);
            this.txtAccountNumber.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(25, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "ADDRESS";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(155, 96);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 48);
            this.txtAddress.TabIndex = 6;
            this.txtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtAddress_Validating);
            this.txtAddress.Validated += new System.EventHandler(this.txtAddress_Validated);
            // 
            // gbAccountDetails
            // 
            this.gbAccountDetails.Controls.Add(this.cbxNA);
            this.gbAccountDetails.Controls.Add(this.txtAcc4);
            this.gbAccountDetails.Controls.Add(this.txtAccountName);
            this.gbAccountDetails.Controls.Add(this.btnSearch);
            this.gbAccountDetails.Controls.Add(this.txtAcc3);
            this.gbAccountDetails.Controls.Add(this.label1);
            this.gbAccountDetails.Controls.Add(this.txtAcc2);
            this.gbAccountDetails.Controls.Add(this.label8);
            this.gbAccountDetails.Controls.Add(this.txtAddress);
            this.gbAccountDetails.Controls.Add(this.txtAcc1);
            this.gbAccountDetails.Controls.Add(this.label7);
            this.gbAccountDetails.Controls.Add(this.label16);
            this.gbAccountDetails.Controls.Add(this.label14);
            this.gbAccountDetails.Controls.Add(this.label12);
            this.gbAccountDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAccountDetails.Location = new System.Drawing.Point(21, 19);
            this.gbAccountDetails.Name = "gbAccountDetails";
            this.gbAccountDetails.Size = new System.Drawing.Size(389, 154);
            this.gbAccountDetails.TabIndex = 0;
            this.gbAccountDetails.TabStop = false;
            this.gbAccountDetails.Text = "ACCOUNT DETAILS";
            // 
            // cbxNA
            // 
            this.cbxNA.AutoSize = true;
            this.cbxNA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxNA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxNA.Location = new System.Drawing.Point(336, 46);
            this.cbxNA.Name = "cbxNA";
            this.cbxNA.Size = new System.Drawing.Size(43, 17);
            this.cbxNA.TabIndex = 4;
            this.cbxNA.Text = "N/A";
            this.cbxNA.UseVisualStyleBackColor = true;
            this.cbxNA.CheckedChanged += new System.EventHandler(this.cbxNA_CheckedChanged);
            // 
            // txtAcc4
            // 
            this.txtAcc4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAcc4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAcc4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcc4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcc4.Location = new System.Drawing.Point(308, 43);
            this.txtAcc4.MaxLength = 2;
            this.txtAcc4.Name = "txtAcc4";
            this.txtAcc4.Size = new System.Drawing.Size(22, 21);
            this.txtAcc4.TabIndex = 3;
            this.txtAcc4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAcc4.TextChanged += new System.EventHandler(this.txtAcc3_TextChanged);
            // 
            // txtAccountName
            // 
            this.txtAccountName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAccountName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountName.Location = new System.Drawing.Point(155, 70);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(200, 21);
            this.txtAccountName.TabIndex = 5;
            this.txtAccountName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtAccountName_Validating);
            this.txtAccountName.Validated += new System.EventHandler(this.TxtAccountName_Validated);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::JOMonitoringApp.Properties.Resources.btn_search;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(257, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(97, 23);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "Search  [F1]";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtAcc3
            // 
            this.txtAcc3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAcc3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAcc3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcc3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcc3.Location = new System.Drawing.Point(257, 43);
            this.txtAcc3.MaxLength = 3;
            this.txtAcc3.Name = "txtAcc3";
            this.txtAcc3.Size = new System.Drawing.Size(39, 21);
            this.txtAcc3.TabIndex = 2;
            this.txtAcc3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAcc3.TextChanged += new System.EventHandler(this.txtAcc3_TextChanged);
            this.txtAcc3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAcc1_KeyDown);
            this.txtAcc3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOnly);
            // 
            // txtAcc2
            // 
            this.txtAcc2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAcc2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAcc2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcc2.Location = new System.Drawing.Point(206, 43);
            this.txtAcc2.MaxLength = 3;
            this.txtAcc2.Name = "txtAcc2";
            this.txtAcc2.Size = new System.Drawing.Size(39, 21);
            this.txtAcc2.TabIndex = 1;
            this.txtAcc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAcc2.TextChanged += new System.EventHandler(this.txtAcc3_TextChanged);
            this.txtAcc2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAcc1_KeyDown);
            this.txtAcc2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOnly);
            // 
            // txtAcc1
            // 
            this.txtAcc1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAcc1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAcc1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcc1.Location = new System.Drawing.Point(155, 43);
            this.txtAcc1.MaxLength = 3;
            this.txtAcc1.Name = "txtAcc1";
            this.txtAcc1.Size = new System.Drawing.Size(39, 21);
            this.txtAcc1.TabIndex = 0;
            this.txtAcc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAcc1.TextChanged += new System.EventHandler(this.txtAcc3_TextChanged);
            this.txtAcc1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAcc1_KeyDown);
            this.txtAcc1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOnly);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(194, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(12, 15);
            this.label16.TabIndex = 32;
            this.label16.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(297, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(12, 15);
            this.label14.TabIndex = 30;
            this.label14.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(245, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(12, 15);
            this.label12.TabIndex = 30;
            this.label12.Text = "-";
            // 
            // gbJODetails
            // 
            this.gbJODetails.Controls.Add(this.clBoxParticulars);
            this.gbJODetails.Controls.Add(this.txtWARNumber);
            this.gbJODetails.Controls.Add(this.label15);
            this.gbJODetails.Controls.Add(this.label11);
            this.gbJODetails.Controls.Add(this.txtMRSNumber);
            this.gbJODetails.Controls.Add(this.label10);
            this.gbJODetails.Controls.Add(this.txtMRISNumber);
            this.gbJODetails.Controls.Add(this.label9);
            this.gbJODetails.Controls.Add(this.txtJONumber);
            this.gbJODetails.Controls.Add(this.label2);
            this.gbJODetails.Controls.Add(this.txtORNumber);
            this.gbJODetails.Controls.Add(this.label3);
            this.gbJODetails.Controls.Add(this.dtpDate);
            this.gbJODetails.Controls.Add(this.label4);
            this.gbJODetails.Controls.Add(this.label5);
            this.gbJODetails.Controls.Add(this.nudAmount);
            this.gbJODetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbJODetails.Location = new System.Drawing.Point(21, 179);
            this.gbJODetails.Name = "gbJODetails";
            this.gbJODetails.Size = new System.Drawing.Size(389, 345);
            this.gbJODetails.TabIndex = 16;
            this.gbJODetails.TabStop = false;
            this.gbJODetails.Text = "JOB ORDER DETAILS";
            // 
            // clBoxParticulars
            // 
            this.clBoxParticulars.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clBoxParticulars.FormattingEnabled = true;
            this.clBoxParticulars.Location = new System.Drawing.Point(155, 55);
            this.clBoxParticulars.Name = "clBoxParticulars";
            this.clBoxParticulars.Size = new System.Drawing.Size(199, 116);
            this.clBoxParticulars.TabIndex = 1;
            this.clBoxParticulars.Validating += new System.ComponentModel.CancelEventHandler(this.clBoxParticulars_Validating);
            this.clBoxParticulars.Validated += new System.EventHandler(this.clBoxParticulars_Validated);
            // 
            // txtWARNumber
            // 
            this.txtWARNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWARNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWARNumber.Location = new System.Drawing.Point(155, 312);
            this.txtWARNumber.Name = "txtWARNumber";
            this.txtWARNumber.Size = new System.Drawing.Size(200, 21);
            this.txtWARNumber.TabIndex = 7;
            this.txtWARNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOnly);
            this.txtWARNumber.Validating += new System.ComponentModel.CancelEventHandler(this.TxtWARNumber_Validating);
            this.txtWARNumber.Validated += new System.EventHandler(this.TxtWARNumber_Validated);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(25, 315);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 15);
            this.label15.TabIndex = 29;
            this.label15.Text = "WAR Number";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(25, 237);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 15);
            this.label11.TabIndex = 20;
            this.label11.Text = "MRS NUMBER";
            // 
            // txtMRSNumber
            // 
            this.txtMRSNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMRSNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMRSNumber.Location = new System.Drawing.Point(155, 234);
            this.txtMRSNumber.Name = "txtMRSNumber";
            this.txtMRSNumber.Size = new System.Drawing.Size(200, 21);
            this.txtMRSNumber.TabIndex = 4;
            this.txtMRSNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOnly);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(25, 211);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 15);
            this.label10.TabIndex = 18;
            this.label10.Text = "MRIS NUMBER";
            // 
            // txtMRISNumber
            // 
            this.txtMRISNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMRISNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMRISNumber.Location = new System.Drawing.Point(155, 208);
            this.txtMRISNumber.Name = "txtMRISNumber";
            this.txtMRISNumber.Size = new System.Drawing.Size(200, 21);
            this.txtMRISNumber.TabIndex = 3;
            this.txtMRISNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOnly);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(25, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "JO NUMBER";
            // 
            // txtJONumber
            // 
            this.txtJONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJONumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJONumber.Location = new System.Drawing.Point(155, 27);
            this.txtJONumber.Name = "txtJONumber";
            this.txtJONumber.Size = new System.Drawing.Size(200, 21);
            this.txtJONumber.TabIndex = 0;
            this.txtJONumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOnly);
            this.txtJONumber.Validating += new System.ComponentModel.CancelEventHandler(this.TxtJONumber_Validating);
            this.txtJONumber.Validated += new System.EventHandler(this.TxtJONumber_Validated);
            // 
            // cmbxMaterialsIssuedBy
            // 
            this.cmbxMaterialsIssuedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxMaterialsIssuedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxMaterialsIssuedBy.FormattingEnabled = true;
            this.cmbxMaterialsIssuedBy.Location = new System.Drawing.Point(155, 28);
            this.cmbxMaterialsIssuedBy.Name = "cmbxMaterialsIssuedBy";
            this.cmbxMaterialsIssuedBy.Size = new System.Drawing.Size(200, 23);
            this.cmbxMaterialsIssuedBy.TabIndex = 0;
            this.cmbxMaterialsIssuedBy.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxMaterialsIssuedBy_Validating);
            this.cmbxMaterialsIssuedBy.Validated += new System.EventHandler(this.cmbxMaterialsIssuedBy_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(25, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 15);
            this.label13.TabIndex = 23;
            this.label13.Text = "MAT. ISSUED BY";
            // 
            // gbIssuanceAndAssignment
            // 
            this.gbIssuanceAndAssignment.Controls.Add(this.cmbxAccomplishedBy);
            this.gbIssuanceAndAssignment.Controls.Add(this.label6);
            this.gbIssuanceAndAssignment.Controls.Add(this.cmbxMaterialsIssuedBy);
            this.gbIssuanceAndAssignment.Controls.Add(this.label13);
            this.gbIssuanceAndAssignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbIssuanceAndAssignment.Location = new System.Drawing.Point(21, 530);
            this.gbIssuanceAndAssignment.Name = "gbIssuanceAndAssignment";
            this.gbIssuanceAndAssignment.Size = new System.Drawing.Size(389, 90);
            this.gbIssuanceAndAssignment.TabIndex = 17;
            this.gbIssuanceAndAssignment.TabStop = false;
            this.gbIssuanceAndAssignment.Text = "ISSUANCES AND JOB ASSIGNMENTS";
            // 
            // cmbxAccomplishedBy
            // 
            this.cmbxAccomplishedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxAccomplishedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxAccomplishedBy.FormattingEnabled = true;
            this.cmbxAccomplishedBy.Location = new System.Drawing.Point(155, 55);
            this.cmbxAccomplishedBy.Name = "cmbxAccomplishedBy";
            this.cmbxAccomplishedBy.Size = new System.Drawing.Size(200, 23);
            this.cmbxAccomplishedBy.TabIndex = 1;
            this.cmbxAccomplishedBy.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxAccomplishedBy_Validating);
            this.cmbxAccomplishedBy.Validated += new System.EventHandler(this.cmbxAccomplishedBy_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 15);
            this.label6.TabIndex = 25;
            this.label6.Text = "ACCOMPLISHED BY";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtRemarks);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.radAccomplished);
            this.groupBox4.Controls.Add(this.radCancel);
            this.groupBox4.Controls.Add(this.radProcessing);
            this.groupBox4.Controls.Add(this.radPending);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(21, 626);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(389, 96);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "STATUS";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(153, 54);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(200, 36);
            this.txtRemarks.TabIndex = 8;
            this.txtRemarks.Validating += new System.ComponentModel.CancelEventHandler(this.txtRemarks_Validating);
            this.txtRemarks.Validated += new System.EventHandler(this.txtRemarks_Validated);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(25, 55);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 15);
            this.label17.TabIndex = 7;
            this.label17.Text = "REMARKS ";
            // 
            // radAccomplished
            // 
            this.radAccomplished.AutoSize = true;
            this.radAccomplished.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAccomplished.Location = new System.Drawing.Point(267, 26);
            this.radAccomplished.Name = "radAccomplished";
            this.radAccomplished.Size = new System.Drawing.Size(120, 19);
            this.radAccomplished.TabIndex = 3;
            this.radAccomplished.Tag = "4";
            this.radAccomplished.Text = "ACCOMPLISHED";
            this.radAccomplished.UseVisualStyleBackColor = true;
            this.radAccomplished.CheckedChanged += new System.EventHandler(this.RadAccomplished_CheckedChanged);
            // 
            // radCancel
            // 
            this.radCancel.AutoSize = true;
            this.radCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCancel.Location = new System.Drawing.Point(195, 26);
            this.radCancel.Name = "radCancel";
            this.radCancel.Size = new System.Drawing.Size(72, 19);
            this.radCancel.TabIndex = 2;
            this.radCancel.Tag = "3";
            this.radCancel.Text = "CANCEL";
            this.radCancel.UseVisualStyleBackColor = true;
            this.radCancel.CheckedChanged += new System.EventHandler(this.RadCancel_CheckedChanged);
            // 
            // radProcessing
            // 
            this.radProcessing.AutoSize = true;
            this.radProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radProcessing.Location = new System.Drawing.Point(92, 26);
            this.radProcessing.Name = "radProcessing";
            this.radProcessing.Size = new System.Drawing.Size(104, 19);
            this.radProcessing.TabIndex = 1;
            this.radProcessing.Tag = "2";
            this.radProcessing.Text = "PROCESSING";
            this.radProcessing.UseVisualStyleBackColor = true;
            this.radProcessing.CheckedChanged += new System.EventHandler(this.RadProcessing_CheckedChanged);
            // 
            // radPending
            // 
            this.radPending.AutoSize = true;
            this.radPending.Checked = true;
            this.radPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPending.Location = new System.Drawing.Point(8, 26);
            this.radPending.Name = "radPending";
            this.radPending.Size = new System.Drawing.Size(80, 19);
            this.radPending.TabIndex = 0;
            this.radPending.TabStop = true;
            this.radPending.Tag = "1";
            this.radPending.Text = "PENDING";
            this.radPending.UseVisualStyleBackColor = true;
            this.radPending.CheckedChanged += new System.EventHandler(this.RadPending_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // ucJoborder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gbIssuanceAndAssignment);
            this.Controls.Add(this.gbJODetails);
            this.Controls.Add(this.gbAccountDetails);
            this.Controls.Add(this.txtAccountNumber);
            this.Name = "ucJoborder";
            this.Size = new System.Drawing.Size(427, 730);
            this.Load += new System.EventHandler(this.UcJoborder_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UcJoborder_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.gbAccountDetails.ResumeLayout(false);
            this.gbAccountDetails.PerformLayout();
            this.gbJODetails.ResumeLayout(false);
            this.gbJODetails.PerformLayout();
            this.gbIssuanceAndAssignment.ResumeLayout(false);
            this.gbIssuanceAndAssignment.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.TextBox txtAccountNumber;
        internal System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.TextBox txtORNumber;
        internal System.Windows.Forms.DateTimePicker dtpDate;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        internal System.Windows.Forms.TextBox txtJONumber;
        internal System.Windows.Forms.TextBox txtMRISNumber;
        internal System.Windows.Forms.TextBox txtMRSNumber;
        internal System.Windows.Forms.ComboBox cmbxMaterialsIssuedBy;
        internal System.Windows.Forms.TextBox txtWARNumber;
        internal System.Windows.Forms.GroupBox gbJODetails;
        internal System.Windows.Forms.GroupBox gbAccountDetails;
        internal System.Windows.Forms.GroupBox gbIssuanceAndAssignment;
        internal System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.RadioButton radPending;
        internal System.Windows.Forms.RadioButton radProcessing;
        internal System.Windows.Forms.RadioButton radCancel;
        internal System.Windows.Forms.RadioButton radAccomplished;
        private System.Windows.Forms.Button btnSearch;
        internal System.Windows.Forms.TextBox txtAccountName;
        internal System.Windows.Forms.ComboBox cmbxAccomplishedBy;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.CheckBox cbxNA;
        internal System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.CheckedListBox clBoxParticulars;
        internal System.Windows.Forms.TextBox txtAcc3;
        internal System.Windows.Forms.TextBox txtAcc2;
        internal System.Windows.Forms.TextBox txtAcc1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.TextBox txtAcc4;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.TextBox txtRemarks;
    }
}
