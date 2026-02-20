using JOMonitoringApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.MainForm.ChatRoom
{
    public partial class ucMessageBubble : UserControl
    {
        public ucMessageBubble(ChatMessageModel msg)
        {
            InitializeComponent();
           

            lblMessage.Text = msg.MessageText.Trim();
            lblTime.Text = msg.CreatedAt.ToString("hh:mm tt").Trim();
            lblSender.Text = msg.Sender.Trim();

            if (msg.IsMine)
                StyleMine();
            else
                StyleOther();
        }


        private void StyleMine()
        {
            this.Dock = DockStyle.Right;
            pnlBubble.BackColor = Color.White;
            lblSender.ForeColor = Color.Black;
            lblMessage.ForeColor = Color.Black;
        }

        private void StyleOther()
        {
            this.Dock = DockStyle.Left;
            pnlBubble.BackColor = Color.White;
            lblMessage.ForeColor = Color.DarkGray;
        }


        
        private void ucMessageBubble_Load(object sender, EventArgs e)
        {

        }
        private void pnlBubble_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
