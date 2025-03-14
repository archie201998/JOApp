using AccountingSystem;
using JOMonitoringApp.Properties;
using JOMonitoringApp.Views.MainForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp
{
    public partial class frmSignIn : Form
    {
        public frmSignIn()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
        
            try
            {
          

                ValidateLoginCredentials();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ValidateLoginCredentials()
        {

            string username = txtUserName.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Helper.MessageBoxError("Please enter both username and password.");
                return;
            }

            var userId = Factory.UsersRepository().ValidateLogin(username, password);

            if (userId != 0)
            {
                Helper.UserId = userId;
                var mainForm = new frmMain(this);
                mainForm.Show();
                Hide();
                txtPassword.Clear();
                txtPassword.PasswordChar = '•';
                Cursor = Cursors.Default;
                return;
            }

            Helper.MessageBoxError("Incorrect username or password.");

        }

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            ToggleCharVisibility(txtPassword, btnShowHide);
        }

        private void ToggleCharVisibility(TextBox textBox, Button button)
        {
            Image invisibleImage = Resources.invisible_16px;
            Image visibleImage = Resources.visible_16px;

            if (textBox.PasswordChar == '•')
            {
                button.Image = invisibleImage;
                textBox.PasswordChar = default(char);
            }
            else
            {
                button.Image = visibleImage;
                textBox.PasswordChar = '•';
            }
        }
    }
}
