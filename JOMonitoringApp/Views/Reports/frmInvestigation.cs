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
    public partial class frmInvestigation : Form
    {
        public frmInvestigation()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }
                                                        
        private void frmInvestigation_Load(object sender, EventArgs e)
        {
                                                                                                                
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            reportViewer1.LocalReport.ReportPath = $"{Application.StartupPath}\\RDLC\\investigation-form.rdlc";

            ReportParameter[] parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("paramCustomer", "ARCHIE SORIANO SALE");
            parameters[1] = new ReportParameter("paramAccountNumber", "192-0202-002-Z");
            parameters[2] = new ReportParameter("paramAddress", "BONIFACIO EXTENSION, SAN JOSE, PAGADIAN CITY");
            parameters[3] = new ReportParameter("paramNatureOfComplaint", "METER CALIBRATION");


            parameters[4] = new ReportParameter("paramComments", "Installation of new Meter.");
            parameters[5] = new ReportParameter("paramRecommendations", "Go! Go! Go! Na yan. For the change meter na ang ferson.");

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
