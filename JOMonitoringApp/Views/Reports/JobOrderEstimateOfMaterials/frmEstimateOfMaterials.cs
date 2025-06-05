using AccountingSystem;
using JOMonitoringApp.Dataset;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Reports
{
    public partial class frmEstimateOfMaterials : Form
    {
        string _jobOrderNumber = string.Empty;  

        public frmEstimateOfMaterials(string jobOrderNumber)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _jobOrderNumber = jobOrderNumber;

            if (!string.IsNullOrEmpty(jobOrderNumber))
            {
                txtJONo.Text = jobOrderNumber;
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
            ReportParameter[] parameters = new ReportParameter[19];
            var receivedBy = Helper.GetUserDataById(Convert.ToInt32(dictJODetails["prepared_by_id"].ToString()));

            parameters[0] = new ReportParameter("paramCustomerName", dictJODetails["account_name"]);
            parameters[1] = new ReportParameter("paramCustomerContact", dictJODetails["contact_number"]);
            parameters[2] = new ReportParameter("paramCustomerAddress", dictJODetails["address"]);

            parameters[3] = new ReportParameter("paramJONumber", dictJODetails["job_order_no"]);
            parameters[4] = new ReportParameter("paramJODate", dictJODetails["date"].ToString());
            parameters[5] = new ReportParameter("paramPOSDate", dictJODetails["date"]);

            parameters[6] = new ReportParameter("paramAccomplishedBy", dictJODetails["accomplished_by"]);
            parameters[7] = new ReportParameter("paramParticulars", dictJODetails["particular"]);
            parameters[8] = new ReportParameter("paramReceivedBy", receivedBy["user_full_name"].ToString());



            //duplicate
            parameters[9] = new ReportParameter("paramCustomerName_", dictJODetails["account_name"]);
            parameters[10] = new ReportParameter("paramCustomerContact_", dictJODetails["contact_number"]);
            parameters[11] = new ReportParameter("paramCustomerAddress_", dictJODetails["address"]);

            parameters[12] = new ReportParameter("paramJONumber_", dictJODetails["job_order_no"]);
            parameters[13] = new ReportParameter("paramJODate_", dictJODetails["date"].ToString());
            parameters[14] = new ReportParameter("paramPOSDate_", dictJODetails["date"]);

            parameters[15] = new ReportParameter("paramAccomplishedBy_", dictJODetails["accomplished_by"]);
            parameters[16] = new ReportParameter("paramParticulars_", dictJODetails["particular"]);
            parameters[17] = new ReportParameter("paramReceivedBy_", receivedBy["user_full_name"].ToString());
            parameters[18] = new ReportParameter("paramFullPagePrint", cbxFullPage.Checked.ToString());


            //string accountNumber = string.IsNullOrEmpty(dictJODetails["account_number"]) ? string.Empty : dictJODetails["account_number"];

            //check if has meter number
            //Dictionary<string, string> meterDict = Factory.CustomersRepository().GetCustomerMeterDetails(accountNumber);
            //string meterNumber = meterDict.Count == 0 ? string.Empty : meterDict["MeterNumber"];
            //parameters[10] = new ReportParameter("paramMeterNumber", meterNumber);
            //parameters[11] = new ReportParameter("paramCustomerContact", dictJODetails["contact_number"]);

            // Set the data source\\
            var dtTappingMaterials = Factory.MaterialsRepository().GetTappingDefaultMaterials();
            var dtMaterials = new dsReport.dtMaterialsDataTable().Clone();

            foreach (DataRow dataRow in dtTappingMaterials.Rows)
            {
                var newRow = dtMaterials.NewRow();
                newRow["item"] = dataRow["item_name"];
                newRow["qty"] = dataRow["item_quantity"];
                newRow["unit_cost"] = dataRow["item_quantity"] != DBNull.Value && Convert.ToDecimal(dataRow["item_quantity"]) != 0
    ? (Convert.ToDecimal(dataRow["item_cost"]) / Convert.ToDecimal(dataRow["item_quantity"])).ToString()
    : "0";
                newRow["amount"] = Convert.ToDecimal(dataRow["item_cost"]);

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
