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
            components = new System.ComponentModel.Container();
            label1 = new System.Windows.Forms.Label();
            txtORNumber = new System.Windows.Forms.TextBox();
            dtpDate = new System.Windows.Forms.DateTimePicker();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            nudAmount = new System.Windows.Forms.NumericUpDown();
            label5 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            txtAccountNumber = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            txtAddress = new System.Windows.Forms.TextBox();
            gbAccountDetails = new System.Windows.Forms.GroupBox();
            txtContact = new System.Windows.Forms.TextBox();
            label18 = new System.Windows.Forms.Label();
            cbxNA = new System.Windows.Forms.CheckBox();
            txtAcc4 = new System.Windows.Forms.TextBox();
            txtAccountName = new System.Windows.Forms.TextBox();
            btnSearch = new System.Windows.Forms.Button();
            txtAcc3 = new System.Windows.Forms.TextBox();
            txtAcc2 = new System.Windows.Forms.TextBox();
            txtAcc1 = new System.Windows.Forms.TextBox();
            label16 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            gbJODetails = new System.Windows.Forms.GroupBox();
            clBoxParticulars = new System.Windows.Forms.CheckedListBox();
            label9 = new System.Windows.Forms.Label();
            txtJONumber = new System.Windows.Forms.TextBox();
            txtWARNumber = new System.Windows.Forms.TextBox();
            label15 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            txtMRSNumber = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            txtMRISNumber = new System.Windows.Forms.TextBox();
            cmbxMaterialsIssuedBy = new System.Windows.Forms.ComboBox();
            label13 = new System.Windows.Forms.Label();
            gbIssuanceAndAssignment = new System.Windows.Forms.GroupBox();
            cmbxAccomplishedBy = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            groupBox4 = new System.Windows.Forms.GroupBox();
            txtRemarks = new System.Windows.Forms.TextBox();
            label17 = new System.Windows.Forms.Label();
            radAccomplished = new System.Windows.Forms.RadioButton();
            radCancel = new System.Windows.Forms.RadioButton();
            radProcessing = new System.Windows.Forms.RadioButton();
            radPending = new System.Windows.Forms.RadioButton();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            gbAccountDetails.SuspendLayout();
            gbJODetails.SuspendLayout();
            gbIssuanceAndAssignment.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(29, 82);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(102, 15);
            label1.TabIndex = 0;
            label1.Text = "ACCOUNT NAME";
            // 
            // txtORNumber
            // 
            txtORNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtORNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtORNumber.Location = new System.Drawing.Point(181, 273);
            txtORNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtORNumber.Name = "txtORNumber";
            txtORNumber.Size = new System.Drawing.Size(233, 21);
            txtORNumber.TabIndex = 5;
            txtORNumber.KeyPress += NumberOnly;
            // 
            // dtpDate
            // 
            dtpDate.CustomFormat = "MMMM dd, yyyy";
            dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpDate.Location = new System.Drawing.Point(181, 242);
            dtpDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new System.Drawing.Size(233, 21);
            dtpDate.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(29, 47);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(89, 15);
            label2.TabIndex = 4;
            label2.Text = "PARTICULARS";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(33, 242);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(38, 15);
            label3.TabIndex = 6;
            label3.Text = "DATE";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label4.Location = new System.Drawing.Point(33, 276);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(82, 15);
            label4.TabIndex = 7;
            label4.Text = "OR NUMBER";
            // 
            // nudAmount
            // 
            nudAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            nudAmount.Location = new System.Drawing.Point(181, 305);
            nudAmount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudAmount.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new System.Drawing.Size(233, 21);
            nudAmount.TabIndex = 6;
            nudAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            nudAmount.ThousandsSeparator = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label5.Location = new System.Drawing.Point(33, 307);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(59, 15);
            label5.TabIndex = 9;
            label5.Text = "AMOUNT";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label7.Location = new System.Drawing.Point(29, 52);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(121, 15);
            label7.TabIndex = 12;
            label7.Text = "ACCOUNT NUMBER";
            // 
            // txtAccountNumber
            // 
            txtAccountNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            txtAccountNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            txtAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtAccountNumber.Location = new System.Drawing.Point(574, 39);
            txtAccountNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtAccountNumber.Name = "txtAccountNumber";
            txtAccountNumber.Size = new System.Drawing.Size(235, 21);
            txtAccountNumber.TabIndex = 0;
            txtAccountNumber.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label8.Location = new System.Drawing.Point(29, 113);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(65, 15);
            label8.TabIndex = 14;
            label8.Text = "ADDRESS";
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtAddress.Location = new System.Drawing.Point(181, 112);
            txtAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new System.Drawing.Size(233, 21);
            txtAddress.TabIndex = 6;
            txtAddress.Validating += txtAddress_Validating;
            txtAddress.Validated += txtAddress_Validated;
            // 
            // gbAccountDetails
            // 
            gbAccountDetails.Controls.Add(txtContact);
            gbAccountDetails.Controls.Add(label18);
            gbAccountDetails.Controls.Add(cbxNA);
            gbAccountDetails.Controls.Add(txtAcc4);
            gbAccountDetails.Controls.Add(txtAccountName);
            gbAccountDetails.Controls.Add(btnSearch);
            gbAccountDetails.Controls.Add(txtAcc3);
            gbAccountDetails.Controls.Add(label1);
            gbAccountDetails.Controls.Add(txtAcc2);
            gbAccountDetails.Controls.Add(label8);
            gbAccountDetails.Controls.Add(txtAddress);
            gbAccountDetails.Controls.Add(txtAcc1);
            gbAccountDetails.Controls.Add(label7);
            gbAccountDetails.Controls.Add(label16);
            gbAccountDetails.Controls.Add(label14);
            gbAccountDetails.Controls.Add(label12);
            gbAccountDetails.Dock = System.Windows.Forms.DockStyle.Top;
            gbAccountDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            gbAccountDetails.Location = new System.Drawing.Point(12, 12);
            gbAccountDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbAccountDetails.Name = "gbAccountDetails";
            gbAccountDetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbAccountDetails.Size = new System.Drawing.Size(433, 178);
            gbAccountDetails.TabIndex = 0;
            gbAccountDetails.TabStop = false;
            gbAccountDetails.Text = "ACCOUNT DETAILS";
            // 
            // txtContact
            // 
            txtContact.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            txtContact.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtContact.Location = new System.Drawing.Point(181, 143);
            txtContact.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtContact.Name = "txtContact";
            txtContact.Size = new System.Drawing.Size(233, 21);
            txtContact.TabIndex = 7;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label18.Location = new System.Drawing.Point(29, 143);
            label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(62, 15);
            label18.TabIndex = 33;
            label18.Text = "CONTACT";
            label18.Click += label18_Click;
            // 
            // cbxNA
            // 
            cbxNA.AutoSize = true;
            cbxNA.Checked = true;
            cbxNA.CheckState = System.Windows.Forms.CheckState.Checked;
            cbxNA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cbxNA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cbxNA.Location = new System.Drawing.Point(364, 53);
            cbxNA.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbxNA.Name = "cbxNA";
            cbxNA.Size = new System.Drawing.Size(43, 17);
            cbxNA.TabIndex = 4;
            cbxNA.Text = "N/A";
            cbxNA.UseVisualStyleBackColor = true;
            cbxNA.CheckedChanged += cbxNA_CheckedChanged;
            // 
            // txtAcc4
            // 
            txtAcc4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            txtAcc4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            txtAcc4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtAcc4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtAcc4.Location = new System.Drawing.Point(335, 50);
            txtAcc4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtAcc4.MaxLength = 2;
            txtAcc4.Name = "txtAcc4";
            txtAcc4.ReadOnly = true;
            txtAcc4.Size = new System.Drawing.Size(25, 21);
            txtAcc4.TabIndex = 3;
            txtAcc4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtAcc4.TextChanged += txtAcc3_TextChanged;
            // 
            // txtAccountName
            // 
            txtAccountName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            txtAccountName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            txtAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtAccountName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtAccountName.Location = new System.Drawing.Point(181, 81);
            txtAccountName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtAccountName.Name = "txtAccountName";
            txtAccountName.Size = new System.Drawing.Size(233, 21);
            txtAccountName.TabIndex = 5;
            txtAccountName.Validating += TxtAccountName_Validating;
            txtAccountName.Validated += TxtAccountName_Validated;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSearch.BackColor = System.Drawing.Color.White;
            btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnSearch.Image = Properties.Resources.btn_search;
            btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnSearch.Location = new System.Drawing.Point(181, 17);
            btnSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(159, 27);
            btnSearch.TabIndex = 19;
            btnSearch.TabStop = false;
            btnSearch.Text = "Search Account  [F1]";
            btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += BtnSearch_Click;
            // 
            // txtAcc3
            // 
            txtAcc3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            txtAcc3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            txtAcc3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtAcc3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtAcc3.Location = new System.Drawing.Point(281, 50);
            txtAcc3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtAcc3.MaxLength = 3;
            txtAcc3.Name = "txtAcc3";
            txtAcc3.ReadOnly = true;
            txtAcc3.Size = new System.Drawing.Size(32, 21);
            txtAcc3.TabIndex = 2;
            txtAcc3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtAcc3.TextChanged += txtAcc3_TextChanged;
            txtAcc3.KeyDown += txtAcc1_KeyDown;
            txtAcc3.KeyPress += NumberOnly;
            // 
            // txtAcc2
            // 
            txtAcc2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            txtAcc2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            txtAcc2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtAcc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtAcc2.Location = new System.Drawing.Point(230, 50);
            txtAcc2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtAcc2.MaxLength = 3;
            txtAcc2.Name = "txtAcc2";
            txtAcc2.ReadOnly = true;
            txtAcc2.Size = new System.Drawing.Size(32, 21);
            txtAcc2.TabIndex = 1;
            txtAcc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtAcc2.TextChanged += txtAcc3_TextChanged;
            txtAcc2.KeyDown += txtAcc1_KeyDown;
            txtAcc2.KeyPress += NumberOnly;
            // 
            // txtAcc1
            // 
            txtAcc1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            txtAcc1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            txtAcc1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtAcc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtAcc1.Location = new System.Drawing.Point(181, 50);
            txtAcc1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtAcc1.MaxLength = 3;
            txtAcc1.Name = "txtAcc1";
            txtAcc1.ReadOnly = true;
            txtAcc1.Size = new System.Drawing.Size(32, 21);
            txtAcc1.TabIndex = 0;
            txtAcc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtAcc1.TextChanged += txtAcc3_TextChanged;
            txtAcc1.KeyDown += txtAcc1_KeyDown;
            txtAcc1.KeyPress += NumberOnly;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = System.Drawing.Color.Transparent;
            label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label16.Location = new System.Drawing.Point(215, 53);
            label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(12, 15);
            label16.TabIndex = 32;
            label16.Text = "-";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = System.Drawing.Color.Transparent;
            label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label14.Location = new System.Drawing.Point(318, 53);
            label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(12, 15);
            label14.TabIndex = 3;
            label14.Text = "-";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = System.Drawing.Color.Transparent;
            label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label12.Location = new System.Drawing.Point(267, 53);
            label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(12, 15);
            label12.TabIndex = 30;
            label12.Text = "-";
            // 
            // gbJODetails
            // 
            gbJODetails.Controls.Add(clBoxParticulars);
            gbJODetails.Controls.Add(label9);
            gbJODetails.Controls.Add(txtJONumber);
            gbJODetails.Controls.Add(label2);
            gbJODetails.Controls.Add(txtORNumber);
            gbJODetails.Controls.Add(label3);
            gbJODetails.Controls.Add(dtpDate);
            gbJODetails.Controls.Add(label4);
            gbJODetails.Controls.Add(label5);
            gbJODetails.Controls.Add(nudAmount);
            gbJODetails.Dock = System.Windows.Forms.DockStyle.Top;
            gbJODetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            gbJODetails.Location = new System.Drawing.Point(12, 190);
            gbJODetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbJODetails.Name = "gbJODetails";
            gbJODetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbJODetails.Size = new System.Drawing.Size(433, 338);
            gbJODetails.TabIndex = 16;
            gbJODetails.TabStop = false;
            gbJODetails.Text = "JOB ORDER DETAILS";
            // 
            // clBoxParticulars
            // 
            clBoxParticulars.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            clBoxParticulars.FormattingEnabled = true;
            clBoxParticulars.Location = new System.Drawing.Point(181, 45);
            clBoxParticulars.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            clBoxParticulars.Name = "clBoxParticulars";
            clBoxParticulars.Size = new System.Drawing.Size(231, 180);
            clBoxParticulars.TabIndex = 1;
            clBoxParticulars.Validating += clBoxParticulars_Validating;
            clBoxParticulars.Validated += clBoxParticulars_Validated;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label9.Location = new System.Drawing.Point(29, 18);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(79, 15);
            label9.TabIndex = 16;
            label9.Text = "JO NUMBER";
            // 
            // txtJONumber
            // 
            txtJONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtJONumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtJONumber.Location = new System.Drawing.Point(181, 16);
            txtJONumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtJONumber.Name = "txtJONumber";
            txtJONumber.Size = new System.Drawing.Size(233, 21);
            txtJONumber.TabIndex = 0;
            txtJONumber.KeyPress += NumberOnly;
            txtJONumber.Validating += TxtJONumber_Validating;
            txtJONumber.Validated += TxtJONumber_Validated;
            // 
            // txtWARNumber
            // 
            txtWARNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtWARNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtWARNumber.Location = new System.Drawing.Point(181, 158);
            txtWARNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtWARNumber.Name = "txtWARNumber";
            txtWARNumber.Size = new System.Drawing.Size(233, 21);
            txtWARNumber.TabIndex = 7;
            txtWARNumber.KeyPress += NumberOnly;
            txtWARNumber.Validating += TxtWARNumber_Validating;
            txtWARNumber.Validated += TxtWARNumber_Validated;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label15.Location = new System.Drawing.Point(29, 162);
            label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(91, 15);
            label15.TabIndex = 29;
            label15.Text = "WAR NUMBER";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label11.Location = new System.Drawing.Point(29, 130);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(92, 15);
            label11.TabIndex = 20;
            label11.Text = "MRS NUMBER";
            // 
            // txtMRSNumber
            // 
            txtMRSNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMRSNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtMRSNumber.Location = new System.Drawing.Point(181, 127);
            txtMRSNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtMRSNumber.Name = "txtMRSNumber";
            txtMRSNumber.Size = new System.Drawing.Size(233, 21);
            txtMRSNumber.TabIndex = 4;
            txtMRSNumber.KeyPress += NumberOnly;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label10.Location = new System.Drawing.Point(29, 100);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(95, 15);
            label10.TabIndex = 18;
            label10.Text = "MRIS NUMBER";
            // 
            // txtMRISNumber
            // 
            txtMRISNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMRISNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtMRISNumber.Location = new System.Drawing.Point(181, 97);
            txtMRISNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtMRISNumber.Name = "txtMRISNumber";
            txtMRISNumber.Size = new System.Drawing.Size(233, 21);
            txtMRISNumber.TabIndex = 3;
            txtMRISNumber.KeyPress += NumberOnly;
            // 
            // cmbxMaterialsIssuedBy
            // 
            cmbxMaterialsIssuedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxMaterialsIssuedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cmbxMaterialsIssuedBy.FormattingEnabled = true;
            cmbxMaterialsIssuedBy.Location = new System.Drawing.Point(181, 32);
            cmbxMaterialsIssuedBy.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbxMaterialsIssuedBy.Name = "cmbxMaterialsIssuedBy";
            cmbxMaterialsIssuedBy.Size = new System.Drawing.Size(233, 23);
            cmbxMaterialsIssuedBy.TabIndex = 0;
            cmbxMaterialsIssuedBy.Validating += cmbxMaterialsIssuedBy_Validating;
            cmbxMaterialsIssuedBy.Validated += cmbxMaterialsIssuedBy_Validated;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label13.Location = new System.Drawing.Point(29, 36);
            label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(101, 15);
            label13.TabIndex = 23;
            label13.Text = "MAT. ISSUED BY";
            // 
            // gbIssuanceAndAssignment
            // 
            gbIssuanceAndAssignment.Controls.Add(cmbxAccomplishedBy);
            gbIssuanceAndAssignment.Controls.Add(txtWARNumber);
            gbIssuanceAndAssignment.Controls.Add(label6);
            gbIssuanceAndAssignment.Controls.Add(cmbxMaterialsIssuedBy);
            gbIssuanceAndAssignment.Controls.Add(label15);
            gbIssuanceAndAssignment.Controls.Add(label13);
            gbIssuanceAndAssignment.Controls.Add(txtMRISNumber);
            gbIssuanceAndAssignment.Controls.Add(label11);
            gbIssuanceAndAssignment.Controls.Add(label10);
            gbIssuanceAndAssignment.Controls.Add(txtMRSNumber);
            gbIssuanceAndAssignment.Dock = System.Windows.Forms.DockStyle.Top;
            gbIssuanceAndAssignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            gbIssuanceAndAssignment.Location = new System.Drawing.Point(12, 528);
            gbIssuanceAndAssignment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbIssuanceAndAssignment.Name = "gbIssuanceAndAssignment";
            gbIssuanceAndAssignment.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbIssuanceAndAssignment.Size = new System.Drawing.Size(433, 194);
            gbIssuanceAndAssignment.TabIndex = 17;
            gbIssuanceAndAssignment.TabStop = false;
            gbIssuanceAndAssignment.Text = "ISSUANCES AND JOB ASSIGNMENTS";
            // 
            // cmbxAccomplishedBy
            // 
            cmbxAccomplishedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxAccomplishedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cmbxAccomplishedBy.FormattingEnabled = true;
            cmbxAccomplishedBy.Location = new System.Drawing.Point(181, 63);
            cmbxAccomplishedBy.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbxAccomplishedBy.Name = "cmbxAccomplishedBy";
            cmbxAccomplishedBy.Size = new System.Drawing.Size(233, 23);
            cmbxAccomplishedBy.TabIndex = 1;
            cmbxAccomplishedBy.Validating += cmbxAccomplishedBy_Validating;
            cmbxAccomplishedBy.Validated += cmbxAccomplishedBy_Validated;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label6.Location = new System.Drawing.Point(29, 67);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(120, 15);
            label6.TabIndex = 25;
            label6.Text = "ACCOMPLISHED BY";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtRemarks);
            groupBox4.Controls.Add(label17);
            groupBox4.Controls.Add(radAccomplished);
            groupBox4.Controls.Add(radCancel);
            groupBox4.Controls.Add(radProcessing);
            groupBox4.Controls.Add(radPending);
            groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            groupBox4.Location = new System.Drawing.Point(12, 722);
            groupBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox4.Size = new System.Drawing.Size(433, 84);
            groupBox4.TabIndex = 18;
            groupBox4.TabStop = false;
            groupBox4.Text = "STATUS AND REMARKS";
            // 
            // txtRemarks
            // 
            txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtRemarks.Location = new System.Drawing.Point(181, 23);
            txtRemarks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new System.Drawing.Size(233, 21);
            txtRemarks.TabIndex = 4;
            txtRemarks.Validating += txtRemarks_Validating;
            txtRemarks.Validated += txtRemarks_Validated;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label17.Location = new System.Drawing.Point(29, 25);
            label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(70, 15);
            label17.TabIndex = 7;
            label17.Text = "REMARKS ";
            // 
            // radAccomplished
            // 
            radAccomplished.AutoSize = true;
            radAccomplished.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            radAccomplished.Location = new System.Drawing.Point(308, 57);
            radAccomplished.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radAccomplished.Name = "radAccomplished";
            radAccomplished.Size = new System.Drawing.Size(120, 19);
            radAccomplished.TabIndex = 3;
            radAccomplished.Tag = "4";
            radAccomplished.Text = "ACCOMPLISHED";
            radAccomplished.UseVisualStyleBackColor = true;
            radAccomplished.CheckedChanged += RadAccomplished_CheckedChanged;
            // 
            // radCancel
            // 
            radCancel.AutoSize = true;
            radCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            radCancel.Location = new System.Drawing.Point(224, 57);
            radCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radCancel.Name = "radCancel";
            radCancel.Size = new System.Drawing.Size(72, 19);
            radCancel.TabIndex = 2;
            radCancel.Tag = "3";
            radCancel.Text = "CANCEL";
            radCancel.UseVisualStyleBackColor = true;
            radCancel.CheckedChanged += RadCancel_CheckedChanged;
            // 
            // radProcessing
            // 
            radProcessing.AutoSize = true;
            radProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            radProcessing.Location = new System.Drawing.Point(104, 57);
            radProcessing.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radProcessing.Name = "radProcessing";
            radProcessing.Size = new System.Drawing.Size(104, 19);
            radProcessing.TabIndex = 1;
            radProcessing.Tag = "2";
            radProcessing.Text = "PROCESSING";
            radProcessing.UseVisualStyleBackColor = true;
            radProcessing.CheckedChanged += RadProcessing_CheckedChanged;
            // 
            // radPending
            // 
            radPending.AutoSize = true;
            radPending.Checked = true;
            radPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            radPending.Location = new System.Drawing.Point(6, 57);
            radPending.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radPending.Name = "radPending";
            radPending.Size = new System.Drawing.Size(80, 19);
            radPending.TabIndex = 0;
            radPending.TabStop = true;
            radPending.Tag = "1";
            radPending.Text = "PENDING";
            radPending.UseVisualStyleBackColor = true;
            radPending.CheckedChanged += RadPending_CheckedChanged;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucJoborder
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            Controls.Add(groupBox4);
            Controls.Add(gbIssuanceAndAssignment);
            Controls.Add(gbJODetails);
            Controls.Add(txtAccountNumber);
            Controls.Add(gbAccountDetails);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ucJoborder";
            Padding = new System.Windows.Forms.Padding(12, 12, 12, 12);
            Size = new System.Drawing.Size(457, 853);
            Load += UcJoborder_Load;
            KeyPress += UcJoborder_KeyPress;
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            gbAccountDetails.ResumeLayout(false);
            gbAccountDetails.PerformLayout();
            gbJODetails.ResumeLayout(false);
            gbJODetails.PerformLayout();
            gbIssuanceAndAssignment.ResumeLayout(false);
            gbIssuanceAndAssignment.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.TextBox txtAcc4;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.TextBox txtRemarks;
        internal System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label18;
        internal System.Windows.Forms.TextBox txtAcc1;
    }
}
