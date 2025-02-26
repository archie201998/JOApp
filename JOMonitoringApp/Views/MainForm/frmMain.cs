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
                new DataColumn("job_orders_id", typeof (int)),
                new DataColumn("customers_id", typeof(int)),
                new DataColumn("date", typeof(DateTime)),
                new DataColumn("customers_account_number", typeof(string)),
                new DataColumn("customers_full_name", typeof(string)),
                new DataColumn("customers_address", typeof(string)),
                new DataColumn("particulars_id", typeof(int)),
                new DataColumn("particulars", typeof(string)),
                new DataColumn("or_number", typeof(string)),
                new DataColumn("amount", typeof(decimal)),
                new DataColumn("prepared_by_user_id", typeof(string)),
                new DataColumn("prepared_by_user_full_name", typeof(string)),
            };
        }

        private (string searchKey, bool showInactive, int rowFilter) LoadJobOrdersParameters()
        {
            string searchKey = txtSearch.Text.Trim();
            bool showInactive = cbxCancelled.Checked;
            int rowFilter = Convert.ToInt32(cmbxRowLimit.SelectedValue);

            return (searchKey, showInactive, rowFilter);
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
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
                    DateTime date = Convert.ToDateTime(row["date"]);
                    string accountNumber = $"{row["account_number"]}";
                    string accountName = $"{row["account_name"]}";
                    string address = $"{row["address"]}";
                    int particularId = Convert.ToInt32(row["particulars_id"]);
                    string particular = $"{row["particular"]}";
                    string orNumber = $"{row["or_number"]}";
                    decimal amount = string.IsNullOrEmpty(row["or_number"].ToString()) ? 0 : Convert.ToDecimal(row["amount"]);
                    int preparedById = Convert.ToInt32(row["prepared_by_id"]);
                    string preparedByName = $"{row["prepared_by"]}";

                    newRow["job_orders_id"] = id;
                    newRow["customers_id"] = customerId;
                    newRow["date"] = date;
                    newRow["customers_account_number"] = accountName;
                    newRow["customers_full_name"] = accountName;
                    newRow["customers_address"] = address;
                    newRow["particulars_id"] = particularId;
                    newRow["particulars"] = particular;
                    newRow["or_number"] = orNumber;
                    newRow["amount"] = amount;
                    newRow["prepared_by_user_id"] = preparedById;
                    newRow["prepared_by_user_full_name"] = preparedByName;

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
            //toolStripStatusLabelRecordCount.Text = dgTaxpayers.Rows.Count.ToString();
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
            LoadJobOrders();
            ucDashboardSummaryView.LoadJobOrdersSummary();
            Helper.EnableDisableButtons(dgJobOrders, btnUpdate, btnDelete);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            _ = new frmAddJobOrders(this).ShowDialog();
        }

    }
}
