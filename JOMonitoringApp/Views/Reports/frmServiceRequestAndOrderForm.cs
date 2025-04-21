using AccountingSystem;
using JOMonitoringApp.Dataset;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.Investigation;
using JOMonitoringApp.Views.JobOrder;
using JOMonitoringApp.Views.PromptBox;
using Microsoft.Reporting.WinForms;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Reports
{
    public partial class frmServiceRequestAndOrderForm : Form
    {
        private string _jobOrderNumber;
        private int jobOrderId;
        public frmServiceRequestAndOrderForm(string jobOrderNumber)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            panel3.Controls.Add(reportViewer1);
            _jobOrderNumber = jobOrderNumber;
        }

        private void frmServiceRequestAndOrderForm_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void OnLoad()
        {
            txtJONumberFrom.Text = _jobOrderNumber;
            if (!string.IsNullOrEmpty(_jobOrderNumber)) LoadReport();
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
                if (string.IsNullOrEmpty(txtJONumberFrom.Text))
                {
                    Helper.MessageBoxSuccess("Please input J.O Number.");
                    return;
                }


                if (!Factory.JobOrdersRepository().JONumberExist(txtJONumberFrom.Text.Trim()))
                {
                    Helper.MessageBoxError("J.O Number does not exist.");
                    return;
                }
                LoadReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int totalProgressCount = 100;
                int progressCount = 0;

                var dtJobOrderSummary = new dsReport.dtJobOrderSummaryDataTable();

                //Bulk Printing
                int srofCount = 0;
                if (int.TryParse(txtJONumberTo.Text.Trim(), out int joNumberTo) && int.TryParse(txtJONumberFrom.Text.Trim(), out int joNumberFrom))
                    srofCount = joNumberTo - joNumberFrom;
                else
                    Helper.MessageBoxError("Invalid J.O Number format.");

                if (srofCount > 1)
                {
                    _ = new frmMessagePrompt().ShowDialog();
                }


                var dtJobOrders = Factory.JobOrdersRepository().GetViewRecordsByJONumber(int.Parse(txtJONumberFrom.Text));

                jobOrderId = Convert.ToInt32(dtJobOrders["id"].ToString());
                List<ReportParameter> reportParameters1 = new List<ReportParameter>();
                progressCount += 10;
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                var userData = Helper.LoggedInUserData();
                reportParameters1.Add(new ReportParameter("paramSRNo", string.Empty));
                reportParameters1.Add(new ReportParameter("paramJOR", txtJONumberFrom.Text));
                reportParameters1.Add(new ReportParameter("paramStatus", dtJobOrders["status"].ToString()));

                reportParameters1.Add(new ReportParameter("paramMRISNo", dtJobOrders["mris"].ToString()));
                reportParameters1.Add(new ReportParameter("paramMRSNo", dtJobOrders["mrs"].ToString()));
                reportParameters1.Add(new ReportParameter("paramWARNo", dtJobOrders["war"].ToString()));

                var receivedBy = Helper.GetUserDataById(Convert.ToInt32(dtJobOrders["prepared_by_id"].ToString()));
                reportParameters1.Add(new ReportParameter("paramDate", DateTime.Now.ToString("MMMM, dd yyyy")));
                reportParameters1.Add(new ReportParameter("paramConcessionaire", dtJobOrders["account_name"].ToString()));
                reportParameters1.Add(new ReportParameter("paramAccountNumber", dtJobOrders["account_number"].ToString()));
                reportParameters1.Add(new ReportParameter("paramContact", dtJobOrders["contact_number"].ToString()));
                reportParameters1.Add(new ReportParameter("paramAddress", dtJobOrders["address"].ToString()));
                reportParameters1.Add(new ReportParameter("paramRequest", dtJobOrders["particular"].ToString()));
                reportParameters1.Add(new ReportParameter("paramReceivedBy", receivedBy["user_full_name"].ToString().ToUpper()));
                reportParameters1.Add(new ReportParameter("paramWARNo", dtJobOrders["war"].ToUpper()));

                string dateActed = string.Empty;
                if (dtJobOrders["status_id"].ToString() == "4")
                    dateActed = dtJobOrders["updated_at"].ToString();

                reportParameters1.Add(new ReportParameter("paramDateActed", dateActed.ToString()));
                reportParameters1.Add(new ReportParameter("paramPerformedBy", dtJobOrders["accomplished_by"].ToUpper()));



                Dictionary<string, string> meterDict = Factory.CustomersRepository().GetCustomerMeterDetails(dtJobOrders["account_number"].ToString());
                if (meterDict.Count != 0)
                {
                    reportParameters1.Add(new ReportParameter("paramMeterNumber", meterDict["MeterNumber"].ToString().ToUpper()));
                    reportParameters1.Add(new ReportParameter("paramMeterSize", meterDict["MeterSize"].ToString().ToUpper()));
                    reportParameters1.Add(new ReportParameter("paramMeterBrand", meterDict["MeterBrand"].ToString().ToUpper()));
                    reportParameters1.Add(new ReportParameter("paramMeterReading", meterDict["LastReading"].ToString().ToUpper()));

                }

                progressCount += 90;
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                e.Result = (reportParameters1);
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

                List<ReportParameter> paramters = (List<ReportParameter>)e.Result;
                reportViewer1.Clear();
                var localReport = reportViewer1.LocalReport;
                localReport.DataSources.Clear();

                localReport.ReportPath = $"{Application.StartupPath}\\RDLC\\service-request-and-order-form.rdlc";
                localReport.DataSources.Add(new ReportDataSource("dsJOMonthlyReport", new DataTable()));
                localReport.SetParameters(paramters);
                localReport.Refresh();

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.Refresh();
                ToogleRunButton(true);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Allow only number input
            if (!char.IsControl((char)e.KeyCode) && !char.IsDigit((char)e.KeyCode))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtJONoFrom_TextChanged(object sender, EventArgs e)
        {
            txtJONumberTo.Text = txtJONumberFrom.Text;  
        }

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
        }

        private void reportViewer1_Print(object sender, ReportPrintEventArgs e)
        {

            bool setLogRest = Factory.JOLogsRepository().Insert(JOLogsModel());
        }

        internal JOLogsModel JOLogsModel()
        {
            return new JOLogsModel()
            {
                TransactionEvent = "Printed ",
                DateAndTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"),
                JobOrderId = jobOrderId,
                UserId = Helper.UserId
            };
        }
    }
}
