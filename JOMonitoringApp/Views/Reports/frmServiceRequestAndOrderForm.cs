using AccountingSystem;
using JOMonitoringApp.Dataset;
using JOMonitoringApp.Views.JobOrder;
using Microsoft.Reporting.WinForms;
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
            txtJONoFrom.Text = _jobOrderNumber;
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
                if (string.IsNullOrEmpty(txtJONoFrom.Text))
                {
                    Helper.MessageBoxError("Please input J.O Number.");
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
                var dtJobOrders = Factory.JobOrdersRepository().GetViewRecordsByJONumber(int.Parse(txtJONoFrom.Text));
                List<ReportParameter> reportParameters1 = new List<ReportParameter>();
                progressCount += 10;
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                var userData = Helper.LoggedInUserData();
                reportParameters1.Add(new ReportParameter("paramSRNo", string.Empty));
                reportParameters1.Add(new ReportParameter("paramJOR", txtJONoFrom.Text));

                reportParameters1.Add(new ReportParameter("paramMRISNo", dtJobOrders["mris"].ToString()));
                reportParameters1.Add(new ReportParameter("paramMRSNo", dtJobOrders["mrs"].ToString()));
                reportParameters1.Add(new ReportParameter("paramWARNo", dtJobOrders["war"].ToString()));

                reportParameters1.Add(new ReportParameter("paramDate", DateTime.Now.ToString("MMMM, dd yyyy")));
                reportParameters1.Add(new ReportParameter("paramConcessionaire", dtJobOrders["account_name"].ToString()));
                reportParameters1.Add(new ReportParameter("paramAccountNumber", dtJobOrders["account_number"].ToString()));
                reportParameters1.Add(new ReportParameter("paramAddress", dtJobOrders["address"].ToString()));
                reportParameters1.Add(new ReportParameter("paramRequest", dtJobOrders["particular"].ToString()));
                reportParameters1.Add(new ReportParameter("paramReceivedBy", userData["user_full_name"].ToUpper()));
                reportParameters1.Add(new ReportParameter("paramWARNo", dtJobOrders["war"].ToUpper()));
                reportParameters1.Add(new ReportParameter("paramPerformedBy", dtJobOrders["accomplished_by"].ToUpper()));

                Dictionary<string, string> meterDict = Factory.CustomersRepository().GetCustomerMeterDetails(dtJobOrders["account_number"].ToString());
                reportParameters1.Add(new ReportParameter("paramMeterNumber", meterDict["MeterNumber"].ToString().ToUpper()));
                reportParameters1.Add(new ReportParameter("paramMeterSize", meterDict["MeterSize"].ToString().ToUpper()));
                reportParameters1.Add(new ReportParameter("paramMeterBrand", meterDict["MeterBrand"].ToString().ToUpper()));
                reportParameters1.Add(new ReportParameter("paramMeterReading", meterDict["LastReading"].ToString().ToUpper()));

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

     
    }
}
