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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnApproved = new System.Windows.Forms.Button();
            this.btnDisapproved = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(639, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(632, 616);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(8, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(625, 616);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // btnApproved
            // 
            this.btnApproved.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnApproved.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnApproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproved.ForeColor = System.Drawing.Color.White;
            this.btnApproved.Image = global::JOMonitoringApp.Properties.Resources.icons8_check_24;
            this.btnApproved.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApproved.Location = new System.Drawing.Point(1088, 624);
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
            this.btnDisapproved.BackColor = System.Drawing.Color.Red;
            this.btnDisapproved.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDisapproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisapproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisapproved.ForeColor = System.Drawing.Color.White;
            this.btnDisapproved.Image = global::JOMonitoringApp.Properties.Resources.icons8_circled_x_24;
            this.btnDisapproved.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDisapproved.Location = new System.Drawing.Point(1179, 624);
            this.btnDisapproved.Name = "btnDisapproved";
            this.btnDisapproved.Size = new System.Drawing.Size(92, 32);
            this.btnDisapproved.TabIndex = 6;
            this.btnDisapproved.Text = "CANCEL";
            this.btnDisapproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisapproved.UseVisualStyleBackColor = false;
            this.btnDisapproved.Click += new System.EventHandler(this.btnDisapproved_Click);
            // 
            // frmInvestigationImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 664);
            this.Controls.Add(this.btnApproved);
            this.Controls.Add(this.btnDisapproved);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "frmInvestigationImageViewer";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image";
            this.Load += new System.EventHandler(this.frmInvestigationImageViewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInvestigationImageViewer_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Button btnApproved;
        internal System.Windows.Forms.Button btnDisapproved;
    }
}