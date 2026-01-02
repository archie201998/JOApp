namespace JOMonitoringApp.Views.Investigation
{
    partial class frmInvestigationList
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
            this.dgInvestigations = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewBAMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToRecipientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxParticular = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cmbxRowLimit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.r = new System.Windows.Forms.PictureBox();
            this.cmbxStatus = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.wholePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.investigatorCommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recommendationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recommendationAndAdjustmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvestigations)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.r)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgInvestigations);
            this.panel2.Controls.Add(this.lblRecordCount);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1311, 698);
            this.panel2.TabIndex = 28;
            // 
            // dgInvestigations
            // 
            this.dgInvestigations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgInvestigations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInvestigations.ContextMenuStrip = this.contextMenuStrip1;
            this.dgInvestigations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgInvestigations.Location = new System.Drawing.Point(0, 0);
            this.dgInvestigations.MultiSelect = false;
            this.dgInvestigations.Name = "dgInvestigations";
            this.dgInvestigations.Size = new System.Drawing.Size(1311, 673);
            this.dgInvestigations.TabIndex = 25;
            this.dgInvestigations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgInvestigations_CellContentClick);
            this.dgInvestigations.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgInvestigations_CellFormatting);
            this.dgInvestigations.DoubleClick += new System.EventHandler(this.dgInvestigations_DoubleClick);
            this.dgInvestigations.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgInvestigations_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewBAMToolStripMenuItem,
            this.seeImageToolStripMenuItem,
            this.addToRecipientToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(179, 70);
            // 
            // viewBAMToolStripMenuItem
            // 
            this.viewBAMToolStripMenuItem.Name = "viewBAMToolStripMenuItem";
            this.viewBAMToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.viewBAMToolStripMenuItem.Text = "BAM";
            this.viewBAMToolStripMenuItem.Click += new System.EventHandler(this.viewBAMToolStripMenuItem_Click);
            // 
            // seeImageToolStripMenuItem
            // 
            this.seeImageToolStripMenuItem.Name = "seeImageToolStripMenuItem";
            this.seeImageToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.seeImageToolStripMenuItem.Text = "Image Attachments";
            this.seeImageToolStripMenuItem.Click += new System.EventHandler(this.seeImageToolStripMenuItem_Click);
            // 
            // addToRecipientToolStripMenuItem
            // 
            this.addToRecipientToolStripMenuItem.Name = "addToRecipientToolStripMenuItem";
            this.addToRecipientToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.addToRecipientToolStripMenuItem.Text = "Add to recipient";
            this.addToRecipientToolStripMenuItem.Click += new System.EventHandler(this.addToRecipientToolStripMenuItem_Click);
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.Location = new System.Drawing.Point(73, 561);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(248, 17);
            this.lblRecordCount.TabIndex = 1;
            this.lblRecordCount.Text = "0";
            this.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblRecordCount.Click += new System.EventHandler(this.lblRecordCount_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label26);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 673);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1311, 25);
            this.panel3.TabIndex = 28;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(3, 1);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(77, 23);
            this.label26.TabIndex = 0;
            this.label26.Text = "SHOWING : ";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbxParticular);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.cmbxRowLimit);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.r);
            this.panel1.Controls.Add(this.cmbxStatus);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1311, 30);
            this.panel1.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(386, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 49;
            this.label1.Text = "PARTICULAR";
            // 
            // cmbxParticular
            // 
            this.cmbxParticular.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxParticular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbxParticular.FormattingEnabled = true;
            this.cmbxParticular.Location = new System.Drawing.Point(473, 3);
            this.cmbxParticular.Name = "cmbxParticular";
            this.cmbxParticular.Size = new System.Drawing.Size(211, 23);
            this.cmbxParticular.TabIndex = 48;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Image = global::JOMonitoringApp.Properties.Resources.icons8_printer_16;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Location = new System.Drawing.Point(1212, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(96, 23);
            this.btnPrint.TabIndex = 47;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.button3_Click);
            // 
            // cmbxRowLimit
            // 
            this.cmbxRowLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxRowLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxRowLimit.FormattingEnabled = true;
            this.cmbxRowLimit.Location = new System.Drawing.Point(76, 3);
            this.cmbxRowLimit.Name = "cmbxRowLimit";
            this.cmbxRowLimit.Size = new System.Drawing.Size(106, 23);
            this.cmbxRowLimit.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 45;
            this.label4.Text = "RECORDS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(186, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 44;
            this.label7.Text = "STATUS";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::JOMonitoringApp.Properties.Resources.icons8_view_16;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(1089, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 23);
            this.button2.TabIndex = 43;
            this.button2.Text = "View Details";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(688, 4);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(144, 21);
            this.txtSearch.TabIndex = 42;
            // 
            // r
            // 
            this.r.Image = global::JOMonitoringApp.Properties.Resources.icons8_information_14;
            this.r.Location = new System.Drawing.Point(843, 6);
            this.r.Name = "r";
            this.r.Size = new System.Drawing.Size(16, 16);
            this.r.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.r.TabIndex = 37;
            this.r.TabStop = false;
            // 
            // cmbxStatus
            // 
            this.cmbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbxStatus.FormattingEnabled = true;
            this.cmbxStatus.Items.AddRange(new object[] {
            "All",
            "For Investigation",
            "For Recommendation",
            "For Adjustment",
            "For Approval",
            "For ReInvestigation",
            "Approved"});
            this.cmbxStatus.Location = new System.Drawing.Point(245, 2);
            this.cmbxStatus.Name = "cmbxStatus";
            this.cmbxStatus.Size = new System.Drawing.Size(141, 23);
            this.cmbxStatus.TabIndex = 38;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::JOMonitoringApp.Properties.Resources.icons8_x_24;
            this.button1.Location = new System.Drawing.Point(946, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 23);
            this.button1.TabIndex = 36;
            this.button1.TabStop = false;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
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
            this.btnSearch.Location = new System.Drawing.Point(865, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 23);
            this.btnSearch.TabIndex = 35;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wholePageToolStripMenuItem,
            this.investigatorCommentToolStripMenuItem,
            this.recommendationToolStripMenuItem,
            this.adjustmentToolStripMenuItem,
            this.recommendationAndAdjustmentToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(258, 136);
            // 
            // wholePageToolStripMenuItem
            // 
            this.wholePageToolStripMenuItem.Name = "wholePageToolStripMenuItem";
            this.wholePageToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.wholePageToolStripMenuItem.Text = "Whole Page";
            this.wholePageToolStripMenuItem.Click += new System.EventHandler(this.wholePageToolStripMenuItem_Click);
            // 
            // investigatorCommentToolStripMenuItem
            // 
            this.investigatorCommentToolStripMenuItem.Name = "investigatorCommentToolStripMenuItem";
            this.investigatorCommentToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.investigatorCommentToolStripMenuItem.Text = "Investigator Findings";
            this.investigatorCommentToolStripMenuItem.Click += new System.EventHandler(this.investigatorCommentToolStripMenuItem_Click);
            // 
            // recommendationToolStripMenuItem
            // 
            this.recommendationToolStripMenuItem.Name = "recommendationToolStripMenuItem";
            this.recommendationToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.recommendationToolStripMenuItem.Text = "Recommendation";
            this.recommendationToolStripMenuItem.Click += new System.EventHandler(this.recommendationToolStripMenuItem_Click);
            // 
            // adjustmentToolStripMenuItem
            // 
            this.adjustmentToolStripMenuItem.Name = "adjustmentToolStripMenuItem";
            this.adjustmentToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.adjustmentToolStripMenuItem.Text = "Adjustment";
            this.adjustmentToolStripMenuItem.Click += new System.EventHandler(this.adjustmentToolStripMenuItem_Click);
            // 
            // recommendationAndAdjustmentToolStripMenuItem
            // 
            this.recommendationAndAdjustmentToolStripMenuItem.Name = "recommendationAndAdjustmentToolStripMenuItem";
            this.recommendationAndAdjustmentToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.recommendationAndAdjustmentToolStripMenuItem.Text = "Recommendation and Adjustment";
            this.recommendationAndAdjustmentToolStripMenuItem.Click += new System.EventHandler(this.recommendationAndAdjustmentToolStripMenuItem_Click);
            // 
            // frmInvestigationList
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 736);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmInvestigationList";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "Investigation List";
            this.Load += new System.EventHandler(this.frmInvestigationList_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgInvestigations)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.r)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgInvestigations;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Button button2;
        internal System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox r;
        private System.Windows.Forms.ComboBox cmbxStatus;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbxRowLimit;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewBAMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seeImageToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem wholePageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem investigatorCommentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recommendationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adjustmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToRecipientToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbxParticular;
        private System.Windows.Forms.ToolStripMenuItem recommendationAndAdjustmentToolStripMenuItem;
    }
}