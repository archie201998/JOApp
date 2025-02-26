using AccountingSystem;
using JOMonitoringApp.Views.Dashboard;
using JOMonitoringApp.Views.JobOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.MainForm
{
    public partial class frmMain : Form
    {
        private readonly ucDashboardSummaryView ucDashboardSummaryView;
        public frmMain(frmSignIn frmSignIn)
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgJobOrders, true);
            Helper.LoadFormIcon(this);
            ucDashboardSummaryView = ucDashboardSummaryView1;
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
                new DataColumn("customers_id", typeof(int)),
                new DataColumn("particulars_id", typeof (int)),
                new DataColumn("prepared_by_id", typeof(int)),
                new DataColumn("materials_issued_by_id", typeof(int)),
                new DataColumn("materials_returned_to_id", typeof(int)),
                new DataColumn("status_id", typeof(int)),
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
                new DataColumn("materials_returned_to", typeof(string)),
                new DataColumn("status", typeof(string))

            };
        }

        private (string searchKey, bool showInactive, int rowFilter) LoadJobOrdersParameters()
        {
            string searchKey = txtSearch.Text.Trim();
            bool showInactive = cbxShowAll.Checked;
            int rowFilter = Convert.ToInt32(cmbxRowLimit.SelectedValue);

            return (searchKey, showInactive, rowFilter);
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var parameters = ((string searchKey, bool showInactive, int rowFilter))e.Argument;
            var dataTable = new DataTable();
            var dtJobOrders = Factory.JobOrdersRepository().GetViewRecordsByParameters(parameters.searchKey, parameters.showInactive, parameters.rowFilter);
            dataTable.Columns.AddRange(JobOrdersColumns());

            int progressCount = 0;
            int totalProgressCount = dtJobOrders.Rows.Count;

            if (dtJobOrders.Rows.Count < 1) { backgroundWorker1.ReportProgress(100); e.Result = dataTable; return; }

            foreach (DataRow row in dtJobOrders.Rows)
            {

                var newRow = dataTable.NewRow();
                int id = Convert.ToInt32(row["id"]);
                int customerId = Convert.ToInt32(row["customers_id"]);
                int particularId = Convert.ToInt32(row["particulars_id"]);
                int preparedById = Convert.ToInt32(row["prepared_by_id"]);
                int materialsIssuedById = string.IsNullOrEmpty(row["materials_issued_by_id"].ToString()) ? 0 : Convert.ToInt32(row["materials_issued_by_id"]); 
                int materialsReturnedToId = string.IsNullOrEmpty(row["materials_returned_to_id"].ToString()) ? 0 : Convert.ToInt32(row["materials_returned_to_id"]); 
                int statusId = Convert.ToInt32(row["status_id"]);
                DateTime date = Convert.ToDateTime(row["date"]);
                string accountNumber = $"{row["account_number"]}";
                string accountName = $"{row["account_name"]}";
                string address = $"{row["address"]}";
                string particular = $"{row["particular"]}";
                string orNumber = $"{row["or_number"]}";
                decimal amount = string.IsNullOrEmpty(row["or_number"].ToString()) ? 0 : Convert.ToDecimal(row["amount"]);
                string MRISNumber = $"{row["mris"]}";
                string MRSNumber = $"{row["mrs"]}";
                string WARNumber = $"{row["war"]}";
                string preparedBy = $"{row["prepared_by"]}";
                string materialsIssuedBy = $"{row["materials_issued_by"]}";
                string materialsReturnedTo = $"{row["materials_returned_to"]}";
                string status = $"{row["status"]}";

                newRow["id"] = id;
                newRow["customers_id"] = customerId;
                newRow["particulars_id"] = particularId;
                newRow["prepared_by_id"] = preparedById;
                newRow["materials_issued_by_id"] = materialsIssuedById;
                newRow["materials_returned_to_id"] = materialsReturnedToId;
                newRow["particulars_id"] = particularId;
                newRow["particular"] = particular;
                newRow["status_id"] = statusId;
                newRow["date"] = date;
                newRow["account_number"] = accountNumber;
                newRow["account_name"] = accountNumber;
                newRow["address"] = address;
                newRow["or_number"] = orNumber;
                newRow["amount"] = amount;
                newRow["mris"] = MRISNumber;
                newRow["mrs"] = MRSNumber;
                newRow["war"] = WARNumber;
                newRow["prepared_by"] = preparedBy;
                newRow["materials_issued_by"] = materialsIssuedBy;
                newRow["materials_returned_to"] = materialsReturnedTo;
                newRow["status"] = status;

                progressCount++;
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                dataTable.Rows.Add(newRow);
            }

            e.Result = dataTable;
            try
            {
                
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
        }

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
            ucDashboardSummaryView.LoadJobOrdersSummary();
            Dictionary<string, string> userDict = Helper.GetUserDataById(Helper.UserId);
            lblCurrentUser.Text = userDict["user_full_name"].ToString().ToUpper();
            LoadJobOrders();
            Helper.EnableDisableButtons(dgJobOrders, btnUpdate, btnDelete);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            _ = new frmAddJobOrders(this).ShowDialog();
        }

    }
}
