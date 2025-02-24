using AccountingSystem;
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
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            ValidateLoginCredentials();
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ValidateLoginCredentials()
        {
            //if (!this.ValidateChildren())
            //{
            //    Helper.MessageBoxError(GetFormErrors());
            //    return;
            //}

            string username = txtUserName.Text;
            string password = txtPassword.Text;

            Helper.userId = Factory.UsersRepository().ValidateLogin(username, password);
            txtUserName.SelectAll();
            txtUserName.Focus();
            txtPassword.Clear();

            new frmMain(this).Show();
            Hide();

        }

        private string GetFormErrors()
        {
            throw new NotImplementedException();
        }
    }
}
