namespace JOMonitoringApp.Views.Barangay
{
    partial class ucBarangay
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
            this.txtPurokCode = new System.Windows.Forms.TextBox();
            this.txtPurokName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 15);
            this.label4.TabIndex = 53;
            this.label4.Text = "BARANGAY CODE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 50;
            this.label1.Text = "NAME OF BARANGAY";
            // 
            // txtPurokCode
            // 
            this.txtPurokCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPurokCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPurokCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurokCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPurokCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtPurokCode.Location = new System.Drawing.Point(147, 7);
            this.txtPurokCode.Name = "txtPurokCode";
            this.txtPurokCode.Size = new System.Drawing.Size(92, 21);
            this.txtPurokCode.TabIndex = 51;
            // 
            // txtPurokName
            // 
            this.txtPurokName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPurokName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPurokName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurokName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtPurokName.Location = new System.Drawing.Point(147, 34);
            this.txtPurokName.Name = "txtPurokName";
            this.txtPurokName.Size = new System.Drawing.Size(200, 21);
            this.txtPurokName.TabIndex = 52;
            // 
            // ucBarangay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPurokCode);
            this.Controls.Add(this.txtPurokName);
            this.Name = "ucBarangay";
            this.Size = new System.Drawing.Size(360, 64);
            this.Load += new System.EventHandler(this.ucBarangay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtPurokCode;
        internal System.Windows.Forms.TextBox txtPurokName;
    }
}
