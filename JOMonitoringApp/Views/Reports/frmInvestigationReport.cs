using AccountingSystem;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Reports
{
    public partial class frmInvestigationReport : Form
    {
        Dictionary<string, string> _dictInvestigation = new Dictionary<string, string>();

        public frmInvestigationReport(Dictionary<string, string> dictInvestigation)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _dictInvestigation = dictInvestigation; 

            txtJONo.Text = _dictInvestigation["job_order_no"]; 
        }
                                                        
        private void frmInvestigation_Load(object sender, EventArgs e)
        {
                                                                                                                
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtJONo.Text;
            reportViewer1.LocalReport.ReportPath = $"{Application.StartupPath}\\RDLC\\investigation-form.rdlc";
            reportViewer1.LocalReport.EnableExternalImages = true;
            ReportParameter[] parameters = new ReportParameter[18];
            parameters[0] = new ReportParameter("paramCustomer", _dictInvestigation["customer_name"]);
            parameters[1] = new ReportParameter("paramAccountNumber", _dictInvestigation["account_number"]);
            parameters[2] = new ReportParameter("paramAddress", _dictInvestigation["customer_address"]);
            parameters[3] = new ReportParameter("paramNatureOfComplaint", _dictInvestigation["nature_of_complaint"]);
            parameters[4] = new ReportParameter("paramComments", _dictInvestigation["investigator_comments"]);
            parameters[5] = new ReportParameter("paramRecommendations", _dictInvestigation["recommendations"]);

            parameters[6] = new ReportParameter("paramRelatives", _dictInvestigation["relatives"]);
            parameters[7] = new ReportParameter("paramHouseHelpers", _dictInvestigation["house_helper"]);
            parameters[8] = new ReportParameter("paramBoarders", _dictInvestigation["boarders"]);
            parameters[9] = new ReportParameter("paramOtherHHDependentsFromService", _dictInvestigation["immediate_members_of_fam"]);

            parameters[10] = new ReportParameter("paramMeterBrandAndSize", $"{_dictInvestigation["meter_brand"]} - {_dictInvestigation["meter_size"]} ");
            parameters[11] = new ReportParameter("paramMeterNumber", _dictInvestigation["meter_size"]);
            parameters[12] = new ReportParameter("paramReadingBeforeTest", _dictInvestigation["reading_before_test"]);
            parameters[13] = new ReportParameter("paramReadingAfterTest", _dictInvestigation["reading_after_test"]);
            parameters[14] = new ReportParameter("paramCalibrationResult", _dictInvestigation["calibration_result"]);
            parameters[15] = new ReportParameter("paramImmediateMembers", _dictInvestigation["immediate_members_of_fam"]);

            // Load image from file path
            string imagePath1 = @"\\192.168.18.183\InvestigationImages\Dacol\123.jpg";
            string imagePath2 = @"\\192.168.18.183\InvestigationImages\Dacol\456.png";
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
    }


}
