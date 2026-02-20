using JOMonitoringApp;
using JOMonitoringApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using Color = System.Drawing.Color;


namespace AccountingSystem
{
    public static class Helper
    {
        public static bool attachLink = false;
        public static string imageLink1; 
        public static string imageLink2;

        public static byte CurrentUserID { get; internal set; }
        internal static string CurrentUser;

        public static int UserRoleId { get; internal set; }
        internal static bool temporaryAdminMode = false;
        internal static string changes;
        public static string ServerIPAddress => ConfigurationManager.AppSettings["ServerIP"];
        public static string ServerName => ConfigurationManager.AppSettings["ServerName"];
        public static string CSDHead => ConfigurationManager.AppSettings["CSDHead"];
        public static string BranchManager => ConfigurationManager.AppSettings["BranchManager"];

        public static bool RequestApproved = false;

        internal static decimal DefaultMarkup = 0.20m; 
        internal static DateTime advanceSearchDateFrom = DateTime.Today;
        internal static DateTime advanceSearchDateTo = DateTime.Today;
        internal static int AdvanceSearchPreparedBy;
        internal static int AdvanceSearchAccomplishedBy;
        internal static bool AdvanceSearchWithRemarks = false;

        internal static string AdvanceSearchPreparedByName;
        internal static string AdvanceSearchAccomplishedByName;


        //Default
        internal static decimal IllegalConnectionFee = 6000;
        internal static decimal IllegalConnectionFeeVAT = 720;
        
        //temporary until such time may viable ng paraan.
        internal static string previousReading;
        internal static string presentReading;
        internal static string previousConsumption;
        internal static string presentConsumption;
        internal static string average;
        internal static string adjustedAmount;
        internal static string adjustmentParticular;


        internal static string ImagePath;
        internal static string SecondaryImagePath;

        public static Color StatusColor(string status)
        {
            switch (status)
            {
                case "pending":
                    return Color.Gold;
                case "processing":
                    return Color.MediumSeaGreen;
                case "cancelled":
                    return Color.IndianRed;
                case "accomplished":
                    return Color.SteelBlue;
                default:
                    return Color.Gray;
            }
        }
        public static Color InvestigationStatusColor(string status)
        {
            switch (status)
            {
                case "FOR APPROVAL":
                    return Color.Gold;
                case "FOR RECOMMENDATION":
                    return Color.MediumSeaGreen;
                case "FOR INVESTIGATION":
                    return Color.IndianRed;
                case "APPROVED":
                    return Color.SteelBlue;
                case "FOR REINVESTIGATION":
                    return Color.MediumVioletRed;
                default:
                    return Color.Gray;
            }
        }


        public static string GetCurrentVersion()
        {
            return "1.0";
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }


        internal static void UserAdminView(Form frm)
        { 
            frm.Size = new Size(682, 414);
        }


        public static string LogMessage(bool isUpdate, string jobNumber)
        {
            if (isUpdate)
            {
                return $"{ changes }";
            }

            return $"Added " + jobNumber;
            
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["water_system_main"].ConnectionString);
        }

        public static bool UserHasPermission(string permissionName)
        {
            return Factory.RoleHasPermissionRepository().RoleHasPermission(permissionName, Helper.UserRoleId);
             
        }
        public static Dictionary<string, string> GetUserDataById(int userId)
        {
            var dictUser = new Dictionary<string, string>();
            try
            {
                dictUser = Factory.UsersRepository().GetRecordByID(userId);

                string prefix = dictUser["prefix"];
                string suffix = dictUser["suffix"];

                string userFullName = $" {(string.IsNullOrWhiteSpace(prefix) ? string.Empty : $"{prefix}.")} {dictUser["first_name"]} {dictUser["middle_name"]} {dictUser["last_name"]} {(string.IsNullOrWhiteSpace(suffix) ? string.Empty : $", {suffix}")}";
             
                dictUser.Add("id", userId.ToString());
                dictUser.Add("user_full_name", userFullName);

                return dictUser;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            return dictUser;
        }
        public static void LoadFormIcon(Form form)
        {
            form.Icon = JOMonitoringApp.Properties.Resources.new_system_logo;
        }

        public static void DatagridFullRowSelectStyle(DataGridView dgv, bool Fill = false, bool isReadOnly = true, bool showRowHeader = false)
        {
            dgv.RowHeadersVisible = showRowHeader;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.BackgroundColor = Color.White;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromKnownColor(KnownColor.Control);
            dgv.GridColor = Color.White;
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.ReadOnly = isReadOnly;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToResizeRows = false;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.White);
            dgv.RowTemplate.Height = 20;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.White);
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.White);
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.RowHeadersWidth = 25;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgv.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Outset;
            dgv.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv.DefaultCellStyle.Font = new Font("Segiou", 8);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segiou", 8, FontStyle.Regular);
            dgv.EnableHeadersVisualStyles = false;

            if (Fill == true) dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public static void DatagridFullRowSelectStyleEditable(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.BackgroundColor = Color.White;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromKnownColor(KnownColor.Control);
            dgv.GridColor = Color.White;
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToResizeRows = false;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.White);
            dgv.RowTemplate.Height = 20;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.White);
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption);
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.White);
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.RowHeadersWidth = 25;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgv.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Outset;
            dgv.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv.DefaultCellStyle.Font = new Font("Segoui", 8);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoui", 8, FontStyle.Regular);
            dgv.EnableHeadersVisualStyles = false;

            // Make only the second column (index 1) editable
            if (dgv.Columns.Count > 1) // Make sure the second column exists
            {
                dgv.Columns[1].ReadOnly = false; // Set the second column to editable
            }
        }



        public static void DataGrivBlankStyle(DataGridView dgv, bool Fill = false, bool isReadOnly = true, bool showRowHeader = false)
        {
            dgv.BorderStyle = BorderStyle.None; // No border around DataGridView
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None; // No border around cells
            dgv.GridColor = Color.White; // No gridlines
            dgv.RowHeadersVisible = false; // Hide row headers
            dgv.ColumnHeadersVisible = false; // Hide column headers
        }

        #region Check Box Column Utility Datagrid

        public static void CheckUncheckCheckBoxHeader(DataGridView dataGridView, string checkBoxColumnName, CheckBox checkBox)
        {
            if (dataGridView.Rows.Count < 1)
                return;

            int totalRowCount = dataGridView.Rows.Count;
            int checkedRowCount = 0;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (Convert.ToBoolean(row.Cells[checkBoxColumnName].Value) == true)
                    checkedRowCount += 1;
            }

            if (totalRowCount == checkedRowCount)
                checkBox.Checked = true;
            else
                checkBox.Checked = false;
        }

        public static void CheckUncheckCheckBoxRows(DataGridView dataGridView, string checkBoxColumnName, bool isChecked)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Cells[checkBoxColumnName].Value = isChecked;
            }
        }

   

        #endregion ServerConfig and Server List

        #region Miscellaneous

        public static void ProgressCounter(BackgroundWorker backgroundWorker, int totalProgressCount, int progressCount, string progressText = "")
        {
            if (totalProgressCount <= 0)
            {
                backgroundWorker.ReportProgress(0, progressText);
                return;
            }

            int progressBarPercentage = (int)((double)progressCount / totalProgressCount * 100);
            backgroundWorker.ReportProgress(progressBarPercentage, progressText);
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static byte[] ImageToByteArray(Image image)
        {
            if (image == null)
                return null;

            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

    

        public static void DatagridViewRecordFinder(DataGridView dataGridView, string columnName, string value)
        {
            int visibleColumCount = 0;
            var visibleColumn = new DataGridViewColumn();

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.Visible)
                {
                    visibleColumn = column;
                    visibleColumCount++;
                    break;
                }
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[columnName].Value == null && visibleColumCount == 0)
                    continue;

                string currentRowValue = row.Cells[columnName].Value.ToString();

                if (currentRowValue == value)
                {
                    dataGridView.CurrentCell = row.Cells[visibleColumn.Name];
                    row.Selected = true;
                    break;
                }
            }
        }

        public static DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }

        public static string GenerateFullName(string prefix, string firstName, string MiddleName, string LastName, string suffix)
        {
            string fullName = $" {(string.IsNullOrWhiteSpace(prefix) ? string.Empty : $"{prefix}.")} {firstName} {(string.IsNullOrWhiteSpace(MiddleName) ? string.Empty : MiddleName.Substring(0, 1))}. {LastName} {(string.IsNullOrWhiteSpace(suffix) ? string.Empty : $", {suffix}")}";

            return fullName;
        }

        internal static Dictionary<string, string> LoggedInUserData()
        {
            var dictUser = new Dictionary<string, string>();
            try
            {
                dictUser = Factory.UsersRepository().GetRecordByID(CurrentUserID);
                string prefix = dictUser["prefix"];
                string suffix = dictUser["suffix"];

                string userFullName = $" {(string.IsNullOrWhiteSpace(prefix) ? string.Empty : $"{prefix}.")} {dictUser["first_name"]} {dictUser["middle_name"]}. {dictUser["last_name"]} {(string.IsNullOrWhiteSpace(suffix) ? string.Empty : $", {suffix}")}";
                dictUser.Add("user_full_name", userFullName);

                return dictUser;
            }
            catch (Exception ex)
            {
                MessageBoxError(ex.Message);
            }

            return dictUser;
        }

        #endregion Get User Data

        #region ErrorProviders on Controls

        public static void ClearErrorCheckedListBox(ErrorProvider ep, CheckedListBox chklstBox)
        {
            ep.SetError(chklstBox, string.Empty);
        }

        public static void ClearErrorComboBox(ErrorProvider ep, ComboBox cmbBox)
        {
            ep.SetError(cmbBox, string.Empty);
        }

        public static void ClearErrorDatagridView(ErrorProvider ep, DataGridView dgView)
        {
            ep.SetError(dgView, string.Empty);
        }

        public static void ClearErrorDateTimePickerRange(ErrorProvider ep, DateTimePicker dtpDateRange)
        {
            ep.SetError(dtpDateRange, string.Empty);
        }

        public static void ClearErrorDateTimePickerRange(ErrorProvider ep, NumericUpDown numUpDown)
        {
            ep.SetError(numUpDown, string.Empty);
        }

        public static void ClearErrorNumericUpDown(ErrorProvider ep, NumericUpDown numUpDown)
        {
            ep.SetError(numUpDown, string.Empty);
        }

        public static void ClearErrorRichTextBox(ErrorProvider ep, RichTextBox richtxtBox)
        {
            ep.SetError(richtxtBox, string.Empty);
        }

        public static void ClearErrorTextBox(ErrorProvider ep, TextBox txtBox)
        {
            ep.SetError(txtBox, string.Empty);
        }

        public static void ClearMaskedTextboxError(ErrorProvider ep, MaskedTextBox maskedTextBox)
        {
            ep.SetError(maskedTextBox, string.Empty);
        }

        public static string ErrorMessage(string fieldName)
        {
            if (GetFirstLetter(fieldName) == "A")
                return $"Please enter an {fieldName}.";
            else
                return $"Please enter a {fieldName}.";
        }

        public static bool ShowErrorCheckedListBox(ErrorProvider ep, CheckedListBox chklstBox, string fieldName = "Field")
        {
            if (chklstBox.CheckedIndices.Count == 0)
            {
                ep.SetError(chklstBox, $"{fieldName} is required");
                return true;
            }

            return false;
        }

        public static bool ShowErrorComboBoxEmpty(ErrorProvider ep, ComboBox cmbBox, string fieldName = "Field")
        {
            if (string.IsNullOrWhiteSpace(cmbBox.Text))
            {
                ep.SetError(cmbBox, $"{ErrorMessageForEmpty(fieldName)}");
                return true;
            }

            return false;
        }

        public static bool ShowErrorDatagridView(ErrorProvider ep, DataGridView dgView, string fieldName = "Field")
        {
            if (dgView.Rows.Count == 0)
            {
                ep.SetError(dgView, $"{ErrorMessageForEmpty(fieldName)}");
                return true;
            }

            return false;
        }

        public static bool ShowErrorDateTimePickerRange(ErrorProvider ep, DateTime firstDate, DateTime secondDate, DateTimePicker dtp, string fieldName = "Field")
        {
            bool isValidDate = firstDate > secondDate;

            if (!isValidDate)
            {
                ep.SetError(dtp, $"{fieldName} is invalid.");
                return true;
            }
            return false;
        }

        public static bool ShowErrorNumericUpDownEmpty(ErrorProvider ep, NumericUpDown numUpDown, string fieldName = "Field")
        {
            if (string.IsNullOrWhiteSpace(numUpDown.Text.ToString()))
            {
                ep.SetError(numUpDown, $"{ErrorMessageForEmpty(fieldName)}.");
                return true;
            }

            return false;
        }

        public static bool ShowErrorNumericUpDownZero(ErrorProvider ep, NumericUpDown numericUpDown, string fieldName = "Field")
        {
            if (numericUpDown.Value == 0)
            {
                ep.SetError(numericUpDown, $"{ErrorMessageForEmpty(fieldName)}");
                return true;
            }

            return false;
        }

        public static bool ShowErrorRichTextBoxEmpty(ErrorProvider ep, RichTextBox richTxtBox, string fieldName = "Field")
        {
            if (string.IsNullOrWhiteSpace(richTxtBox.Text.Trim()))
            {
                ep.SetError(richTxtBox, $"{ErrorMessageForEmpty(fieldName)}");
                return true;
            }

            return false;
        }

        public static bool ShowErrorTextBoxEmpty(ErrorProvider ep, TextBox txtBox, string fieldName = "Field")
        {
            if (string.IsNullOrWhiteSpace(txtBox.Text.Trim()))
            {
                ep.SetError(txtBox, $"{ErrorMessageForEmpty(fieldName)}");
                return true;
            }

            return false;
        }

        public static bool ShowErrorDuplicateEntry(ErrorProvider ep, TextBox txtBox, string fieldName = "Field")
        {
            ep.SetError(txtBox, $"{ErrorMessageForDuplicateEntry(fieldName)}");
            return true;
        }

        public static bool ShowMaskedTextboxError(ErrorProvider ep, MaskedTextBox maskedTextBox, string fieldName)
        {
            if (!maskedTextBox.MaskCompleted)
            {
                ep.SetError(maskedTextBox, $"{fieldName} is required");
                return true;
            }
            return false;
        }

        private static string ErrorMessageForDuplicateEntry(string fieldName)
        {
            return $"{fieldName} alreadly in the database.";
        }

        private static string ErrorMessageForEmpty(string fieldName)
        {
            if (GetFirstLetter(fieldName) == "A" || GetFirstLetter(fieldName) == "a")
                return $"Please enter an {fieldName.ToLower()}";
            else
                return $"Please enter a {fieldName.ToLower()}";
        }

        private static string GetFirstLetter(string word)
        {
            return word.Substring(0, 1);
        }

        #endregion ErrorProviders on Controls

        #region MessageBoxes

        // prompt a success messagebox

        public static bool MessageBoxConfirmCancel(string confirmMessage)
        {
            string message = confirmMessage;

            if (MessageBox.Show(message, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                return true;

            return false;
        }


        public static bool MessageBoxWarningConfirm(string confirmMessage)
        {
            string message = confirmMessage;

            if (MessageBox.Show(message, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                return true;

            return false;
        }

        public static bool MessageBoxConfirmDelete(int rowCount)
        {
            string message = string.Empty;

            if (rowCount == 1)
                message = "Are you sure you want to delete a record?";
            else if (rowCount > 1)
                message = $"Are you sure you want to delete {rowCount} records?";

            if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                return true;

            return false;
        }

        // prompt an error messagebox
        public static void MessageBoxError(string message)
        {
            _ = MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void MessageBoxSuccess(string message)
        {
            _ = MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MessageBoxWarning(string message)
        {
            _ = MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion MessageBoxes

        #region EnableDisableButtons

        public static void EnableDisableButtons(DataGridView dgv, Button btnEdit, Button btnDelete)
        {
            int SelectedRows = dgv.SelectedRows.Count;
            if (SelectedRows == 1)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnDelete.Text = "Delete (" + SelectedRows + ")";
            }
            else if (SelectedRows > 1)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = true;
                btnDelete.Text = "Delete (" + SelectedRows + ")";
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnDelete.Text = "Delete";
            }
        }

        public static void EnableDisableToolStripButtons(DataGridView dgv, ToolStripButton tsBtnEdit, ToolStripButton tsBtnDelete)
        {
            int SelectedRows = dgv.SelectedRows.Count;
            if (SelectedRows == 1)
            {
                tsBtnEdit.Enabled = true;
                tsBtnDelete.Enabled = true;
                tsBtnDelete.Text = "Delete (" + SelectedRows + ")";
            }
            else if (SelectedRows > 1)
            {
                tsBtnEdit.Enabled = false;
                tsBtnDelete.Enabled = true;
                tsBtnDelete.Text = "Delete (" + SelectedRows + ")";
            }
            else
            {
                tsBtnEdit.Enabled = false;
                tsBtnDelete.Enabled = false;
                tsBtnDelete.Text = "Delete";
            }
        }

        public static void EnableDisableToolStripMenuItems(DataGridView dgv, ToolStripButton tsBtnEdit, ToolStripButton tsBtnDelete)
        {
            int SelectedRows = dgv.SelectedRows.Count;
            if (SelectedRows == 1)
            {
                tsBtnEdit.Enabled = true;
                tsBtnDelete.Enabled = true;
                tsBtnDelete.Text = "Delete (" + SelectedRows + ")";
            }
            else if (SelectedRows > 1)
            {
                tsBtnEdit.Enabled = false;
                tsBtnDelete.Enabled = true;
                tsBtnDelete.Text = "Delete (" + SelectedRows + ")";
            }
            else
            {
                tsBtnEdit.Enabled = false;
                tsBtnDelete.Enabled = false;
                tsBtnDelete.Text = "Delete";
            }
        }

        #endregion EnableDisableButtons

        public static Dictionary<int, string> MonthsDatasource()
        {
            var month = new Dictionary<int, string>();
            month.Add(1, "January");
            month.Add(2, "February");
            month.Add(3, "March");
            month.Add(4, "April");
            month.Add(5, "May");
            month.Add(6, "June");
            month.Add(7, "July");
            month.Add(8, "August");
            month.Add(9, "September");
            month.Add(10, "October");
            month.Add(11, "November");
            month.Add(12, "December");

            return month;
        }

        public static Dictionary<int, string> YearsDatasource()
        {
            var month = new Dictionary<int, string>();

            month.Add(1, "2025");
            month.Add(2, "2026");
            month.Add(3, "2027");
            month.Add(4, "2028");
            month.Add(5, "2029");
            month.Add(6, "2030");
            month.Add(7, "2031");
            month.Add(8, "2032");
            month.Add(9, "2033");
            month.Add(10, "2034");
            month.Add(11, "2035");
            month.Add(12, "2036");

            return month;
        }

        public static void ShowRecordTimestamp(DataGridView dataGridView, byte[] index, ToolStripStatusLabel lblCreatedAt, ToolStripStatusLabel lblUpdatedAt)
        {
            string placeHolder = "--";

            if (dataGridView.SelectedRows.Count == 1)
            {
                lblCreatedAt.Text = Convert.ToDateTime(dataGridView.SelectedCells[index[0]].Value).ToShortDateString();
                lblUpdatedAt.Text = string.IsNullOrWhiteSpace(dataGridView.SelectedCells[index[1]].Value.ToString()) ? placeHolder : Convert.ToDateTime(dataGridView.SelectedCells[index[1]].Value).ToShortDateString();
            }
            else
            {
                lblCreatedAt.Text = placeHolder;
                lblUpdatedAt.Text = placeHolder;
            }
        }

        public static void ShowRecordTimestampMod(DataGridView dataGridView, ToolStripLabel lblCreatedAt, ToolStripLabel lblUpdatedAt)
        {
            if (dataGridView.Columns.Contains("created_at") && dataGridView.Columns.Contains("updated_at") && dataGridView.SelectedRows.Count > 0)
            {
                var createdAtValue = dataGridView.CurrentRow.Cells["created_at"].Value;
                var updatedAtValue = dataGridView.CurrentRow.Cells["updated_at"].Value;

                lblCreatedAt.Text = !string.IsNullOrWhiteSpace(createdAtValue.ToString()) ? Convert.ToDateTime(createdAtValue).ToShortDateString() : string.Empty;
                lblUpdatedAt.Text = !string.IsNullOrWhiteSpace(updatedAtValue.ToString()) ? Convert.ToDateTime(updatedAtValue).ToShortDateString() : string.Empty;
            }
            else
            {
                lblCreatedAt.Text = string.Empty;
                lblUpdatedAt.Text = string.Empty;
            }
        }

        public static string TruncateString(string myString, int maxLength)
        {
            return myString.Length > maxLength ? $"{myString.Substring(0, 20)}..." : $"{myString}";
        }

        internal static string StatusText(int statusId)
        {
            switch (statusId)
            {
                case 1:
                    return "Pending";
                case 2:
                    return "Processing";
                case 3:
                    return "Cancelled";
                case 4:
                    return "Accomplished";
                default:
                    return "Unknown Status";
            }
        }
        public static string GetPublishVersion()
        {
            //try
            //{
            //    return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            //}
            //catch (InvalidDeploymentException)
            //{
            //    return "Not a ClickOnce application";
            //}

            return string.Empty;
        }

        internal static bool IsInvestigator()
        {
            var userRecord = Factory.UsersRepository().GetRecordByID(Helper.CurrentUserID);
            return userRecord != null && userRecord.ContainsKey("roles_id") && (userRecord["roles_id"] == "5" || userRecord["roles_id"] == "1");
        }

        internal static string InvestigationStatusText(int statusId)
        {
            switch (statusId)
            {
                case 0:
                    return "For Investigation";
                case 1:
                    return "For Recommendation";
                case 2:
                    return "For Adjustment";
                case 3:
                    return "For Approval";
                case 4:
                    return "Approved";
                case 5:
                    return "For ReInvestigation";
                default:
                    return "Unknown";
            }
        }

        public static Dictionary<int, double> AnyWaterRates(int consumption)
        {
            if (consumption < 1)
                throw new ArgumentOutOfRangeException(nameof(consumption), "Max key must be >= 1");

            var result = new Dictionary<int, double>();

            for (int i = 1; i <= consumption; i++)
            {
                if (i <= 10)
                    result[i] = 252.000;
                else
                    result[i] = 280.336 + (i - 11) * 28.336;
            }

            return result;
        }

        internal static Dictionary<int, double> WaterRates()
        {
            return new Dictionary<int, double>
            {
                {1, 252.000}, {2, 252.000}, {3, 252.000}, {4, 252.000}, {5, 252.000},
                {6, 252.000}, {7, 252.000}, {8, 252.000}, {9, 252.000}, {10, 252.000},
                {11, 280.34}, {12, 308.67}, {13, 337.01}, {14, 365.34}, {15, 393.68},
                {16, 422.02}, {17, 450.35}, {18, 478.69}, {19, 507.02}, {20, 535.36},
                {21, 566.94}, {22, 598.53}, {23, 630.11}, {24, 661.70}, {25, 693.28},
                {26, 724.86}, {27, 756.45}, {28, 788.03}, {29, 819.62}, {30, 851.20},
                {31, 886.59}, {32, 921.98}, {33, 957.38}, {34, 992.77}, {35, 1028.16},
                {36, 1063.55}, {37, 1098.94}, {38, 1134.34}, {39, 1169.73}, {40, 1205.12},
                {41, 1245.33}, {42, 1285.54}, {43, 1325.74}, {44, 1365.95}, {45, 1406.16},
                {46, 1446.368}, {47, 1486.576}, {48, 1526.784}, {49, 1566.992}, {50, 1607.200},
                {51, 1653.232}, {52, 1699.264}, {53, 1745.296}, {54, 1791.328}, {55, 1837.360},
                {56, 1883.392}, {57, 1929.424}, {58, 1975.456}, {59, 2021.488}, {60, 2067.520},
                {61, 2113.552}, {62, 2159.584}, {63, 2205.616}, {64, 2251.648}, {65, 2297.680},
                {66, 2343.712}, {67, 2389.744}, {68, 2435.776}, {69, 2481.808}, {70, 2527.840},
                {71, 2573.872}, {72, 2619.904}, {73, 2665.936}, {74, 2711.968}, {75, 2758.000},
                {76, 2804.032}, {77, 2850.064}, {78, 2896.096}, {79, 2942.128}, {80, 2988.160},
                {81, 3034.192}, {82, 3080.224}, {83, 3126.256}, {84, 3172.288}, {85, 3218.320},
                {86, 3264.352}, {87, 3310.384}, {88, 3356.416}, {89, 3402.448}, {90, 3448.480},
                {91, 3494.512}, {92, 3540.544}, {93, 3586.576}, {94, 3632.608}, {95, 3678.640},
                {96, 3724.672}, {97, 3770.704}, {98, 3816.736}, {99, 3862.768}, {100, 3908.800},
                {101, 3954.832}, {102, 4000.864}, {103, 4046.896}, {104, 4092.928}, {105, 4138.960},
                {106, 4184.992}, {107, 4231.024}, {108, 4277.056}, {109, 4323.088}, {110, 4369.120},
                {111, 4415.152}, {112, 4461.184}, {113, 4507.216}, {114, 4553.248}, {115, 4599.280},
                {116, 4645.312}, {117, 4691.344}, {118, 4737.376}, {119, 4783.408}, {120, 4829.440},
                {121, 4875.472}, {122, 4921.504}, {123, 4967.536}, {124, 5013.568}, {125, 5059.600},
                {126, 5105.632}, {127, 5151.664}, {128, 5197.696}, {129, 5243.728}, {130, 5289.760},
                {131, 5335.792}, {132, 5381.824}, {133, 5427.856}, {134, 5473.888}, {135, 5519.920},
                {136, 5565.952}, {137, 5611.984}, {138, 5658.016}, {139, 5704.048}, {140, 5750.080},
                {141, 5796.112}, {142, 5842.144}, {143, 5888.176}, {144, 5934.208}, {145, 5980.240},
                {146, 6026.272}, {147, 6072.304}, {148, 6118.336}, {149, 6164.368}, {150, 6210.400},
                {151, 6256.432}, {152, 6302.464}, {153, 6348.496}, {154, 6394.528}, {155, 6440.560},
                {156, 6486.592}, {157, 6532.624}, {158, 6578.656}, {159, 6624.688}, {160, 6670.720},
                {161, 6716.752}, {162, 6762.784}, {163, 6808.816}, {164, 6854.848}, {165, 6900.880},
                {166, 6946.912}, {167, 6992.944}, {168, 7038.976}, {169, 7085.008}, {170, 7131.040},
                {171, 7177.072}, {172, 7223.104}, {173, 7269.136}, {174, 7315.168}, {175, 7361.200},
                {176, 7407.232}, {177, 7453.264}, {178, 7499.296}, {179, 7545.328}, {180, 7591.360},
                {181, 7637.392}, {182, 7683.424}, {183, 7729.456}, {184, 7775.488}, {185, 7821.520},
                {186, 7867.552}, {187, 7913.584}, {188, 7959.616}, {189, 8005.648}, {190, 8051.680},
                {191, 8097.712}, {192, 8143.744}, {193, 8189.776}, {194, 8235.808}, {195, 8281.840},
                {196, 8327.872}, {197, 8373.904}, {198, 8419.936}, {199, 8465.968}, {200, 8512.000},
                {201, 8552.208}, {202, 8592.416}, {203, 8632.624}, {204, 8672.832}, {205, 8713.040},
                {206, 8753.248}, {207, 8793.456}, {208, 8833.664}, {209, 8873.872}, {210, 8914.080},
                {211, 8954.288}, {212, 8994.496}, {213, 9034.704}, {214, 9074.912}, {215, 9115.120},
                {216, 9155.328}, {217, 9195.536}, {218, 9235.744}, {219, 9275.952}, {220, 9316.160},
                {221, 9356.368}, {222, 9396.576}, {223, 9436.784}, {224, 9476.992}, {225, 9517.200},
                {226, 9557.408}, {227, 9597.616}, {228, 9637.824}, {229, 9678.032}, {230, 9718.240},
                {231, 9758.448}, {232, 9798.656}, {233, 9838.864}, {234, 9879.072}, {235, 9919.280},
                {236, 9959.488}, {237, 9999.696}, {238, 10039.904}, {239, 10080.112}, {240, 10120.320},
                {241, 10160.528}, {242, 10200.736}, {243, 10240.944}, {244, 10281.152}, {245, 10321.360},
                {246, 10361.568}, {247, 10401.776}, {248, 10441.984}, {249, 10482.192}, {250, 10522.400},
                {251, 10562.608}, {252, 10602.816}, {253, 10643.024}, {254, 10683.232}, {255, 10723.440},
                {256, 10763.648}, {257, 10803.856}, {258, 10844.064}, {259, 10884.272}, {260, 10924.480},
                {261, 10964.688}, {262, 11004.896}, {263, 11045.104}, {264, 11085.312}, {265, 11125.520},
                {266, 11165.728}, {267, 11205.936}, {268, 11246.144}, {269, 11286.352}, {270, 11326.560},
                {271, 11366.768}, {272, 11406.976}, {273, 11447.184}, {274, 11487.392}, {275, 11527.600},
                {276, 11567.808}, {277, 11608.016}, {278, 11648.224}, {279, 11688.432}, {280, 11728.640},
                {281, 11768.848}, {282, 11809.056}, {283, 11849.264}, {284, 11889.472}, {285, 11929.680},
                {286, 11969.888}, {287, 12010.096}, {288, 12050.304}, {289, 12090.512}, {290, 12130.720},
                {291, 12170.928}, {292, 12211.136}, {293, 12251.344}, {294, 12291.552}, {295, 12331.760},
                {296, 12371.968}, {297, 12412.176}, {298, 12452.384}, {299, 12492.592}, {300, 12532.800},
                {301, 12572.992}, {302, 12613.184}, {303, 12653.376}, {304, 12693.568}, {305, 12733.760},
                {306, 12773.952}, {307, 12814.144}, {308, 12854.336}, {309, 12894.528}, {310, 12934.720},
                {311, 12974.912}, {312, 13015.104}, {313, 13055.296}, {314, 13095.488}, {315, 13135.680},
                {316, 13175.872}, {317, 13216.064}, {318, 13256.256}, {319, 13296.448}, {320, 13336.640},
                {321, 13376.832}, {322, 13417.024}, {323, 13457.216}, {324, 13497.408}, {325, 13537.600},
                {326, 13577.792}, {327, 13617.984}, {328, 13658.176}, {329, 13698.368}, {330, 13738.560},
                {331, 13778.752}, {332, 13818.944}, {333, 13859.136}, {334, 13899.328}, {335, 13939.520},
                {336, 13979.712}, {337, 14019.904}, {338, 14060.096}, {339, 14100.288}, {340, 14140.480},
                {341, 14180.672}, {342, 14220.864}, {343, 14261.056}, {344, 14301.248}, {345, 14341.440},
                {346, 14381.632}, {347, 14421.824}, {348, 14462.016}, {349, 14502.208}, {350, 14542.400},
                {351, 14582.592}, {352, 14622.784}, {353, 14662.976}, {354, 14703.168}, {355, 14743.360},
                {356, 14783.552}, {357, 14823.744}, {358, 14863.936}, {359, 14904.128}, {360, 14944.320},
                {361, 14984.512}, {362, 15024.704}, {363, 15064.896}, {364, 15105.088}, {365, 15145.280},
                {366, 15185.472}, {367, 15225.664}, {368, 15265.856}, {369, 15306.048}, {370, 15346.240},
                {371, 15386.432}, {372, 15426.624}, {373, 15466.816}, {374, 15507.008}, {375, 15547.200},
                {376, 15587.392}, {377, 15627.584}, {378, 15667.776}, {379, 15707.968}, {380, 15748.160},
                {381, 15788.352}, {382, 15828.544}, {383, 15868.736}, {384, 15908.928}, {385, 15949.120},
                {386, 15989.312}, {387, 16029.504}, {388, 16069.696}, {389, 16109.888}, {390, 16150.080},
                {391, 16190.272}, {392, 16230.464}, {393, 16270.656}, {394, 16310.848}, {395, 16351.040},
                {396, 16391.232}, {397, 16431.424}, {398, 16471.616}, {399, 16511.808}, {400, 16552.000},
                {401, 16592.192}, {402, 16632.384}, {403, 16672.576}, {404, 16712.768}, {405, 16752.960},
                {406, 16793.152}, {407, 16833.344}, {408, 16873.536}, {409, 16913.728}, {410, 16953.920},
                {411, 16994.112}, {412, 17034.304}, {413, 17074.496}, {414, 17114.688}, {415, 17154.880},
                {416, 17195.072}, {417, 17235.264}, {418, 17275.456}, {419, 17315.648}, {420, 17355.840},
                {421, 17396.032}, {422, 17436.224}, {423, 17476.416}, {424, 17516.608}, {425, 17556.800},
                {426, 17596.992}, {427, 17637.184}, {428, 17677.376}, {429, 17717.568}, {430, 17757.760},
                {431, 17797.952}, {432, 17838.144}, {433, 17878.336}, {434, 17918.528}, {435, 17958.720},
                {436, 17998.912}, {437, 18039.104}, {438, 18079.296}, {439, 18119.488}, {440, 18159.680},
                {441, 18199.872}, {442, 18240.064}, {443, 18280.256}, {444, 18320.448}, {445, 18360.640},
                {446, 18400.832}, {447, 18441.024}, {448, 18481.216}, {449, 18521.408}, {450, 18561.600},
                {451, 18601.792}, {452, 18641.984}, {453, 18682.176}, {454, 18722.368}, {455, 18762.560},
                {456, 18802.752}, {457, 18842.944}, {458, 18883.136}, {459, 18923.328}, {460, 18963.520},
                {461, 19003.712}, {462, 19043.904}, {463, 19084.096}, {464, 19124.288}, {465, 19164.480},
                {466, 19204.672}, {467, 19244.864}, {468, 19285.056}, {469, 19325.248}, {470, 19365.440},
                {471, 19405.632}, {472, 19445.824}, {473, 19486.016}, {474, 19526.208}, {475, 19566.400},
                {476, 19606.592}, {477, 19646.784}, {478, 19686.976}, {479, 19727.168}, {480, 19767.360},
                {481, 19807.552}, {482, 19847.744}, {483, 19887.936}, {484, 19928.128}, {485, 19968.320},
                {486, 20008.512}, {487, 20048.704}, {488, 20088.896}, {489, 20129.088}, {490, 20169.280},
                {491, 20209.472}, {492, 20249.664}, {493, 20289.856}, {494, 20330.048}, {495, 20370.240},
                {496, 20410.432}, {497, 20450.624}, {498, 20490.816}, {499, 20531.008}, {500, 20571.200}

            };
        }

        internal static double GetWaterRate(int value)
        {
            if (value <= 10)
                return 252.000;
            else if (value <= 50)
                return 252 + ((value - 10) * 28.34); // Example pattern
            else
                return 1607.200 + ((value - 50) * 46.032); // Example pattern for larger values
        }

        internal static JOLogsModel LogJO(string transaction, int jobOrderId)
        {
            return new JOLogsModel()
            {
                TransactionEvent = transaction,
                DateAndTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"),
                JobOrderId = jobOrderId,
                UserId = Helper.CurrentUserID
            };
        }



        internal static string GetSelectedRadioButton(params RadioButton[] radioButtons)
        {
            foreach (var rb in radioButtons)
            {
                if (rb.Checked)
                {
                    return rb.Tag?.ToString() ?? rb.Text;
                }
            }
            return string.Empty;
        }


    }
}