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
            this.components = new System.ComponentModel.Container();
            this.cmbxParticular = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnAddOtherFees = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAdjustmentNote = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOtherFeesAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNewOtherFees = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOtherFessDescription = new System.Windows.Forms.TextBox();
            this.txtAdjustedAmount = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtAdjustment = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtWaterBill = new System.Windows.Forms.TextBox();
            this.dgOtherFees = new System.Windows.Forms.DataGridView();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewOtherFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOtherFees)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.cmbxParticular.Location = new System.Drawing.Point(166, 20);
            this.cmbxParticular.Name = "cmbxParticular";
            this.cmbxParticular.Size = new System.Drawing.Size(307, 23);
            this.cmbxParticular.TabIndex = 0;
            this.cmbxParticular.SelectedIndexChanged += new System.EventHandler(this.cmbxParticular_SelectedIndexChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(14, 20);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(92, 15);
            this.label24.TabIndex = 9;
            this.label24.Text = "* PARTICULAR ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.btnCancel);
            this.groupBox4.Controls.Add(this.btnSave);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox4.Location = new System.Drawing.Point(12, 476);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(493, 57);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label19.Location = new System.Drawing.Point(6, 17);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(272, 15);
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
            this.btnCancel.Location = new System.Drawing.Point(398, 19);
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
            this.btnSave.Location = new System.Drawing.Point(301, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnAddOtherFees);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txtAdjustmentNote);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtOtherFeesAmount);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.btnNewOtherFees);
            this.groupBox5.Controls.Add(this.cmbxParticular);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.txtOtherFessDescription);
            this.groupBox5.Controls.Add(this.txtAdjustedAmount);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.txtAdjustment);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.txtWaterBill);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(493, 261);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            // 
            // btnAddOtherFees
            // 
            this.btnAddOtherFees.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddOtherFees.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddOtherFees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOtherFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOtherFees.ForeColor = System.Drawing.Color.White;
            this.btnAddOtherFees.Location = new System.Drawing.Point(426, 184);
            this.btnAddOtherFees.Name = "btnAddOtherFees";
            this.btnAddOtherFees.Size = new System.Drawing.Size(47, 23);
            this.btnAddOtherFees.TabIndex = 39;
            this.btnAddOtherFees.Text = "Add";
            this.btnAddOtherFees.UseVisualStyleBackColor = false;
            this.btnAddOtherFees.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 15);
            this.label5.TabIndex = 38;
            this.label5.Text = "NOTES / REMARKS ";
            // 
            // txtAdjustmentNote
            // 
            this.txtAdjustmentNote.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAdjustmentNote.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAdjustmentNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdjustmentNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtAdjustmentNote.ForeColor = System.Drawing.Color.Black;
            this.txtAdjustmentNote.Location = new System.Drawing.Point(166, 213);
            this.txtAdjustmentNote.Multiline = true;
            this.txtAdjustmentNote.Name = "txtAdjustmentNote";
            this.txtAdjustmentNote.Size = new System.Drawing.Size(307, 42);
            this.txtAdjustmentNote.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(325, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 36;
            this.label4.Text = "Amount";
            // 
            // txtOtherFeesAmount
            // 
            this.txtOtherFeesAmount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtOtherFeesAmount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtOtherFeesAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOtherFeesAmount.Enabled = false;
            this.txtOtherFeesAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherFeesAmount.ForeColor = System.Drawing.Color.Black;
            this.txtOtherFeesAmount.Location = new System.Drawing.Point(327, 185);
            this.txtOtherFeesAmount.Name = "txtOtherFeesAmount";
            this.txtOtherFeesAmount.Size = new System.Drawing.Size(93, 22);
            this.txtOtherFeesAmount.TabIndex = 35;
            this.txtOtherFeesAmount.Text = "0";
            this.txtOtherFeesAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(163, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "Description";
            // 
            // btnNewOtherFees
            // 
            this.btnNewOtherFees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewOtherFees.Image = global::JOMonitoringApp.Properties.Resources.icons8_plus_50;
            this.btnNewOtherFees.Location = new System.Drawing.Point(139, 184);
            this.btnNewOtherFees.Name = "btnNewOtherFees";
            this.btnNewOtherFees.Size = new System.Drawing.Size(24, 21);
            this.btnNewOtherFees.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNewOtherFees.TabIndex = 33;
            this.btnNewOtherFees.TabStop = false;
            this.btnNewOtherFees.Click += new System.EventHandler(this.btnNewOtherFees_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 31;
            this.label1.Text = "OTHER FEES";
            // 
            // txtOtherFessDescription
            // 
            this.txtOtherFessDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtOtherFessDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtOtherFessDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOtherFessDescription.Enabled = false;
            this.txtOtherFessDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherFessDescription.ForeColor = System.Drawing.Color.Black;
            this.txtOtherFessDescription.Location = new System.Drawing.Point(166, 185);
            this.txtOtherFessDescription.Name = "txtOtherFessDescription";
            this.txtOtherFessDescription.Size = new System.Drawing.Size(156, 22);
            this.txtOtherFessDescription.TabIndex = 30;
            // 
            // txtAdjustedAmount
            // 
            this.txtAdjustedAmount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAdjustedAmount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAdjustedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdjustedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAdjustedAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdjustedAmount.ForeColor = System.Drawing.Color.Black;
            this.txtAdjustedAmount.Location = new System.Drawing.Point(166, 87);
            this.txtAdjustedAmount.Name = "txtAdjustedAmount";
            this.txtAdjustedAmount.Size = new System.Drawing.Size(307, 29);
            this.txtAdjustedAmount.TabIndex = 1;
            this.txtAdjustedAmount.Text = "0";
            this.txtAdjustedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(14, 93);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(133, 15);
            this.label23.TabIndex = 29;
            this.label23.Text = "* ADJUSTED AMOUNT";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(14, 130);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(96, 15);
            this.label22.TabIndex = 26;
            this.label22.Text = "* ADJUSTMENT";
            // 
            // txtAdjustment
            // 
            this.txtAdjustment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAdjustment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAdjustment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdjustment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAdjustment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdjustment.ForeColor = System.Drawing.Color.Black;
            this.txtAdjustment.Location = new System.Drawing.Point(166, 124);
            this.txtAdjustment.Name = "txtAdjustment";
            this.txtAdjustment.Size = new System.Drawing.Size(307, 29);
            this.txtAdjustment.TabIndex = 5;
            this.txtAdjustment.Text = "0";
            this.txtAdjustment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "* WATER BILL";
            // 
            // txtWaterBill
            // 
            this.txtWaterBill.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtWaterBill.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtWaterBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWaterBill.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWaterBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWaterBill.ForeColor = System.Drawing.Color.Black;
            this.txtWaterBill.Location = new System.Drawing.Point(166, 50);
            this.txtWaterBill.Name = "txtWaterBill";
            this.txtWaterBill.Size = new System.Drawing.Size(307, 29);
            this.txtWaterBill.TabIndex = 0;
            this.txtWaterBill.Text = "0";
            this.txtWaterBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgOtherFees
            // 
            this.dgOtherFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOtherFees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.description,
            this.amount});
            this.dgOtherFees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgOtherFees.Location = new System.Drawing.Point(5, 18);
            this.dgOtherFees.Name = "dgOtherFees";
            this.dgOtherFees.Size = new System.Drawing.Size(483, 135);
            this.dgOtherFees.TabIndex = 21;
            this.dgOtherFees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOtherFees_CellContentClick);
            this.dgOtherFees.SelectionChanged += new System.EventHandler(this.dgOtherFees_SelectionChanged);
            // 
            // description
            // 
            this.description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            // 
            // amount
            // 
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgOtherFees);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(12, 282);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(493, 188);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "OTHER FEES";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 30);
            this.panel1.TabIndex = 22;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.White;
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRemove.Enabled = false;
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRemove.Location = new System.Drawing.Point(0, 7);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(483, 23);
            this.btnRemove.TabIndex = 42;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click_1);
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmInvestigationAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 541);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInvestigationAdjustment";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adjustment Form";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmInvestigationAdjustment_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewOtherFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOtherFees)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbxParticular;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtWaterBill;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.TextBox txtAdjustment;
        internal System.Windows.Forms.TextBox txtAdjustedAmount;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridView dgOtherFees;
        private System.Windows.Forms.GroupBox groupBox2;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtOtherFessDescription;
        private System.Windows.Forms.PictureBox btnNewOtherFees;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtOtherFeesAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtAdjustmentNote;
        private System.Windows.Forms.Button btnAddOtherFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRemove;
    }
}