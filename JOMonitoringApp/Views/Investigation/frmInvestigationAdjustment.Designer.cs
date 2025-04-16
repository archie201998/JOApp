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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblAccountNumber = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAdjustedAmount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPreviousReading = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtActualReading = new System.Windows.Forms.TextBox();
            this.txtConsumption = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPresentReading = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbxPenalty = new System.Windows.Forms.CheckBox();
            this.cbxExtensionFee = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbxParticular
            // 
            this.cmbxParticular.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxParticular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbxParticular.FormattingEnabled = true;
            this.cmbxParticular.Items.AddRange(new object[] {
            "Leaking",
            "Leaking (Not Visible)",
            "Failed Calibration",
            "Erroneous Reading",
            "RFB + Illegal"});
            this.cmbxParticular.Location = new System.Drawing.Point(158, 20);
            this.cmbxParticular.Name = "cmbxParticular";
            this.cmbxParticular.Size = new System.Drawing.Size(204, 23);
            this.cmbxParticular.TabIndex = 0;
            this.cmbxParticular.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
            this.groupBox1.Size = new System.Drawing.Size(388, 53);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox2.Location = new System.Drawing.Point(12, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 181);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
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
            this.groupBox3.Size = new System.Drawing.Size(388, 52);
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
            this.groupBox4.Location = new System.Drawing.Point(12, 368);
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
            this.btnCancel.Location = new System.Drawing.Point(295, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel [Esc]";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnSave.Location = new System.Drawing.Point(137, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 32);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save [Control + S]";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblAdjustedAmount);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox5.Location = new System.Drawing.Point(12, 316);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(388, 46);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "ADJUSTED AMOUNT : ";
            // 
            // lblAdjustedAmount
            // 
            this.lblAdjustedAmount.AutoSize = true;
            this.lblAdjustedAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdjustedAmount.Location = new System.Drawing.Point(155, 17);
            this.lblAdjustedAmount.Name = "lblAdjustedAmount";
            this.lblAdjustedAmount.Size = new System.Drawing.Size(38, 15);
            this.lblAdjustedAmount.TabIndex = 11;
            this.lblAdjustedAmount.Text = "00.00";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPresentReading);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtConsumption);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtActualReading);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtPreviousReading);
            this.panel1.Location = new System.Drawing.Point(456, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 124);
            this.panel1.TabIndex = 14;
            // 
            // txtPreviousReading
            // 
            this.txtPreviousReading.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPreviousReading.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPreviousReading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPreviousReading.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPreviousReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreviousReading.Location = new System.Drawing.Point(152, 11);
            this.txtPreviousReading.Name = "txtPreviousReading";
            this.txtPreviousReading.Size = new System.Drawing.Size(112, 21);
            this.txtPreviousReading.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "PREVIOUS READING : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "ACTUAL READING : ";
            // 
            // txtActualReading
            // 
            this.txtActualReading.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtActualReading.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtActualReading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActualReading.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtActualReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActualReading.Location = new System.Drawing.Point(152, 65);
            this.txtActualReading.Name = "txtActualReading";
            this.txtActualReading.Size = new System.Drawing.Size(112, 21);
            this.txtActualReading.TabIndex = 12;
            this.txtActualReading.TextChanged += new System.EventHandler(this.txtActualReading_TextChanged);
            // 
            // txtConsumption
            // 
            this.txtConsumption.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtConsumption.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtConsumption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConsumption.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConsumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsumption.Location = new System.Drawing.Point(152, 92);
            this.txtConsumption.Name = "txtConsumption";
            this.txtConsumption.Size = new System.Drawing.Size(112, 21);
            this.txtConsumption.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "CONSUMPTION :";
            // 
            // txtPresentReading
            // 
            this.txtPresentReading.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPresentReading.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPresentReading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPresentReading.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPresentReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPresentReading.Location = new System.Drawing.Point(152, 38);
            this.txtPresentReading.Name = "txtPresentReading";
            this.txtPresentReading.Size = new System.Drawing.Size(112, 21);
            this.txtPresentReading.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "PRESENT READING : ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbxExtensionFee);
            this.panel2.Controls.Add(this.cbxPenalty);
            this.panel2.Location = new System.Drawing.Point(456, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 37);
            this.panel2.TabIndex = 15;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // cbxPenalty
            // 
            this.cbxPenalty.AutoSize = true;
            this.cbxPenalty.Location = new System.Drawing.Point(17, 9);
            this.cbxPenalty.Name = "cbxPenalty";
            this.cbxPenalty.Size = new System.Drawing.Size(75, 17);
            this.cbxPenalty.TabIndex = 17;
            this.cbxPenalty.Text = "PENALTY";
            this.cbxPenalty.UseVisualStyleBackColor = true;
            this.cbxPenalty.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cbxExtensionFee
            // 
            this.cbxExtensionFee.AutoSize = true;
            this.cbxExtensionFee.Location = new System.Drawing.Point(98, 9);
            this.cbxExtensionFee.Name = "cbxExtensionFee";
            this.cbxExtensionFee.Size = new System.Drawing.Size(111, 17);
            this.cbxExtensionFee.TabIndex = 17;
            this.cbxExtensionFee.Text = "EXNTESION FEE";
            this.cbxExtensionFee.UseVisualStyleBackColor = true;
            this.cbxExtensionFee.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // frmInvestigationAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 433);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInvestigationAdjustment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Computation";
            this.Load += new System.EventHandler(this.frmInvestigationAdjustment_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInvestigationAdjustment_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbxParticular;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblAccountNumber;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAdjustedAmount;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.TextBox txtConsumption;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtActualReading;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtPreviousReading;
        internal System.Windows.Forms.TextBox txtPresentReading;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cbxExtensionFee;
        private System.Windows.Forms.CheckBox cbxPenalty;
    }
}