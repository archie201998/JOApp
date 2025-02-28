using AccountingSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.MessageBox
{
    public partial class ConfirmMessageBox : Form
    {
        private string _message;

        public ConfirmMessageBox(string message)
        {
            InitializeComponent();
            _message = message;
            Helper.LoadFormIcon(this);
        }

        private void MessageBox_Load(object sender, EventArgs e)
        {
            txtMessage.Text = _message;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
