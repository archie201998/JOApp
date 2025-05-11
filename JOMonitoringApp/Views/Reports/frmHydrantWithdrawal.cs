
using AccountingSystem;
using JOMonitoringApp.Dataset;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Reports
{
    public partial class frmHydrantWithdrawal : Form
    {
        string _jobOrderNumber;

        public frmHydrantWithdrawal(string jobOrderNumber)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _jobOrderNumber = jobOrderNumber;   
            txtJONo.Text = jobOrderNumber;  
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                string jobNumber = txtJONo.Text;
                if (string.IsNullOrEmpty(jobNumber))
                    return;

                var dictJODetails = Factory.JobOrdersRepository().GetViewRecordsByJONumber(Convert.ToInt32(jobNumber));

                reportViewer1.LocalReport.ReportPath = $"{Application.StartupPath}\\RDLC\\hydrant-withdrawal.rdlc";
                reportViewer1.LocalReport.EnableExternalImages = true;

                ReportParameter[] parameters = new ReportParameter[7];

                parameters[0] = new ReportParameter("paramCSDHead", Helper.CSDHead);
                parameters[1] = new ReportParameter("paramCustomer", dictJODetails["account_name"]);
                parameters[2] = new ReportParameter("paramAddress", dictJODetails["address"]);
                parameters[3] = new ReportParameter("paramContact", dictJODetails["contact_number"]);
                parameters[4] = new ReportParameter("paramJONumber", dictJODetails["job_order_no"]);
                parameters[5] = new ReportParameter("paramAccountNumber", string.IsNullOrEmpty(dictJODetails["account_number"]) ? "-" : dictJODetails["account_number"]);
                parameters[6] = new ReportParameter("paramPrintFullPage", cbxFullPage.Checked.ToString());

                reportViewer1.LocalReport.DataSources.Clear();

                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;

                reportViewer1.RefreshReport();
            }
            catch (Exception)
            {
                Helper.MessageBoxError("Something went wrong. Please contact your system administrator.");
            }
           
        }

        private void frmHydrantWithdrawal_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_jobOrderNumber))
            {
                LoadReport();
            }
        }
    }
}
