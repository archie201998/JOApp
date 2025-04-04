using Google.Protobuf;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace MiniChatApp
{
    public partial class frmMiniChatRoom : Form
    {
        public frmMiniChatRoom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMessage.Text.Trim()))
            {
                string message = this.txtMessage.Text.Trim();
                string senderName = Helper.currentUserDisplayName;

                bool messageSent = Factory.ConvoRepository().SendMessage(senderName, message);

                if (!messageSent)
                {
                    MessageBox.Show("Message not sent.");
                }


                txtMessage.Clear();
                LoadMessages();
                flowLayoutPanelChat.AutoScrollPosition = new System.Drawing.Point(0, flowLayoutPanelChat.VerticalScroll.Maximum);
            }
        }

        private void frmMiniChatRoom_Load(object sender, EventArgs e)
        {
            this.Text = "Mini Chat Room - User : " + Helper.currentUserDisplayName;
            LoadMessages();
            flowLayoutPanelChat.AutoScrollPosition = new System.Drawing.Point(0, flowLayoutPanelChat.VerticalScroll.Maximum);
        }

        private void LoadMessages()
        {
            var messages = Factory.ConvoRepository().GetAllConvo();

            flowLayoutPanelChat.Controls.Clear();  // Clear previous messages
            foreach (DataRow row in messages.Rows)
            {
                string sender = row["sender"].ToString();
                string messageText = row["message"].ToString();

                // Create a new Label for each message
                Label messageLabel = new Label();
                messageLabel.Text = $"{sender.ToUpper()}: {messageText}";  // Format: Sender: Message
                messageLabel.AutoSize = true;  // Ensure the label adjusts to message size
                messageLabel.MaximumSize = new System.Drawing.Size(500, 0);  // Optional: max width
                messageLabel.Padding = new Padding(0);
                messageLabel.Margin = new Padding(0, 5, 0, 5);  // Add space between messages

                // Add the label to the FlowLayoutPanel
                flowLayoutPanelChat.Controls.Add(messageLabel);

                // Add a new line for every row
                //flowLayoutPanelChat.Controls.Add(new Label() { AutoSize = true, Text = Environment.NewLine });
            }

            flowLayoutPanelChat.AutoScrollPosition = new System.Drawing.Point(0, flowLayoutPanelChat.VerticalScroll.Maximum);
        }

        private void messageChecker_Tick(object sender, EventArgs e)
        {
            LoadMessages();
        }
    }
}
