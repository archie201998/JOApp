namespace MiniChatApp
{
    partial class frmMiniChatRoom
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
            components = new System.ComponentModel.Container();
            flowLayoutPanelChat = new FlowLayoutPanel();
            button1 = new Button();
            txtMessage = new TextBox();
            panel1 = new Panel();
            messageChecker = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanelChat
            // 
            flowLayoutPanelChat.AutoScroll = true;
            flowLayoutPanelChat.AutoScrollMinSize = new Size(0, 500);
            flowLayoutPanelChat.AutoSize = true;
            flowLayoutPanelChat.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanelChat.Dock = DockStyle.Fill;
            flowLayoutPanelChat.FlowDirection = FlowDirection.BottomUp;
            flowLayoutPanelChat.Location = new Point(5, 5);
            flowLayoutPanelChat.Name = "flowLayoutPanelChat";
            flowLayoutPanelChat.Size = new Size(363, 510);
            flowLayoutPanelChat.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(238, 7);
            button1.Name = "button1";
            button1.Size = new Size(122, 33);
            button1.TabIndex = 3;
            button1.Text = "Send Message";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtMessage
            // 
            txtMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMessage.BorderStyle = BorderStyle.FixedSingle;
            txtMessage.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMessage.Location = new Point(3, 6);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(229, 33);
            txtMessage.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(txtMessage);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(5, 515);
            panel1.Name = "panel1";
            panel1.Size = new Size(363, 48);
            panel1.TabIndex = 1;
            // 
            // messageChecker
            // 
            messageChecker.Enabled = true;
            messageChecker.Interval = 5000;
            messageChecker.Tick += messageChecker_Tick;
            // 
            // frmMiniChatRoom
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 568);
            Controls.Add(flowLayoutPanelChat);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "frmMiniChatRoom";
            Padding = new Padding(5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mini Chat-Room";
            Load += frmMiniChatRoom_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelChat;
        private Button button1;
        private TextBox txtMessage;
        private Panel panel1;
        private System.Windows.Forms.Timer messageChecker;
    }
}