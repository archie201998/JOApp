namespace JOMonitoringApp.Views.Reports
{
    partial class frmJOStatusSummary
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxAccomplished = new System.Windows.Forms.CheckBox();
            this.cbxCancelled = new System.Windows.Forms.CheckBox();
            this.cbxProcessing = new System.Windows.Forms.CheckBox();
            this.cbxPending = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.radDate = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.radJo = new System.Windows.Forms.RadioButton();
            this.cmbxParticular = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRecordsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(10, 41);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(1709, 9);
            this.panel2.TabIndex = 9;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(3, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1703, 3);
            this.progressBar1.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtpTo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpFrom);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbxAccomplished);
            this.panel1.Controls.Add(this.cbxCancelled);
            this.panel1.Controls.Add(this.cbxProcessing);
            this.panel1.Controls.Add(this.cbxPending);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.radDate);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.radJo);
            this.panel1.Controls.Add(this.cmbxParticular);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1709, 31);
            this.panel1.TabIndex = 12;
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
            this.btnSearch.Location = new System.Drawing.Point(1518, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 23);
            this.btnSearch.TabIndex = 32;
            this.btnSearch.Text = "Generate";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.CustomFormat = "MMMM dd, yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(256, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(164, 22);
            this.dtpTo.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(228, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "TO";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.CustomFormat = "MMMM dd, yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(50, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(164, 22);
            this.dtpFrom.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(5, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "FROM";
            // 
            // cbxAccomplished
            // 
            this.cbxAccomplished.AutoSize = true;
            this.cbxAccomplished.Checked = true;
            this.cbxAccomplished.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAccomplished.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxAccomplished.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAccomplished.Location = new System.Drawing.Point(1132, 5);
            this.cbxAccomplished.Name = "cbxAccomplished";
            this.cbxAccomplished.Size = new System.Drawing.Size(118, 19);
            this.cbxAccomplished.TabIndex = 27;
            this.cbxAccomplished.Text = "ACCOMPLISHED";
            this.cbxAccomplished.UseVisualStyleBackColor = true;
            this.cbxAccomplished.CheckedChanged += new System.EventHandler(this.cb1_CheckedChanged);
            // 
            // cbxCancelled
            // 
            this.cbxCancelled.AutoSize = true;
            this.cbxCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCancelled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCancelled.Location = new System.Drawing.Point(1032, 5);
            this.cbxCancelled.Name = "cbxCancelled";
            this.cbxCancelled.Size = new System.Drawing.Size(94, 19);
            this.cbxCancelled.TabIndex = 26;
            this.cbxCancelled.Text = "CANCELLED";
            this.cbxCancelled.UseVisualStyleBackColor = true;
            this.cbxCancelled.CheckedChanged += new System.EventHandler(this.cb1_CheckedChanged);
            // 
            // cbxProcessing
            // 
            this.cbxProcessing.AutoSize = true;
            this.cbxProcessing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxProcessing.Location = new System.Drawing.Point(924, 5);
            this.cbxProcessing.Name = "cbxProcessing";
            this.cbxProcessing.Size = new System.Drawing.Size(102, 19);
            this.cbxProcessing.TabIndex = 25;
            this.cbxProcessing.Text = "PROCESSING";
            this.cbxProcessing.UseVisualStyleBackColor = true;
            this.cbxProcessing.CheckedChanged += new System.EventHandler(this.cb1_CheckedChanged);
            // 
            // cbxPending
            // 
            this.cbxPending.AutoSize = true;
            this.cbxPending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPending.Location = new System.Drawing.Point(840, 5);
            this.cbxPending.Name = "cbxPending";
            this.cbxPending.Size = new System.Drawing.Size(78, 19);
            this.cbxPending.TabIndex = 24;
            this.cbxPending.Text = "PENDING";
            this.cbxPending.UseVisualStyleBackColor = true;
            this.cbxPending.CheckedChanged += new System.EventHandler(this.cb1_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(776, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "STATUS : ";
            // 
            // radDate
            // 
            this.radDate.AutoSize = true;
            this.radDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDate.Location = new System.Drawing.Point(1457, 7);
            this.radDate.Name = "radDate";
            this.radDate.Size = new System.Drawing.Size(55, 19);
            this.radDate.TabIndex = 17;
            this.radDate.Tag = "date";
            this.radDate.Text = "DATE";
            this.radDate.UseVisualStyleBackColor = true;
            this.radDate.CheckedChanged += new System.EventHandler(this.radDate_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(1265, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "ORDER BY : ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // radJo
            // 
            this.radJo.AutoSize = true;
            this.radJo.Checked = true;
            this.radJo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radJo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radJo.Location = new System.Drawing.Point(1354, 6);
            this.radJo.Name = "radJo";
            this.radJo.Size = new System.Drawing.Size(99, 19);
            this.radJo.TabIndex = 16;
            this.radJo.TabStop = true;
            this.radJo.Tag = "job_order_no";
            this.radJo.Text = "J.O NUMBER";
            this.radJo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radJo.UseVisualStyleBackColor = true;
            this.radJo.CheckedChanged += new System.EventHandler(this.radJo_CheckedChanged);
            // 
            // cmbxParticular
            // 
            this.cmbxParticular.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxParticular.FormattingEnabled = true;
            this.cmbxParticular.Location = new System.Drawing.Point(522, 5);
            this.cmbxParticular.Name = "cmbxParticular";
            this.cmbxParticular.Size = new System.Drawing.Size(248, 21);
            this.cmbxParticular.TabIndex = 19;
            this.cmbxParticular.SelectedIndexChanged += new System.EventHandler(this.cmbxParticular_SelectedIndexChanged_2);
            this.cmbxParticular.SelectionChangeCommitted += new System.EventHandler(this.cmbxParticular_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(423, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "PARTICULAR : ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.reportViewer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(10, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1709, 596);
            this.panel3.TabIndex = 13;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowCredentialPrompts = false;
            this.reportViewer1.ShowDocumentMapButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(1709, 596);
            this.reportViewer1.TabIndex = 14;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.lblRecordsCount});
            this.statusStrip1.Location = new System.Drawing.Point(10, 646);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1709, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(111, 17);
            this.toolStripStatusLabel3.Text = "RECORDS SHOWN :";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(31, 17);
            this.lblRecordsCount.Text = "1000";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // frmJOStatusSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1729, 678);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmJOStatusSummary";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Job Order Monitoring App | J.O Status Summary Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmJOSummary_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        // TODO Microsoft.Reporting.WinForms.ReportViewer no longer supported.
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cmbxParticular;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radDate;
        private System.Windows.Forms.RadioButton radJo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordsCount;
        private System.Windows.Forms.Label label6;
        protected System.Windows.Forms.CheckBox cbxProcessing;
        private System.Windows.Forms.CheckBox cbxPending;
        protected System.Windows.Forms.CheckBox cbxCancelled;
        protected System.Windows.Forms.CheckBox cbxAccomplished;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
    }
}