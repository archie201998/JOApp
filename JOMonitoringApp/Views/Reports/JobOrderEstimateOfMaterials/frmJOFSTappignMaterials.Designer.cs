namespace JOMonitoringApp.Views.Reports.SROF
{
    partial class frmJOFSTappignMaterials
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgJOTappingMaterials = new System.Windows.Forms.DataGridView();
            this.clbMaterials = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbxInStock = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblStockLeft = new System.Windows.Forms.Label();
            this.lbl00 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnContinue = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgJOTappingMaterials)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgJOTappingMaterials);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(489, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 558);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FS/Tapping Default Materials ";
            // 
            // dgJOTappingMaterials
            // 
            this.dgJOTappingMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgJOTappingMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgJOTappingMaterials.Location = new System.Drawing.Point(3, 21);
            this.dgJOTappingMaterials.MultiSelect = false;
            this.dgJOTappingMaterials.Name = "dgJOTappingMaterials";
            this.dgJOTappingMaterials.RowHeadersWidth = 51;
            this.dgJOTappingMaterials.Size = new System.Drawing.Size(474, 534);
            this.dgJOTappingMaterials.TabIndex = 3;
            // 
            // clbMaterials
            // 
            this.clbMaterials.CheckOnClick = true;
            this.clbMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbMaterials.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbMaterials.FormattingEnabled = true;
            this.clbMaterials.Location = new System.Drawing.Point(3, 83);
            this.clbMaterials.Name = "clbMaterials";
            this.clbMaterials.Size = new System.Drawing.Size(483, 475);
            this.clbMaterials.TabIndex = 0;
            this.clbMaterials.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbMaterials_ItemCheck);
            this.clbMaterials.SelectedIndexChanged += new System.EventHandler(this.clbMaterials_SelectedIndexChanged);
            this.clbMaterials.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clbMaterials_MouseDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clbMaterials);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 590);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Materials";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbxInStock);
            this.panel4.Controls.Add(this.btnSearch);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtSearch);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 21);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(483, 62);
            this.panel4.TabIndex = 4;
            // 
            // cbxInStock
            // 
            this.cbxInStock.AutoSize = true;
            this.cbxInStock.Checked = true;
            this.cbxInStock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxInStock.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbxInStock.Location = new System.Drawing.Point(88, 32);
            this.cbxInStock.Name = "cbxInStock";
            this.cbxInStock.Size = new System.Drawing.Size(73, 21);
            this.cbxInStock.TabIndex = 37;
            this.cbxInStock.Text = "In-Stock";
            this.cbxInStock.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::JOMonitoringApp.Properties.Resources.icons8_search_16;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(394, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 23);
            this.btnSearch.TabIndex = 36;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "ITEM NAME ";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSearch.Location = new System.Drawing.Point(87, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(302, 25);
            this.txtSearch.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblStockLeft);
            this.panel3.Controls.Add(this.lbl00);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 558);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(483, 29);
            this.panel3.TabIndex = 1;
            // 
            // lblStockLeft
            // 
            this.lblStockLeft.AutoSize = true;
            this.lblStockLeft.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblStockLeft.Location = new System.Drawing.Point(85, 7);
            this.lblStockLeft.Name = "lblStockLeft";
            this.lblStockLeft.Size = new System.Drawing.Size(15, 17);
            this.lblStockLeft.TabIndex = 3;
            this.lblStockLeft.Text = "0";
            // 
            // lbl00
            // 
            this.lbl00.AutoSize = true;
            this.lbl00.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lbl00.Location = new System.Drawing.Point(7, 6);
            this.lbl00.Name = "lbl00";
            this.lbl00.Size = new System.Drawing.Size(76, 17);
            this.lbl00.TabIndex = 3;
            this.lbl00.Text = "RECORDS : ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnContinue);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(489, 558);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 32);
            this.panel1.TabIndex = 4;
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnContinue.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.ForeColor = System.Drawing.Color.White;
            this.btnContinue.Image = global::JOMonitoringApp.Properties.Resources.icons8_continue_16;
            this.btnContinue.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnContinue.Location = new System.Drawing.Point(356, 4);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(93, 23);
            this.btnContinue.TabIndex = 37;
            this.btnContinue.Text = "Continue";
            this.btnContinue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // frmJOFSTappignMaterials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 590);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmJOFSTappignMaterials";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Job Order Monitoring App | FS/Tapping Materials";
            this.Load += new System.EventHandler(this.frmJOFSTappignMaterials_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgJOTappingMaterials)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox clbMaterials;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl00;
        private System.Windows.Forms.DataGridView dgJOTappingMaterials;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblStockLeft;
        internal System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox cbxInStock;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Button btnContinue;
    }
}