namespace JOMonitoringApp.Views.JobOrder
{
    partial class frmSearchAccount
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
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgAccounts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAccountName
            // 
            this.txtAccountName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAccountName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountName.Location = new System.Drawing.Point(133, 19);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(174, 20);
            this.txtAccountName.TabIndex = 13;
            this.txtAccountName.TextChanged += new System.EventHandler(this.TxtAccountNumber_TextChanged);
            this.txtAccountName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtAccountName_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Search Account Name";
            // 
            // dgAccounts
            // 
            this.dgAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgAccounts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAccounts.Location = new System.Drawing.Point(15, 45);
            this.dgAccounts.Name = "dgAccounts";
            this.dgAccounts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgAccounts.Size = new System.Drawing.Size(292, 178);
            this.dgAccounts.TabIndex = 15;
            this.dgAccounts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgAccounts_CellContentClick);
            this.dgAccounts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgAccounts_CellDoubleClick);
            this.dgAccounts.DoubleClick += new System.EventHandler(this.DgAccounts_DoubleClick);
            // 
            // frmSearchAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 235);
            this.Controls.Add(this.dgAccounts);
            this.Controls.Add(this.txtAccountName);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchAccount";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Job Order Monitoring App | Search Account";
            this.Load += new System.EventHandler(this.FrmSearchAccount_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSearchAccount_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgAccounts;
    }
}