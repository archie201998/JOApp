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
            this.lblAccountNumber = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbxExtensionFee = new System.Windows.Forms.CheckBox();
            this.cbxPenalty = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAdjustedAmount = new System.Windows.Forms.TextBox();
            this.txtPresentReading = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConsumption = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtActualReading = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPreviousReading = new System.Windows.Forms.TextBox();
            this.gbErrorReading = new System.Windows.Forms.GroupBox();
            this.gbLeakingVisible = new System.Windows.Forms.GroupBox();
            this.txtLeakingCorrectCons = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLeakingCurrentCons = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
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
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.gbLeakingNotVisible = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gbErrorReading.SuspendLayout();
            this.gbLeakingVisible.SuspendLayout();
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
            "Leaking",
            "Leaking (Not Visible)",
            "Failed Calibration",
            "Erroneous Reading",
            "RFB + Illegal"});
            this.cmbxParticular.Location = new System.Drawing.Point(158, 20);
            this.cmbxParticular.Name = "cmbxParticular";
            this.cmbxParticular.Size = new System.Drawing.Size(204, 23);
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
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox1.Location = new System.Drawing.Point(12, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 53);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.AutoSize = true;
            this.lblAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountNumber.Location = new System.Drawing.Point(155, 20);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Size = new System.Drawing.Size(89, 15);
            this.lblAccountNumber.TabIndex = 12;
            this.lblAccountNumber.Text = "000-000-000-0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblAccountNumber);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(391, 52);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "ACCOUNT NUMBER :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCancel);
            this.groupBox4.Controls.Add(this.btnSave);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox4.Location = new System.Drawing.Point(12, 422);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(391, 59);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancel.Location = new System.Drawing.Point(269, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel ";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(172, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 32);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbxExtensionFee);
            this.groupBox5.Controls.Add(this.cbxPenalty);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.lblAdjustedAmount);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox5.Location = new System.Drawing.Point(12, 294);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(391, 122);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            // 
            // cbxExtensionFee
            // 
            this.cbxExtensionFee.AutoSize = true;
            this.cbxExtensionFee.Location = new System.Drawing.Point(172, 42);
            this.cbxExtensionFee.Name = "cbxExtensionFee";
            this.cbxExtensionFee.Size = new System.Drawing.Size(121, 19);
            this.cbxExtensionFee.TabIndex = 17;
            this.cbxExtensionFee.Text = "EXTENSION FEE";
            this.cbxExtensionFee.UseVisualStyleBackColor = true;
            // 
            // cbxPenalty
            // 
            this.cbxPenalty.AutoSize = true;
            this.cbxPenalty.Location = new System.Drawing.Point(172, 20);
            this.cbxPenalty.Name = "cbxPenalty";
            this.cbxPenalty.Size = new System.Drawing.Size(79, 19);
            this.cbxPenalty.TabIndex = 17;
            this.cbxPenalty.Text = "PENALTY";
            this.cbxPenalty.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.OrangeRed;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(172, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 27);
            this.button1.TabIndex = 20;
            this.button1.Text = "Compute Now";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "ADJUSTED AMOUNT : ";
            // 
            // lblAdjustedAmount
            // 
            this.lblAdjustedAmount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.lblAdjustedAmount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.lblAdjustedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAdjustedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lblAdjustedAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAdjustedAmount.ForeColor = System.Drawing.Color.Red;
            this.lblAdjustedAmount.Location = new System.Drawing.Point(172, 96);
            this.lblAdjustedAmount.Name = "lblAdjustedAmount";
            this.lblAdjustedAmount.Size = new System.Drawing.Size(117, 21);
            this.lblAdjustedAmount.TabIndex = 21;
            this.lblAdjustedAmount.Text = "0";
            this.lblAdjustedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.gbErrorReading.Location = new System.Drawing.Point(441, 19);
            this.gbErrorReading.Name = "gbErrorReading";
            this.gbErrorReading.Size = new System.Drawing.Size(315, 146);
            this.gbErrorReading.TabIndex = 17;
            this.gbErrorReading.TabStop = false;
            this.gbErrorReading.Text = "ERROR READING";
            // 
            // gbLeakingVisible
            // 
            this.gbLeakingVisible.Controls.Add(this.txtLeakingCorrectCons);
            this.gbLeakingVisible.Controls.Add(this.label12);
            this.gbLeakingVisible.Controls.Add(this.txtLeakingCurrentCons);
            this.gbLeakingVisible.Controls.Add(this.label13);
            this.gbLeakingVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbLeakingVisible.Location = new System.Drawing.Point(12, 129);
            this.gbLeakingVisible.Name = "gbLeakingVisible";
            this.gbLeakingVisible.Size = new System.Drawing.Size(315, 86);
            this.gbLeakingVisible.TabIndex = 18;
            this.gbLeakingVisible.TabStop = false;
            this.gbLeakingVisible.Text = "LEAKING VISIBLE";
            // 
            // txtLeakingCorrectCons
            // 
            this.txtLeakingCorrectCons.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtLeakingCorrectCons.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLeakingCorrectCons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeakingCorrectCons.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLeakingCorrectCons.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeakingCorrectCons.Location = new System.Drawing.Point(172, 53);
            this.txtLeakingCorrectCons.Name = "txtLeakingCorrectCons";
            this.txtLeakingCorrectCons.Size = new System.Drawing.Size(112, 21);
            this.txtLeakingCorrectCons.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(28, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 15);
            this.label12.TabIndex = 15;
            this.label12.Text = "CORRECT CONS. :";
            // 
            // txtLeakingCurrentCons
            // 
            this.txtLeakingCurrentCons.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtLeakingCurrentCons.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLeakingCurrentCons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeakingCurrentCons.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLeakingCurrentCons.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeakingCurrentCons.Location = new System.Drawing.Point(172, 26);
            this.txtLeakingCurrentCons.Name = "txtLeakingCurrentCons";
            this.txtLeakingCurrentCons.Size = new System.Drawing.Size(112, 21);
            this.txtLeakingCurrentCons.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(28, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 15);
            this.label13.TabIndex = 10;
            this.label13.Text = "CURRENT CONS. : ";
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
            this.gbFailedCalibration.Location = new System.Drawing.Point(441, 278);
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
            this.gbIllegal.Controls.Add(this.textBox11);
            this.gbIllegal.Controls.Add(this.label17);
            this.gbIllegal.Controls.Add(this.textBox12);
            this.gbIllegal.Controls.Add(this.label18);
            this.gbIllegal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbIllegal.Location = new System.Drawing.Point(762, 19);
            this.gbIllegal.Name = "gbIllegal";
            this.gbIllegal.Size = new System.Drawing.Size(315, 86);
            this.gbIllegal.TabIndex = 19;
            this.gbIllegal.TabStop = false;
            this.gbIllegal.Text = "RFB + ILLEGAL";
            // 
            // textBox11
            // 
            this.textBox11.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox11.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox11.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(172, 53);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(112, 21);
            this.textBox11.TabIndex = 16;
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
            // textBox12
            // 
            this.textBox12.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox12.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox12.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.Location = new System.Drawing.Point(172, 26);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(112, 21);
            this.textBox12.TabIndex = 6;
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
            this.gbLeakingNotVisible.Controls.Add(this.textBox1);
            this.gbLeakingNotVisible.Controls.Add(this.label4);
            this.gbLeakingNotVisible.Controls.Add(this.textBox2);
            this.gbLeakingNotVisible.Controls.Add(this.label8);
            this.gbLeakingNotVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbLeakingNotVisible.Location = new System.Drawing.Point(762, 186);
            this.gbLeakingNotVisible.Name = "gbLeakingNotVisible";
            this.gbLeakingNotVisible.Size = new System.Drawing.Size(315, 86);
            this.gbLeakingNotVisible.TabIndex = 19;
            this.gbLeakingNotVisible.TabStop = false;
            this.gbLeakingNotVisible.Text = "LEAKING NOT VISIBLE";
            // 
            // textBox1
            // 
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(172, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(112, 21);
            this.textBox1.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "NEW CONS.";
            // 
            // textBox2
            // 
            this.textBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(172, 26);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 21);
            this.textBox2.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "CURRENT CONS. : ";
            // 
            // frmInvestigationAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 493);
            this.Controls.Add(this.gbLeakingVisible);
            this.Controls.Add(this.gbErrorReading);
            this.Controls.Add(this.gbLeakingNotVisible);
            this.Controls.Add(this.gbIllegal);
            this.Controls.Add(this.gbFailedCalibration);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gbErrorReading.ResumeLayout(false);
            this.gbErrorReading.PerformLayout();
            this.gbLeakingVisible.ResumeLayout(false);
            this.gbLeakingVisible.PerformLayout();
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
        private System.Windows.Forms.Label lblAccountNumber;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.GroupBox gbLeakingVisible;
        internal System.Windows.Forms.TextBox txtLeakingCorrectCons;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox txtLeakingCurrentCons;
        private System.Windows.Forms.Label label13;
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
        internal System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label17;
        internal System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox gbLeakingNotVisible;
        internal System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox lblAdjustedAmount;
        private System.Windows.Forms.Button button1;
    }
}