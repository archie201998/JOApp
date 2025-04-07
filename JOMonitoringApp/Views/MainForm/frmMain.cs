using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.Dashboard;
using JOMonitoringApp.Views.Investigation;
using JOMonitoringApp.Views.JobOrder;
using JOMonitoringApp.Views.Particulars;
using JOMonitoringApp.Views.PromptBox;
using JOMonitoringApp.Views.Reports;
using JOMonitoringApp.Views.RolesAndPermissions;
using JOMonitoringApp.Views.Users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.MainForm
{
    public partial class frmMain : Form
    {
        private readonly ucDashboardSummaryView ucDashboardSummaryView;
        private readonly ucJoborder ucJoborder;
        private readonly ucInvestigationForm ucInvestigationForm;
        private int previousSelection = 0;
        private List<Keys> keySequence = new List<Keys>();

        public frmMain(frmSignIn frmSignIn)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgJobOrders, true);
            ucDashboardSummaryView = ucDashboardSummaryView1;
            ucJoborder = ucJoborder1;
            ucInvestigationForm = ucInvestigation1;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadJobOrders()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync(LoadJobOrdersParameters());
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
                new DataColumn("remarks", typeof(string)),
                new DataColumn("date", typeof(DateTime)),
                new DataColumn("prepared_by", typeof(string)),
                new DataColumn("materials_issued_by", typeof(string)),

            };
        }
                                            
        private (string searchKey,int rowFilter, int statusId, string particular) LoadJobOrdersParameters()
        {
            string searchKey = txtSearch.Text.Trim();
            int rowFilter = Convert.ToInt32(cmbxRowLimit.SelectedValue);
            int statusId = Convert.ToInt32(cmbxStatus.SelectedValue);
            string particular = cmbxParticulars.Text;

            return (searchKey, rowFilter, statusId, particular);
        }
                                                    
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((string searchKey, int rowFilter, int statusId, string particular))e.Argument;
                var dataTable = new DataTable();
                var dtJobOrders = Factory.JobOrdersRepository().GetViewRecordsByParameters(parameters.searchKey, parameters.rowFilter, parameters.statusId, parameters.particular);
                dataTable.Columns.AddRange(JobOrdersColumns());

                int progressCount = 0;
                int totalProgressCount = dtJobOrders.Rows.Count;

                if (dtJobOrders.Rows.Count < 1) { backgroundWorker1.ReportProgress(100); e.Result = dataTable; return; }

                foreach (DataRow row in dtJobOrders.Rows)
                {

                    var newRow = dataTable.NewRow();
                    int id = Convert.ToInt32(row["id"]);
                    string status = $"{row["status"]}";
                    int preparedById = Convert.ToInt32(row["prepared_by_id"]);
                    int materialsIssuedById = string.IsNullOrEmpty(row["materials_issued_by_id"].ToString()) ? 0 : Convert.ToInt32(row["materials_issued_by_id"]);
                    int statusId = Convert.ToInt32(row["status_id"]);
                    DateTime date = Convert.ToDateTime(row["date"]);
                    string accountNumber = $"{row["account_number"]}";
                    string accountName = $"{row["account_name"]}";
                    string address = $"{row["address"]}";
                    string jobOrderNumber = $"{row["job_order_no"]}";
                    string particular = $"{row["particular"]}";
                    string orNumber = $"{row["or_number"]}";
                    decimal amount = string.IsNullOrEmpty(row["or_number"].ToString()) ? 0 : Convert.ToDecimal(row["amount"]);
                    string MRISNumber = $"{row["mris"]}";
                    string MRSNumber = $"{row["mrs"]}";
                    string WARNumber = $"{row["war"]}";
                    string remarks = $"{row["remarks"]}";
                    string preparedBy = $"{row["prepared_by"]}";
                    string materialsIssuedBy = $"{row["materials_issued_by"]}";

                    newRow["id"] = id;
                    newRow["prepared_by_id"] = preparedById;
                    newRow["materials_issued_by_id"] = materialsIssuedById;
                    newRow["particular"] = particular;
                    newRow["status_id"] = statusId;
                    newRow["job_order_no"] = jobOrderNumber;
                    newRow["account_number"] = accountNumber;
                    newRow["account_name"] = accountName;
                    newRow["address"] = address;
                    newRow["or_number"] = orNumber;
                    newRow["amount"] = amount;
                    newRow["mris"] = MRISNumber;
                    newRow["mrs"] = MRSNumber;
                    newRow["war"] = WARNumber;
                    newRow["remarks"] = remarks;
                    newRow["date"] = date;
                    newRow["prepared_by"] = preparedBy;
                    newRow["materials_issued_by"] = materialsIssuedBy;
                    newRow["status"] = status.ToUpper();
                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                    dataTable.Rows.Add(newRow);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                    return;


                if (!(e.Result is DataTable))
                    return;

                DataTable dataTable = (DataTable)e.Result;

                HelperLoadRecords.JobOrdersDataGridView(dgJobOrders, dataTable);
                dgJobOrders.CurrentCell = dgJobOrders.FirstDisplayedCell;
                lblRecordsCount.Text = dgJobOrders.Rows.Count.ToString();

                dgJobOrders.Rows[previousSelection].Selected = true;

            }
            catch (Exception)
            {

            }
            
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowLimit);
                HelperLoadRecords.StatusCombobox(cmbxStatus);

                var dtParticulars = Factory.ParticularsRepository().GetRecords();   
                HelperLoadRecords.ParticularsCombobox(cmbxParticulars, dtParticulars, "id" , "particular");


                Dictionary<string, string> userDict = Helper.GetUserDataById(Helper.UserId);
                lblCurrentUser.Text = userDict["user_full_name"].ToString().ToUpper();
                lblUserRole.Text = userDict["role_name"].ToString().ToUpper();  
                cmbxStatus.SelectedValue = 5;
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void OnLoad()
        {
            LoadJobOrders();
            ucJoborder.OnLoad();

            //if user is not investigator=> disable investigation menu
            btnCreateInvestigationForm.Visible = Helper.IsInvestigator();

            ValidatePermissions();

        }

        private void ValidatePermissions()
        {
            ucJoborder.gbAccountDetails.Enabled = Helper.UserHasPermission("ADD_ACCOUNT_DETAILS");
            ucJoborder.gbJODetails.Enabled = Helper.UserHasPermission("ADD_JOB_ORDER_DETAILS");
            ucJoborder.gbJODetails.Enabled = Helper.UserHasPermission("ADD_ISSUANCE_AND_JOB_ASSIGNMENT");
            ucJoborder.radPending.Enabled = Helper.UserHasPermission("ADD_STATUS");
            ucJoborder.radProcessing.Enabled = Helper.UserHasPermission("ADD_STATUS");
            ucJoborder.radAccomplished.Enabled = Helper.UserHasPermission("ADD_STATUS");
            ucJoborder.radAccomplished.Enabled = Helper.UserHasPermission("ADD_STATUS");
            ucJoborder.txtRemarks.Enabled = Helper.UserHasPermission("ADD_REMARKS");
        }

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

        private void JOSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmJOStatusSummary().ShowDialog();
        }

        private void LogoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool res = Helper.MessageBoxConfirmCancel("Do you want to log-out your account?");
            if (res)
            {
                Close();
                Helper.UserId = 0;
                _ = new frmSignIn().ShowDialog();
            }
            return;
        }

        private bool SoftDeleteJO()
        {
            var jobOrderModelList = new List<JobOrdersModel>();
            int rowCount = dgJobOrders.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(rowCount))
            {
                foreach (DataGridViewRow row in dgJobOrders.SelectedRows)
                {
                    int jobOrderId = Convert.ToInt32(row.Cells["id"].Value);
                    int deletedBy = Helper.UserId;

                    var model = new JobOrdersModel() { ID = jobOrderId, DeletedBy = deletedBy };
                    jobOrderModelList.Add(model);
                }

                return Factory.JobOrdersRepository().SoftDeleteJOById(jobOrderModelList);
            }

            return false;
        }

        private void LoadSelectedData()
        {
            int selectedJobOrderId = Convert.ToInt32(dgJobOrders.SelectedRows[0].Cells["id"].Value);
            ucJoborder.jobOrderId = selectedJobOrderId;

            Dictionary<string, string> dictJobOrders = Factory.JobOrdersRepository().GetRecordByID(selectedJobOrderId);
            if (dictJobOrders.Count == 0) return;

            ucJoborder.txtAccountName.Text = dictJobOrders["account_name"];
            ucJoborder.txtAccountNumber.Text = dictJobOrders["account_number"];
            ucJoborder.cbxNA.Checked = string.IsNullOrEmpty(dictJobOrders["account_number"]);
            ucJoborder.txtAddress.Text = dictJobOrders["address"];
            ucJoborder.txtContact.Text = dictJobOrders["contact_number"];

            char[] delimiters = new char[] { '\\' };
            string[] particulars = dictJobOrders["particular"].ToString().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);


            foreach (var item in particulars)
            {
                for (int i = 0; i < ucJoborder.clBoxParticulars.Items.Count; i++)
                {
                    if (ucJoborder.clBoxParticulars.Items[i].ToString().Trim() == item.Trim())
                    {
                        ucJoborder.clBoxParticulars.SetItemChecked(i, true);
                        break;
                    }
                }
            }

            char[] delimiter = new char[] { '-' };
            string[] accountNumber = dictJobOrders["account_number"].ToString().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            bool noAccountNumber = string.IsNullOrEmpty(dictJobOrders["account_number"].ToString());

            ucJoborder.txtAcc1.Text = noAccountNumber ? string.Empty : accountNumber[0];
            ucJoborder.txtAcc2.Text = noAccountNumber ? string.Empty : accountNumber[1];
            ucJoborder.txtAcc3.Text = noAccountNumber ? string.Empty : accountNumber[2];
            ucJoborder.txtAcc4.Text = noAccountNumber ? string.Empty : accountNumber[3];

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

            int statusId = Convert.ToInt16(dictJobOrders["status_id"]);
            ucJoborder.radPending.Checked = (statusId == Convert.ToInt16(ucJoborder.radPending.Tag));
            ucJoborder.radProcessing.Checked = (statusId == Convert.ToInt16(ucJoborder.radProcessing.Tag));
            ucJoborder.radCancel.Checked = (statusId == Convert.ToInt16(ucJoborder.radCancel.Tag));
            ucJoborder.radAccomplished.Checked = (statusId == Convert.ToInt16(ucJoborder.radAccomplished.Tag));

            if (ucJoborder.radAccomplished.Checked)
            {
                ucJoborder.groupBox4.Enabled = false;
                ucJoborder.gbAccountDetails.Enabled = false;
                ucJoborder.gbIssuanceAndAssignment.Enabled = false;
                ucJoborder.gbJODetails.Enabled = false;
            }
            

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ResetInputForm();
        }

        internal void ResetInputForm()
        {
            ucJoborder.txtJONumber.Clear();
            ucJoborder.dtpDate.Value = DateTime.Now;
            ucJoborder.txtMRISNumber.Clear();
            ucJoborder.txtMRSNumber.Clear();
            ucJoborder.txtORNumber.Clear();
            ucJoborder.nudAmount.Value = 0;
            ucJoborder.txtWARNumber.Clear();

            ucJoborder.cmbxMaterialsIssuedBy.SelectedValue = -1;
            ucJoborder.cmbxAccomplishedBy.SelectedValue = -1;

            ucJoborder.jobOrderId = 0;
            ucJoborder.statusId = 1;
            ucJoborder.radPending.Checked = true;
            ucJoborder.isNewAccount = true;

            btnSave.BackColor = Color.DodgerBlue;
            btnSave.Text = "Save [Ctrl + S]";
            ucJoborder.isUpdate = false;

            dgJobOrders.Enabled = true;
            ucJoborder.errorProvider1.Clear();

            ucJoborder.txtAcc1.Clear();
            ucJoborder.txtAcc2.Clear();
            ucJoborder.txtAcc3.Clear();
            ucJoborder.txtAcc4.Clear();
            ucJoborder.txtRemarks.Clear();

            ucJoborder.groupBox4.Enabled = true;
            ucJoborder.gbAccountDetails.Enabled = true;
            ucJoborder.gbIssuanceAndAssignment.Enabled = true;
            ucJoborder.gbJODetails.Enabled = true;


            for (int i = 0; i < ucJoborder.clBoxParticulars.Items.Count; i++)
                ucJoborder.clBoxParticulars.SetItemChecked(i, false);

            ucJoborder.accountId = 0;
            ucJoborder.txtAccountName.Clear();
            ucJoborder.txtAccountName.Focus();
            ucJoborder.txtAccountNumber.Clear();
            ucJoborder.txtAddress.Clear();
            ucJoborder.txtContact.Clear();
            //dgJobOrders.ClearSelection();

        }

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
                return ;
            }
        }
   
        private void ButtonSaveTrigger()
        {
            try
            {
                if (ucJoborder.isUpdate)
                {
                    if (UpdateData())
                    {
                        LogJOTransaction();
                        OnLoad();
                        Helper.MessageBoxSuccess("Job Order details successfully updated.");
                        ResetInputForm();
                        return;
                    }
                }
                else
                {
                    if (SaveData())
                    {
                        LogJOTransaction();
                        OnLoad();
                        Helper.MessageBoxSuccess("Job Order successfully created.");
                        ResetInputForm();

                        //temporary disabled    
                        //if (Helper.MessageBoxConfirmCancel("Do you want to print SROF for J.O Number? " + ucJoborder.txtJONumber.Text))
                        //{
                        //    string joNumber = ucJoborder.txtJONumber.Text.Trim();
                        //    _ = new frmServiceRequestAndOrderForm(joNumber).ShowDialog();
                        //    return;
                        //}
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            ButtonSaveTrigger();
        }


        private bool UpdateData()
        {

            if (!ucJoborder.ValidateChildren())
            {
                Helper.MessageBoxError(ucJoborder.GetFormErrors());
                return false;
            }

            if (ucJoborder.HasDataChanged())
               return Factory.JobOrdersRepository().Update(ucJoborder.JobOrderModel());

            else
            {
                // No changes detected
                Helper.MessageBoxSuccess("No changes detected.");
                return false;
            }
        }

        private bool CheckPossibleDuplicateEntry()
        {
            string accountNumber = ucJoborder.txtAcc1.Text + "-" + ucJoborder.txtAcc2.Text + "-" + ucJoborder.txtAcc3.Text + "-" + ucJoborder.txtAcc4.Text;
            string particulars = string.Join("\\", ucJoborder.clBoxParticulars.CheckedItems.Cast<string>().ToArray());

            bool recordFound =  Factory.JobOrdersRepository().CheckPossibleDuplicate(accountNumber, particulars);

            if (recordFound)
                if (Helper.MessageBoxConfirmCancel("Similar Job Order Details are found in the record. Do you want to proceed?"))
                    return true;
                else
                    return false;

            return true;
        }

        #region Save Job orders
        internal bool SaveData()
        {
            if (!ucJoborder.ValidateChildren())
            {
                Helper.MessageBoxError(ucJoborder.GetFormErrors());
                return false;
            }

            if (CheckPossibleDuplicateEntry())
            {
                if (Helper.MessageBoxConfirmCancel("Do you confirm to create J.O No. " + ucJoborder.txtJONumber.Text))
                {
                    return Factory.JobOrdersRepository().Insert(ucJoborder.JobOrderModel());
                }
            }
            return false;


        }
        #endregion

        private void TabPage2_Enter(object sender, EventArgs e)
        {
            
        }

        private void UpdateSettings()
        {
            dgJobOrders.Enabled = false;
            btnSave.Text = "Save [Ctrl + S]";
            btnSave.BackColor = Color.OrangeRed;
            ucJoborder.isUpdate = true;
            previousSelection = dgJobOrders.SelectedRows[0].Index;
        }

        private void DgJobOrders_DoubleClick(object sender, EventArgs e)
        {
            if (dgJobOrders.Rows.Count == 0) return;

            //SetPermissions();
            UpdateSettings();
            LoadSelectedData();
            ucJoborder.StoreOriginalValues();
        }

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

            if (keySequence.SequenceEqual(new List<Keys> { Keys.D2, Keys.D8, Keys.D4, Keys.D6, Keys.F4, Keys.F4 }))
            {
                ucJoborder.groupBox4.Enabled = true;
                ucJoborder.gbAccountDetails.Enabled = true;
                ucJoborder.gbIssuanceAndAssignment.Enabled = true;
                ucJoborder.gbJODetails.Enabled = true;
                keySequence.Clear();
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

        private void dgJobOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmMain_FormClosing_1(object sender, FormClosingEventArgs e)
        {
           DialogResult result = MessageBox.Show("Are you sure you want to exit?",
                                         "Confirm Exit",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.No)
                e.Cancel = true; 
        }

        private void jOTrackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmJOProgressTracking().ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmUsers().ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void investigationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmInvestigationReport(null).ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                using (var ping = new System.Net.NetworkInformation.Ping())
                {
                    var reply = ping.Send("192.168.18.183");
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

        private void button2_Click(object sender, EventArgs e)
        {
            _ = new frmMessagePrompt().ShowDialog();
            //if (dgJobOrders.SelectedRows.Count > 0)
            //{
            //    int selectedIndex = dgJobOrders.SelectedRows[0].Index;
            //    if (selectedIndex >= 0)
            //    {

            //        string jobOrderNumber = dgJobOrders.Rows[selectedIndex].Cells["job_order_no"].Value.ToString();
            //        string accountName = dgJobOrders.Rows[selectedIndex].Cells["account_name"].Value.ToString();
            //        string accountNumber = dgJobOrders.Rows[selectedIndex].Cells["account_number"].Value.ToString();
            //        string customerAddress = dgJobOrders.Rows[selectedIndex].Cells["address"].Value.ToString();
            //        string remarks = dgJobOrders.Rows[selectedIndex].Cells["remarks"].Value.ToString();

            //        ucInvestigationForm._jobOrderId = Convert.ToInt32(dgJobOrders.Rows[selectedIndex].Cells["id"].Value);
            //        ucInvestigationForm.txtAccountName.Text = accountName;
            //        ucInvestigationForm.txtAccountNumber.Text = accountNumber;
            //        ucInvestigationForm.txtJORemarks.Text = remarks;
            //        ucInvestigationForm._customerAddress = customerAddress;
            //        ucInvestigationForm.txtJONumber.Text = jobOrderNumber;

            //        // Change the tab focus to the next tab
            //        int nextTabIndex = (tabControl1.SelectedIndex + 1) % tabControl1.TabCount;
            //        tabControl1.SelectedIndex = nextTabIndex;
            //    }
            //}
        }

        private void particularsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmParticulars().ShowDialog();  
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.MdiParent = this;

        }

        private void rolesAndPermissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmRolesAndPermissions().ShowDialog();
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            _ = new frmMessagePrompt().ShowDialog();
            tabControl1.SelectedTab = tabPage1;
        }
    }
}
