using AccountingSystem;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Reports
{
    public partial class frmInvestigationReport : Form
    {

        private readonly int? _jobOrderId;
        private readonly string jobOrderNumber = string.Empty;
        private readonly string whatToPrint = string.Empty;  

        public frmInvestigationReport(int? jobOrderId, string jobOrderNumber, string whatToPrint)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            _jobOrderId = jobOrderId;
            this.jobOrderNumber = jobOrderNumber;
            this.whatToPrint = whatToPrint;
        }

        private void frmInvestigation_Load(object sender, EventArgs e)
        {
            txtJONo.Text = jobOrderNumber;

            if (!string.IsNullOrEmpty(txtJONo.Text))
            {
                switch(whatToPrint)
                {
                    case "FULL_REPORT":
                        LoadWholeReport();
                        break;
                    case "INVESTIGATOR_COMMENT":
                        LoadInvestigatorCommentReport();
                        break;
                    case "RECOMMENDATION":
                        LoadRecommendationReport();
                        //LoadWholeReport();
                        break;
                    case "ADJUSTMENT":
                        LoadInvestigationAdjustment();
                        break;
                }
            }
            
        }

        private void LoadRecommendationReport()
        {
            try
            {
                string jobOrderNumber = txtJONo.Text;
                reportViewer1.LocalReport.ReportPath = $"{Application.StartupPath}\\RDLC\\Investigation\\investigator-recommendation.rdlc";
                Dictionary<string, string> dictInvestigation = Factory.InvestigationRepository().GetViewRecordByJobOrderNo(jobOrderNumber);
                if (dictInvestigation.Count == 0)
                {
                    Helper.MessageBoxSuccess("Investigation data unavailable. awaiting input from investigator or not applicable.");
                    Close();
                    return;
                }


                ReportParameter[] parameters = new ReportParameter[1];
                parameters[0] = new ReportParameter("paramRecommendations", dictInvestigation["recommendations"]);

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadWholeReport();
        }

        private void LoadInvestigationAdjustment()
        {
            string jobOrderNumber = txtJONo.Text;

            reportViewer1.LocalReport.ReportPath = $"{Application.StartupPath}\\RDLC\\Investigation\\investigation-form-adjustment.rdlc";
            reportViewer1.LocalReport.EnableExternalImages = true;

            Dictionary<string, string> dictInvestigation = Factory.InvestigationRepository().GetViewRecordByJobOrderNo(jobOrderNumber);

            if (dictInvestigation.Count == 0)
            {
                Helper.MessageBoxSuccess("Investigation data unavailable. awaiting input from investigator or not applicable.");
                Close();
                return;
            }

            ReportParameter[] parameters = new ReportParameter[5];

            int investigationID = Convert.ToInt32(dictInvestigation["id"]);
            var othersFees = Factory.InvestigationAdjustmentRepository().GetRecordsBySearch(investigationID.ToString());

            string particulars = string.Empty;
            string _values = string.Empty;

            string otherFeesDescription = string.Empty;
            decimal otherFeesAmountSum = 0.00M;
            string otherFeesAmount = string.Empty;



            decimal waterBill = Convert.ToDecimal(dictInvestigation["water_bill"]);
            decimal adjustedWaterBill = Convert.ToDecimal(dictInvestigation["adjusted_water_bill"]);
            decimal adjustment = Convert.ToDecimal(dictInvestigation["water_bill_adjustment"]);
            decimal sumAdjustment = waterBill + adjustedWaterBill + adjustedWaterBill;

            foreach (DataRow item in othersFees.Rows)
            {
                otherFeesAmount += item["value"].ToString() + "\n";
                otherFeesAmountSum += Convert.ToDecimal(item["value"].ToString());
                otherFeesDescription += item["particular"].ToString() + " :" + item["value"].ToString() + "\n";
            }

            if (sumAdjustment > 0)
            {
                particulars += "\n";
                particulars += "Water Bill " + "\n";
                particulars += "Adjusted Amount " + "\n";
                particulars += "Other Fees " + "\n";
                particulars += "Adjustment" + "\n";

                _values += "\n";
                _values += Convert.ToDecimal(dictInvestigation["water_bill"]).ToString("N2") + "\n";
                _values += Convert.ToDecimal(dictInvestigation["adjusted_water_bill"]).ToString("N2") + "\n";
                _values += otherFeesAmountSum.ToString("N2") + "\n";
                _values += Convert.ToDecimal(dictInvestigation["water_bill_adjustment"]).ToString("N2") + "\n";
            }

            parameters[0] = new ReportParameter("paramAdjustmentParticulars", particulars);
            parameters[1] = new ReportParameter("paramAdjustmentValues", _values);
            parameters[2] = new ReportParameter("paramAdjustmentParticular", dictInvestigation["adjustment_particular"]);
            parameters[3] = new ReportParameter("paramOtherFees", otherFeesDescription);
            parameters[4] = new ReportParameter("paramAdjustmentNote", dictInvestigation["adjustment_note"]);

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

        private void LoadInvestigatorCommentReport()
        {
            try
            {
                string jobOrderNumber = txtJONo.Text;
                reportViewer1.LocalReport.ReportPath = $"{Application.StartupPath}\\RDLC\\Investigation\\investigator-comment.rdlc";
                Dictionary<string, string> dictInvestigation = Factory.InvestigationRepository().GetViewRecordByJobOrderNo(jobOrderNumber);
                if (dictInvestigation.Count == 0)
                {
                    Helper.MessageBoxSuccess("Investigation data unavailable. awaiting input from investigator or not applicable.");
                    Close();
                    return;
                }


                ReportParameter[] parameters = new ReportParameter[1];
                parameters[0] = new ReportParameter("paramComments", dictInvestigation["investigator_comments"]);

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

        private void LoadWholeReport()
        {
            try
            {
                string jobOrderNumber = txtJONo.Text;

                reportViewer1.LocalReport.ReportPath = $"{Application.StartupPath}\\RDLC\\Investigation\\investigation-form.rdlc";
                reportViewer1.LocalReport.EnableExternalImages = true;

                Dictionary<string, string> dictInvestigation = Factory.InvestigationRepository().GetViewRecordByJobOrderNo(jobOrderNumber);

                if (dictInvestigation.Count == 0)
                {
                    Helper.MessageBoxSuccess("Investigation data unavailable. awaiting input from investigator or not applicable.");
                    Close();
                    return;
                }

                ReportParameter[] parameters = new ReportParameter[29];
                parameters[0] = new ReportParameter("paramCustomer", dictInvestigation["customer_name"]);
                parameters[1] = new ReportParameter("paramAccountNumber", dictInvestigation["account_number"]);
                parameters[2] = new ReportParameter("paramAddress", dictInvestigation["customer_address"]);
                parameters[3] = new ReportParameter("paramNatureOfComplaint", dictInvestigation["nature_of_complaint"]);
                parameters[4] = new ReportParameter("paramComments", dictInvestigation["investigator_comments"]);
                parameters[5] = new ReportParameter("paramRecommendations", dictInvestigation["recommendations"]);

                int investigationID = Convert.ToInt32(dictInvestigation["id"]);
                var othersFees = Factory.InvestigationAdjustmentRepository().GetRecordsBySearch(investigationID.ToString());

                string particulars = string.Empty;
                string _values = string.Empty;

                string otherFeesDescription = string.Empty;
                decimal otherFeesAmountSum = 0.00M;
                string otherFeesAmount = string.Empty;



                decimal waterBill = Convert.ToDecimal(dictInvestigation["water_bill"]);
                decimal adjustedWaterBill = Convert.ToDecimal(dictInvestigation["adjusted_water_bill"]);    
                decimal adjustment = Convert.ToDecimal(dictInvestigation["water_bill_adjustment"]);
                decimal sumAdjustment = waterBill + adjustedWaterBill + adjustedWaterBill;

                foreach (DataRow item in othersFees.Rows)
                {
                    otherFeesAmount += item["value"].ToString() + "\n";
                    otherFeesAmountSum += Convert.ToDecimal(item["value"].ToString());
                    otherFeesDescription += item["particular"].ToString() + " :" + item["value"].ToString() + "\n";
                }

                if (sumAdjustment > 0)
                {
                    particulars += "\n";
                    particulars += "Water Bill " + "\n";
                    particulars += "Adjusted Amount " + "\n";
                    particulars += "Other Fees " + "\n";
                    particulars += "Adjustment" + "\n";

                    _values += "\n";
                    _values += Convert.ToDecimal(dictInvestigation["water_bill"]).ToString("N2") + "\n";
                    _values += Convert.ToDecimal(dictInvestigation["adjusted_water_bill"]).ToString("N2") + "\n";
                    _values += otherFeesAmountSum.ToString("N2") + "\n";
                    _values += Convert.ToDecimal(dictInvestigation["water_bill_adjustment"]).ToString("N2") + "\n";
                }
                
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
                string ImagePath1 = dictInvestigation["image_path"];
                string ImagePath2 = dictInvestigation["secondary_image_path"];
                if (File.Exists(ImagePath1) || File.Exists(ImagePath2))
                {
                    parameters[16] = new ReportParameter("paramImage1", $"file:///{ImagePath1}");
                    parameters[17] = new ReportParameter("paramImage2", $"file:///{ImagePath2}");
                }
                else
                {
                    parameters[16] = new ReportParameter("paramImage1", string.Empty);
                    parameters[17] = new ReportParameter("paramImage2", string.Empty);
                }

                parameters[18] = new ReportParameter("paramRecommendingApproval", Helper.CSDHead);
                parameters[19] = new ReportParameter("paramPreparedBy", string.IsNullOrEmpty(dictInvestigation["investigated_by"]) ? string.Empty : dictInvestigation["investigated_by"].ToString().ToUpper());
                parameters[20] = new ReportParameter("paramApproved", Helper.BranchManager);
                parameters[21] = new ReportParameter("paramStatus", status);
                parameters[22] = new ReportParameter("paramAdjustmentParticulars", particulars);
                parameters[23] = new ReportParameter("paramAdjustmentValues", _values);


                parameters[24] = new ReportParameter("paramJobOrderNumber", jobOrderNumber);
                parameters[25] = new ReportParameter("paramContactNumber", dictInvestigation["contact_number"]);
                parameters[26] = new ReportParameter("paramAdjustmentParticular", dictInvestigation["adjustment_particular"]);


                parameters[27] = new ReportParameter("paramOtherFees", otherFeesDescription );
                parameters[28] = new ReportParameter("paramAdjustmentNote", dictInvestigation["adjustment_note"]);

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
