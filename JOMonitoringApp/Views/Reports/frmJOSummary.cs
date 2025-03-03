using AccountingSystem;
using JOMonitoringApp.Dataset;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Reports
{
    public partial class frmJOSummary : Form
    {
        public frmJOSummary()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            panel3.Controls.Add(reportViewer1);
        }

        private void FrmJOSummary_Load(object sender, EventArgs e)
        {
            //LoadMonths();
        }



        private void LoadMonths()
        {
            foreach (var item in Helper.MonthsDatasource().Values)
                comboBox1.Items.Add(item);
            comboBox1.SelectedIndex = 1;
        }

        private void LoadReport()
        {
            try
            {
                if (!backgroundWorker1.IsBusy)
                {
                    progressBar1.Value = 0;
                    var date = new DateTime().Month;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.StackTrace); }
        }


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadReport();
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {// Define tasks and their progress weights
            var tasks = new Dictionary<string, int>
                {
                    { "Initialize Parameters", 50 },
                    { "Set Parameter Values", 50 }
                };

            var dtJobOrderSummary = new dsReport.dtJobOrderSummaryDataTable().Clone();
            var dtJobOrders = Factory.JobOrdersRepository().GetViewRecordsByMonth();
            int totalProgressCount = tasks.Sum(t => t.Value) + dtJobOrders.Rows.Count;
            int progressCount = 0;


            // Initialize Parameters
            List<ReportParameter> reportParameters1 = new List<ReportParameter>();
            progressCount += tasks["Initialize Parameters"];
            Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

            // Set Parameter Values
            var userData = Helper.LoggedInUserData();

            reportParameters1.Add(new ReportParameter("paramPreparedBy", userData["user_full_name"].ToUpper()));
            reportParameters1.Add(new ReportParameter("paramRecommendingApproval", userData["user_full_name"].ToUpper()));
            reportParameters1.Add(new ReportParameter("paramApproved", userData["user_full_name"].ToUpper()));
            reportParameters1.Add(new ReportParameter("paramMonth", DateTime.Now.Month.ToString()));
            progressCount += tasks["Set Parameter Values"];
            Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);


            foreach (DataRow dataRow in dtJobOrders.Rows)
            {
                var newRow = dtJobOrderSummary.NewRow();
                newRow["date"] = dataRow["date"];
                newRow["job_order_no"] = dataRow["job_order_no"];
                newRow["customer"] = dataRow["account_name"];
                newRow["account_number"] = dataRow["account_number"];
                newRow["particular"] = dataRow["particular"];
                newRow["status"] = dataRow["status"];

                progressCount++;
                dtJobOrderSummary.Rows.Add(newRow);
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
            }

            e.Result = (reportParameters1, dtJobOrders);
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
            var parameters = ((List<ReportParameter> reportParameters1, DataTable dtJOSummary))e.Result;

            reportViewer1.Clear();
            var localReport = reportViewer1.LocalReport;
            localReport.DataSources.Clear();

            localReport.ReportPath = $"{Application.StartupPath}\\RDLC\\job-order-summary.rdlc";
            localReport.DataSources.Add(new ReportDataSource("dsJOMonthlyReport", parameters.dtJOSummary));
            localReport.SetParameters(parameters.reportParameters1);
            localReport.Refresh();

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.FullPage;
            reportViewer1.Refresh();
            try
            {
               
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
