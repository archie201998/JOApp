namespace JOMonitoringApp.Views.Investigation.SMS
{
    partial class frmSMSConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxComport = new System.Windows.Forms.ComboBox();
            this.txtMessageHeader = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Device Port";
            // 
            // cmbxComport
            // 
            this.cmbxComport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxComport.FormattingEnabled = true;
            this.cmbxComport.Location = new System.Drawing.Point(114, 49);
            this.cmbxComport.Name = "cmbxComport";
            this.cmbxComport.Size = new System.Drawing.Size(157, 23);
            this.cmbxComport.TabIndex = 1;
            // 
            // txtMessageHeader
            // 
            this.txtMessageHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessageHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessageHeader.Location = new System.Drawing.Point(114, 20);
            this.txtMessageHeader.Name = "txtMessageHeader";
            this.txtMessageHeader.Size = new System.Drawing.Size(327, 23);
            this.txtMessageHeader.TabIndex = 3;
            this.txtMessageHeader.Text = "PAMANA WATER CORPORATION - PAGADIAN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Message Header";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Image = global::JOMonitoringApp.Properties.Resources.icons8_connect_port;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Location = new System.Drawing.Point(114, 79);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(157, 23);
            this.btnPrint.TabIndex = 48;
            this.btnPrint.Text = "Connect and Save";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmSMSConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 117);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtMessageHeader);
            this.Controls.Add(this.cmbxComport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSMSConfig";
            this.Text = "J.O Monitoring > SMS Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbxComport;
        private System.Windows.Forms.TextBox txtMessageHeader;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button btnPrint;
    }
}