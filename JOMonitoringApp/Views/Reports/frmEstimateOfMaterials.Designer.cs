namespace JOMonitoringApp.Views.Reports
{
    partial class frmEstimateOfMaterials
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
            this.cbxFullPage = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJONo = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            // TODO Microsoft.Reporting.WinForms.ReportViewer no longer supported.
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.cbxFullPage);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtJONo);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1389, 38);
            this.panel1.TabIndex = 15;
            // 
            // cbxFullPage
            // 
            this.cbxFullPage.AutoSize = true;
            this.cbxFullPage.BackColor = System.Drawing.Color.Transparent;
            this.cbxFullPage.Checked = true;
            this.cbxFullPage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxFullPage.Location = new System.Drawing.Point(279, 10);
            this.cbxFullPage.Margin = new System.Windows.Forms.Padding(4);
            this.cbxFullPage.Name = "cbxFullPage";
            this.cbxFullPage.Size = new System.Drawing.Size(185, 20);
            this.cbxFullPage.TabIndex = 17;
            this.cbxFullPage.Text = "Full Page Print ( 2 Copies) ";
            this.cbxFullPage.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "J.O Number: ";
            // 
            // txtJONo
            // 
            this.txtJONo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJONo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJONo.Location = new System.Drawing.Point(96, 6);
            this.txtJONo.Margin = new System.Windows.Forms.Padding(4);
            this.txtJONo.Name = "txtJONo";
            this.txtJONo.Size = new System.Drawing.Size(175, 26);
            this.txtJONo.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(479, 6);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(125, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Generate";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 38);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1389, 886);
            this.reportViewer1.TabIndex = 16;
            // 
            // frmEstimateOfMaterials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1389, 924);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEstimateOfMaterials";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports > Estimate of Material";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJONo;
        private System.Windows.Forms.Button btnSearch;
        // TODO Microsoft.Reporting.WinForms.ReportViewer no longer supported.
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.CheckBox cbxFullPage;
    }
}