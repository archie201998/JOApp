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
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Users
{

    public partial class frmUsers: Form
    {
        private int _userId;
        private List<Keys> keySequence = new List<Keys>();

        public frmUsers()
        {

            InitializeComponent();
            Helper.LoadFormIcon(this);
            txtPrefix.Focus();


            if (Helper.temporaryAdminMode)
                Helper.UserAdminView(this);
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
                Id = _userId,   
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

            //temporary disable this feature
            //if (!IsValidPassword(password))
            //{
            //    errorProvider1.SetError(txtPassword, "Password must be at least 8 characters long and include upper and lower case letters, special characters, and numbers.");
            //    return false;
            //}
            //else
            //{
            //    errorProvider1.SetError(txtPassword, string.Empty);
            //}

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

                if (Helper.temporaryAdminMode)
                {
                    bool updateRes = Factory.UsersRepository().Update(UsersModel());
                    if (updateRes)
                    {
                        Helper.MessageBoxSuccess("User successfully Updated.");
                        ResetForm();
                        return;
                    }
                    return;
                }

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

            this.Size = new Size(466, 414);
            Helper.temporaryAdminMode = false;
        }

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            ToggleCharVisibility(txtPassword, btnShowHide);
        }
        private void btnShowHideConfirmPassword_Click(object sender, EventArgs e)
        {
            ToggleCharVisibility(txtConfirmPassword, btnShowHideConfirmPassword);
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

        private void frmUsers_KeyDown(object sender, KeyEventArgs e)
        {
            keySequence.Add(e.KeyCode);

            if (keySequence.Count > 6)
            {
                keySequence.RemoveAt(0);
            }

            if (keySequence.SequenceEqual(new List<Keys> { Keys.D2, Keys.D8, Keys.D4, Keys.D6, Keys.F1, Keys.F2}))
            {
                if (Helper.temporaryAdminMode)
                {
                    if (Helper.MessageBoxConfirmCancel("Close Administrator Mode?"))
                    {
                        Helper.temporaryAdminMode = false;
                        ResetForm();
                    }
                    return;
                }

                if (Helper.MessageBoxConfirmCancel("Enter Administrator Mode?"))
                {
                    Helper.temporaryAdminMode = true;
                    txtSearchUserName.Focus();
                    Helper.MessageBoxSuccess("Welcome to Administrator mode access.");
                    Helper.UserAdminView(this);
                    keySequence.Clear();
                }
                else
                    return;
            }
        }

        private void txtSearchUserName_KeyDown(object sender, KeyEventArgs e)
        {
         
        }

        private void LoadSearchAccount(Dictionary<string, string> userDict)
        {
            if (userDict.TryGetValue("id", out string id))
                _userId = int.Parse(id);

            if (userDict.TryGetValue("prefix", out string prefix))
                txtPrefix.Text = prefix;

            if (userDict.TryGetValue("first_name", out string firstName))
                txtFirstName.Text = firstName;

            if (userDict.TryGetValue("middle_name", out string middleName))
                txtMiddleName.Text = middleName;

            if (userDict.TryGetValue("last_name", out string lastName))
                txtLastName.Text = lastName;

            if (userDict.TryGetValue("suffix", out string suffix))
                txtSuffix.Text = suffix;

            if (userDict.TryGetValue("user_name", out string userName))
                txtUserName.Text = userName;

            if (userDict.TryGetValue("password", out string password))
                txtPassword.Text = password;

            if (userDict.TryGetValue("password", out string confirmPassword))
                txtConfirmPassword.Text = confirmPassword;

            if (userDict.TryGetValue("roles_id", out string rolesId))
                cmbRoles.SelectedValue = Convert.ToInt32(rolesId);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string userName = txtSearchUserName.Text.Trim();
            Dictionary<string, string> userDict = Factory.UsersRepository().GetRecordsbyUserName(userName);

            if (userDict.Count == 0)
            {
                Helper.MessageBoxSuccess("Username not found.");
                return;
            }

            LoadSearchAccount(userDict);
        }

       
    }
}
