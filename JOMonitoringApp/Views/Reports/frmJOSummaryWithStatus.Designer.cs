namespace JOMonitoringApp.Views.Reports
{
    partial class frmJOSummaryWithStatus
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radParticulars = new System.Windows.Forms.RadioButton();
            this.radJOR = new System.Windows.Forms.RadioButton();
            this.radDate = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEndingDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStartingDate = new System.Windows.Forms.DateTimePicker();
            this.gbxParticularStatus = new System.Windows.Forms.GroupBox();
            this.cmbxParticular = new System.Windows.Forms.ComboBox();
            this.cbxPending = new System.Windows.Forms.CheckBox();
            this.cbxProcessing = new System.Windows.Forms.CheckBox();
            this.cbxAccomplished = new System.Windows.Forms.CheckBox();
            this.cbxCancelled = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbxParticularStatus.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.gbxParticularStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1743, 112);
            this.panel1.TabIndex = 13;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::JOMonitoringApp.Properties.Resources.icons8_create_16;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(758, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 97);
            this.btnSearch.TabIndex = 32;
            this.btnSearch.Text = "Generate";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radParticulars);
            this.groupBox3.Controls.Add(this.radJOR);
            this.groupBox3.Controls.Add(this.radDate);
            this.groupBox3.Location = new System.Drawing.Point(597, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(155, 104);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Order Results by";
            // 
            // radParticulars
            // 
            this.radParticulars.AutoSize = true;
            this.radParticulars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radParticulars.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.radParticulars.Location = new System.Drawing.Point(21, 70);
            this.radParticulars.Name = "radParticulars";
            this.radParticulars.Size = new System.Drawing.Size(122, 17);
            this.radParticulars.TabIndex = 18;
            this.radParticulars.Tag = "particular";
            this.radParticulars.Text = "Job Order Particulars";
            this.radParticulars.UseVisualStyleBackColor = true;
            // 
            // radJOR
            // 
            this.radJOR.AutoSize = true;
            this.radJOR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radJOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.radJOR.Location = new System.Drawing.Point(21, 47);
            this.radJOR.Name = "radJOR";
            this.radJOR.Size = new System.Drawing.Size(110, 17);
            this.radJOR.TabIndex = 17;
            this.radJOR.Tag = "job_order_order";
            this.radJOR.Text = "Job Order Number";
            this.radJOR.UseVisualStyleBackColor = true;
            // 
            // radDate
            // 
            this.radDate.AutoSize = true;
            this.radDate.Checked = true;
            this.radDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.radDate.Location = new System.Drawing.Point(21, 24);
            this.radDate.Name = "radDate";
            this.radDate.Size = new System.Drawing.Size(87, 17);
            this.radDate.TabIndex = 17;
            this.radDate.TabStop = true;
            this.radDate.Tag = "date";
            this.radDate.Text = "Date Created";
            this.radDate.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpEndingDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpStartingDate);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 104);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date Range";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Ending";
            // 
            // dtpEndingDate
            // 
            this.dtpEndingDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndingDate.CustomFormat = "";
            this.dtpEndingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndingDate.Location = new System.Drawing.Point(76, 59);
            this.dtpEndingDate.Name = "dtpEndingDate";
            this.dtpEndingDate.Size = new System.Drawing.Size(164, 22);
            this.dtpEndingDate.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Starting";
            // 
            // dtpStartingDate
            // 
            this.dtpStartingDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartingDate.CustomFormat = "";
            this.dtpStartingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartingDate.Location = new System.Drawing.Point(76, 31);
            this.dtpStartingDate.Name = "dtpStartingDate";
            this.dtpStartingDate.Size = new System.Drawing.Size(164, 22);
            this.dtpStartingDate.TabIndex = 29;
            // 
            // gbxParticularStatus
            // 
            this.gbxParticularStatus.Controls.Add(this.cmbxParticular);
            this.gbxParticularStatus.Controls.Add(this.cbxPending);
            this.gbxParticularStatus.Controls.Add(this.cbxProcessing);
            this.gbxParticularStatus.Controls.Add(this.cbxAccomplished);
            this.gbxParticularStatus.Controls.Add(this.cbxCancelled);
            this.gbxParticularStatus.Location = new System.Drawing.Point(269, 3);
            this.gbxParticularStatus.Name = "gbxParticularStatus";
            this.gbxParticularStatus.Size = new System.Drawing.Size(322, 104);
            this.gbxParticularStatus.TabIndex = 15;
            this.gbxParticularStatus.TabStop = false;
            this.gbxParticularStatus.Text = "Job Order Particulars and Status";
            // 
            // cmbxParticular
            // 
            this.cmbxParticular.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxParticular.FormattingEnabled = true;
            this.cmbxParticular.Location = new System.Drawing.Point(18, 23);
            this.cmbxParticular.Name = "cmbxParticular";
            this.cmbxParticular.Size = new System.Drawing.Size(286, 21);
            this.cmbxParticular.TabIndex = 19;
            this.cmbxParticular.SelectedIndexChanged += new System.EventHandler(this.cmbxParticular_SelectedIndexChanged);
            // 
            // cbxPending
            // 
            this.cbxPending.AutoSize = true;
            this.cbxPending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cbxPending.Location = new System.Drawing.Point(37, 50);
            this.cbxPending.Name = "cbxPending";
            this.cbxPending.Size = new System.Drawing.Size(62, 17);
            this.cbxPending.TabIndex = 24;
            this.cbxPending.Text = "Pending";
            this.cbxPending.UseVisualStyleBackColor = true;
            // 
            // cbxProcessing
            // 
            this.cbxProcessing.AutoSize = true;
            this.cbxProcessing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cbxProcessing.Location = new System.Drawing.Point(37, 75);
            this.cbxProcessing.Name = "cbxProcessing";
            this.cbxProcessing.Size = new System.Drawing.Size(75, 17);
            this.cbxProcessing.TabIndex = 25;
            this.cbxProcessing.Text = "Processing";
            this.cbxProcessing.UseVisualStyleBackColor = true;
            // 
            // cbxAccomplished
            // 
            this.cbxAccomplished.AutoSize = true;
            this.cbxAccomplished.Checked = true;
            this.cbxAccomplished.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAccomplished.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxAccomplished.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cbxAccomplished.Location = new System.Drawing.Point(156, 75);
            this.cbxAccomplished.Name = "cbxAccomplished";
            this.cbxAccomplished.Size = new System.Drawing.Size(89, 17);
            this.cbxAccomplished.TabIndex = 27;
            this.cbxAccomplished.Text = "Accomplished";
            this.cbxAccomplished.UseVisualStyleBackColor = true;
            // 
            // cbxCancelled
            // 
            this.cbxCancelled.AutoSize = true;
            this.cbxCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCancelled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cbxCancelled.Location = new System.Drawing.Point(156, 50);
            this.cbxCancelled.Name = "cbxCancelled";
            this.cbxCancelled.Size = new System.Drawing.Size(70, 17);
            this.cbxCancelled.TabIndex = 26;
            this.cbxCancelled.Text = "Cancelled";
            this.cbxCancelled.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.reportViewer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 112);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(1743, 658);
            this.panel2.TabIndex = 14;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1737, 652);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmJOSummaryWithStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1743, 770);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmJOSummaryWithStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmJOSummaryWithStatus";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmJOSummaryWithStatus_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbxParticularStatus.ResumeLayout(false);
            this.gbxParticularStatus.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpStartingDate;
        protected System.Windows.Forms.CheckBox cbxAccomplished;
        protected System.Windows.Forms.CheckBox cbxCancelled;
        protected System.Windows.Forms.CheckBox cbxProcessing;
        private System.Windows.Forms.CheckBox cbxPending;
        private System.Windows.Forms.RadioButton radDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpEndingDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbxParticularStatus;
        private System.Windows.Forms.ComboBox cmbxParticular;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radJOR;
        private System.Windows.Forms.RadioButton radParticulars;
        private System.Windows.Forms.Panel panel2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}