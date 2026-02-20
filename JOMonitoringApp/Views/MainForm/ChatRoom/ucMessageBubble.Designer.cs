namespace JOMonitoringApp.Views.MainForm.ChatRoom
{
    partial class ucMessageBubble
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBubble = new System.Windows.Forms.Panel();
            this.lblSender = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlBubble.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBubble
            // 
            this.pnlBubble.Controls.Add(this.lblSender);
            this.pnlBubble.Controls.Add(this.lblTime);
            this.pnlBubble.Controls.Add(this.lblMessage);
            this.pnlBubble.Location = new System.Drawing.Point(5, 5);
            this.pnlBubble.Name = "pnlBubble";
            this.pnlBubble.Size = new System.Drawing.Size(603, 52);
            this.pnlBubble.TabIndex = 0;
            this.pnlBubble.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBubble_Paint);
            // 
            // lblSender
            // 
            this.lblSender.AutoSize = true;
            this.lblSender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(46)))));
            this.lblSender.Location = new System.Drawing.Point(4, 18);
            this.lblSender.Name = "lblSender";
            this.lblSender.Size = new System.Drawing.Size(53, 15);
            this.lblSender.TabIndex = 2;
            this.lblSender.Text = "Sender";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.lblTime.Location = new System.Drawing.Point(5, 5);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(35, 13);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "label1";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(6, 36);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(50, 13);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Message";
            // 
            // ucMessageBubble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.pnlBubble);
            this.Name = "ucMessageBubble";
            this.Size = new System.Drawing.Size(611, 60);
            this.Load += new System.EventHandler(this.ucMessageBubble_Load);
            this.pnlBubble.ResumeLayout(false);
            this.pnlBubble.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBubble;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblSender;
    }
}
