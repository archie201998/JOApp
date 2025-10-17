namespace JOMonitoringApp.Views.Investigation
{
    partial class frmInvestigationApprovalForm
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
            this.btnDisapproved = new System.Windows.Forms.Button();
            this.btnApproved = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.approveTimer = new System.Windows.Forms.Timer(this.components);
            this.panelTimer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
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
            this.btnDisapproved.Location = new System.Drawing.Point(486, 260);
            this.btnDisapproved.Name = "btnDisapproved";
            this.btnDisapproved.Size = new System.Drawing.Size(141, 32);
            this.btnDisapproved.TabIndex = 2;
            this.btnDisapproved.Text = "DISAPPROVED";
            this.btnDisapproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisapproved.UseVisualStyleBackColor = false;
            this.btnDisapproved.Click += new System.EventHandler(this.btnDisapproved_Click);
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
            this.btnApproved.Location = new System.Drawing.Point(339, 260);
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(141, 32);
            this.btnApproved.TabIndex = 1;
            this.btnApproved.Text = "APPROVED";
            this.btnApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApproved.UseVisualStyleBackColor = false;
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(12, 101);
            this.txtMessage.MaxLength = 999999;
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(615, 153);
            this.txtMessage.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 39;
            this.label1.Text = "DETAILS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(12, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "REQUESTED TIME ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(12, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "REQUESTED BY";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 15);
            this.label4.TabIndex = 42;
            this.label4.Text = "ARPPROVAL CODE";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 37);
            this.textBox1.MaxLength = 999999;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(615, 39);
            this.textBox1.TabIndex = 41;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // approveTimer
            // 
            this.approveTimer.Enabled = true;
            this.approveTimer.Tick += new System.EventHandler(this.approveTimer_Tick);
            // 
            // panelTimer
            // 
            this.panelTimer.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelTimer.Location = new System.Drawing.Point(0, 0);
            this.panelTimer.Name = "panelTimer";
            this.panelTimer.Size = new System.Drawing.Size(639, 5);
            this.panelTimer.TabIndex = 43;
            // 
            // frmInvestigationApprovalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 305);
            this.Controls.Add(this.panelTimer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnApproved);
            this.Controls.Add(this.btnDisapproved);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInvestigationApprovalForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Approval Form";
            this.Load += new System.EventHandler(this.frmInvestigationApprovalForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button btnDisapproved;
        internal System.Windows.Forms.Button btnApproved;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer approveTimer;
        private System.Windows.Forms.Panel panelTimer;
    }
}