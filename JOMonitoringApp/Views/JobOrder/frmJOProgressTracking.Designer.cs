namespace JOMonitoringApp.Views.JobOrder
{
    partial class frmJOProgressTracking
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
            this.dgJobOrderStatusDetails = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJONumber = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgJobOrderStatusDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dgJobOrderStatusDetails
            // 
            this.dgJobOrderStatusDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgJobOrderStatusDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgJobOrderStatusDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgJobOrderStatusDetails.Location = new System.Drawing.Point(12, 47);
            this.dgJobOrderStatusDetails.Name = "dgJobOrderStatusDetails";
            this.dgJobOrderStatusDetails.Size = new System.Drawing.Size(310, 376);
            this.dgJobOrderStatusDetails.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "J.O NUMBER : ";
            // 
            // txtJONumber
            // 
            this.txtJONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJONumber.Location = new System.Drawing.Point(97, 14);
            this.txtJONumber.Name = "txtJONumber";
            this.txtJONumber.Size = new System.Drawing.Size(149, 20);
            this.txtJONumber.TabIndex = 2;
            this.txtJONumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtJONumber.TextChanged += new System.EventHandler(this.txtJONumber_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(252, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 23);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmJOProgressTracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 439);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtJONumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgJobOrderStatusDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmJOProgressTracking";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Job Order Monitoring App | J.O Progress Tracking";
            this.Load += new System.EventHandler(this.frmJOProgressTracking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgJobOrderStatusDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgJobOrderStatusDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJONumber;
        private System.Windows.Forms.Button btnSearch;
    }
}