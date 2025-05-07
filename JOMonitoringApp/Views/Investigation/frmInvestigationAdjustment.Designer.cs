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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.label22 = new System.Windows.Forms.Label();
            this.txtAmountDueAfterAdjustment = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxExtensionFee = new System.Windows.Forms.CheckBox();
            this.txtExtensionFee = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAmountDue = new System.Windows.Forms.TextBox();
            this.cbxPenalty = new System.Windows.Forms.CheckBox();
            this.txtPenalty = new System.Windows.Forms.TextBox();
            this.txtPresentReading = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConsumption = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtActualReading = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPreviousReading = new System.Windows.Forms.TextBox();
            this.gbErrorReading = new System.Windows.Forms.GroupBox();
            this.gbFailedCalibration = new System.Windows.Forms.GroupBox();
            this.txtNewAverageCons = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtLastMonth = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtLast2Month = new System.Windows.Forms.TextBox();
            this.lblasdasd = new System.Windows.Forms.Label();
            this.txtLast3Month = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.gbIllegal = new System.Windows.Forms.GroupBox();
            this.txtConsAfterDisconnection = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtConsOnDisconnection = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.gbLeakingNotVisible = new System.Windows.Forms.GroupBox();
            this.txtAdjustedConsumption = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAdjustmentConsumption = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLeakingNotVisCurrentCons = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gbErrorReading.SuspendLayout();
            this.gbFailedCalibration.SuspendLayout();
            this.gbIllegal.SuspendLayout();
            this.gbLeakingNotVisible.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbxParticular
            // 
            this.cmbxParticular.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxParticular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbxParticular.FormattingEnabled = true;
            this.cmbxParticular.Items.AddRange(new object[] {
            "",
            "Leaking (Not Visible)",
            "Failed Calibration",
            "Erroneous Reading",
            "RFB + Illegal"});
            this.cmbxParticular.Location = new System.Drawing.Point(150, 20);
            this.cmbxParticular.Name = "cmbxParticular";
            this.cmbxParticular.Size = new System.Drawing.Size(280, 23);
            this.cmbxParticular.TabIndex = 0;
            this.cmbxParticular.SelectedIndexChanged += new System.EventHandler(this.cmbxParticular_SelectedIndexChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(18, 20);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(90, 15);
            this.label24.TabIndex = 9;
            this.label24.Text = "PARTICULAR : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbxParticular);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox1.Location = new System.Drawing.Point(12, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 53);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.OrangeRed;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(436, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Auto Compute";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.groupBox3.Size = new System.Drawing.Size(567, 82);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
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
            this.txtAccountType.Size = new System.Drawing.Size(177, 21);
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
            this.label21.Click += new System.EventHandler(this.label21_Click);
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
            this.txtAccountName.Size = new System.Drawing.Size(398, 21);
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
            this.groupBox4.Location = new System.Drawing.Point(0, 674);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1371, 59);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label19.Location = new System.Drawing.Point(274, 34);
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
            this.btnCancel.TabIndex = 3;
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
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.txtAmountDueAfterAdjustment);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.cbxExtensionFee);
            this.groupBox5.Controls.Add(this.txtExtensionFee);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.txtAmountDue);
            this.groupBox5.Controls.Add(this.cbxPenalty);
            this.groupBox5.Controls.Add(this.txtPenalty);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox5.Location = new System.Drawing.Point(12, 336);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(567, 332);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(15, 129);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(138, 30);
            this.label22.TabIndex = 26;
            this.label22.Text = "AMOUNT DUE \r\nAFTER ADJUSTMENT : ";
            // 
            // txtAmountDueAfterAdjustment
            // 
            this.txtAmountDueAfterAdjustment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAmountDueAfterAdjustment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAmountDueAfterAdjustment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountDueAfterAdjustment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAmountDueAfterAdjustment.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountDueAfterAdjustment.ForeColor = System.Drawing.Color.ForestGreen;
            this.txtAmountDueAfterAdjustment.Location = new System.Drawing.Point(172, 128);
            this.txtAmountDueAfterAdjustment.Name = "txtAmountDueAfterAdjustment";
            this.txtAmountDueAfterAdjustment.Size = new System.Drawing.Size(176, 38);
            this.txtAmountDueAfterAdjustment.TabIndex = 27;
            this.txtAmountDueAfterAdjustment.Text = "0";
            this.txtAmountDueAfterAdjustment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 15);
            this.label11.TabIndex = 25;
            this.label11.Text = "PENALTY : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "EXTENSION FEE : ";
            // 
            // cbxExtensionFee
            // 
            this.cbxExtensionFee.AutoSize = true;
            this.cbxExtensionFee.Location = new System.Drawing.Point(218, 55);
            this.cbxExtensionFee.Name = "cbxExtensionFee";
            this.cbxExtensionFee.Size = new System.Drawing.Size(15, 14);
            this.cbxExtensionFee.TabIndex = 17;
            this.cbxExtensionFee.UseVisualStyleBackColor = true;
            this.cbxExtensionFee.CheckedChanged += new System.EventHandler(this.cbxExtensionFee_CheckedChanged);
            // 
            // txtExtensionFee
            // 
            this.txtExtensionFee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtExtensionFee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtExtensionFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExtensionFee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExtensionFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txtExtensionFee.Location = new System.Drawing.Point(236, 52);
            this.txtExtensionFee.Name = "txtExtensionFee";
            this.txtExtensionFee.Size = new System.Drawing.Size(112, 21);
            this.txtExtensionFee.TabIndex = 20;
            this.txtExtensionFee.Text = "0";
            this.txtExtensionFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExtensionFee.TextChanged += new System.EventHandler(this.txtPenalty_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "AMOUNT DUE :";
            // 
            // txtAmountDue
            // 
            this.txtAmountDue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAmountDue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAmountDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountDue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAmountDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountDue.ForeColor = System.Drawing.Color.Red;
            this.txtAmountDue.Location = new System.Drawing.Point(236, 25);
            this.txtAmountDue.Name = "txtAmountDue";
            this.txtAmountDue.Size = new System.Drawing.Size(112, 22);
            this.txtAmountDue.TabIndex = 23;
            this.txtAmountDue.Text = "0";
            this.txtAmountDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmountDue.TextChanged += new System.EventHandler(this.txtPenalty_TextChanged);
            // 
            // cbxPenalty
            // 
            this.cbxPenalty.AutoSize = true;
            this.cbxPenalty.Location = new System.Drawing.Point(218, 82);
            this.cbxPenalty.Name = "cbxPenalty";
            this.cbxPenalty.Size = new System.Drawing.Size(15, 14);
            this.cbxPenalty.TabIndex = 17;
            this.cbxPenalty.UseVisualStyleBackColor = true;
            this.cbxPenalty.CheckedChanged += new System.EventHandler(this.cbxPenalty_CheckedChanged);
            // 
            // txtPenalty
            // 
            this.txtPenalty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPenalty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPenalty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPenalty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPenalty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txtPenalty.Location = new System.Drawing.Point(236, 79);
            this.txtPenalty.Name = "txtPenalty";
            this.txtPenalty.Size = new System.Drawing.Size(112, 21);
            this.txtPenalty.TabIndex = 20;
            this.txtPenalty.Text = "0";
            this.txtPenalty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPenalty.TextChanged += new System.EventHandler(this.txtPenalty_TextChanged);
            // 
            // txtPresentReading
            // 
            this.txtPresentReading.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPresentReading.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPresentReading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPresentReading.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPresentReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPresentReading.Location = new System.Drawing.Point(172, 53);
            this.txtPresentReading.Name = "txtPresentReading";
            this.txtPresentReading.Size = new System.Drawing.Size(112, 21);
            this.txtPresentReading.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "PRESENT READING : ";
            // 
            // txtConsumption
            // 
            this.txtConsumption.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtConsumption.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtConsumption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConsumption.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConsumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsumption.Location = new System.Drawing.Point(172, 107);
            this.txtConsumption.Name = "txtConsumption";
            this.txtConsumption.Size = new System.Drawing.Size(112, 21);
            this.txtConsumption.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "CONSUMPTION :";
            // 
            // txtActualReading
            // 
            this.txtActualReading.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtActualReading.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtActualReading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActualReading.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtActualReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActualReading.Location = new System.Drawing.Point(172, 80);
            this.txtActualReading.Name = "txtActualReading";
            this.txtActualReading.Size = new System.Drawing.Size(112, 21);
            this.txtActualReading.TabIndex = 12;
            this.txtActualReading.Leave += new System.EventHandler(this.txtActualReading_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "ACTUAL READING : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "PREVIOUS READING : ";
            // 
            // txtPreviousReading
            // 
            this.txtPreviousReading.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPreviousReading.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPreviousReading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPreviousReading.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPreviousReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreviousReading.Location = new System.Drawing.Point(172, 26);
            this.txtPreviousReading.Name = "txtPreviousReading";
            this.txtPreviousReading.Size = new System.Drawing.Size(112, 21);
            this.txtPreviousReading.TabIndex = 6;
            // 
            // gbErrorReading
            // 
            this.gbErrorReading.Controls.Add(this.txtPresentReading);
            this.gbErrorReading.Controls.Add(this.label7);
            this.gbErrorReading.Controls.Add(this.label2);
            this.gbErrorReading.Controls.Add(this.txtPreviousReading);
            this.gbErrorReading.Controls.Add(this.txtConsumption);
            this.gbErrorReading.Controls.Add(this.label5);
            this.gbErrorReading.Controls.Add(this.label6);
            this.gbErrorReading.Controls.Add(this.txtActualReading);
            this.gbErrorReading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbErrorReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gbErrorReading.Location = new System.Drawing.Point(650, 229);
            this.gbErrorReading.Name = "gbErrorReading";
            this.gbErrorReading.Size = new System.Drawing.Size(315, 146);
            this.gbErrorReading.TabIndex = 17;
            this.gbErrorReading.TabStop = false;
            this.gbErrorReading.Text = "ERROR READING";
            // 
            // gbFailedCalibration
            // 
            this.gbFailedCalibration.Controls.Add(this.txtNewAverageCons);
            this.gbFailedCalibration.Controls.Add(this.label16);
            this.gbFailedCalibration.Controls.Add(this.txtLastMonth);
            this.gbFailedCalibration.Controls.Add(this.label15);
            this.gbFailedCalibration.Controls.Add(this.txtLast2Month);
            this.gbFailedCalibration.Controls.Add(this.lblasdasd);
            this.gbFailedCalibration.Controls.Add(this.txtLast3Month);
            this.gbFailedCalibration.Controls.Add(this.label14);
            this.gbFailedCalibration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbFailedCalibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gbFailedCalibration.Location = new System.Drawing.Point(650, 382);
            this.gbFailedCalibration.Name = "gbFailedCalibration";
            this.gbFailedCalibration.Size = new System.Drawing.Size(315, 138);
            this.gbFailedCalibration.TabIndex = 19;
            this.gbFailedCalibration.TabStop = false;
            this.gbFailedCalibration.Text = "FAILED IN CALIBRATION";
            // 
            // txtNewAverageCons
            // 
            this.txtNewAverageCons.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtNewAverageCons.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNewAverageCons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewAverageCons.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNewAverageCons.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewAverageCons.Location = new System.Drawing.Point(172, 107);
            this.txtNewAverageCons.Name = "txtNewAverageCons";
            this.txtNewAverageCons.Size = new System.Drawing.Size(112, 21);
            this.txtNewAverageCons.TabIndex = 20;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(28, 110);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 15);
            this.label16.TabIndex = 19;
            this.label16.Text = "NEW CONS.  :";
            // 
            // txtLastMonth
            // 
            this.txtLastMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtLastMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLastMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastMonth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastMonth.Location = new System.Drawing.Point(172, 80);
            this.txtLastMonth.Name = "txtLastMonth";
            this.txtLastMonth.Size = new System.Drawing.Size(112, 21);
            this.txtLastMonth.TabIndex = 18;
            this.txtLastMonth.Leave += new System.EventHandler(this.txtLastMonth_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(28, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 15);
            this.label15.TabIndex = 17;
            this.label15.Text = "LAST MONTH CONS. : ";
            // 
            // txtLast2Month
            // 
            this.txtLast2Month.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtLast2Month.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLast2Month.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLast2Month.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLast2Month.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLast2Month.Location = new System.Drawing.Point(172, 53);
            this.txtLast2Month.Name = "txtLast2Month";
            this.txtLast2Month.Size = new System.Drawing.Size(112, 21);
            this.txtLast2Month.TabIndex = 16;
            // 
            // lblasdasd
            // 
            this.lblasdasd.AutoSize = true;
            this.lblasdasd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblasdasd.Location = new System.Drawing.Point(28, 55);
            this.lblasdasd.Name = "lblasdasd";
            this.lblasdasd.Size = new System.Drawing.Size(143, 15);
            this.lblasdasd.TabIndex = 15;
            this.lblasdasd.Text = "LAST 2 MONTH CONS. : ";
            // 
            // txtLast3Month
            // 
            this.txtLast3Month.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtLast3Month.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLast3Month.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLast3Month.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLast3Month.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLast3Month.Location = new System.Drawing.Point(172, 26);
            this.txtLast3Month.Name = "txtLast3Month";
            this.txtLast3Month.Size = new System.Drawing.Size(112, 21);
            this.txtLast3Month.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(28, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(143, 15);
            this.label14.TabIndex = 10;
            this.label14.Text = "LAST 3 MONTH CONS. : ";
            // 
            // gbIllegal
            // 
            this.gbIllegal.Controls.Add(this.txtConsAfterDisconnection);
            this.gbIllegal.Controls.Add(this.label17);
            this.gbIllegal.Controls.Add(this.txtConsOnDisconnection);
            this.gbIllegal.Controls.Add(this.label18);
            this.gbIllegal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbIllegal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gbIllegal.Location = new System.Drawing.Point(971, 229);
            this.gbIllegal.Name = "gbIllegal";
            this.gbIllegal.Size = new System.Drawing.Size(315, 86);
            this.gbIllegal.TabIndex = 19;
            this.gbIllegal.TabStop = false;
            this.gbIllegal.Text = "RFB + ILLEGAL";
            // 
            // txtConsAfterDisconnection
            // 
            this.txtConsAfterDisconnection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtConsAfterDisconnection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtConsAfterDisconnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConsAfterDisconnection.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConsAfterDisconnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsAfterDisconnection.Location = new System.Drawing.Point(172, 53);
            this.txtConsAfterDisconnection.Name = "txtConsAfterDisconnection";
            this.txtConsAfterDisconnection.Size = new System.Drawing.Size(112, 21);
            this.txtConsAfterDisconnection.TabIndex = 16;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(28, 55);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(115, 15);
            this.label17.TabIndex = 15;
            this.label17.Text = "CURRENT CONS. : ";
            // 
            // txtConsOnDisconnection
            // 
            this.txtConsOnDisconnection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtConsOnDisconnection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtConsOnDisconnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConsOnDisconnection.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConsOnDisconnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsOnDisconnection.Location = new System.Drawing.Point(172, 26);
            this.txtConsOnDisconnection.Name = "txtConsOnDisconnection";
            this.txtConsOnDisconnection.Size = new System.Drawing.Size(112, 21);
            this.txtConsOnDisconnection.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(28, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(134, 15);
            this.label18.TabIndex = 10;
            this.label18.Text = "CONS. UPON DISCO. : ";
            // 
            // gbLeakingNotVisible
            // 
            this.gbLeakingNotVisible.Controls.Add(this.txtAdjustedConsumption);
            this.gbLeakingNotVisible.Controls.Add(this.label1);
            this.gbLeakingNotVisible.Controls.Add(this.label13);
            this.gbLeakingNotVisible.Controls.Add(this.txtAdjustmentConsumption);
            this.gbLeakingNotVisible.Controls.Add(this.label4);
            this.gbLeakingNotVisible.Controls.Add(this.txtLeakingNotVisCurrentCons);
            this.gbLeakingNotVisible.Controls.Add(this.label8);
            this.gbLeakingNotVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbLeakingNotVisible.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gbLeakingNotVisible.Location = new System.Drawing.Point(12, 159);
            this.gbLeakingNotVisible.Name = "gbLeakingNotVisible";
            this.gbLeakingNotVisible.Size = new System.Drawing.Size(567, 171);
            this.gbLeakingNotVisible.TabIndex = 19;
            this.gbLeakingNotVisible.TabStop = false;
            this.gbLeakingNotVisible.Text = "LEAKING NOT VISIBLE";
            // 
            // txtAdjustedConsumption
            // 
            this.txtAdjustedConsumption.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAdjustedConsumption.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAdjustedConsumption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdjustedConsumption.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAdjustedConsumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdjustedConsumption.Location = new System.Drawing.Point(161, 61);
            this.txtAdjustedConsumption.Name = "txtAdjustedConsumption";
            this.txtAdjustedConsumption.Size = new System.Drawing.Size(112, 21);
            this.txtAdjustedConsumption.TabIndex = 23;
            this.txtAdjustedConsumption.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "ADJUSTED CONS. : ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(276, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(145, 16);
            this.label13.TabIndex = 21;
            this.label13.Text = "*Average Consumption";
            this.label13.Visible = false;
            // 
            // txtAdjustmentConsumption
            // 
            this.txtAdjustmentConsumption.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAdjustmentConsumption.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAdjustmentConsumption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdjustmentConsumption.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAdjustmentConsumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdjustmentConsumption.Location = new System.Drawing.Point(161, 88);
            this.txtAdjustmentConsumption.Name = "txtAdjustmentConsumption";
            this.txtAdjustmentConsumption.Size = new System.Drawing.Size(112, 21);
            this.txtAdjustmentConsumption.TabIndex = 16;
            this.txtAdjustmentConsumption.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "70% ADJUSTMENT : ";
            // 
            // txtLeakingNotVisCurrentCons
            // 
            this.txtLeakingNotVisCurrentCons.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtLeakingNotVisCurrentCons.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLeakingNotVisCurrentCons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeakingNotVisCurrentCons.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLeakingNotVisCurrentCons.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeakingNotVisCurrentCons.Location = new System.Drawing.Point(161, 34);
            this.txtLeakingNotVisCurrentCons.Name = "txtLeakingNotVisCurrentCons";
            this.txtLeakingNotVisCurrentCons.Size = new System.Drawing.Size(112, 21);
            this.txtLeakingNotVisCurrentCons.TabIndex = 6;
            this.txtLeakingNotVisCurrentCons.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "CURRENT CONS. : ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(233, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 15);
            this.label12.TabIndex = 28;
            this.label12.Text = "----------------------------";
            // 
            // frmInvestigationAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 733);
            this.Controls.Add(this.gbErrorReading);
            this.Controls.Add(this.gbLeakingNotVisible);
            this.Controls.Add(this.gbIllegal);
            this.Controls.Add(this.gbFailedCalibration);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInvestigationAdjustment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adjustment Computation";
            this.Load += new System.EventHandler(this.frmInvestigationAdjustment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gbErrorReading.ResumeLayout(false);
            this.gbErrorReading.PerformLayout();
            this.gbFailedCalibration.ResumeLayout(false);
            this.gbFailedCalibration.PerformLayout();
            this.gbIllegal.ResumeLayout(false);
            this.gbIllegal.PerformLayout();
            this.gbLeakingNotVisible.ResumeLayout(false);
            this.gbLeakingNotVisible.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbxParticular;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox5;
        internal System.Windows.Forms.TextBox txtConsumption;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtActualReading;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtPreviousReading;
        internal System.Windows.Forms.TextBox txtPresentReading;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbxExtensionFee;
        private System.Windows.Forms.CheckBox cbxPenalty;
        private System.Windows.Forms.GroupBox gbErrorReading;
        private System.Windows.Forms.GroupBox gbFailedCalibration;
        internal System.Windows.Forms.TextBox txtLast2Month;
        private System.Windows.Forms.Label lblasdasd;
        internal System.Windows.Forms.TextBox txtLast3Month;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox txtLastMonth;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.TextBox txtNewAverageCons;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox gbIllegal;
        internal System.Windows.Forms.TextBox txtConsAfterDisconnection;
        private System.Windows.Forms.Label label17;
        internal System.Windows.Forms.TextBox txtConsOnDisconnection;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox gbLeakingNotVisible;
        internal System.Windows.Forms.TextBox txtAdjustmentConsumption;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtLeakingNotVisCurrentCons;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.TextBox txtPenalty;
        internal System.Windows.Forms.TextBox txtExtensionFee;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtAmountDue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        internal System.Windows.Forms.TextBox txtAccountNumber;
        internal System.Windows.Forms.TextBox txtAccountName;
        internal System.Windows.Forms.TextBox txtAccountType;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.TextBox txtAmountDueAfterAdjustment;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox txtAdjustedConsumption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
    }
}