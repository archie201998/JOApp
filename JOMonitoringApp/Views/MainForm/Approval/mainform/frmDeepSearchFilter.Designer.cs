namespace JOMonitoringApp.Views.MainForm
{
    partial class frmDeepSearchFilter
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
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxPreparedBy = new System.Windows.Forms.ComboBox();
            this.chbxJoWithRemarks = new System.Windows.Forms.CheckBox();
            this.cmbxAccomplishedBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(12, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "DATE FROM ";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(140, 21);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(138, 21);
            this.dtpDateFrom.TabIndex = 24;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(287, 21);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(138, 21);
            this.dtpDateTo.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 27;
            this.label1.Text = "PREPARED BY ";
            // 
            // cmbxPreparedBy
            // 
            this.cmbxPreparedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxPreparedBy.FormattingEnabled = true;
            this.cmbxPreparedBy.Location = new System.Drawing.Point(140, 48);
            this.cmbxPreparedBy.Name = "cmbxPreparedBy";
            this.cmbxPreparedBy.Size = new System.Drawing.Size(285, 21);
            this.cmbxPreparedBy.TabIndex = 28;
            // 
            // chbxJoWithRemarks
            // 
            this.chbxJoWithRemarks.AutoSize = true;
            this.chbxJoWithRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.chbxJoWithRemarks.Location = new System.Drawing.Point(285, 102);
            this.chbxJoWithRemarks.Name = "chbxJoWithRemarks";
            this.chbxJoWithRemarks.Size = new System.Drawing.Size(140, 19);
            this.chbxJoWithRemarks.TabIndex = 29;
            this.chbxJoWithRemarks.Text = "J.O WITH REMARKS";
            this.chbxJoWithRemarks.UseVisualStyleBackColor = true;
            // 
            // cmbxAccomplishedBy
            // 
            this.cmbxAccomplishedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxAccomplishedBy.FormattingEnabled = true;
            this.cmbxAccomplishedBy.Location = new System.Drawing.Point(140, 75);
            this.cmbxAccomplishedBy.Name = "cmbxAccomplishedBy";
            this.cmbxAccomplishedBy.Size = new System.Drawing.Size(285, 21);
            this.cmbxAccomplishedBy.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "ACCOMPLISHED BY ";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancel.Location = new System.Drawing.Point(335, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 32);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Cancel ";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(238, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 32);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "Search";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmDeepSearchFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 174);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbxAccomplishedBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chbxJoWithRemarks);
            this.Controls.Add(this.cmbxPreparedBy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDateTo);
            this.Controls.Add(this.dtpDateFrom);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeepSearchFilter";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Job Orders > Deep Search Parameters";
            this.Load += new System.EventHandler(this.frmDeepSearchFilter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbxPreparedBy;
        private System.Windows.Forms.CheckBox chbxJoWithRemarks;
        private System.Windows.Forms.ComboBox cmbxAccomplishedBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}