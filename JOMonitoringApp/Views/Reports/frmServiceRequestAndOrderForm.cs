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
    public partial class frmServiceRequestAndOrderForm : Form
    {
        public frmServiceRequestAndOrderForm()
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
                LoadReport();
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
                var dtJobOrders = Factory.JobOrdersRepository().GetViewRecordsByJONumber(99985589);
                int totalProgressCount = tasks.Sum(t => t.Value) + dtJobOrders.Rows.Count;
                int progressCount = 0;


                // Initialize Parameters
                List<ReportParameter> reportParameters1 = new List<ReportParameter>();
                progressCount += tasks["Initialize Parameters"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                // Set Parameter Values
                var userData = Helper.LoggedInUserData();

                reportParameters1.Add(new ReportParameter("paramSRNo", "1241212"));
                reportParameters1.Add(new ReportParameter("paramJOR", "12313"));
                reportParameters1.Add(new ReportParameter("paramDate", "13241324"));
                reportParameters1.Add(new ReportParameter("paramWARNo", "1234"));
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

                localReport.ReportPath = $"{Application.StartupPath}\\RDLC\\service-request--and-order-form.rdlc";
                localReport.DataSources.Add(new ReportDataSource("dsRequisitionAndIssuSlip", parameters.dtJOSummary));
                localReport.SetParameters(parameters.reportParameters1);
                localReport.Refresh();

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.Refresh();
                ToogleRunButton(true);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

    }
}
