using AccountingSystem;
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

            ReportParameter[] parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("paramCustomer", _dictInvestigation["customer_name"]);
            parameters[1] = new ReportParameter("paramAccountNumber", _dictInvestigation["account_number"]);
            parameters[2] = new ReportParameter("paramAddress", _dictInvestigation["customer_address"]);
            parameters[3] = new ReportParameter("paramNatureOfComplaint", _dictInvestigation["nature_of_complaint"]);
            parameters[4] = new ReportParameter("paramComments", _dictInvestigation["investigator_comments"]);
            parameters[5] = new ReportParameter("paramRecommendations", _dictInvestigation["recommendations"]);

            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.RefreshReport();
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }

    }

}
