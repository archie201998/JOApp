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
    public partial class frmEstimateOfMaterials : Form
    {
        Dictionary<string, string> _fs = new Dictionary<string, string>();
        string _jobOrderNumber = string.Empty;  

        public frmEstimateOfMaterials(string jobOrderNumber)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _jobOrderNumber = jobOrderNumber;
            if (!string.IsNullOrEmpty(_jobOrderNumber))
            {
                txtJONo.Text = _jobOrderNumber;
                LoadReport();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            LoadReport();

        }

        private void LoadReport()
        {
            string jobNumber = txtJONo.Text;
            if (string.IsNullOrEmpty(jobNumber))
                return;

            var dictJODetails = Factory.JobOrdersRepository().GetViewRecordsByJONumber(Convert.ToInt32(jobNumber));

            reportViewer1.LocalReport.ReportPath = $"{Application.StartupPath}\\RDLC\\estimate-of-materials.rdlc";
            reportViewer1.LocalReport.EnableExternalImages = true;
            ReportParameter[] parameters = new ReportParameter[12];

            parameters[0] = new ReportParameter("paramCustomerName", dictJODetails["account_name"]);
            parameters[1] = new ReportParameter("paramCustomerContact", dictJODetails["contact_number"]);
            parameters[2] = new ReportParameter("paramCustomerAddress", dictJODetails["address"]);

            parameters[3] = new ReportParameter("paramJONumber", dictJODetails["job_order_no"]);
            parameters[4] = new ReportParameter("paramJODate", dictJODetails["date"].ToString());
            parameters[5] = new ReportParameter("paramPOSDate", dictJODetails["date"]);

            parameters[6] = new ReportParameter("paramAccomplishedBy", dictJODetails["accomplished_by"]);
            parameters[7] = new ReportParameter("paramMaterialsIssuedBy", dictJODetails["materials_issued_by"]);
            parameters[8] = new ReportParameter("paramParticulars", dictJODetails["particular"]);

            string accountNumber = string.IsNullOrEmpty(dictJODetails["account_number"]) ? string.Empty : dictJODetails["account_number"];
            
            parameters[9] = new ReportParameter("paramAccountNumber", accountNumber);

            //check if has meter number
            Dictionary<string, string> meterDict = Factory.CustomersRepository().GetCustomerMeterDetails(accountNumber);
            string meterNumber = meterDict.Count == 0 ? string.Empty : meterDict["MeterNumber"];
            parameters[10] = new ReportParameter("paramMeterNumber", meterNumber);
            parameters[11] = new ReportParameter("paramCustomerContact", dictJODetails["contact_number"]);

            // Set the data source\\
            var dtMaterialsFromDB = Factory.MaterialsRepository().GetRecords();
            var dtMaterials = new dsReport.dtMaterialsDataTable().Clone();

            foreach (DataRow dataRow in dtMaterialsFromDB.Rows)
            {
                var newRow = dtMaterials.NewRow();
                newRow["item"] = dataRow["material"];
                dtMaterials.Rows.Add(newRow);
            }

            ReportDataSource dataSource = new ReportDataSource("dsMaterials", dtMaterials);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dataSource);


            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;

            reportViewer1.RefreshReport();

        }

        private void frmEstimateOfMaterials_Load(object sender, EventArgs e)
        {

        }
    }
}
