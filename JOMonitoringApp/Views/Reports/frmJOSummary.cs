using AccountingSystem;
using JOMonitoringApp.Dataset;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Reports
{
    public partial class frmJOStatusSummary : Form
    {
        int monthIndex;
        string particular;
        string statusFilter = "status = 4";



        public frmJOStatusSummary()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            panel3.Controls.Add(reportViewer1);
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnSearch.Text = isGenerated ? "Generate" : "Generating..";
            btnSearch.Enabled = isGenerated;
        }

        private void FrmJOSummary_Load(object sender, EventArgs e)
        {
            LoadMonths();
            LoadParticulars();
            CheckStatus();
        }

        private void LoadParticulars()
        {
            cmbxParticular.Items.Clear();
            var dtParticulars = Factory.ParticularsRepository().GetRecords();

            dtParticulars.Rows.Add(0, "All");
            cmbxParticular.DataSource = dtParticulars;
            cmbxParticular.DisplayMember = "particular";
            cmbxParticular.ValueMember = "id";

            particular = cmbxParticular.Text;
        }

        private void LoadMonths()
        {
            foreach (var item in Helper.MonthsDatasource().Values)
                cmbxMonth.Items.Add(item);
            cmbxMonth.SelectedIndex = DateTime.Now.Month - 1;

            monthIndex = cmbxMonth.SelectedIndex;
        }

        private void LoadReport()
        {
            try
            {
                if (!backgroundWorker1.IsBusy)
                {
                    progressBar1.Value = 0;
                    ToogleRunButton(false);
                    var date = new DateTime().Month;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.StackTrace); }
        }


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb1.Checked || cb2.Checked || cb3.Checked || cb4.Checked)
                {
                    LoadReport();
                    return;
                }
                Helper.MessageBoxError("Please select at least one status.");
                return; 
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Define tasks and their progress weights
                var tasks = new Dictionary<string, int>
                {
                    { "Initialize Parameters", 50 },
                    { "Set Parameter Values", 50 }
                };

                var dtJobOrderSummary = new dsReport.dtJobOrderSummaryDataTable().Clone();
                //var dtJobOrders = Factory.JobOrdersRepository().GetViewRecordsByMonth(monthIndex + 1);
                string orderBy = radJo.Checked ? radJo.Tag.ToString() : radDate.Tag.ToString();

                var dtJobOrders = Factory.JobOrdersRepository().GetViewRecordsBySearch(monthIndex + 1, particular, statusFilter, orderBy);

                int totalProgressCount = tasks.Sum(t => t.Value) + dtJobOrders.Rows.Count;
                int progressCount = 0;


                // Initialize Parameters
                List<ReportParameter> reportParameters1 = new List<ReportParameter>();
                progressCount += tasks["Initialize Parameters"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                // Set Parameter Values
                var userData = Helper.LoggedInUserData();

                reportParameters1.Add(new ReportParameter("paramPreparedBy", userData["user_full_name"].ToUpper()));
                reportParameters1.Add(new ReportParameter("paramRecommendingApproval", "CHRISTOPHER JASON R. CABABARO"));
                reportParameters1.Add(new ReportParameter("paramApproved", "ENG. VIVIEL MAY B. RAMIREZ"));
                reportParameters1.Add(new ReportParameter("paramMonth", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthIndex + 1)));
                progressCount += tasks["Set Parameter Values"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);


                foreach (DataRow dataRow in dtJobOrders.Rows)
                {

                    var newRow = dtJobOrderSummary.NewRow();
                    newRow["date"] = dataRow["date"];
                    newRow["job_order_no"] = dataRow["job_order_no"];
                    newRow["account_name"] = dataRow["account_name"];
                    newRow["account_number"] = dataRow["account_number"];
                    newRow["particular"] = dataRow["particular"];
                    newRow["status"] = dataRow["status"];

                    progressCount++;
                    dtJobOrderSummary.Rows.Add(newRow);
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                e.Result = (reportParameters1, dtJobOrders);
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

                var parameters = ((List<ReportParameter> reportParameters1, DataTable dtJOSummary))e.Result;

                reportViewer1.Clear();
                var localReport = reportViewer1.LocalReport;
                localReport.DataSources.Clear();

                localReport.ReportPath = $"{Application.StartupPath}\\RDLC\\job-order-summary.rdlc";
                localReport.DataSources.Add(new ReportDataSource("dsJOMonthlyReport", parameters.dtJOSummary));
                localReport.SetParameters(parameters.reportParameters1);
                localReport.Refresh();

                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;

                reportViewer1.Refresh();
                ToogleRunButton(true);

                lblRecordsCount.Text = parameters.dtJOSummary.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            monthIndex = cmbxMonth.SelectedIndex;
        }

        private void cmbxParticular_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbxParticular_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            particular = cmbxParticular.Text;   
        }

        private void label5_Click(object sender, EventArgs e)
        {


        }

        private void radJo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radDate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cb1_CheckedChanged(object sender, EventArgs e)
        {
            CheckStatus();
        }

        private void CheckStatus()
        {
            statusFilter = string.Empty;

            if (cb1.Checked)
                statusFilter += "status_id = 1";
            else
                RemoveFilter(ref statusFilter, "status_id = 1");

            if (cb2.Checked)
                statusFilter += (statusFilter == "" ? "" : " OR ") + "status_id = 2";
            else
                RemoveFilter(ref statusFilter, "status_id = 2");

            if (cb3.Checked)
                statusFilter += (statusFilter == "" ? "" : " OR ") + "status_id = 3";
            else
                RemoveFilter(ref statusFilter, "status_id = 3");

            if (cb4.Checked)
                statusFilter += (statusFilter == "" ? "" : " OR ") + "status_id = 4";
            else
                RemoveFilter(ref statusFilter, "status_id = 4");

        }
        void RemoveFilter(ref string filter, string condition)
        {
            if (filter.Contains(condition))
            {
                filter = filter.Replace(condition, "").Trim();
                if (filter.StartsWith("OR"))
                    filter = filter.Substring(3).Trim(); // Remove leading "OR"
            }
        }
    }
}
