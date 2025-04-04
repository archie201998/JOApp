
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniChatApp
{
    public partial class frmName : Form
    {
        public frmName()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter your name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.Hide();
                Helper.currentUserDisplayName = textBox1.Text;
                var chatRoom = new frmMiniChatRoom();
                chatRoom.ShowDialog();
            }
        }

        private void frmName_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
        }
    }
}
