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
            this.label16 = new System.Windows.Forms.Label();
            this.txtAcc4 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAcc3 = new System.Windows.Forms.TextBox();
            this.txtAcc2 = new System.Windows.Forms.TextBox();
            this.txtAcc1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgAccounts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAccountName
            // 
            this.txtAccountName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAccountName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountName.Location = new System.Drawing.Point(153, 41);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(219, 20);
            this.txtAccountName.TabIndex = 4;
            this.txtAccountName.TextChanged += new System.EventHandler(this.TxtAccountNumber_TextChanged);
            this.txtAccountName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtAccountName_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Account Number";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(197, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(12, 15);
            this.label16.TabIndex = 3;
            this.label16.Text = "-";
            // 
            // txtAcc4
            // 
            this.txtAcc4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAcc4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAcc4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcc4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcc4.Location = new System.Drawing.Point(314, 12);
            this.txtAcc4.MaxLength = 2;
            this.txtAcc4.Name = "txtAcc4";
            this.txtAcc4.Size = new System.Drawing.Size(22, 21);
            this.txtAcc4.TabIndex = 3;
            this.txtAcc4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAcc4.TextChanged += new System.EventHandler(this.txtAcc4_TextChanged);
            this.txtAcc4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAcc4_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(302, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(12, 15);
            this.label14.TabIndex = 36;
            this.label14.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(249, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(12, 15);
            this.label12.TabIndex = 37;
            this.label12.Text = "-";
            // 
            // txtAcc3
            // 
            this.txtAcc3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAcc3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAcc3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcc3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcc3.Location = new System.Drawing.Point(264, 12);
            this.txtAcc3.MaxLength = 3;
            this.txtAcc3.Name = "txtAcc3";
            this.txtAcc3.Size = new System.Drawing.Size(39, 21);
            this.txtAcc3.TabIndex = 2;
            this.txtAcc3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAcc3.TextChanged += new System.EventHandler(this.txtAcc4_TextChanged);
            this.txtAcc3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAcc4_KeyDown);
            // 
            // txtAcc2
            // 
            this.txtAcc2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAcc2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAcc2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcc2.Location = new System.Drawing.Point(211, 12);
            this.txtAcc2.MaxLength = 3;
            this.txtAcc2.Name = "txtAcc2";
            this.txtAcc2.Size = new System.Drawing.Size(39, 21);
            this.txtAcc2.TabIndex = 1;
            this.txtAcc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAcc2.TextChanged += new System.EventHandler(this.txtAcc4_TextChanged);
            this.txtAcc2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAcc4_KeyDown);
            // 
            // txtAcc1
            // 
            this.txtAcc1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAcc1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAcc1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcc1.Location = new System.Drawing.Point(153, 12);
            this.txtAcc1.MaxLength = 3;
            this.txtAcc1.Name = "txtAcc1";
            this.txtAcc1.Size = new System.Drawing.Size(41, 21);
            this.txtAcc1.TabIndex = 0;
            this.txtAcc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAcc1.TextChanged += new System.EventHandler(this.txtAcc4_TextChanged);
            this.txtAcc1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAcc4_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Account Name";
            // 
            // dgAccounts
            // 
            this.dgAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgAccounts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAccounts.Location = new System.Drawing.Point(15, 67);
            this.dgAccounts.Name = "dgAccounts";
            this.dgAccounts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgAccounts.Size = new System.Drawing.Size(357, 241);
            this.dgAccounts.TabIndex = 5;
            this.dgAccounts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgAccounts_CellContentClick);
            this.dgAccounts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgAccounts_CellDoubleClick);
            this.dgAccounts.DoubleClick += new System.EventHandler(this.DgAccounts_DoubleClick);
            this.dgAccounts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAcc4_KeyDown);
            // 
            // frmSearchAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 320);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAcc4);
            this.Controls.Add(this.txtAcc3);
            this.Controls.Add(this.txtAcc2);
            this.Controls.Add(this.txtAcc1);
            this.Controls.Add(this.dgAccounts);
            this.Controls.Add(this.txtAccountName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
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
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.TextBox txtAcc4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox txtAcc3;
        internal System.Windows.Forms.TextBox txtAcc2;
        internal System.Windows.Forms.TextBox txtAcc1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgAccounts;
    }
}