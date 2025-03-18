using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Properties;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Users
{
    public partial class frmUsers: Form
    {
        public frmUsers()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            txtPrefix.Focus();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            LoadRoles();
        }

        private void LoadRoles()
        {
            cmbRoles.Items.Clear();

            var roles = Factory.RolesRepository().GetRecords();
            cmbRoles.DataSource = roles;
            cmbRoles.DisplayMember = "role";
            cmbRoles.ValueMember = "id";
        }   

        internal UsersModel UsersModel()
        {
            string preFix = txtPrefix.Text; 
            string firstName = txtFirstName.Text;
            string middleName = txtMiddleName.Text;
            string lastName = txtLastName.Text;
            string suffix = txtSuffix.Text;
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            int roleId = Convert.ToInt32(cmbRoles.SelectedValue);

            var usersModel = new UsersModel()
            {
                Prefix = preFix,
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Suffix = suffix,
                UserName = username,
                Password = password,
                ConfirmPassword = confirmPassword,
                RolesId = roleId    
            };

            return usersModel;
        }

        private bool IsAccountDetailsValid()
        {

            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;


            if (!IsValidPassword(password))
            {
                errorProvider1.SetError(txtPassword, "Password must be at least 8 characters long and include upper and lower case letters, special characters, and numbers.");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtPassword, string.Empty);
            }

            if (password != confirmPassword)
            {
                errorProvider1.SetError(txtConfirmPassword, "Password and Confirm Password do not match.");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, string.Empty);
            }

            if (cmbRoles.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbRoles, "Please select a role for the user.");
                return false;
            }
            else
            {
                errorProvider1.SetError(cmbRoles, string.Empty);
            }

            return true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (IsAccountDetailsValid())
            {
                bool insertRes = Factory.UsersRepository().Insert(UsersModel());
                if (insertRes)
                {
                    Helper.MessageBoxSuccess("New user successfully added.");
                    ResetForm();
                    return;
                }
            }
            else
            {
                Helper.MessageBoxSuccess("User not save.");
            }
        }

        private bool IsValidPassword(string password)
        {
            if (password.Length < 8)
                return false;

            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasLowerCase = password.Any(char.IsLower);
            bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));
            bool hasDigit = password.Any(char.IsDigit);

            return hasUpperCase && hasLowerCase && hasSpecialChar && hasDigit;
        }

        private void ResetForm()
        {
            txtPrefix.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtMiddleName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtSuffix.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            errorProvider1.Clear();
        }

        private void btnShowHide_Click_1(object sender, EventArgs e)
        {
            ToggleCharVisibility(txtPassword, btnShowHide);
        }

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            ToggleCharVisibility(txtConfirmPassword, btnShowHide);
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
