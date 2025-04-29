using AccountingSystem;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Reports
{
    public partial class frmInvestigationReport : Form
    {

        private readonly int? _jobOrderId;
        private readonly string _jobOrderNumber = string.Empty;

        public frmInvestigationReport(int? jobOrderId, string jobOrderNumber)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            _jobOrderId = jobOrderId;
            _jobOrderNumber = jobOrderNumber;
        }

        private void frmInvestigation_Load(object sender, EventArgs e)
        {
            txtJONo.Text = _jobOrderNumber;

            if (!string.IsNullOrEmpty(txtJONo.Text))
                LoadReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                string jobOrderNumber = txtJONo.Text;

                reportViewer1.LocalReport.ReportPath = $"{Application.StartupPath}\\RDLC\\investigation-form-initial-print.rdlc";
                reportViewer1.LocalReport.EnableExternalImages = true;

                Dictionary<string, string> dictInvestigation = Factory.InvestigationRepository().GetViewRecordByJobOrderNo(jobOrderNumber);

                ReportParameter[] parameters = new ReportParameter[18];
                parameters[0] = new ReportParameter("paramCustomer", dictInvestigation["customer_name"]);
                parameters[1] = new ReportParameter("paramAccountNumber", dictInvestigation["account_number"]);
                parameters[2] = new ReportParameter("paramAddress", dictInvestigation["customer_address"]);
                parameters[3] = new ReportParameter("paramNatureOfComplaint", dictInvestigation["nature_of_complaint"]);
                parameters[4] = new ReportParameter("paramComments", dictInvestigation["investigator_comments"]);
                parameters[5] = new ReportParameter("paramRecommendations", dictInvestigation["recommendations"]);

                parameters[6] = new ReportParameter("paramRelatives", dictInvestigation["relatives"]);
                parameters[7] = new ReportParameter("paramHouseHelpers", dictInvestigation["house_helper"]);
                parameters[8] = new ReportParameter("paramBoarders", dictInvestigation["boarders"]);
                parameters[9] = new ReportParameter("paramOtherHHDependentsFromService", dictInvestigation["immediate_members_of_fam"]);

                parameters[10] = new ReportParameter("paramMeterBrandAndSize", $"{dictInvestigation["meter_brand"]} - {dictInvestigation["meter_size"]} ");
                parameters[11] = new ReportParameter("paramMeterNumber", dictInvestigation["meter_size"]);
                parameters[12] = new ReportParameter("paramReadingBeforeTest", dictInvestigation["reading_before_test"]);
                parameters[13] = new ReportParameter("paramReadingAfterTest", dictInvestigation["reading_after_test"]);
                parameters[14] = new ReportParameter("paramCalibrationResult", dictInvestigation["calibration_result"]);
                parameters[15] = new ReportParameter("paramImmediateMembers", dictInvestigation["immediate_members_of_fam"]);

                // Load image from file path
                string imagePath1 = dictInvestigation["image_path"];
                string imagePath2 = dictInvestigation["secondary_image_path"];
                if (File.Exists(imagePath1) || File.Exists(imagePath2))
                {  
                    parameters[16] = new ReportParameter("paramImage1", $"file:///{imagePath1}");
                    parameters[17] = new ReportParameter("paramImage2", $"file:///{imagePath2}");
                }
                else
                {
                    parameters[16] = new ReportParameter("paramImage1", string.Empty);
                    parameters[17] = new ReportParameter("paramImage2", string.Empty);
                }
                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Test " + ex.Message);
            }
            
        }
    }


}
