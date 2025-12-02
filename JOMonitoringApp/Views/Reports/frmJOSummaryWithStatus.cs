using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Model.GenericModel;
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

    public partial class frmJOSummaryWithStatus : Form
    {
        public frmJOSummaryWithStatus()
        {
            InitializeComponent();
        }

        private bool ValidateFilters()
        {
            string errorList = string.Empty;
            bool hasSelectedParticular = false;

            if (dtpStartingDate.Value.Date > dtpEndingDate.Value.Date)
                errorList += "* Starting date cannot be later than ending date." + Environment.NewLine;

            foreach (Control checkBoxes in gbxParticularStatus.Controls)
                    if (checkBoxes is CheckBox cb) 
                        if (cb.Checked) hasSelectedParticular = true;

            if (!hasSelectedParticular)
                errorList += "* Select at least one Particular Status." + Environment.NewLine;


            if (!string.IsNullOrEmpty(errorList))
            {
                Helper.MessageBoxSuccess("Please correct the following filter selections " + Environment.NewLine + Environment.NewLine + errorList);
                return false;
            }

            return true;
        }   

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!ValidateFilters()) return;


            LoadReport();
           
        }

        private void LoadReport()
        {
            var localReport = reportViewer1.LocalReport;
            localReport.DataSources.Clear();

            localReport.ReportPath = $"{Application.StartupPath}\\RDLC\\job-order-summary-with-status.rdlc";
            localReport.DataSources.Add(new ReportDataSource("dsJobOrderStatus", ReportDataSource()));

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;

            reportViewer1.Refresh();
        }

        private DataTable ReportDataSource()
        {
            var startingDate = dtpStartingDate.Value.Date;
            var endingDate = dtpEndingDate.Value.Date;
            string particular = cmbxParticular.Text;
            string status = string.Empty;
            string orderBy = Helper.GetSelectedRadioButton(radDate, radJOR, radParticulars);

            var parameters = new JobOrdersParticularsModel
            {
                StartingDate = startingDate,
                EndingDate = endingDate,
                Particular = particular,
                Status = status,
                OrderBy = orderBy,  
            };
            
            DataTable data = Factory.JobOrderParticularsRepository().GetJOSummary(parameters);

            var accounts = data.AsEnumerable()
                .Select(row => row.Field<string>("account_number"))
                .Distinct()
                .ToList();

            string accountNumbers = string.Join(",", accounts);

            DataTable dtChangeMeter = Factory.CustomersRepository().GetChangeMeterDetails("045-302-383-0");

           
            return data;
        }




        private void frmJOSummaryWithStatus_Load(object sender, EventArgs e)
        {

        }

        private void cmbxParticular_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
