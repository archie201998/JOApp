namespace JOMonitoringApp.Views.Purok
{
    partial class ucPurok
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
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.txtLandMark = new System.Windows.Forms.TextBox();
            this.cmbxBarangay = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 46;
            this.label4.Text = "PUROK CODE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 43;
            this.label1.Text = "NAME OF PUROK";
            // 
            // txtStreet
            // 
            this.txtStreet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtStreet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtStreet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStreet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStreet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtStreet.Location = new System.Drawing.Point(151, 43);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(92, 21);
            this.txtStreet.TabIndex = 44;
            // 
            // txtLandMark
            // 
            this.txtLandMark.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtLandMark.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLandMark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLandMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtLandMark.Location = new System.Drawing.Point(151, 70);
            this.txtLandMark.Name = "txtLandMark";
            this.txtLandMark.Size = new System.Drawing.Size(200, 21);
            this.txtLandMark.TabIndex = 45;
            // 
            // cmbxBarangay
            // 
            this.cmbxBarangay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxBarangay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbxBarangay.FormattingEnabled = true;
            this.cmbxBarangay.Location = new System.Drawing.Point(151, 14);
            this.cmbxBarangay.Name = "cmbxBarangay";
            this.cmbxBarangay.Size = new System.Drawing.Size(172, 23);
            this.cmbxBarangay.TabIndex = 47;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::JOMonitoringApp.Properties.Resources.icons8_plus_50;
            this.pictureBox1.Location = new System.Drawing.Point(327, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 49;
            this.label2.Text = "BARANGAY";
            // 
            // ucPurok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbxBarangay);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.txtLandMark);
            this.Name = "ucPurok";
            this.Size = new System.Drawing.Size(365, 99);
            this.Load += new System.EventHandler(this.ucPurok_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtStreet;
        internal System.Windows.Forms.TextBox txtLandMark;
        private System.Windows.Forms.ComboBox cmbxBarangay;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
    }
}
