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

            ReportParameter[] parameters = new ReportParameter[32];
            parameters[0] = new ReportParameter("paramCustomer", dictInvestigation["customer_name"]);
            parameters[1] = new ReportParameter("paramAccountNumber", dictInvestigation["account_number"]);
            parameters[2] = new ReportParameter("paramAddress", dictInvestigation["customer_address"]);
            parameters[3] = new ReportParameter("paramNatureOfComplaint", dictInvestigation["nature_of_complaint"]);
            parameters[4] = new ReportParameter("paramComments", dictInvestigation["investigator_comments"]);
            parameters[5] = new ReportParameter("paramRecommendations", dictInvestigation["recommendations"]);
            parameters[30] = new ReportParameter("paramJobOrderNumber", jobOrderNumber);
            parameters[31] = new ReportParameter("paramContactNumber", dictInvestigation["contact_number"]);

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

            parameters[18] = new ReportParameter("paramRecommendingApproval", Helper.CSDHead);
            parameters[19] = new ReportParameter("paramPreparedBy", string.Empty);
            parameters[20] = new ReportParameter("paramApproved", Helper.BranchManager);

            string status = Helper.InvestigationStatusText(Convert.ToInt32(dictInvestigation["is_approved"]));
            parameters[29] = new ReportParameter("paramStatus", status);
            string particular = dictInvestigation["adjustment_particular"];
            string adjustment = dictInvestigation["adjustment_amount"];

            //string display here
            string _particular = dictInvestigation.ContainsKey("adjustment_particular") && dictInvestigation["adjustment_particular"] != null
      ? dictInvestigation["adjustment_particular"]
    : "";
            string amountDue = dictInvestigation.ContainsKey("amount_due") && decimal.TryParse(Convert.ToString(dictInvestigation["amount_due"]), out var amountDueDecimal)
                ? (amountDueDecimal == 0 ? "0" : amountDueDecimal.ToString("N2"))
                : "0";
            string adjustmentAmount = dictInvestigation.ContainsKey("adjustment_amount") && decimal.TryParse(Convert.ToString(dictInvestigation["adjustment_amount"]), out var adjustmentDecimal)
                ? adjustmentDecimal.ToString("N2")
                : "0";
            string adjustedAmount = dictInvestigation.ContainsKey("adjusted_amount") && decimal.TryParse(Convert.ToString(dictInvestigation["adjusted_amount"]), out var adjustedDecimal)
                ? adjustedDecimal.ToString("N2")
                : "0";
            string penalty = dictInvestigation.ContainsKey("penalty") && decimal.TryParse(Convert.ToString(dictInvestigation["penalty"]), out var penaltyDecimal)
                ? penaltyDecimal.ToString("N2")
                : "0";
            string extensionFee = dictInvestigation.ContainsKey("extension_fee") && decimal.TryParse(Convert.ToString(dictInvestigation["extension_fee"]), out var extensionDecimal)
                ? extensionDecimal.ToString("N2")
                : "0";

            string previousReading = dictInvestigation["previous_reading"];
            string presentReading = dictInvestigation["present_reading"];
            string actualReading = dictInvestigation["actual_reading"];

            string previousConsumption = dictInvestigation["previous_consumption"];
            string presentConsumption = dictInvestigation["present_consumption"];
            string actualConsumption = dictInvestigation["actual_consumption"];
            string averageConsumption = dictInvestigation["last_three_months_consumption"];

            string details =
                $"Particular           \n" +
                $"Amount Due           \n" +
                $"Penalty              \n" +
                $"Extension Fee        \n" +
                $"Adjustment Amount    \n" +
                $"_____________________\n" +
                $"Adjusted Amount      ";

            string detailsValues =
                $"{_particular}\n" +
                $"{amountDue}\n" +
                $"{penalty}\n" +
                $"{extensionFee}\n" +
                $"{adjustmentAmount}\n" +
                $"_____________________\n" +
                $"{adjustedAmount}";

            parameters[21] = new ReportParameter("paramAdjustments", $"{details}");
            parameters[22] = new ReportParameter("paramAdjustmentsValues", $"{detailsValues}");


            parameters[23] = new ReportParameter("paramPreviousReading", previousReading);
            parameters[24] = new ReportParameter("paramPresentReading", presentReading);
            parameters[25] = new ReportParameter("paramActualReading", actualReading);
            parameters[26] = new ReportParameter("paramPreviousCons", previousConsumption);
            parameters[27] = new ReportParameter("paramPresentCons", presentConsumption);
            parameters[28] = new ReportParameter("paramActualCons", actualConsumption);

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

            try
            {

            }
            catch (Exception ex)
            {
                Helper.MessageBoxSuccess("Investigation data is unavailable. awaiting input from investigator or not applicable.");
                Close();
            }
            
        }
    }


}
