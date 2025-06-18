using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.Admin;
using JOMonitoringApp.Views.Database;
using JOMonitoringApp.Views.Investigation;
using JOMonitoringApp.Views.JobOrder;
using JOMonitoringApp.Views.Materials;
using JOMonitoringApp.Views.Particulars;
using JOMonitoringApp.Views.PromptBox;
using JOMonitoringApp.Views.Reports;
using JOMonitoringApp.Views.Reports.SROF;
using JOMonitoringApp.Views.RolesAndPermissions;
using JOMonitoringApp.Views.Signatories;
using JOMonitoringApp.Views.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.MainForm
{
    public partial class frmMain : Form
    {
        private readonly ucJoborder ucJoborder;
        private int previousSelection = 0;
        private List<Keys> keySequence = new List<Keys>();
        private Timer updateTimer;
        bool updateLabelVisible = false;
        private readonly frmSignIn _frmSignIn;

        public frmMain(frmSignIn frmSignIn)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgJobOrders, true);
            ucJoborder = ucJoborder1;
            _frmSignIn = frmSignIn;
        }

        #region AutoUpdate Notifcation On Background

        private void StartUpdateTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 10000; // Check every 10 minutes
            updateTimer.Tick += (s, e) => CheckForUpdateAsync();
            updateTimer.Start();
        }

        public async void CheckForUpdateAsync()
        {
            //if (!ApplicationDeployment.IsNetworkDeployed)
            //    return;

            //try
            //{
            //    var deployment = ApplicationDeployment.CurrentDeployment;

            //    // Check in background thread
            //    var updateInfo = await Task.Run(() => deployment.CheckForDetailedUpdate());

            //    if (updateInfo.UpdateAvailable)
            //    {
            //        // Notify the user

            //        lblCheckingUpdate.Visible = updateLabelVisible;
            //        updateLabelVisible = !updateLabelVisible;

            //        // Optional: Auto-restart app if you want
            //        // if (result == DialogResult.OK)
            //        //     Application.Restart();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Log or handle errors like no network, update server unreachable, etc.
            //}
        }
        #endregion


        #region Search Records Functions

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadJobOrdersAsync();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal async Task LoadJobOrdersAsync()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lblRetrieved.Visible = true;

                string searchKey = txtSearch.Text.Trim();
                int rowFilter = Convert.ToInt32(cmbxRowLimit.SelectedValue);
                int statusId = Convert.ToInt32(cmbxStatus.SelectedValue);
                string particular = cmbxParticulars.Text;

                // Run the data loading in a background task
                DataTable dataTable = await Task.Run(() =>
                {
                    var dtJobOrders = Factory.JobOrdersRepository().GetViewRecordsByParameters(
                        searchKey,
                        rowFilter,
                        statusId,
                        particular
                    );

                    var tempTable = new DataTable();
                    tempTable.Columns.AddRange(JobOrdersColumns());

                    foreach (DataRow row in dtJobOrders.Rows)
                    {
                        var newRow = tempTable.NewRow();

                        newRow["id"] = Convert.ToInt32(row["id"]);
                        newRow["status"] = row["status"].ToString().ToUpper();
                        newRow["prepared_by_id"] = Convert.ToInt32(row["prepared_by_id"]);
                        newRow["materials_issued_by_id"] = string.IsNullOrEmpty(row["materials_issued_by_id"]?.ToString()) ? 0 : Convert.ToInt32(row["materials_issued_by_id"]);
                        newRow["status_id"] = Convert.ToInt32(row["status_id"]);
                        newRow["date"] = Convert.ToDateTime(row["date"]);
                        newRow["account_number"] = row["account_number"].ToString();
                        newRow["account_name"] = row["account_name"].ToString();
                        newRow["address"] = row["address"].ToString();
                        newRow["job_order_no"] = row["job_order_no"].ToString();
                        newRow["particular"] = row["particular"].ToString();
                        newRow["or_number"] = row["or_number"].ToString();
                        newRow["amount"] = string.IsNullOrEmpty(row["amount"]?.ToString()) ? 0 : Convert.ToDecimal(row["amount"]);
                        newRow["mris"] = row["mris"].ToString();
                        newRow["mrs"] = row["mrs"].ToString();
                        newRow["war"] = row["war"].ToString();
                        newRow["remarks"] = row["remarks"].ToString();
                        newRow["prepared_by"] = row["prepared_by"].ToString();
                        newRow["materials_issued_by"] = row["materials_issued_by"].ToString();

                        tempTable.Rows.Add(newRow);
                    }

                    return tempTable;
                });
                toolStripStatusLabel3.Text = $"RECORDS COUNT : {dataTable.Rows.Count}";
                // Load into DataGridView
                HelperLoadRecords.JobOrdersDataGridView(dgJobOrders, dataTable);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            finally
            {
                // Reset UI state
                Cursor.Current = Cursors.Default;
                lblRetrieved.Visible = false;
            }
        }

        #endregion


        #region Form Load 

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void OnLoad()
        {
            HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowLimit);
            HelperLoadRecords.StatusCombobox(cmbxStatus);
            HelperLoadRecords.ParticularsCombobox(cmbxParticulars);

            Dictionary<string, string> userDict = Helper.GetUserDataById(Helper.UserId);
            lblCurrentUser.Text = userDict["user_full_name"].ToString().ToUpper();
            lblUserRole.Text = userDict["role_name"].ToString().ToUpper();
            cmbxStatus.SelectedValue = 5;
            cmbxRowLimit.SelectedIndex = 1;

            ValidatePermissions();
            StartUpdateTimer();
            LoadJobOrdersAsync();
            ucJoborder.OnLoad();

        }

        #endregion

        #region Permission and Controls Validation
        private void ValidatePermissions()
        {
            bool adminMode = Helper.temporaryAdminMode;

            ucJoborder.gbAccountDetails.Enabled = adminMode ? true : Helper.UserHasPermission("ADD_ACCOUNT_DETAILS");
            ucJoborder.gbJODetails.Enabled = adminMode ? true : Helper.UserHasPermission("ADD_JOB_ORDER_DETAILS");
            ucJoborder.gbJODetails.Enabled = adminMode ? true : Helper.UserHasPermission("ADD_ISSUANCE_AND_JOB_ASSIGNMENT");
            ucJoborder.radPending.Enabled = adminMode ? true : Helper.UserHasPermission("ADD_STATUS");
            ucJoborder.radProcessing.Enabled = adminMode ? true : Helper.UserHasPermission("ADD_STATUS");
            ucJoborder.radAccomplished.Enabled = adminMode ? true : Helper.UserHasPermission("ADD_STATUS");
            ucJoborder.radAccomplished.Enabled = adminMode ? true : Helper.UserHasPermission("ADD_STATUS");
            ucJoborder.txtRemarks.Enabled = adminMode ? true : Helper.UserHasPermission("ADD_REMARKS");
            btnSave.Enabled = adminMode ? true : Helper.UserHasPermission("SAVE_JOB_ORDER");

            dgJobOrders.Visible = adminMode ? true : Helper.UserHasPermission("VIEW_JOB_ORDERS");

            toolStripUser.Enabled = adminMode ? true : Helper.UserHasPermission("SETTINGS_ADD_USER");
            toolStripMaterials.Enabled = adminMode ? true : Helper.UserHasPermission("SETTINGS_ADD_MATERIALS");
            toolStripParticulars.Enabled = adminMode ? true : Helper.UserHasPermission("SETTINGS_ADD_PARTICULARS");
            toolStripRolesAndPermissions.Enabled = adminMode ? true : Helper.UserHasPermission("SETTINGS_ADD_ROLES_AND_PERMISSIONS");
            toolStripSignatories.Enabled = adminMode ? true : Helper.UserHasPermission("SETTINGS_REPORT_SIGNATORIES");

            toolStripJOSummary.Enabled = adminMode ? true : Helper.UserHasPermission("REPORT_JO_SUMMARY");
            toolStripJOProgressTracking.Enabled = adminMode ? true : Helper.UserHasPermission("REPORT_JO_PROGRESS_TRACKING");
            toolStripSROF.Enabled = adminMode ? true : Helper.UserHasPermission("REPORT_SROF");
            toolStripInvestigation.Enabled = adminMode ? true : Helper.UserHasPermission("REPORT_INVESTIGATION");


            toolStripFS.Enabled = adminMode ? true : Helper.UserHasPermission("FS");
            investigationsToolStripMenuItem.Enabled = adminMode ? true : Helper.UserHasPermission("TRANSACTION_INVESTIGATION");
            timer_investigator.Enabled = Helper.UserHasPermission("INVESTIGATION_NOTIFICATION");

            if (Helper.temporaryAdminMode)
            {
                ucJoborder.gbStatusAndRemaarks.Enabled = true;
                ucJoborder.gbAccountDetails.Enabled = true;
                ucJoborder.gbIssuanceAndAssignment.Enabled = true;
                ucJoborder.gbJODetails.Enabled = true;
            }
           
        }
        #endregion


        #region DataGrid Processing 

        private void DgJobOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgJobOrders.Columns[e.ColumnIndex].Name == "status")
            {
                e.CellStyle.ForeColor = Color.White;
                if (e.Value != null)
                {
                    string status = e.Value.ToString();
                    if (status == "PENDING")
                    {
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.BackColor = Helper.StatusColor("pending");
                    }

                    else if (status == "PROCESSING")
                    {
                        e.CellStyle.BackColor = Helper.StatusColor("processing");
                    }

                    else if (status == "CANCELLED")
                    {
                        e.CellStyle.BackColor = Helper.StatusColor("cancelled");
                    }
                    else if (status == "ACCOMPLISHED")
                    {
                        e.CellStyle.BackColor = Helper.StatusColor("accomplished");
                    }
                }
            }
        }

        private DataColumn[] JobOrdersColumns()
        {
            return new DataColumn[]
            {
                new DataColumn("id", typeof (int)),
                new DataColumn("status", typeof(string)),
                new DataColumn("prepared_by_id", typeof(int)),
                new DataColumn("particular", typeof (string)),
                new DataColumn("materials_issued_by_id", typeof(int)),
                new DataColumn("status_id", typeof(int)),
                new DataColumn("job_order_no", typeof(string)),
                new DataColumn("account_number", typeof(string)),
                new DataColumn("account_name", typeof(string)),
                new DataColumn("address", typeof(string)),
                new DataColumn("or_number", typeof(string)),
                new DataColumn("amount", typeof(decimal)),
                new DataColumn("mris", typeof(string)),
                new DataColumn("mrs", typeof(string)),
                new DataColumn("war", typeof(string)),
                new DataColumn("date", typeof(DateTime)),
                new DataColumn("prepared_by", typeof(string)),
                new DataColumn("materials_issued_by", typeof(string)),
                new DataColumn("remarks", typeof(string)),

            };
        }

        #endregion

        #region Update

        private void DgJobOrders_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgJobOrders.Rows.Count == 0) return;

                UpdateSettings();
                ucJoborder.StoreOriginalValues();
                LoadSelectedData();
            }
            catch (Exception)
            {
                Helper.MessageBoxError("Something went wrong. Please contact the system administrator.");
            }

        }

        private void UpdateSettings()
        {
            ucJoborder.isUpdate = true;
            dgJobOrders.Enabled = false;
            btnSave.Text = "Save Changes [Ctrl + S]";
            btnSave.BackColor = Color.OrangeRed;
            previousSelection = dgJobOrders.SelectedRows[0].Index;
        }


        private void LoadSelectedData()
        {
            int selectedJobOrderId = Convert.ToInt32(dgJobOrders.SelectedRows[0].Cells["id"].Value);
            Dictionary<string, string> dictJobOrders = Factory.JobOrdersRepository().GetRecordByID(selectedJobOrderId);

            //setting of data
            ucJoborder.jobOrderId = selectedJobOrderId;
            ucJoborder.txtAccountName.Text = dictJobOrders["account_name"];
            ucJoborder.txtAccountNumber.Text = dictJobOrders["account_number"];
            ucJoborder.cbxNA.Checked = string.IsNullOrEmpty(dictJobOrders["account_number"]);
            ucJoborder.txtAddress.Text = dictJobOrders["address"];
            ucJoborder.txtContact.Text = dictJobOrders["contact_number"];

            //account number setup
            char[] delimiter = new char[] { '-' };
            string[] accountNumber = dictJobOrders["account_number"].ToString().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            bool noAccountNumber = string.IsNullOrEmpty(dictJobOrders["account_number"].ToString());

            ucJoborder.txtAcc1.Text = noAccountNumber ? string.Empty : accountNumber[0];
            ucJoborder.txtAcc2.Text = noAccountNumber ? string.Empty : accountNumber[1];
            ucJoborder.txtAcc3.Text = noAccountNumber ? string.Empty : accountNumber[2];
            ucJoborder.txtAcc4.Text = noAccountNumber ? string.Empty : accountNumber[3];
            //end of account number setup

            ucJoborder.txtJONumber.Text = dictJobOrders["job_order_no"];
            ucJoborder.dtpDate.Value = Convert.ToDateTime(dictJobOrders["date"]);
            ucJoborder.txtMRISNumber.Text = dictJobOrders["mris"];
            ucJoborder.txtMRSNumber.Text = dictJobOrders["mrs"];
            ucJoborder.txtORNumber.Text = dictJobOrders["or_number"];
            ucJoborder.nudAmount.Value = string.IsNullOrEmpty(dictJobOrders["amount"].ToString()) ? 0 : Convert.ToDecimal(dictJobOrders["amount"]);
            ucJoborder.txtWARNumber.Text = dictJobOrders["war"];
            ucJoborder.cmbxMaterialsIssuedBy.SelectedValue = string.IsNullOrEmpty(dictJobOrders["materials_issued_by_id"]) ? -1 : Convert.ToInt32(dictJobOrders["materials_issued_by_id"]);
            ucJoborder.cmbxAccomplishedBy.SelectedValue = string.IsNullOrEmpty(dictJobOrders["accomplished_by_id"]) ? -1 : Convert.ToInt32(dictJobOrders["accomplished_by_id"]);
            ucJoborder.txtRemarks.Text = dictJobOrders["remarks"].ToString();

            //status setup
            int statusId = Convert.ToInt16(dictJobOrders["status_id"]);
            ucJoborder.radPending.Checked = (statusId == Convert.ToInt16(ucJoborder.radPending.Tag));
            ucJoborder.radProcessing.Checked = (statusId == Convert.ToInt16(ucJoborder.radProcessing.Tag));
            ucJoborder.radCancel.Checked = (statusId == Convert.ToInt16(ucJoborder.radCancel.Tag));
            ucJoborder.radAccomplished.Checked = (statusId == Convert.ToInt16(ucJoborder.radAccomplished.Tag));
            //end of status setup

            //particulars setup 
            DataTable jobOrderParticulars = Factory.JobOrderParticularsRepository().GetParticularIdByJOId(selectedJobOrderId);

            foreach (DataRow item in jobOrderParticulars.Rows)
            {
                string particular = item["particular"].ToString();

                for (int i = 0; i < ucJoborder.clBoxParticulars.Items.Count; i++)
                {
                    if (ucJoborder.clBoxParticulars.Items[i].ToString() == particular)
                    {
                        ucJoborder.clBoxParticulars.SetItemChecked(i, true);
                    }
                }
            }


            //restrict user to update if job order is accomplished
            bool isAccomplished = ucJoborder.radAccomplished.Checked;
            bool isAdmin = Helper.temporaryAdminMode;

            bool shouldEnable = !isAccomplished || isAdmin;
            
            ucJoborder.gbStatusAndRemaarks.Enabled = shouldEnable;
            ucJoborder.gbAccountDetails.Enabled = shouldEnable;
            ucJoborder.gbIssuanceAndAssignment.Enabled = shouldEnable;
            ucJoborder.gbJODetails.Enabled = shouldEnable;
        }


        #endregion


        #region Logout
        private void LogoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
                                        "Confirm Logout",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);

            if (result.Equals(DialogResult.Yes))
            {
                Helper.UserId = 0;
                Helper.UserRoleId = 0;
                Helper.temporaryAdminMode = false;

                Close();
                _frmSignIn.txtPassword.Clear();
                _frmSignIn.txtUserName.Clear();
                _frmSignIn.txtUserName.Focus();
                _frmSignIn.Show();

            }

            return;

        }
        #endregion




        #region Reset Input
        internal void ResetInputForm()
        {
            // Clear general fields
            ucJoborder.txtJONumber.Clear();
            ucJoborder.dtpDate.Value = DateTime.Now;
            ucJoborder.txtMRISNumber.Clear();
            ucJoborder.txtMRSNumber.Clear();
            ucJoborder.txtORNumber.Clear();
            ucJoborder.nudAmount.Value = 0;
            ucJoborder.txtWARNumber.Clear();

            // Reset dropdowns
            ucJoborder.cmbxMaterialsIssuedBy.SelectedValue = -1;
            ucJoborder.cmbxAccomplishedBy.SelectedValue = -1;

            // Reset job order state
            ucJoborder.jobOrderId = 0;
            ucJoborder.statusId = 1;
            ucJoborder.radPending.Checked = true;
            ucJoborder.isUpdate = false;

            // Reset form controls
            btnSave.BackColor = Color.DodgerBlue;
            btnSave.Text = "Save [Ctrl + S]";
            dgJobOrders.Enabled = true;
            ucJoborder.errorProvider1.Clear();

            // Clear account-related fields
            ucJoborder.txtAcc1.Clear();
            ucJoborder.txtAcc2.Clear();
            ucJoborder.txtAcc3.Clear();
            ucJoborder.txtAcc4.Clear();
            ucJoborder.txtRemarks.Clear();

            // Enable groupboxes
            ucJoborder.gbStatusAndRemaarks.Enabled = true;
            ucJoborder.gbAccountDetails.Enabled = true;
            ucJoborder.gbIssuanceAndAssignment.Enabled = true;
            ucJoborder.gbJODetails.Enabled = true;

            // Clear CheckedListBox selections
            for (int i = 0; i < ucJoborder.clBoxParticulars.Items.Count; i++)
            {
                ucJoborder.clBoxParticulars.SetItemChecked(i, false);
            }

            // Reset hidden state/flags
            Helper.temporaryAdminMode = false;
            ucJoborder.accountId = 0;

            // Clear account details
            ucJoborder.txtAccountName.Clear();
            ucJoborder.txtAccountNumber.Clear();
            ucJoborder.txtAddress.Clear();
            ucJoborder.txtContact.Clear();

            ValidatePermissions();

        }
        #endregion


        private void LogJOTransaction()
        {
            try
            {
                bool setLogRest = Factory.JOLogsRepository().Insert(ucJoborder.JOLogsModel());

                if (!setLogRest)
                {
                    Helper.MessageBoxError("Failed to saved transaction log.");
                    return;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
                return;
            }
        }

        //This will save job order details into investigation if the particular selected is investigation
        private bool CheckIfInvestigation()
        {
            foreach (var item in ucJoborder.clBoxParticulars.CheckedItems)
            {
                if (item.ToString().IndexOf("Investigation", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void ButtonSaveTrigger()
        {
            try
            {
                bool success = ucJoborder.isUpdate ? UpdateData() : SaveData();

                if (success)
                {
                    LogJOTransaction();
                    if (CheckIfInvestigation())
                        InsertJobOrderToInvestigation(); //<-- Save to investigation table

                    string message = ucJoborder.isUpdate
                        ? "Job Order details successfully updated."
                        : "Job Order successfully created.";
                    Helper.MessageBoxSuccess(message);
                    ResetInputForm();
                    LoadJobOrdersAsync();
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private bool UpdateData()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (!ucJoborder.ValidateChildren())
                {
                    Helper.MessageBoxError(ucJoborder.GetFormErrors());
                    return false;
                }

                if (ucJoborder.HasDataChanged())
                {
                    int jobOrderId = ucJoborder.jobOrderId;
                    bool updateRes = Factory.JobOrdersRepository().Update(ucJoborder.JobOrderModel());

                    if (updateRes)
                    {
                        InsertJobOrderParticulars(jobOrderId);
                        scope.Complete();
                        return true;
                    }
                    else
                    {
                        Helper.MessageBoxError("Failed to update job order.");
                    }

                    return false;
                }
                else
                {
                    Helper.MessageBoxSuccess("No changes detected.");
                    return false;
                }
            }
        }

        private bool CheckPossibleDuplicateEntry()
        {
            string accountNumber = ucJoborder.txtAcc1.Text + "-" + ucJoborder.txtAcc2.Text + "-" + ucJoborder.txtAcc3.Text + "-" + ucJoborder.txtAcc4.Text;
            string particulars = string.Join("\\", ucJoborder.clBoxParticulars.CheckedItems.Cast<string>().ToArray());

            bool recordFound = Factory.JobOrdersRepository().CheckPossibleDuplicate(accountNumber, particulars);

            if (recordFound)
                if (Helper.MessageBoxConfirmCancel("Similar Job Order Details are found in the record. Do you want to proceed?"))
                    return true;
                else
                    return false;

            return true;
        }

        #region Save Job orders

        private void InsertJobOrderToInvestigation()
        {
            string accountNumber = ucJoborder.txtAccountNumber.Text;
            int jobOrderID = Factory.JobOrdersRepository().GetLastInsertedID(Helper.UserId);

            var meterDetails = Factory.CustomersRepository().GetCustomerMeterDetails(accountNumber);

            string meterBrand = meterDetails.ContainsKey("MeterBrand") ? meterDetails["MeterBrand"].ToUpper() : string.Empty;
            string meterSize = meterDetails.ContainsKey("MeterSize") ? meterDetails["MeterSize"].ToUpper() : string.Empty;
            string meterNumber = meterDetails.ContainsKey("MeterNumber") ? meterDetails["MeterNumber"].ToUpper() : string.Empty;

            string natureOfComplaint = string.Join(",", ucJoborder.clBoxParticulars.CheckedItems.Cast<object>());

            var investigation = new InvestigationModel
            {
                JobOrderId = ucJoborder.isUpdate ? ucJoborder.jobOrderId : jobOrderID,
                JobOrderNo = ucJoborder.txtJONumber.Text,
                CustomerName = ucJoborder.txtAccountName.Text,
                CustomerAddress = ucJoborder.txtAddress.Text,
                CustomerAccountNumber = accountNumber,
                CustomerContactNumber = ucJoborder.txtContact.Text,
                CreatedAt = ucJoborder.dtpDate.Value,
                NatureOfComplaint = natureOfComplaint,
                MeterBrand = meterBrand,
                MeterSize = meterSize,
                MeterNumber = meterNumber,
                CreatedBy = Helper.UserId
            };

            if (ucJoborder.isUpdate)
            {
                bool updateRes = Factory.InvestigationRepository().UpdateInvestigation(investigation);

                if (!updateRes)//insert to investigation table if updateRes = false
                {
                    _ = Factory.InvestigationRepository().Insert(investigation);
                }
            }
            else
            {
                _ = Factory.InvestigationRepository().Insert(investigation);
            }
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            ButtonSaveTrigger();
        }

        internal bool SaveData()
        {
            if (!ucJoborder.ValidateChildren())
            {
                Helper.MessageBoxError(ucJoborder.GetFormErrors());
                return false;
            }

            if (Helper.MessageBoxConfirmCancel("Do you confirm to create J.O No. " + ucJoborder.txtJONumber.Text))
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    bool successInsert = Factory.JobOrdersRepository().Insert(ucJoborder.JobOrderModel());
                    if (successInsert)
                    {
                        int jobOrderId = Factory.JobOrdersRepository().GetLastInsertedID(Helper.UserId);

                        if (InsertJobOrderParticulars(jobOrderId))
                        {
                            scope.Complete();
                            return true;
                        }
                        else { return false; }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            //if (CheckPossibleDuplicateEntry())
            //{

            //}
            return false;
        }


        private bool InsertJobOrderParticulars(int jobOrderId)
        {
            if (ucJoborder.isUpdate)
                Factory.JobOrdersRepository().DeleteJobOrderParticulars(jobOrderId);



            foreach (var item in ucJoborder.clBoxParticulars.CheckedItems)
            {
                string particularName = item.ToString();
                int particularId = Factory.ParticularsRepository().GetIdByParticularName(particularName);

                bool success = Factory.JobOrderParticularsRepository().InsertJobOrdersParticulars(jobOrderId, particularId);
                if (!success)
                {
                    return false;
                }
            }

            return true;


        }
        #endregion

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.F1 == e.KeyData)
            {
                this.ucJoborder.BtnSearch_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                ButtonSaveTrigger();
            }
            else if (e.Control && e.KeyCode == Keys.P)
            {

                if (dgJobOrders.SelectedRows.Count >= 2)
                {
                    Helper.MessageBoxWarning("Select only 1 record to print.");
                    return;
                }

                string jobOrderNumber = dgJobOrders.SelectedRows[0].Cells["job_order_no"].Value.ToString();

                _ = new frmServiceRequestAndOrderForm(jobOrderNumber).ShowDialog();
            }
            else if (e.KeyData == Keys.Escape)
            {
                if (Helper.MessageBoxConfirmCancel("Do you want to clear all inputs?"))
                    ResetInputForm();

                return;
            }

            keySequence.Add(e.KeyCode);

            if (keySequence.Count > 6)
            {
                keySequence.RemoveAt(0);
            }

            if (keySequence.SequenceEqual(new List<Keys> { Keys.D1, Keys.D2, Keys.D3, Keys.D1, Keys.D2, Keys.D3 }))
            {

                DialogResult pinMatch = new frmPassKey().ShowDialog();

                if (DialogResult.OK == pinMatch)
                {
                    ValidatePermissions();
                }

            }
        }

        private void requistionAndIssueSlipRISToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmServiceRequestAndOrderForm(string.Empty).ShowDialog();
        }

        private void dgJobOrders_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgJobOrders.Rows.Count == 0 && dgJobOrders.SelectedRows.Count > 0)
                {
                    previousSelection = dgJobOrders.SelectedRows[0].Index;
                    byte[] indexArray = BitConverter.GetBytes(previousSelection);
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmUsers().ShowDialog();
        }

        
        #region Server Pinging
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                using (var ping = new System.Net.NetworkInformation.Ping())
                {
                    var reply = ping.Send(Helper.serverStatisIPAddress);
                    if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                    {
                        lblPing.Text = $" {reply.RoundtripTime} ms";
                    }
                    else
                    {
                        lblPing.Text = "Ping failed";
                    }
                }
            }
            catch (Exception ex)
            {
                lblPing.Text = $"Error: {ex.Message}";
            }
        }
        #endregion


        private void particularsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmParticulars().ShowDialog();
        }

        private void rolesAndPermissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmRolesAndPermissions().ShowDialog();
        }


        private void toolStripSignatories_Click(object sender, EventArgs e)
        {
            _ = new frmReportSignatories().ShowDialog();
        }

        private void toolStripMaterials_Click(object sender, EventArgs e)
        {
           var frmMaterials = new frmMaterials();
           frmMaterials.Show();
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmDBBackup().ShowDialog();
        }

        private void databaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmMessagePrompt().ShowDialog();
        }

        private void estimatesOfMaterialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmEstimateOfMaterials(string.Empty).ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dgJobOrders.SelectedRows.Count == 0)
            {
                Helper.MessageBoxSuccess("Please select record to print.");
                return;
            }

            string jobOrderNumber = dgJobOrders.SelectedRows[0].Cells["job_order_no"].Value.ToString();
            var frmJOFSTappingMaterials = new frmJOFSTappignMaterials();
            frmJOFSTappingMaterials._jobOrderNumber = jobOrderNumber;
            frmJOFSTappingMaterials.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgJobOrders.SelectedRows.Count == 0)
            {
                Helper.MessageBoxSuccess("Please select record to print.");
                return;
            }

            string jobOrderNumber = dgJobOrders.SelectedRows[0].Cells["job_order_no"].Value.ToString();
            _ = new frmServiceRequestAndOrderForm(jobOrderNumber).ShowDialog();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            ResetInputForm();
        }

        private void timerSystemDateAndTime_Tick(object sender, EventArgs e)
        {
            lblSystemDateAndTime.Text = $"SYSTEM DATE AND TIME : {DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss tt")}";
        }


        private void systemUpdateChecker_Tick(object sender, EventArgs e)
        {
            CheckForUpdateAsync();
        }

        #region User Manual
        private void userManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string tempPath = Path.Combine(Path.GetTempPath(), "Job_Order_e-Monitoring System User Guide.pdf");
                File.WriteAllBytes(tempPath, Properties.Resources.Job_Order_e_Monitoring_System_User_Guide);
                System.Diagnostics.Process.Start(tempPath);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError("Failed to open user manual. Contact your system administrator ");
            }
        }
        #endregion

        #region Delete Job Order 

        private void dgJobOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (Helper.temporaryAdminMode || Helper.UserHasPermission("DELETE_JOB_ORDER"))
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (dgJobOrders.SelectedRows.Count > 0)
                    {
                        var confirm = MessageBox.Show("Are you sure you want to delete the selected record?",
                                                      "Confirm Delete",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                        if (confirm == DialogResult.Yes)
                        {
                            int jobOrderId = Convert.ToInt32(dgJobOrders.SelectedRows[0].Cells["id"].Value);
                            int userId = Helper.UserId;
                            bool deletedSuccessfully = Factory.JobOrdersRepository().SoftDelete(jobOrderId, userId);

                            if (deletedSuccessfully)
                            {
                                Helper.MessageBoxSuccess("J.O Successfully deleted.");
                                LoadJobOrdersAsync();
                                ResetInputForm();
                            }
                        }
                    }
                }
            }

            return;
        }

        #endregion


        private void trackJOProgressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgJobOrders.SelectedRows.Count == 0)
            {
                Helper.MessageBoxSuccess("Please select 1 record.");
                return;
            }

            string jobOrderNumber = dgJobOrders.SelectedRows[0].Cells["job_order_no"].Value.ToString();
            _ = new frmJOProgressTracking(jobOrderNumber).ShowDialog();
        }

        private void hydrantWithdrawalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgJobOrders.SelectedRows.Count == 0)
            {
                Helper.MessageBoxSuccess("Please select record to print.");
                return;
            }

            string jobOrderNumber = dgJobOrders.SelectedRows[0].Cells["job_order_no"].Value.ToString();
            _ = new frmHydrantWithdrawal(jobOrderNumber).ShowDialog();
        }

        private void investigationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgJobOrders.SelectedRows.Count == 0)
            {
                Helper.MessageBoxSuccess("Please select record to print.");
                return;
            }

            int jobOrderId = Convert.ToInt32(dgJobOrders.SelectedRows[0].Cells["id"].Value);
            string jobOrderNumber = dgJobOrders.SelectedRows[0].Cells["job_order_no"].Value.ToString();
            _ = new frmInvestigationReport(jobOrderId, jobOrderNumber).ShowDialog();
        }

        private void investigationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmInvestigation = new frmInvestigation();
            frmInvestigation.Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnX.Visible = txtSearch.Text.Length > 0;
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadJobOrdersAsync();
            btnX.Visible = false;
        }

        private void investigationToolStripMenuItem_Click_2(object sender, EventArgs e)
        {

        }

        private void investigationDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgJobOrders.SelectedRows.Count > 0)
            {
                try
                {
                    int selectedJobOrderId = Convert.ToInt32(dgJobOrders.SelectedRows[0].Cells["id"].Value);
                    string jobOrderNumber = dgJobOrders.SelectedRows[0].Cells["job_order_no"].Value.ToString();
                    string accountName = dgJobOrders.SelectedRows[0].Cells["account_name"].Value.ToString();
                    string accountNumber = dgJobOrders.SelectedRows[0].Cells["account_number"].Value.ToString();
                    string address = dgJobOrders.SelectedRows[0].Cells["address"].Value.ToString();
                    string status = dgJobOrders.SelectedRows[0].Cells["status"].Value.ToString();
                    string particular = dgJobOrders.SelectedRows[0].Cells["particular"].Value.ToString();


                    var frmInvestigation = new frmInvestigation();
                    frmInvestigation.ShowDialog();
                }
                catch (Exception ex)
                {
                    Helper.MessageBoxError($"Error retrieving selected row data: {ex.Message}");
                }
            }
            else
            {
                Helper.MessageBoxWarning("No row is selected.");
            }
        }

        private void printFormToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SkipMyMessage = false;
            Properties.Settings.Default.Save();
        }

        private void progressTrackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmJOProgressTracking(string.Empty).ShowDialog();
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmJOStatusSummary().ShowDialog();  
        }

        private void toolStripMaterials_Click_1(object sender, EventArgs e)
        {
            _ = new frmMaterials().ShowDialog();
        }

        private void investigationFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void applicationFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string networkFolderPath = @"\\192.168.18.102\scanned SA\";
                if (!Directory.Exists(networkFolderPath))
                {
                    Helper.MessageBoxError("The network folder does not exist or is unreachable.");
                    return;
                }

                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = networkFolderPath;
                    openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    openFileDialog.Title = "Select a PDF file";
                    openFileDialog.Multiselect = false;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start(openFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError($"Failed to open network folder: {ex.Message}");
            }
        }
    }
}
