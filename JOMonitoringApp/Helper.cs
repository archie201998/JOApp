
using Google.Protobuf.Compiler;
using JOMonitoringApp;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using Org.BouncyCastle.Asn1.IsisMtt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Color = System.Drawing.Color;


namespace AccountingSystem
{
    public static class Helper
    {


        public static byte UserId { get; internal set; }
        public static int UserRoleId { get; internal set; }
        internal static bool temporaryAdminMode = false;
        internal static string changes;

        internal static string serverStatisIPAddress = "192.168.18.183";


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

        public static string GetCurrentVersion()
        {
            try
            {
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    System.Version version = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                    return version.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (InvalidDeploymentException)
            {
                return "Not a ClickOnce application";
            }
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


        public static string LogMessage(bool isUpdate)
        {
            if (isUpdate)
            {
                //ip address here.
                return $"Updated the following fields : { changes }";
                //return "Updated : " + changes + " at : " + GetLocalIPAddress();
            }

            return $"Added ";
            
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
                dictUser = Factory.UsersRepository().GetRecordByID(UserId);
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
            return $"{fieldName} Alreadly in the database.";
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
            // Check if a row is selected
            if (dataGridView.Columns.Contains("created_at") && dataGridView.Columns.Contains("updated_at") && dataGridView.SelectedRows.Count > 0)
            {
                // Retrieve the values from the "created_at" and "updated_at" columns
                var createdAtValue = dataGridView.CurrentRow.Cells["created_at"].Value;
                var updatedAtValue = dataGridView.CurrentRow.Cells["updated_at"].Value;

                // Convert values to string (or handle null values appropriately)
                lblCreatedAt.Text = !string.IsNullOrWhiteSpace(createdAtValue.ToString()) ? Convert.ToDateTime(createdAtValue).ToShortDateString() : string.Empty;
                lblUpdatedAt.Text = !string.IsNullOrWhiteSpace(updatedAtValue.ToString()) ? Convert.ToDateTime(updatedAtValue).ToShortDateString() : string.Empty;
            }
            else
            {
                // If no row is selected, you can handle it accordingly
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
            try
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch (InvalidDeploymentException)
            {
                return "Not a ClickOnce application";
            }
        }

        internal static bool IsInvestigator()
        {
            var userRecord = Factory.UsersRepository().GetRecordByID(Helper.UserId);
            return userRecord != null && userRecord.ContainsKey("roles_id") && (userRecord["roles_id"] == "5" || userRecord["roles_id"] == "1");
        }



        internal static decimal Domestic(int consumption)
        {






            return 0;

        }


        internal static Dictionary<int, double> DomesticRate()
        {
            return new Dictionary<int, double>
            {
                {1, 252.000}, {2, 252.000}, {3, 252.000}, {4, 252.000}, {5, 252.000},
                {6, 252.000}, {7, 252.000}, {8, 252.000}, {9, 252.000}, {10, 252.000},
                {11, 280.336}, {12, 308.672}, {13, 337.008}, {14, 365.344}, {15, 393.680},
                {16, 422.016}, {17, 450.352}, {18, 478.688}, {19, 507.024}, {20, 535.360},
                {21, 566.944}, {22, 598.528}, {23, 630.112}, {24, 661.696}, {25, 693.280},
                {26, 724.864}, {27, 756.448}, {28, 788.032}, {29, 819.616}, {30, 851.200},
                {31, 886.592}, {32, 921.984}, {33, 957.376}, {34, 992.768}, {35, 1028.160},
                {36, 1063.552}, {37, 1098.944}, {38, 1134.336}, {39, 1169.728}, {40, 1205.120},
                {41, 1245.328}, {42, 1285.536}, {43, 1325.744}, {44, 1365.952}, {45, 1406.160},
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
                {96, 3724.672}, {97, 3770.704}, {98, 3816.736}, {99, 3862.768}, {100, 3908.800}
            };
        }
    }
}