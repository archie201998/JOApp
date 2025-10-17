namespace JOMonitoringApp.Views.MainForm.Approval
{
    partial class frm_WaitingScreen
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDisapproved = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.picDisapproved = new System.Windows.Forms.PictureBox();
            this.picApproved = new System.Windows.Forms.PictureBox();
            this.closeTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDisapproved)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picApproved)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::JOMonitoringApp.Properties.Resources.load_35;
            this.pictureBox1.Location = new System.Drawing.Point(86, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(352, 153);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(150, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 32);
            this.label1.TabIndex = 42;
            this.label1.Text = "Waiting for approval";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDisapproved
            // 
            this.btnDisapproved.BackColor = System.Drawing.Color.Red;
            this.btnDisapproved.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDisapproved.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDisapproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisapproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisapproved.ForeColor = System.Drawing.Color.White;
            this.btnDisapproved.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDisapproved.Location = new System.Drawing.Point(13, 219);
            this.btnDisapproved.Name = "btnDisapproved";
            this.btnDisapproved.Size = new System.Drawing.Size(511, 32);
            this.btnDisapproved.TabIndex = 41;
            this.btnDisapproved.Text = "CANCEL REQUEST";
            this.btnDisapproved.UseVisualStyleBackColor = false;
            this.btnDisapproved.Click += new System.EventHandler(this.btnDisapproved_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 5);
            this.panel1.TabIndex = 43;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // picDisapproved
            // 
            this.picDisapproved.Image = global::JOMonitoringApp.Properties.Resources.icons8_close_window__1_;
            this.picDisapproved.Location = new System.Drawing.Point(219, 46);
            this.picDisapproved.Name = "picDisapproved";
            this.picDisapproved.Size = new System.Drawing.Size(96, 96);
            this.picDisapproved.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picDisapproved.TabIndex = 44;
            this.picDisapproved.TabStop = false;
            this.picDisapproved.Visible = false;
            // 
            // picApproved
            // 
            this.picApproved.Image = global::JOMonitoringApp.Properties.Resources.icons8_approve;
            this.picApproved.Location = new System.Drawing.Point(219, 46);
            this.picApproved.Name = "picApproved";
            this.picApproved.Size = new System.Drawing.Size(96, 96);
            this.picApproved.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picApproved.TabIndex = 45;
            this.picApproved.TabStop = false;
            this.picApproved.Visible = false;
            // 
            // closeTimer
            // 
            this.closeTimer.Interval = 1000;
            this.closeTimer.Tick += new System.EventHandler(this.closeTimer_Tick);
            // 
            // frm_WaitingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(535, 256);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDisapproved);
            this.Controls.Add(this.picDisapproved);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picApproved);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_WaitingScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Request Sent";
            this.Load += new System.EventHandler(this.frm_WaitingScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDisapproved)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picApproved)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button btnDisapproved;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox picDisapproved;
        private System.Windows.Forms.PictureBox picApproved;
        private System.Windows.Forms.Timer closeTimer;
    }
}