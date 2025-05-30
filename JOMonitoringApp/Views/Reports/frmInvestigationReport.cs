using AccountingSystem;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Reports
{
    public partial class frmInvestigationReport : Form
    {

        private readonly int? _jobOrderId;
        private readonly string jobOrderNumber = string.Empty;

        public frmInvestigationReport(int? jobOrderId, string jobOrderNumber)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            _jobOrderId = jobOrderId;
            this.jobOrderNumber = jobOrderNumber;
        }

        private void frmInvestigation_Load(object sender, EventArgs e)
        {
            txtJONo.Text = jobOrderNumber;

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

                reportViewer1.LocalReport.ReportPath = $"{Application.StartupPath}\\RDLC\\investigation-form.rdlc";
                reportViewer1.LocalReport.EnableExternalImages = true;

                Dictionary<string, string> dictInvestigation = Factory.InvestigationRepository().GetViewRecordByJobOrderNo(jobOrderNumber);

                if (dictInvestigation.Count == 0)
                {
                    Helper.MessageBoxSuccess("Investigation data unavailable. awaiting input from investigator or not applicable.");
                    Close();
                    return;
                }

                ReportParameter[] parameters = new ReportParameter[28];
                parameters[0] = new ReportParameter("paramCustomer", dictInvestigation["customer_name"]);
                parameters[1] = new ReportParameter("paramAccountNumber", dictInvestigation["account_number"]);
                parameters[2] = new ReportParameter("paramAddress", dictInvestigation["customer_address"]);
                parameters[3] = new ReportParameter("paramNatureOfComplaint", dictInvestigation["nature_of_complaint"]);
                parameters[4] = new ReportParameter("paramComments", dictInvestigation["investigator_comments"]);
                parameters[5] = new ReportParameter("paramRecommendations", dictInvestigation["recommendations"]);

                int investigationID = Convert.ToInt32(dictInvestigation["id"]);
                var adjustments = Factory.InvestigationAdjustmentRepository().GetRecordsBySearch(investigationID.ToString());

                string particulars = string.Empty;
                string _values = string.Empty;

                foreach (DataRow item in adjustments.Rows)
                {
                    particulars += item["particular"].ToString() + "\n";
                    _values += item["value"].ToString() + "\n";
                }
                particulars += "\n";
                particulars += "Water Bill " + "\n";
                particulars += "Water Bill Adjustment " + "\n";
                particulars += "Penalty " + "\n";
                particulars += "Extension Fee" + "\n";
                particulars += "Adjusted Amount" + "\n";
                particulars += "Adjusted Water Bill" + "\n";
                decimal adjustedAmount = Convert.ToDecimal(dictInvestigation["water_bill"]) - Convert.ToDecimal(dictInvestigation["water_bill_adjustment"]);
                _values += "\n";
                _values += Convert.ToDecimal(dictInvestigation["water_bill"]).ToString("N2") + "\n";
                _values += Convert.ToDecimal(dictInvestigation["water_bill_adjustment"]).ToString("N2") + "\n";
                _values += Convert.ToDecimal(dictInvestigation["penalty"]).ToString("N2") + "\n";
                _values += Convert.ToDecimal(dictInvestigation["extension_fee"]).ToString("N2") + "\n";
                _values += Convert.ToDecimal(dictInvestigation["adjusted_water_bill"]).ToString("N2") + "\n";
                _values += (Convert.ToDecimal(dictInvestigation["adjusted_water_bill"]) + Convert.ToDecimal(dictInvestigation["penalty"]) + Convert.ToDecimal(dictInvestigation["extension_fee"])).ToString("N2") + "\n";

                string status = Helper.InvestigationStatusText(Convert.ToInt32(dictInvestigation["is_approved"]));

                parameters[6] = new ReportParameter("paramRelatives", dictInvestigation["relatives"]);
                parameters[7] = new ReportParameter("paramHouseHelpers", dictInvestigation["house_helper"]);
                parameters[8] = new ReportParameter("paramBoarders", dictInvestigation["boarders"]);
                parameters[9] = new ReportParameter("paramOtherHHDependentsFromService", dictInvestigation["immediate_members_of_fam"]);

                parameters[10] = new ReportParameter("paramMeterBrandAndSize", $"{dictInvestigation["meter_brand"]} - {dictInvestigation["meter_size"]} ");
                parameters[11] = new ReportParameter("paramMeterNumber", dictInvestigation["meter_number"]);
                parameters[12] = new ReportParameter("paramReadingBeforeTest", dictInvestigation["reading_before_test"]);
                parameters[13] = new ReportParameter("paramReadingAfterTest", dictInvestigation["reading_after_test"]);
                parameters[14] = new ReportParameter("paramCalibrationResult", dictInvestigation["calibration_result"]);
                parameters[15] = new ReportParameter("paramImmediateMembers", dictInvestigation["immediate_members_of_fam"]);
                parameters[27] = new ReportParameter("paramDateComplained", dictInvestigation["created_at"]);

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

                parameters[18] = new ReportParameter("paramRecommendingApproval", Helper.CSDHead);
                parameters[19] = new ReportParameter("paramPreparedBy", string.Empty);
                parameters[20] = new ReportParameter("paramApproved", Helper.BranchManager);
                parameters[21] = new ReportParameter("paramStatus", status);
                parameters[22] = new ReportParameter("paramAdjustmentParticulars", particulars);
                parameters[23] = new ReportParameter("paramAdjustmentValues", _values);


                parameters[24] = new ReportParameter("paramJobOrderNumber", jobOrderNumber);
                parameters[25] = new ReportParameter("paramContactNumber", dictInvestigation["contact_number"]);
                parameters[26] = new ReportParameter("paramAdjustmentParticular", dictInvestigation["adjustment_particular"]);

                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.RefreshReport();
          
            }
            catch (Exception ex)
            {
                Helper.MessageBoxSuccess("Investigation data is unavailable. awaiting input from investigator or not applicable.");
                Close();
            }

        }
    }
}
