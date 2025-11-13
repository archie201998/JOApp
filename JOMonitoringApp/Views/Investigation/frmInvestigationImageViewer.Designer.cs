namespace JOMonitoringApp.Views.Investigation
{
    partial class frmInvestigationImageViewer
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnApproved = new System.Windows.Forms.Button();
            this.btnDisapproved = new System.Windows.Forms.Button();
            this.btnRotateImage1 = new System.Windows.Forms.Button();
            this.btnDeleteImage1 = new System.Windows.Forms.Button();
            this.btnUpdateImage1 = new System.Windows.Forms.Button();
            this.btnUpdateImage2 = new System.Windows.Forms.Button();
            this.btnDeleteImage2 = new System.Windows.Forms.Button();
            this.btnRotateImage2 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Location = new System.Drawing.Point(7, 42);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(610, 568);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.DoubleClick += new System.EventHandler(this.pictureBox2_DoubleClick);
            // 
            // btnApproved
            // 
            this.btnApproved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApproved.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnApproved.Enabled = false;
            this.btnApproved.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnApproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproved.ForeColor = System.Drawing.Color.White;
            this.btnApproved.Image = global::JOMonitoringApp.Properties.Resources.icons8_check_24;
            this.btnApproved.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApproved.Location = new System.Drawing.Point(1083, 631);
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(85, 32);
            this.btnApproved.TabIndex = 5;
            this.btnApproved.Text = "SAVE";
            this.btnApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApproved.UseVisualStyleBackColor = false;
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // btnDisapproved
            // 
            this.btnDisapproved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisapproved.BackColor = System.Drawing.Color.Red;
            this.btnDisapproved.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDisapproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisapproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisapproved.ForeColor = System.Drawing.Color.White;
            this.btnDisapproved.Image = global::JOMonitoringApp.Properties.Resources.icons8_circled_x_24;
            this.btnDisapproved.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDisapproved.Location = new System.Drawing.Point(1174, 631);
            this.btnDisapproved.Name = "btnDisapproved";
            this.btnDisapproved.Size = new System.Drawing.Size(92, 32);
            this.btnDisapproved.TabIndex = 6;
            this.btnDisapproved.Text = "CANCEL";
            this.btnDisapproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisapproved.UseVisualStyleBackColor = false;
            this.btnDisapproved.Click += new System.EventHandler(this.btnDisapproved_Click);
            // 
            // btnRotateImage1
            // 
            this.btnRotateImage1.BackColor = System.Drawing.Color.White;
            this.btnRotateImage1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRotateImage1.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnRotateImage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotateImage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRotateImage1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnRotateImage1.Image = global::JOMonitoringApp.Properties.Resources.icons8_rotate_24;
            this.btnRotateImage1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRotateImage1.Location = new System.Drawing.Point(7, 4);
            this.btnRotateImage1.Name = "btnRotateImage1";
            this.btnRotateImage1.Size = new System.Drawing.Size(35, 32);
            this.btnRotateImage1.TabIndex = 7;
            this.btnRotateImage1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnRotateImage1, "Rotate ");
            this.btnRotateImage1.UseVisualStyleBackColor = false;
            this.btnRotateImage1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDeleteImage1
            // 
            this.btnDeleteImage1.BackColor = System.Drawing.Color.White;
            this.btnDeleteImage1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteImage1.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnDeleteImage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteImage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteImage1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnDeleteImage1.Image = global::JOMonitoringApp.Properties.Resources.icons8_remove_24;
            this.btnDeleteImage1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteImage1.Location = new System.Drawing.Point(48, 4);
            this.btnDeleteImage1.Name = "btnDeleteImage1";
            this.btnDeleteImage1.Size = new System.Drawing.Size(35, 32);
            this.btnDeleteImage1.TabIndex = 9;
            this.btnDeleteImage1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnDeleteImage1, "Remove Image");
            this.btnDeleteImage1.UseVisualStyleBackColor = false;
            this.btnDeleteImage1.Click += new System.EventHandler(this.btnDeleteImage1_Click);
            // 
            // btnUpdateImage1
            // 
            this.btnUpdateImage1.BackColor = System.Drawing.Color.White;
            this.btnUpdateImage1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateImage1.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdateImage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateImage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateImage1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdateImage1.Image = global::JOMonitoringApp.Properties.Resources.icons8_edit_image_24;
            this.btnUpdateImage1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateImage1.Location = new System.Drawing.Point(89, 4);
            this.btnUpdateImage1.Name = "btnUpdateImage1";
            this.btnUpdateImage1.Size = new System.Drawing.Size(35, 32);
            this.btnUpdateImage1.TabIndex = 10;
            this.btnUpdateImage1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnUpdateImage1, "Update Image");
            this.btnUpdateImage1.UseVisualStyleBackColor = false;
            this.btnUpdateImage1.Click += new System.EventHandler(this.btnUpdateImage1_Click);
            // 
            // btnUpdateImage2
            // 
            this.btnUpdateImage2.BackColor = System.Drawing.Color.White;
            this.btnUpdateImage2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateImage2.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdateImage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateImage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateImage2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdateImage2.Image = global::JOMonitoringApp.Properties.Resources.icons8_edit_image_24;
            this.btnUpdateImage2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateImage2.Location = new System.Drawing.Point(89, 4);
            this.btnUpdateImage2.Name = "btnUpdateImage2";
            this.btnUpdateImage2.Size = new System.Drawing.Size(35, 32);
            this.btnUpdateImage2.TabIndex = 13;
            this.btnUpdateImage2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnUpdateImage2, "Update Image");
            this.btnUpdateImage2.UseVisualStyleBackColor = false;
            this.btnUpdateImage2.Click += new System.EventHandler(this.btnUpdateImage2_Click);
            // 
            // btnDeleteImage2
            // 
            this.btnDeleteImage2.BackColor = System.Drawing.Color.White;
            this.btnDeleteImage2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteImage2.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnDeleteImage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteImage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteImage2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnDeleteImage2.Image = global::JOMonitoringApp.Properties.Resources.icons8_remove_24;
            this.btnDeleteImage2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteImage2.Location = new System.Drawing.Point(48, 4);
            this.btnDeleteImage2.Name = "btnDeleteImage2";
            this.btnDeleteImage2.Size = new System.Drawing.Size(35, 32);
            this.btnDeleteImage2.TabIndex = 12;
            this.btnDeleteImage2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnDeleteImage2, "Remove Image");
            this.btnDeleteImage2.UseVisualStyleBackColor = false;
            this.btnDeleteImage2.Click += new System.EventHandler(this.btnDeleteImage2_Click);
            // 
            // btnRotateImage2
            // 
            this.btnRotateImage2.BackColor = System.Drawing.Color.White;
            this.btnRotateImage2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRotateImage2.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnRotateImage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotateImage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRotateImage2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnRotateImage2.Image = global::JOMonitoringApp.Properties.Resources.icons8_rotate_24;
            this.btnRotateImage2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRotateImage2.Location = new System.Drawing.Point(7, 4);
            this.btnRotateImage2.Name = "btnRotateImage2";
            this.btnRotateImage2.Size = new System.Drawing.Size(35, 32);
            this.btnRotateImage2.TabIndex = 11;
            this.btnRotateImage2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnRotateImage2, "Rotate");
            this.btnRotateImage2.UseVisualStyleBackColor = false;
            this.btnRotateImage2.Click += new System.EventHandler(this.btnRotateImage2_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(8, 8);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.btnUpdateImage1);
            this.splitContainer1.Panel1.Controls.Add(this.btnRotateImage1);
            this.splitContainer1.Panel1.Controls.Add(this.btnDeleteImage1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox2);
            this.splitContainer1.Panel2.Controls.Add(this.btnUpdateImage2);
            this.splitContainer1.Panel2.Controls.Add(this.btnRotateImage2);
            this.splitContainer1.Panel2.Controls.Add(this.btnDeleteImage2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Size = new System.Drawing.Size(1258, 617);
            this.splitContainer1.SplitterDistance = 630;
            this.splitContainer1.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(7, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(616, 568);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // frmInvestigationImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 671);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnApproved);
            this.Controls.Add(this.btnDisapproved);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "frmInvestigationImageViewer";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInvestigationImageViewer_FormClosing);
            this.Load += new System.EventHandler(this.frmInvestigationImageViewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInvestigationImageViewer_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        internal System.Windows.Forms.Button btnApproved;
        internal System.Windows.Forms.Button btnDisapproved;
        internal System.Windows.Forms.Button btnRotateImage1;
        internal System.Windows.Forms.Button btnDeleteImage1;
        internal System.Windows.Forms.Button btnUpdateImage1;
        internal System.Windows.Forms.Button btnUpdateImage2;
        internal System.Windows.Forms.Button btnDeleteImage2;
        internal System.Windows.Forms.Button btnRotateImage2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}