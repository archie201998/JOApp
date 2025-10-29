using AccountingSystem;
using JOMonitoringApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Config
{
    public partial class frmConfiguration : Form
    {
        public frmConfiguration()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtIpAddress_TextChanged(object sender, EventArgs e)
        {
            ToggleConnectivityIcon(true, btnShowHide);
        }


        private void ToggleConnectivityIcon(bool isConnected, Button button)
        {
            btnShowHide.Visible = true;
            Image connectedImage = Resources.icons8_check_14;
            Image disConnectedImage = Resources.icons8_ex_14;

            if (isConnected)
            {
                button.Image = connectedImage;
            }
            else
            {
                button.Image = disConnectedImage;
            }
        }

        private void frmConfiguration_Load(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtNetwork_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox currentBox = sender as TextBox;

            // Allow only digits and dot
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Block invalid character
                return;
            }

            if (e.KeyChar == '.')
            {
                e.Handled = true; 

                if (currentBox == txtNetwork) txtHost.Focus();
                else if (currentBox == txtHost) txtSubNet.Focus();
                else if (currentBox == txtSubNet) txtSubNetMask.Focus();
            }

            if (string.IsNullOrWhiteSpace(txtNetwork.Text) ||
             string.IsNullOrWhiteSpace(txtHost.Text) ||
             string.IsNullOrWhiteSpace(txtSubNet.Text) ||
             string.IsNullOrWhiteSpace(txtSubNetMask.Text))
            {
                ToggleConnectivityIcon(false, btnShowHide);
            }
            else
            {
                ToggleConnectivityIcon(CheckPing(), btnShowHide);
            }
        }

        private bool CheckPing()
        {
            try
            {
                string ipAddress = $"{txtNetwork.Text}.{txtHost.Text}.{txtSubNet.Text}.{txtSubNetMask.Text}";
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send(ipAddress, 2000); // 2000ms timeout (2 seconds)

                    if (reply.Status == IPStatus.Success)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            { }

            return false;
        }

        private void txtSubNetMask_TextChanged(object sender, EventArgs e)
        {
            ToggleConnectivityIcon(CheckPing(), btnShowHide);
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            _ = new frmSignIn().ShowDialog();
        }
    }
}
