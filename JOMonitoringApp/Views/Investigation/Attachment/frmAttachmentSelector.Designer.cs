namespace JOMonitoringApp.Views.Investigation.Attachment
{
    partial class frmAttachmentSelector
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
            this.btnLink = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLink
            // 
            this.btnLink.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLink.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLink.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLink.ForeColor = System.Drawing.Color.White;
            this.btnLink.Image = global::JOMonitoringApp.Properties.Resources.icons8_link_50;
            this.btnLink.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLink.Location = new System.Drawing.Point(32, 24);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(160, 78);
            this.btnLink.TabIndex = 5;
            this.btnLink.Text = "Attach Link";
            this.btnLink.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLink.UseVisualStyleBackColor = false;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // btnImage
            // 
            this.btnImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImage.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnImage.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImage.ForeColor = System.Drawing.Color.White;
            this.btnImage.Image = global::JOMonitoringApp.Properties.Resources.icons8_image_50;
            this.btnImage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImage.Location = new System.Drawing.Point(210, 24);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(160, 78);
            this.btnImage.TabIndex = 6;
            this.btnImage.Text = "Attach Image";
            this.btnImage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImage.UseVisualStyleBackColor = false;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // frmAttachmentSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 126);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.btnLink);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmAttachmentSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attachment Type";
            this.Load += new System.EventHandler(this.frmAttachmentSelector_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLink;
        private System.Windows.Forms.Button btnImage;
    }
}