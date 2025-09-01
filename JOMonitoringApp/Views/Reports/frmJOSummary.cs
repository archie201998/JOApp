using AccountingSystem;
using JOMonitoringApp.Dataset;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Reports
{
    public partial class frmJOStatusSummary : Form
    {
        int monthIndex;
        string particular;
        string statusFilter = "status = 4";
        int particularID = 0;    


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
            LoadParticulars();
            CheckStatus();

            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

        }

        private void LoadParticulars()
        {
            cmbxParticular.Items.Clear();
            HelperLoadRecords.ParticularsCombobox(cmbxParticular);
            particular = cmbxParticular.Text;
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
                if (cbxPending.Checked || cbxProcessing.Checked || cbxCancelled.Checked || cbxAccomplished.Checked)
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

                int pending = 0, processing = 0, cancelled = 0, accomplished = 0, totalCount = 0;
                var tasks = new Dictionary<string, int>
                {
                    { "Initialize Parameters", 50 },
                    { "Set Parameter Values", 50 }
                };

                var dtJobOrderSummary = new dsReport.dtJobOrderSummaryDataTable().Clone();
                //var dtJobOrders = Factory.JobOrdersRepository().GetViewRecordsByMonth(monthIndex + 1);
                string orderBy = radJo.Checked ? radJo.Tag.ToString() : radDate.Tag.ToString();

                DateTime dateFrom = dtpFrom.Value;
                DateTime dateTo = dtpTo.Value;
                DataTable dtJobOrders;
                if (particularID == 0 || particularID == 100 || particularID == 101)
                {
                    dtJobOrders = Factory.JobOrdersRepository().GetViewRecordsBySearch(dateFrom, dateTo, particular, statusFilter, orderBy);
                }
                else
                    dtJobOrders = Factory.JobOrdersRepository().GetViewRecordsBySearch(dateFrom, dateTo, particularID, statusFilter, orderBy);

                int totalProgressCount = tasks.Sum(t => t.Value) + dtJobOrders.Rows.Count;
                int progressCount = 0;


                // Initialize Parameters
                List<ReportParameter> reportParameters1 = new List<ReportParameter>();
                progressCount += tasks["Initialize Parameters"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                // Set Parameter Values
                var userData = Helper.LoggedInUserData();

                reportParameters1.Add(new ReportParameter("paramPreparedBy", userData["user_full_name"].ToUpper()));
                reportParameters1.Add(new ReportParameter("paramRecommendingApproval", Helper.CSDHead));
                reportParameters1.Add(new ReportParameter("paramApproved", Helper.BranchManager));
                reportParameters1.Add(new ReportParameter("paramMonth", $"Period :  {dtpFrom.Value.ToString("MMMM dd, yyyy")} - {dtpTo.Value.ToString("MMMM dd, yyyy")}"));


                foreach (DataRow dataRow in dtJobOrders.Rows)
                {

                    var newRow = dtJobOrderSummary.NewRow();
                    newRow["date"] = dataRow["date"];
                    newRow["job_order_no"] = dataRow["job_order_no"];
                    newRow["mris"] = dataRow["mris"];
                    newRow["mrs"] = dataRow["mrs"];
                    newRow["war"] = dataRow["war"];
                    newRow["account_name"] = dataRow["account_name"];
                    newRow["account_number"] = dataRow["account_number"];
                    newRow["particular"] = dataRow["particular"];
                    newRow["status"] = dataRow["status"];

                    progressCount++;
                    dtJobOrderSummary.Rows.Add(newRow);
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                    if (dataRow["status_id"].ToString() == "1") pending += 1;
                    if (dataRow["status_id"].ToString() == "2") processing += 1;
                    if (dataRow["status_id"].ToString() == "3") cancelled += 1;
                    if (dataRow["status_id"].ToString() == "4") accomplished += 1;
                    totalCount += 1;

                }

                reportParameters1.Add(new ReportParameter("paramPending", pending.ToString()));
                reportParameters1.Add(new ReportParameter("paramProcessing", processing.ToString()));
                reportParameters1.Add(new ReportParameter("paramCancelled", cancelled.ToString()));
                reportParameters1.Add(new ReportParameter("paramAccomplished", accomplished.ToString()));
                reportParameters1.Add(new ReportParameter("paramTotal", totalCount.ToString()));


                progressCount += tasks["Set Parameter Values"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

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


        private void cmbxParticular_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbxParticular_SelectedIndexChanged_1(object sender, EventArgs e)
        {
             particularID = Convert.ToInt32(cmbxParticular.SelectedValue);
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

            if (cbxPending.Checked)
                statusFilter += "status_id = 1";
            else
                RemoveFilter(ref statusFilter, "status_id = 1");

            if (cbxProcessing.Checked)
                statusFilter += (statusFilter == "" ? "" : " OR ") + "status_id = 2";
            else
                RemoveFilter(ref statusFilter, "status_id = 2");

            if (cbxCancelled.Checked)
                statusFilter += (statusFilter == "" ? "" : " OR ") + "status_id = 3";
            else
                RemoveFilter(ref statusFilter, "status_id = 3");

            if (cbxAccomplished.Checked)
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

        private void cmbxParticular_SelectionChangeCommitted(object sender, EventArgs e)
        {
            particularID = Convert.ToInt32(cmbxParticular.SelectedValue);
        }

        private void cmbxParticular_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            particular = cmbxParticular.Text;
        }
    }
}
