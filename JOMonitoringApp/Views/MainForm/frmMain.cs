using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.Dashboard;
using JOMonitoringApp.Views.JobOrder;
using JOMonitoringApp.Views.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.MainForm
{
    public partial class frmMain : Form
    {
        private readonly ucDashboardSummaryView ucDashboardSummaryView;
        private readonly ucJoborder ucJoborder;
        private int previousSelection = 0;

        private bool _autoPrint = false;

        public frmMain(frmSignIn frmSignIn)
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgJobOrders, true);
            Helper.LoadFormIcon(this);
            ucDashboardSummaryView = ucDashboardSummaryView1;
            ucJoborder = ucJoborder1;
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
                new DataColumn("customers_id", typeof(int)),
                new DataColumn("particulars_id", typeof (int)),
                new DataColumn("prepared_by_id", typeof(int)),
                new DataColumn("materials_issued_by_id", typeof(int)),
                new DataColumn("status_id", typeof(int)),
                new DataColumn("job_order_no", typeof(string)),
                new DataColumn("date", typeof(DateTime)),
                new DataColumn("account_number", typeof(string)),
                new DataColumn("account_name", typeof(string)),
                new DataColumn("address", typeof(string)),
                new DataColumn("particular", typeof(string)),
                new DataColumn("or_number", typeof(string)),
                new DataColumn("amount", typeof(decimal)),
                new DataColumn("mris", typeof(string)),
                new DataColumn("mrs", typeof(string)),
                new DataColumn("war", typeof(string)),
                new DataColumn("prepared_by", typeof(string)),
                new DataColumn("materials_issued_by", typeof(string)),

            };
        }

        private (string searchKey,int rowFilter, int statusId) LoadJobOrdersParameters()
        {
            string searchKey = txtSearch.Text.Trim();
            int rowFilter = Convert.ToInt32(cmbxRowLimit.SelectedValue);
            int statusId = Convert.ToInt32(cmbxStatus.SelectedValue);

            return (searchKey, rowFilter, statusId);
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((string searchKey, int rowFilter, int statusId))e.Argument;
                var dataTable = new DataTable();
                var dtJobOrders = Factory.JobOrdersRepository().GetViewRecordsByParameters(parameters.searchKey, parameters.rowFilter, parameters.statusId);
                dataTable.Columns.AddRange(JobOrdersColumns());

                int progressCount = 0;
                int totalProgressCount = dtJobOrders.Rows.Count;

                if (dtJobOrders.Rows.Count < 1) { backgroundWorker1.ReportProgress(100); e.Result = dataTable; return; }

                foreach (DataRow row in dtJobOrders.Rows)
                {

                    var newRow = dataTable.NewRow();
                    int id = Convert.ToInt32(row["id"]);
                    string status = $"{row["status"]}";
                    int customerId = Convert.ToInt32(row["customers_id"]);
                    int particularId = Convert.ToInt32(row["particulars_id"]);
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
                    string preparedBy = $"{row["prepared_by"]}";
                    string materialsIssuedBy = $"{row["materials_issued_by"]}";

                    newRow["id"] = id;
                    newRow["customers_id"] = customerId;
                    newRow["particulars_id"] = particularId;
                    newRow["prepared_by_id"] = preparedById;
                    newRow["materials_issued_by_id"] = materialsIssuedById;
                    newRow["particulars_id"] = particularId;
                    newRow["particular"] = particular;
                    newRow["status_id"] = statusId;
                    newRow["job_order_no"] = jobOrderNumber;
                    newRow["date"] = date;
                    newRow["account_number"] = accountNumber;
                    newRow["account_name"] = accountName;
                    newRow["address"] = address;
                    newRow["or_number"] = orNumber;
                    newRow["amount"] = amount;
                    newRow["mris"] = MRISNumber;
                    newRow["mrs"] = MRSNumber;
                    newRow["war"] = WARNumber;
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
            if (e.Cancelled)
                return;


            if (!(e.Result is DataTable))
                return;

            DataTable dataTable = (DataTable)e.Result;

            HelperLoadRecords.JobOrdersDataGridView(dgJobOrders, dataTable);
            dgJobOrders.CurrentCell = dgJobOrders.FirstDisplayedCell;
            lblRecordsCount.Text = dgJobOrders.Rows.Count.ToString();


            dgJobOrders.ClearSelection();
            dgJobOrders.Rows[previousSelection].Selected = true;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowLimit);
                HelperLoadRecords.StatusCombobox(cmbxStatus);
                Dictionary<string, string> userDict = Helper.GetUserDataById(Helper.UserId);
                lblCurrentUser.Text = userDict["user_full_name"].ToString().ToUpper();
                cmbxStatus.SelectedValue = 5;
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void OnLoad()
        {
            LoadJobOrders();
            ucDashboardSummaryView.LoadJobOrdersSummary();
            ucJoborder.OnLoad();

        }


        private void DgJobOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgJobOrders.Columns[e.ColumnIndex].Name == "status")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();
                    if (status == "PENDING")
                        e.CellStyle.BackColor = Color.Gold;
                    else if (status == "PROCESSING")
                    {
                        e.CellStyle.BackColor = Color.MediumSeaGreen;
                        e.CellStyle.ForeColor = Color.White;
                    }

                    else if (status == "CANCELLED")
                    {
                        e.CellStyle.BackColor = Color.IndianRed;
                        e.CellStyle.ForeColor = Color.White;
                    }
                    else if (status == "ACCOMPLISHED")
                    {
                        e.CellStyle.BackColor = Color.SteelBlue;
                        e.CellStyle.ForeColor = Color.White;
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (SoftDeleteJO())
                {
                    Helper.MessageBoxSuccess($"{dgJobOrders.SelectedRows.Count} Job order/s is successfully deleted.");
                    OnLoad();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

            ucJoborder.accountId = Convert.ToInt32(dictJobOrders["customers_id"]);
            ucJoborder.txtAccountName.Text = dictJobOrders["account_name"];
            ucJoborder.txtAccountNumber.Text = dictJobOrders["account_number"];
            ucJoborder.cbxNA.Checked = string.IsNullOrEmpty(dictJobOrders["account_number"]);
            ucJoborder.txtAddress.Text = dictJobOrders["address"];

            ucJoborder.txtJONumber.Text = dictJobOrders["job_order_no"];
            ucJoborder.cmbxParticulars.SelectedValue = Convert.ToInt32(dictJobOrders["particulars_id"]);
            ucJoborder.dtpDate.Value = Convert.ToDateTime(dictJobOrders["date"]);
            ucJoborder.txtMRISNumber.Text = dictJobOrders["mris"];
            ucJoborder.txtMRSNumber.Text = dictJobOrders["mrs"];
            ucJoborder.txtORNumber.Text = dictJobOrders["or_number"];
            ucJoborder.nudAmount.Value = string.IsNullOrEmpty(dictJobOrders["amount"].ToString()) ? 0 : Convert.ToDecimal(dictJobOrders["amount"]);
            ucJoborder.txtWARNumber.Text = dictJobOrders["war"];
            ucJoborder.cmbxMaterialsIssuedBy.SelectedValue = string.IsNullOrEmpty(dictJobOrders["materials_issued_by_id"]) ? -1 : Convert.ToInt32(dictJobOrders["materials_issued_by_id"]);
            ucJoborder.cmbxAccomplishedBy.SelectedValue = string.IsNullOrEmpty(dictJobOrders["accomplished_by_id"]) ? -1 : Convert.ToInt32(dictJobOrders["accomplished_by_id"]);

            int statusId = Convert.ToInt16(dictJobOrders["status_id"]);
            ucJoborder.radPending.Checked = (statusId == Convert.ToInt16(ucJoborder.radPending.Tag));
            ucJoborder.radProcessing.Checked = (statusId == Convert.ToInt16(ucJoborder.radProcessing.Tag));
            ucJoborder.radCancel.Checked = (statusId == Convert.ToInt16(ucJoborder.radCancel.Tag));
            ucJoborder.radAccomplished.Checked = (statusId == Convert.ToInt16(ucJoborder.radAccomplished.Tag));
        }

        

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ResetInputForm();

        }

        internal void ResetInputForm()
        {
            ucJoborder.accountId = 0;
            ucJoborder.txtAccountName.Clear();
            ucJoborder.txtAccountName.Focus();
            ucJoborder.txtAccountNumber.Clear();
            ucJoborder.txtAddress.Clear();

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
            btnSave.Text = "Save";
            ucJoborder.isUpdate = false;

            dgJobOrders.Enabled = true;
            dgJobOrders.ClearSelection();
            dgJobOrders.Rows[previousSelection].Selected = true;
        }

        private void ButtonSaveTrigger()
        {
          
            try
            {
                if (ucJoborder.isUpdate)
                {
                    if (UpdateData())
                    {
                        Helper.MessageBoxSuccess("Job Order details successfully updated.");
                        OnLoad();
                        ResetInputForm();
                    }
                }
                else
                {
                    if (SaveData())
                    {
                        Helper.MessageBoxSuccess("Job Order successfully created.");
                        OnLoad();

                        if (Helper.MessageBoxConfirmCancel("Do you want to print SROF for J.O Number? " + ucJoborder.txtJONumber.Text))
                        {
                            string joNumber = ucJoborder.txtJONumber.Text.Trim();
                            _ = new frmServiceRequestAndOrderForm(joNumber).ShowDialog();
                            return;
                        }
                        
                        ResetInputForm();   
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

            return Factory.JobOrdersRepository().Update(ucJoborder.JobOrderModel()) && Factory.CustomersRepository().Update(ucJoborder.CustomersModel());
        }


        #region Save Job orders
        internal bool SaveData()
        {
            if (!ucJoborder.ValidateChildren())
            {
                Helper.MessageBoxError(ucJoborder.GetFormErrors());
                return false;
            }

            if (Helper.MessageBoxConfirmCancel("Do you confirm to create J.O No. " + ucJoborder.txtJONumber.Text ))
            {
                if (ucJoborder.isNewAccount)
                {
                    Factory.CustomersRepository().Insert(ucJoborder.CustomersModel());
                }

                return Factory.JobOrdersRepository().Insert(ucJoborder.JobOrderModel());
            }

            return false;
        }


        #endregion

       
        private void TabPage2_Enter(object sender, EventArgs e)
        {
            ucDashboardSummaryView.LoadAndDisplaySummary(Convert.ToInt32(ucDashboardSummaryView.nudYear.Value), Convert.ToInt32(ucDashboardSummaryView.cmbxMonth.SelectedIndex));
        }

        private void DgJobOrders_DoubleClick(object sender, EventArgs e)
        {
            LoadSelectedData();
            dgJobOrders.Enabled = false;
            btnSave.Text = "Update";
            btnSave.BackColor = Color.OrangeRed;
            ucJoborder.isUpdate = true;
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
                ResetInputForm();
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
                if (dgJobOrders.Rows.Count == 0)
                    previousSelection = dgJobOrders.SelectedRows[0].Index;
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
