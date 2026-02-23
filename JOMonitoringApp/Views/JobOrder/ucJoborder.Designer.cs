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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbxNA = new System.Windows.Forms.CheckBox();
            this.txtAcc4 = new System.Windows.Forms.TextBox();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.txtAcc3 = new System.Windows.Forms.TextBox();
            this.txtAcc2 = new System.Windows.Forms.TextBox();
            this.txtAcc1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gbJODetails = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.clBoxParticulars = new System.Windows.Forms.CheckedListBox();
            this.lblHydrant = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtJONumber = new System.Windows.Forms.TextBox();
            this.txtWARNumber = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMRSNumber = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMRISNumber = new System.Windows.Forms.TextBox();
            this.cmbxMaterialsIssuedBy = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.gbIssuanceAndAssignment = new System.Windows.Forms.GroupBox();
            this.cmbxAccomplishedBy = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.radPending = new System.Windows.Forms.RadioButton();
            this.radProcessing = new System.Windows.Forms.RadioButton();
            this.radCancel = new System.Windows.Forms.RadioButton();
            this.radAccomplished = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.gbStatusAndRemaarks = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.gbAccountDetails.SuspendLayout();
            this.gbJODetails.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbIssuanceAndAssignment.SuspendLayout();
            this.gbStatusAndRemaarks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.txtORNumber.Location = new System.Drawing.Point(155, 231);
            this.txtORNumber.Name = "txtORNumber";
            this.txtORNumber.Size = new System.Drawing.Size(200, 21);
            this.txtORNumber.TabIndex = 5;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "MMMM dd, yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(155, 206);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 21);
            this.dtpDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "PARTICULARS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "DATE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "OR NUMBER";
            // 
            // nudAmount
            // 
            this.nudAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAmount.Location = new System.Drawing.Point(155, 258);
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
            this.label5.Location = new System.Drawing.Point(28, 260);
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
            this.txtAccountNumber.Location = new System.Drawing.Point(492, 34);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(202, 21);
            this.txtAccountNumber.TabIndex = 0;
            this.txtAccountNumber.Visible = false;
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
            this.txtAddress.Location = new System.Drawing.Point(155, 97);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 21);
            this.txtAddress.TabIndex = 6;
            // 
            // gbAccountDetails
            // 
            this.gbAccountDetails.Controls.Add(this.pictureBox1);
            this.gbAccountDetails.Controls.Add(this.textBox1);
            this.gbAccountDetails.Controls.Add(this.txtContact);
            this.gbAccountDetails.Controls.Add(this.label18);
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
            this.gbAccountDetails.Location = new System.Drawing.Point(10, 10);
            this.gbAccountDetails.Name = "gbAccountDetails";
            this.gbAccountDetails.Size = new System.Drawing.Size(372, 154);
            this.gbAccountDetails.TabIndex = 0;
            this.gbAccountDetails.TabStop = false;
            this.gbAccountDetails.Text = "ACCOUNT DETAILS";
            // 
            // textBox1
            // 
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(155, 124);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(36, 21);
            this.textBox1.TabIndex = 34;
            this.textBox1.Text = "+63";
            // 
            // txtContact
            // 
            this.txtContact.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtContact.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact.Location = new System.Drawing.Point(197, 124);
            this.txtContact.MaxLength = 10;
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(130, 21);
            this.txtContact.TabIndex = 7;
            this.txtContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(25, 124);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 15);
            this.label18.TabIndex = 33;
            this.label18.Text = "CONTACT NO.";
            // 
            // cbxNA
            // 
            this.cbxNA.AutoSize = true;
            this.cbxNA.Checked = true;
            this.cbxNA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxNA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxNA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxNA.Location = new System.Drawing.Point(312, 46);
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
            this.txtAcc4.Location = new System.Drawing.Point(287, 43);
            this.txtAcc4.MaxLength = 2;
            this.txtAcc4.Name = "txtAcc4";
            this.txtAcc4.ReadOnly = true;
            this.txtAcc4.Size = new System.Drawing.Size(22, 21);
            this.txtAcc4.TabIndex = 3;
            this.txtAcc4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // txtAcc3
            // 
            this.txtAcc3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAcc3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAcc3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcc3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcc3.Location = new System.Drawing.Point(241, 43);
            this.txtAcc3.MaxLength = 3;
            this.txtAcc3.Name = "txtAcc3";
            this.txtAcc3.ReadOnly = true;
            this.txtAcc3.Size = new System.Drawing.Size(28, 21);
            this.txtAcc3.TabIndex = 2;
            this.txtAcc3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAcc2
            // 
            this.txtAcc2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAcc2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAcc2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcc2.Location = new System.Drawing.Point(197, 43);
            this.txtAcc2.MaxLength = 3;
            this.txtAcc2.Name = "txtAcc2";
            this.txtAcc2.ReadOnly = true;
            this.txtAcc2.Size = new System.Drawing.Size(28, 21);
            this.txtAcc2.TabIndex = 1;
            this.txtAcc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.txtAcc1.ReadOnly = true;
            this.txtAcc1.Size = new System.Drawing.Size(28, 21);
            this.txtAcc1.TabIndex = 0;
            this.txtAcc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(184, 46);
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
            this.label14.Location = new System.Drawing.Point(273, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(12, 15);
            this.label14.TabIndex = 3;
            this.label14.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(229, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(12, 15);
            this.label12.TabIndex = 30;
            this.label12.Text = "-";
            // 
            // gbJODetails
            // 
            this.gbJODetails.Controls.Add(this.dtpDate);
            this.gbJODetails.Controls.Add(this.flowLayoutPanel1);
            this.gbJODetails.Controls.Add(this.label9);
            this.gbJODetails.Controls.Add(this.txtJONumber);
            this.gbJODetails.Controls.Add(this.label2);
            this.gbJODetails.Controls.Add(this.txtORNumber);
            this.gbJODetails.Controls.Add(this.label3);
            this.gbJODetails.Controls.Add(this.label4);
            this.gbJODetails.Controls.Add(this.label5);
            this.gbJODetails.Controls.Add(this.nudAmount);
            this.gbJODetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbJODetails.Location = new System.Drawing.Point(10, 164);
            this.gbJODetails.Name = "gbJODetails";
            this.gbJODetails.Size = new System.Drawing.Size(372, 293);
            this.gbJODetails.TabIndex = 16;
            this.gbJODetails.TabStop = false;
            this.gbJODetails.Text = "JOB ORDER DETAILS";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.clBoxParticulars);
            this.flowLayoutPanel1.Controls.Add(this.lblHydrant);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(154, 50);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(205, 154);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // clBoxParticulars
            // 
            this.clBoxParticulars.CheckOnClick = true;
            this.clBoxParticulars.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clBoxParticulars.FormattingEnabled = true;
            this.clBoxParticulars.Location = new System.Drawing.Point(3, 3);
            this.clBoxParticulars.Name = "clBoxParticulars";
            this.clBoxParticulars.Size = new System.Drawing.Size(199, 132);
            this.clBoxParticulars.TabIndex = 1;
            this.clBoxParticulars.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clBoxParticulars_ItemCheck);
            this.clBoxParticulars.SelectedIndexChanged += new System.EventHandler(this.clBoxParticulars_SelectedIndexChanged);
            // 
            // lblHydrant
            // 
            this.lblHydrant.AutoSize = true;
            this.lblHydrant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHydrant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHydrant.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblHydrant.Location = new System.Drawing.Point(3, 138);
            this.lblHydrant.Name = "lblHydrant";
            this.lblHydrant.Size = new System.Drawing.Size(135, 13);
            this.lblHydrant.TabIndex = 20;
            this.lblHydrant.Text = "Hydrant Withdrawal Details";
            this.lblHydrant.Visible = false;
            this.lblHydrant.Click += new System.EventHandler(this.lblHydrant_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(25, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "JO NUMBER";
            // 
            // txtJONumber
            // 
            this.txtJONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJONumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJONumber.Location = new System.Drawing.Point(155, 23);
            this.txtJONumber.MaxLength = 10;
            this.txtJONumber.Name = "txtJONumber";
            this.txtJONumber.Size = new System.Drawing.Size(200, 21);
            this.txtJONumber.TabIndex = 0;
            this.txtJONumber.Validating += new System.ComponentModel.CancelEventHandler(this.TxtJONumber_Validating);
            this.txtJONumber.Validated += new System.EventHandler(this.TxtJONumber_Validated);
            // 
            // txtWARNumber
            // 
            this.txtWARNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWARNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWARNumber.Location = new System.Drawing.Point(155, 137);
            this.txtWARNumber.Name = "txtWARNumber";
            this.txtWARNumber.Size = new System.Drawing.Size(200, 21);
            this.txtWARNumber.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(25, 140);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 15);
            this.label15.TabIndex = 29;
            this.label15.Text = "WAR NUMBER";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(25, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 15);
            this.label11.TabIndex = 20;
            this.label11.Text = "MRS NUMBER";
            // 
            // txtMRSNumber
            // 
            this.txtMRSNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMRSNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMRSNumber.Location = new System.Drawing.Point(155, 110);
            this.txtMRSNumber.Name = "txtMRSNumber";
            this.txtMRSNumber.Size = new System.Drawing.Size(200, 21);
            this.txtMRSNumber.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(25, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 15);
            this.label10.TabIndex = 18;
            this.label10.Text = "MRIS NUMBER";
            // 
            // txtMRISNumber
            // 
            this.txtMRISNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMRISNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMRISNumber.Location = new System.Drawing.Point(155, 84);
            this.txtMRISNumber.Name = "txtMRISNumber";
            this.txtMRISNumber.Size = new System.Drawing.Size(200, 21);
            this.txtMRISNumber.TabIndex = 3;
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
            this.gbIssuanceAndAssignment.Controls.Add(this.txtWARNumber);
            this.gbIssuanceAndAssignment.Controls.Add(this.label6);
            this.gbIssuanceAndAssignment.Controls.Add(this.cmbxMaterialsIssuedBy);
            this.gbIssuanceAndAssignment.Controls.Add(this.label15);
            this.gbIssuanceAndAssignment.Controls.Add(this.label13);
            this.gbIssuanceAndAssignment.Controls.Add(this.txtMRISNumber);
            this.gbIssuanceAndAssignment.Controls.Add(this.label11);
            this.gbIssuanceAndAssignment.Controls.Add(this.label10);
            this.gbIssuanceAndAssignment.Controls.Add(this.txtMRSNumber);
            this.gbIssuanceAndAssignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbIssuanceAndAssignment.Location = new System.Drawing.Point(10, 457);
            this.gbIssuanceAndAssignment.Name = "gbIssuanceAndAssignment";
            this.gbIssuanceAndAssignment.Size = new System.Drawing.Size(372, 168);
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
            // radPending
            // 
            this.radPending.AutoSize = true;
            this.radPending.Checked = true;
            this.radPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPending.Location = new System.Drawing.Point(55, 52);
            this.radPending.Name = "radPending";
            this.radPending.Size = new System.Drawing.Size(80, 19);
            this.radPending.TabIndex = 0;
            this.radPending.TabStop = true;
            this.radPending.Tag = "1";
            this.radPending.Text = "PENDING";
            this.radPending.UseVisualStyleBackColor = true;
            this.radPending.CheckedChanged += new System.EventHandler(this.RadPending_CheckedChanged);
            // 
            // radProcessing
            // 
            this.radProcessing.AutoSize = true;
            this.radProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radProcessing.Location = new System.Drawing.Point(55, 77);
            this.radProcessing.Name = "radProcessing";
            this.radProcessing.Size = new System.Drawing.Size(104, 19);
            this.radProcessing.TabIndex = 1;
            this.radProcessing.Tag = "2";
            this.radProcessing.Text = "PROCESSING";
            this.radProcessing.UseVisualStyleBackColor = true;
            this.radProcessing.CheckedChanged += new System.EventHandler(this.RadProcessing_CheckedChanged);
            // 
            // radCancel
            // 
            this.radCancel.AutoSize = true;
            this.radCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCancel.Location = new System.Drawing.Point(216, 52);
            this.radCancel.Name = "radCancel";
            this.radCancel.Size = new System.Drawing.Size(72, 19);
            this.radCancel.TabIndex = 2;
            this.radCancel.Tag = "3";
            this.radCancel.Text = "CANCEL";
            this.radCancel.UseVisualStyleBackColor = true;
            this.radCancel.CheckedChanged += new System.EventHandler(this.RadCancel_CheckedChanged);
            // 
            // radAccomplished
            // 
            this.radAccomplished.AutoSize = true;
            this.radAccomplished.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAccomplished.Location = new System.Drawing.Point(216, 77);
            this.radAccomplished.Name = "radAccomplished";
            this.radAccomplished.Size = new System.Drawing.Size(120, 19);
            this.radAccomplished.TabIndex = 3;
            this.radAccomplished.Tag = "4";
            this.radAccomplished.Text = "ACCOMPLISHED";
            this.radAccomplished.UseVisualStyleBackColor = true;
            this.radAccomplished.CheckedChanged += new System.EventHandler(this.RadAccomplished_CheckedChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(25, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 15);
            this.label17.TabIndex = 7;
            this.label17.Text = "REMARKS ";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(155, 20);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(200, 21);
            this.txtRemarks.TabIndex = 4;
            // 
            // gbStatusAndRemaarks
            // 
            this.gbStatusAndRemaarks.Controls.Add(this.txtRemarks);
            this.gbStatusAndRemaarks.Controls.Add(this.label17);
            this.gbStatusAndRemaarks.Controls.Add(this.radAccomplished);
            this.gbStatusAndRemaarks.Controls.Add(this.radCancel);
            this.gbStatusAndRemaarks.Controls.Add(this.radProcessing);
            this.gbStatusAndRemaarks.Controls.Add(this.radPending);
            this.gbStatusAndRemaarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStatusAndRemaarks.Location = new System.Drawing.Point(10, 625);
            this.gbStatusAndRemaarks.Name = "gbStatusAndRemaarks";
            this.gbStatusAndRemaarks.Size = new System.Drawing.Size(372, 101);
            this.gbStatusAndRemaarks.TabIndex = 18;
            this.gbStatusAndRemaarks.TabStop = false;
            this.gbStatusAndRemaarks.Text = "STATUS AND REMARKS";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(419, 137);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label19);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label20);
            this.splitContainer1.Size = new System.Drawing.Size(600, 277);
            this.splitContainer1.SplitterDistance = 133;
            this.splitContainer1.TabIndex = 19;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(3, 2);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(115, 16);
            this.label19.TabIndex = 20;
            this.label19.Text = "Account Details";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(5, 5);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(161, 16);
            this.label20.TabIndex = 21;
            this.label20.Text = "JOB ORDER DETAILS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::JOMonitoringApp.Properties.Resources.icons8_plus_50;
            this.pictureBox1.Location = new System.Drawing.Point(331, 123);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Add more contact number.");
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::JOMonitoringApp.Properties.Resources.btn_search;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(156, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(136, 23);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "Search Account  [F1]";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
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
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.gbStatusAndRemaarks);
            this.Controls.Add(this.gbIssuanceAndAssignment);
            this.Controls.Add(this.gbJODetails);
            this.Controls.Add(this.txtAccountNumber);
            this.Controls.Add(this.gbAccountDetails);
            this.Name = "ucJoborder";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1077, 739);
            this.Load += new System.EventHandler(this.UcJoborder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.gbAccountDetails.ResumeLayout(false);
            this.gbAccountDetails.PerformLayout();
            this.gbJODetails.ResumeLayout(false);
            this.gbJODetails.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.gbIssuanceAndAssignment.ResumeLayout(false);
            this.gbIssuanceAndAssignment.PerformLayout();
            this.gbStatusAndRemaarks.ResumeLayout(false);
            this.gbStatusAndRemaarks.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Button btnSearch;
        internal System.Windows.Forms.TextBox txtAccountName;
        internal System.Windows.Forms.ComboBox cmbxAccomplishedBy;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.CheckBox cbxNA;
        internal System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.CheckedListBox clBoxParticulars;
        internal System.Windows.Forms.TextBox txtAcc3;
        internal System.Windows.Forms.TextBox txtAcc2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.TextBox txtAcc4;
        internal System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label18;
        internal System.Windows.Forms.TextBox txtAcc1;
        internal System.Windows.Forms.GroupBox gbStatusAndRemaarks;
        internal System.Windows.Forms.TextBox txtRemarks;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.RadioButton radAccomplished;
        internal System.Windows.Forms.RadioButton radCancel;
        internal System.Windows.Forms.RadioButton radProcessing;
        internal System.Windows.Forms.RadioButton radPending;
        internal System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblHydrant;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
