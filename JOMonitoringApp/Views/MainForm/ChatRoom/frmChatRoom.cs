using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio.TwiML.Voice;

namespace JOMonitoringApp.Views.MainForm.ChatRoom
{
    public partial class frmChatRoom : Form
    {
        List<ChatMessageModel> conversation = new List<ChatMessageModel>();

        readonly int senderId = Helper.CurrentUserID;
        readonly string currentUser = Helper.CurrentUser;    
        int lastMessageID = 0;  


        public frmChatRoom()
        {
            InitializeComponent();
        }

        private void frmChatRoom_Load(object sender, EventArgs e)
        {
            LoadMessages();
        }

        private void LoadMessages()
        {
            conversation = Factory.ChatMessageRepository().LoadRecentMessages(senderId);

            flpChat.Controls.Clear();

            foreach (var msg in conversation)
                AddBubble(msg);

            if (conversation.Count > 0)
                lastMessageID = conversation.Max(x => x.ID);
        }

        private void AddBubble(ChatMessageModel msg)
        {
            var bubble = new ucMessageBubble(msg);


            flpChat.Controls.Add(bubble);
            
            flpChat.ScrollControlIntoView(bubble);




        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
                return;

            ChatMessageModel msg = new ChatMessageModel
            {
                SenderID = Helper.CurrentUserID,
                Sender = currentUser,
                MessageText = txtMessage.Text,
                CreatedAt = DateTime.Now,
                IsMine = true
            };

            Factory.ChatMessageRepository().InsertMessage(msg);

            conversation.Add(msg);
            AddBubble(msg);

            lastMessageID = msg.MessageID;
            txtMessage.Clear();
        }

        private void tmrPoll_Tick(object sender, EventArgs e)
        {
            var newMsgs = Factory.ChatMessageRepository().GetNewMessages(lastMessageID, Helper.CurrentUserID);

            foreach (var msg in newMsgs)
            {
                conversation.Add(msg);
                AddBubble(msg);
                lastMessageID = msg.MessageID;
            }
        }

        private void flpChat_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
