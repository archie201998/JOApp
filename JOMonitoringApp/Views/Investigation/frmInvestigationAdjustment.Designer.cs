namespace JOMonitoringApp.Views.Investigation
{
    partial class frmInvestigationAdjustment
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
            this.cmbxParticular = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtAccountType = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.txtWaterBillAdjustment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtWaterBillAdjustedAamount = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAdjustedWaterBill = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtWaterBill = new System.Windows.Forms.TextBox();
            this.txtExtensionFee = new System.Windows.Forms.TextBox();
            this.txtPenalty = new System.Windows.Forms.TextBox();
            this.particularFactors = new System.Windows.Forms.CheckedListBox();
            this.dgParticularAdjustment = new System.Windows.Forms.DataGridView();
            this.particular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgParticularAdjustment)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbxParticular
            // 
            this.cmbxParticular.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxParticular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbxParticular.FormattingEnabled = true;
            this.cmbxParticular.Items.AddRange(new object[] {
            "",
            "Account Reclassication",
            "Leaking (Not Visible)",
            "Failed Calibration",
            "Erroneous Reading",
            "RFB + Illegal"});
            this.cmbxParticular.Location = new System.Drawing.Point(150, 16);
            this.cmbxParticular.Name = "cmbxParticular";
            this.cmbxParticular.Size = new System.Drawing.Size(438, 23);
            this.cmbxParticular.TabIndex = 0;
            this.cmbxParticular.SelectedIndexChanged += new System.EventHandler(this.cmbxParticular_SelectedIndexChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(6, 20);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(90, 15);
            this.label24.TabIndex = 9;
            this.label24.Text = "PARTICULAR : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtAccountType);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.txtAccountName);
            this.groupBox3.Controls.Add(this.txtAccountNumber);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(616, 82);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // txtAccountType
            // 
            this.txtAccountType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAccountType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAccountType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccountType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountType.Location = new System.Drawing.Point(371, 20);
            this.txtAccountType.Name = "txtAccountType";
            this.txtAccountType.Size = new System.Drawing.Size(217, 21);
            this.txtAccountType.TabIndex = 23;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label21.Location = new System.Drawing.Point(262, 23);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(106, 15);
            this.label21.TabIndex = 15;
            this.label21.Text = "ACCOUNT TYPE : ";
            // 
            // txtAccountName
            // 
            this.txtAccountName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAccountName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountName.Location = new System.Drawing.Point(150, 47);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(438, 21);
            this.txtAccountName.TabIndex = 22;
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAccountNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAccountNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNumber.Location = new System.Drawing.Point(150, 20);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(105, 21);
            this.txtAccountNumber.TabIndex = 21;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label20.Location = new System.Drawing.Point(15, 49);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(111, 15);
            this.label20.TabIndex = 13;
            this.label20.Text = "ACCOUNT NAME : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(14, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "ACCOUNT NUMBER :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.btnCancel);
            this.groupBox4.Controls.Add(this.btnSave);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox4.Location = new System.Drawing.Point(0, 807);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(642, 58);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label19.Location = new System.Drawing.Point(327, 33);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(298, 16);
            this.label19.TabIndex = 20;
            this.label19.Text = "*Verify the accuracy of the amount before saving. ";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancel.Location = new System.Drawing.Point(109, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel ";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(12, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblImage);
            this.groupBox5.Controls.Add(this.txtWaterBillAdjustment);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.txtWaterBillAdjustedAamount);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.txtAdjustedWaterBill);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.txtWaterBill);
            this.groupBox5.Controls.Add(this.txtExtensionFee);
            this.groupBox5.Controls.Add(this.txtPenalty);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox5.Location = new System.Drawing.Point(12, 545);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(616, 254);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            // 
            // lblImage
            // 
            this.lblImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImage.AutoSize = true;
            this.lblImage.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblImage.ForeColor = System.Drawing.Color.White;
            this.lblImage.Location = new System.Drawing.Point(20, 224);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(86, 15);
            this.lblImage.TabIndex = 89;
            this.lblImage.Text = "View Ledger";
            this.lblImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblImage.Visible = false;
            this.lblImage.Click += new System.EventHandler(this.lblImage_Click);
            // 
            // txtWaterBillAdjustment
            // 
            this.txtWaterBillAdjustment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtWaterBillAdjustment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtWaterBillAdjustment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWaterBillAdjustment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWaterBillAdjustment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txtWaterBillAdjustment.ForeColor = System.Drawing.Color.DarkOrange;
            this.txtWaterBillAdjustment.Location = new System.Drawing.Point(302, 130);
            this.txtWaterBillAdjustment.Name = "txtWaterBillAdjustment";
            this.txtWaterBillAdjustment.Size = new System.Drawing.Size(307, 21);
            this.txtWaterBillAdjustment.TabIndex = 4;
            this.txtWaterBillAdjustment.Text = "0";
            this.txtWaterBillAdjustment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWaterBillAdjustment.TextChanged += new System.EventHandler(this.txtPenalty_TextChanged);
            this.txtWaterBillAdjustment.Leave += new System.EventHandler(this.txtAdjustedDue_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 15);
            this.label1.TabIndex = 31;
            this.label1.Text = "WATER BILL ADJUSTMENT ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(20, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 15);
            this.label11.TabIndex = 25;
            this.label11.Text = "PENALTY ";
            // 
            // txtWaterBillAdjustedAamount
            // 
            this.txtWaterBillAdjustedAamount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtWaterBillAdjustedAamount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtWaterBillAdjustedAamount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWaterBillAdjustedAamount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWaterBillAdjustedAamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txtWaterBillAdjustedAamount.ForeColor = System.Drawing.Color.Red;
            this.txtWaterBillAdjustedAamount.Location = new System.Drawing.Point(302, 49);
            this.txtWaterBillAdjustedAamount.Name = "txtWaterBillAdjustedAamount";
            this.txtWaterBillAdjustedAamount.Size = new System.Drawing.Size(307, 21);
            this.txtWaterBillAdjustedAamount.TabIndex = 1;
            this.txtWaterBillAdjustedAamount.Text = "0";
            this.txtWaterBillAdjustedAamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWaterBillAdjustedAamount.TextChanged += new System.EventHandler(this.txtPenalty_TextChanged);
            this.txtWaterBillAdjustedAamount.Leave += new System.EventHandler(this.txtAdjustment_Leave);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(20, 53);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(125, 15);
            this.label23.TabIndex = 29;
            this.label23.Text = "ADJUSTED AMOUNT";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label12.Location = new System.Drawing.Point(302, 160);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(311, 15);
            this.label12.TabIndex = 28;
            this.label12.Text = "----------------------------------------------------------------------------";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(20, 184);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(143, 15);
            this.label22.TabIndex = 26;
            this.label22.Text = "ADJUSTED WATER BILL";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "EXTENSION FEE ";
            // 
            // txtAdjustedWaterBill
            // 
            this.txtAdjustedWaterBill.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAdjustedWaterBill.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAdjustedWaterBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdjustedWaterBill.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAdjustedWaterBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdjustedWaterBill.ForeColor = System.Drawing.Color.ForestGreen;
            this.txtAdjustedWaterBill.Location = new System.Drawing.Point(303, 178);
            this.txtAdjustedWaterBill.Name = "txtAdjustedWaterBill";
            this.txtAdjustedWaterBill.Size = new System.Drawing.Size(307, 38);
            this.txtAdjustedWaterBill.TabIndex = 5;
            this.txtAdjustedWaterBill.Text = "0";
            this.txtAdjustedWaterBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "WATER BILL";
            // 
            // txtWaterBill
            // 
            this.txtWaterBill.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtWaterBill.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtWaterBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWaterBill.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWaterBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWaterBill.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtWaterBill.Location = new System.Drawing.Point(303, 21);
            this.txtWaterBill.Name = "txtWaterBill";
            this.txtWaterBill.Size = new System.Drawing.Size(307, 22);
            this.txtWaterBill.TabIndex = 0;
            this.txtWaterBill.Text = "0";
            this.txtWaterBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWaterBill.TextChanged += new System.EventHandler(this.txtPenalty_TextChanged);
            this.txtWaterBill.Leave += new System.EventHandler(this.txtAmountDue_Leave);
            // 
            // txtExtensionFee
            // 
            this.txtExtensionFee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtExtensionFee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtExtensionFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExtensionFee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExtensionFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txtExtensionFee.Location = new System.Drawing.Point(303, 76);
            this.txtExtensionFee.Name = "txtExtensionFee";
            this.txtExtensionFee.Size = new System.Drawing.Size(307, 21);
            this.txtExtensionFee.TabIndex = 2;
            this.txtExtensionFee.Text = "0";
            this.txtExtensionFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExtensionFee.TextChanged += new System.EventHandler(this.txtPenalty_TextChanged);
            // 
            // txtPenalty
            // 
            this.txtPenalty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPenalty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPenalty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPenalty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPenalty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txtPenalty.Location = new System.Drawing.Point(303, 103);
            this.txtPenalty.Name = "txtPenalty";
            this.txtPenalty.Size = new System.Drawing.Size(307, 21);
            this.txtPenalty.TabIndex = 3;
            this.txtPenalty.Text = "0";
            this.txtPenalty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPenalty.TextChanged += new System.EventHandler(this.txtPenalty_TextChanged);
            // 
            // particularFactors
            // 
            this.particularFactors.FormattingEnabled = true;
            this.particularFactors.Items.AddRange(new object[] {
            "Actual Consumption",
            "Actual Reading (Correct Reading after verification)",
            "Average Consumption (Last 3 Months)",
            "Consumption Upon Disconnection",
            "Illegal Connection",
            "Previous Consumption",
            "Previous Reading (Previous Month)",
            "Present Consumption",
            "Present Reading (Current Month)",
            "+ VAT (12%)",
            "30% of Current Consumption",
            "70% of Current Consumption"});
            this.particularFactors.Location = new System.Drawing.Point(3, 45);
            this.particularFactors.Name = "particularFactors";
            this.particularFactors.Size = new System.Drawing.Size(610, 184);
            this.particularFactors.TabIndex = 20;
            this.particularFactors.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.particularFactors_ItemCheck);
            // 
            // dgParticularAdjustment
            // 
            this.dgParticularAdjustment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgParticularAdjustment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.particular,
            this._value});
            this.dgParticularAdjustment.Location = new System.Drawing.Point(5, 15);
            this.dgParticularAdjustment.Name = "dgParticularAdjustment";
            this.dgParticularAdjustment.Size = new System.Drawing.Size(604, 179);
            this.dgParticularAdjustment.TabIndex = 21;
            this.dgParticularAdjustment.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgParticularAdjustment_CellValueChanged);
            // 
            // particular
            // 
            this.particular.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.particular.HeaderText = "Variable";
            this.particular.Name = "particular";
            // 
            // _value
            // 
            this._value.HeaderText = "Value";
            this._value.Name = "_value";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgParticularAdjustment);
            this.groupBox2.Location = new System.Drawing.Point(12, 339);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(616, 200);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cmbxParticular);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.particularFactors);
            this.groupBox6.Location = new System.Drawing.Point(12, 100);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(616, 233);
            this.groupBox6.TabIndex = 22;
            this.groupBox6.TabStop = false;
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // frmInvestigationAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 865);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInvestigationAdjustment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adjustment Form";
            this.Load += new System.EventHandler(this.frmInvestigationAdjustment_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgParticularAdjustment)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbxParticular;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox5;
        internal System.Windows.Forms.TextBox txtPenalty;
        internal System.Windows.Forms.TextBox txtExtensionFee;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtWaterBill;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        internal System.Windows.Forms.TextBox txtAccountNumber;
        internal System.Windows.Forms.TextBox txtAccountName;
        internal System.Windows.Forms.TextBox txtAccountType;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.TextBox txtAdjustedWaterBill;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox txtWaterBillAdjustedAamount;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.CheckedListBox particularFactors;
        private System.Windows.Forms.DataGridView dgParticularAdjustment;
        private System.Windows.Forms.DataGridViewTextBoxColumn particular;
        private System.Windows.Forms.DataGridViewTextBoxColumn _value;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        internal System.Windows.Forms.TextBox txtWaterBillAdjustment;
        private System.Windows.Forms.Label label1;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        internal System.Windows.Forms.Label lblImage;
    }
}