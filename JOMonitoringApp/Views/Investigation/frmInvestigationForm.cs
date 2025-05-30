using AccountingSystem;
using JOMonitoringApp.Model;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using static JOMonitoringApp.Views.Investigation.ucInvestigationForm;

namespace JOMonitoringApp.Views.Investigation
{
    public partial class frmInvestigationForm : Form
    {

        string imageFilePath = string.Empty;
        string secondaryImageFilePath = string.Empty;

        internal readonly int _investigationId;
        private int _jobOrderId;

        internal bool _hasAdjustment;

        public frmInvestigationForm(int _investigationId)
        {
            InitializeComponent();
            this._investigationId = _investigationId;   
        }

        private void frmInvestigationForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadSelectedRecord();

                //transfer to reset form 
                dtpDateInvestigated.Enabled = cbxDateOfInvestigation.Checked; 
            }
        }

        private void LoadSelectedRecord()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.SuspendLayout();

            var dictInvestigation = Factory.InvestigationRepository().GetViewRecordById(this._investigationId);

            //account details
            string accountName = dictInvestigation["customer_name"];
            string accountNumber = dictInvestigation["account_number"];
            string address = dictInvestigation["customer_address"];

            //investigation details 
            string natureOfComplaint = dictInvestigation["nature_of_complaint"];
            int jobOrdersId = Convert.ToInt32(dictInvestigation["job_orders_id"]);
            string jobOrderNumber = dictInvestigation["job_order_no"];
            DateTime dateComplained = Convert.ToDateTime(dictInvestigation["created_at"]);
            DateTime dateInvestigated = string.IsNullOrEmpty(dictInvestigation["date_of_investigation"]) ? DateTime.Now : Convert.ToDateTime(dictInvestigation["date_of_investigation"]);
            string investigator = dictInvestigation["investigated_by"];

            //stat findings
            byte immediateMembersOfFam = Convert.ToByte(dictInvestigation["immediate_members_of_fam"]);
            byte houseHelper = Convert.ToByte(dictInvestigation["house_helper"]);
            byte relatives = Convert.ToByte(dictInvestigation["relatives"]);
            byte boarders = Convert.ToByte(dictInvestigation["boarders"]);
            byte noOfHoursServed = Convert.ToByte(dictInvestigation["no_of_hours_served"]);
            byte noServiceOutlets = Convert.ToByte(dictInvestigation["no_service_outlets"]);
            string alternativeSource = dictInvestigation["alternative_source"];
            byte hhPurpose = Convert.ToByte(dictInvestigation["hh_purpose"]);
            byte promoteTradeBusiness = Convert.ToByte(dictInvestigation["promote_trade_business"]);
            byte sellToNeighbor = Convert.ToByte(dictInvestigation["sell_to_neighbours"]);
            byte government = Convert.ToByte(dictInvestigation["government"]);


            //condition of service
            Dictionary<string, string> meterDict = Factory.CustomersRepository().GetCustomerMeterDetails(accountNumber);

            if (meterDict.Count != 0)
            {
                txtMeterBrand.Text = meterDict["MeterBrand"];
                txtMeterNumber.Text = meterDict["MeterNumber"];
                txtMeterSize.Text = meterDict["MeterSize"];
            }

            decimal readingBeforeTest = string.IsNullOrEmpty(dictInvestigation["reading_before_test"]) ? 0 : Convert.ToDecimal(dictInvestigation["reading_before_test"]);
            decimal readingAfterTest = string.IsNullOrEmpty(dictInvestigation["reading_after_test"]) ? 0 : Convert.ToDecimal(dictInvestigation["reading_after_test"]);
            string calibrationResult = dictInvestigation["calibration_result"];

            //messages
            string investigatorComments = dictInvestigation["investigator_comments"];
            string recommendations = dictInvestigation["recommendations"];
            string approvalMessage = dictInvestigation["approval_message"];

            //status
            int approvalStatus = Convert.ToInt16(dictInvestigation["is_approved"]);
            bool forAdjustment = dictInvestigation["has_adjustment"].ToString() == "0" ? false : true;

            cbHHPurpose.Checked = Convert.ToBoolean(hhPurpose);
            cbPromoteTrade.Checked = Convert.ToBoolean(promoteTradeBusiness);
            cbSellToNeighbours.Checked = Convert.ToBoolean(sellToNeighbor);
            cbGovernment.Checked = Convert.ToBoolean(government);
            txtAlternativeSource.Text = alternativeSource;
            txtHoursServed.Text = noOfHoursServed.ToString();
            txtServiceOutlets.Text = noServiceOutlets.ToString();
            txtAccountName.Text = accountName;
            txtAccountNumber.Text = accountNumber;
            txtAddress.Text = address;
            dtpDateComplained.Value = dateComplained;
            cbxDateOfInvestigation.Checked = !string.IsNullOrEmpty(dictInvestigation["date_of_investigation"]);
            dtpDateInvestigated.Value = cbxDateOfInvestigation.Checked ? Convert.ToDateTime(dictInvestigation["date_of_investigation"]) : DateTime.Now;
            txtJONumber.Text = jobOrderNumber;
            txtComplaint.Text = natureOfComplaint;

            txtInvestigatorComments.Text = investigatorComments;
            txtRecommendations.Text = recommendations;
            txtApprovalMessage.Text = approvalMessage;

            _hasAdjustment = !string.IsNullOrEmpty(dictInvestigation["water_bill_adjustment"]);
            _jobOrderId = jobOrdersId;

            nudReadingBeforeTest.Value = readingBeforeTest;
            nudReadingAfterTest.Value = readingAfterTest;
            txtCalibrationResult.Text = calibrationResult;
            txtImmediateFamily.Text = immediateMembersOfFam.ToString();
            txtHouseHelper.Text = houseHelper.ToString();
            txtRelatives.Text = relatives.ToString();
            txtBoarders.Text = boarders.ToString();

            DisplayStatus(approvalStatus);

            cmbxInvestigator.Text = investigator;
            imageFilePath = dictInvestigation["image_path"]?.ToString();
            secondaryImageFilePath = dictInvestigation["secondary_image_path"].ToString();

            //loading of picture box
            //if (dictInvestigation.ContainsKey("image_path"))
            //{
            //    imageFilePath = dictInvestigation["image_path"]?.ToString();
            //    if (!string.IsNullOrEmpty(imageFilePath) && File.Exists(imageFilePath))
            //    {
            //        pictureBox1.Visible = true;
            //        btnClearImage1.Visible = true;
            //        pictureBox1.Image = Image.FromFile(imageFilePath);
            //    }
            //    else
            //    {
            //        pictureBox1.Visible = false;
            //        btnClearImage1.Visible = false;
            //    }
            //}

            //if (dictInvestigation.ContainsKey("secondary_image_path"))
            //{
            //    secondaryImageFilePath = dictInvestigation["secondary_image_path"]?.ToString();
            //    if (!string.IsNullOrEmpty(secondaryImageFilePath) && File.Exists(secondaryImageFilePath))
            //    {
            //        pictureBox2.Visible = true;
            //        btnClearImage2.Visible = true;
            //        pictureBox2.Image = Image.FromFile(secondaryImageFilePath);
            //    }
            //    else
            //    {
            //        pictureBox2.Visible = false;
            //        btnClearImage2.Visible = false;
            //    }
            //}

            this.ResumeLayout();
            Cursor.Current = Cursors.Default;

            try
            {
              
            }
            catch (Exception)
            {

            }
        }

        private void DisplayStatus(int approvalStatus)
        {
            int status = approvalStatus; 

            switch (status)
            {
                case 0:
                    radInvestigation.Checked = true;
                    break;
                case 1:
                    radRecommendation.Checked = true;
                    break;
                case 2:
                    radAdjustment.Checked = true;
                    break;
                case 3:
                    radApproval.Checked = true;
                    break;
                case 4:
                    radApproved.Checked = true;
                    break;
                case 5:
                    radReInvestigation.Checked = true;
                    break;
            }
        }

        private void LoadImages()
        { 
        
        }


        private void frmInvestigation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveClick();
            }
        }

        private void SaveClick()
        {
            try
            {
                btnSave.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;

                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Investigation record has been updated successfully.");

                    // await Task.Run(() => ucInvestigationForm.GetInvestigationRecords());

                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError("Something went wrong. Please contact your system administrator.");
                // Optionally log the exception: Logger.Log(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            SaveClick();
        }

        internal bool SaveData()
        {
            using (var scope = new TransactionScope())
            {
                var investigationModel = InvestigationModel();
                var investigationResult = Factory.InvestigationRepository().Update(investigationModel);

                if (investigationResult)
                {
                    UpdateJobOrderStatus();
                    UploadImage();
                    scope.Complete();
                    return true;
                }
                else
                    return false;
            }
        }

        internal void UpdateJobOrderStatus()
        {
            int jobOrderStatus = 1;
            int investigationStatusID = GetInvestigationStatus();

            if (investigationStatusID == 4)
                jobOrderStatus = 4;

            if (investigationStatusID == 1 || investigationStatusID == 2 || investigationStatusID == 3 || investigationStatusID == 5)
                jobOrderStatus = 2;

            Factory.JobOrdersRepository().UpdateStatus(0, jobOrderStatus); //TAKE NOTE OF THIS
        }

        private void UploadImage()
        {
            try
            {
                if (!string.IsNullOrEmpty(imageFilePath) || !string.IsNullOrEmpty(secondaryImageFilePath))
                {
                    string sharedFolderPath = @"\\192.168.18.68\InvestigationImages\Dacol";

                    if (!Directory.Exists(sharedFolderPath))
                    {
                        Helper.MessageBoxSuccess("Shared folder not found: " + sharedFolderPath);
                        return;
                    }

                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    string destination1 = Path.Combine(sharedFolderPath, Path.GetFileName(imageFilePath));
                    File.Copy(imageFilePath, destination1, true);

                    string destination2 = Path.Combine(sharedFolderPath, Path.GetFileName(secondaryImageFilePath));
                    File.Copy(secondaryImageFilePath, destination2, true);

                }
            }
            catch (Exception)
            {
            }

        }

        internal int GetInvestigationStatus()
        {
            //// mag true if naay sulod.
            //bool hasInvestigatorComments = !string.IsNullOrEmpty(txtInvestigatorComments.Text.Trim());
            //bool hasRecommendation = !string.IsNullOrEmpty(txtRecommendations.Text.Trim());
            //bool hasApproval = !string.IsNullOrEmpty(txtApprovalMessage.Text.Trim());

            //bool isDisapproved = cbxInvestigationDisapproved.Checked;
            //bool isRecommendationDisapproved = cbxRecommendationDisapproved.Checked;
            //bool isForAdjustment = cbxForAdjustment.Checked;


            ////for reinvestigation
            //if (_isForReinvestigation)
            //    return (int)InvestigationStatus.ForRecommendation;

            //if (hasInvestigatorComments && !hasRecommendation && !hasApproval)
            //    return (int)InvestigationStatus.ForRecommendation;

            //if (hasInvestigatorComments && hasRecommendation && isRecommendationDisapproved)
            //    return (int)InvestigationStatus.ForReInvestigation;

            //if (hasInvestigatorComments && hasRecommendation && !isRecommendationDisapproved && isForAdjustment)
            //    return (int)InvestigationStatus.ForAdjustment;

            //if (hasInvestigatorComments && hasRecommendation && !isRecommendationDisapproved && !hasApproval && !isForAdjustment && _hasAdjustment)
            //    return (int)InvestigationStatus.ForApproval;

            //if (hasInvestigatorComments && hasRecommendation && !isRecommendationDisapproved && hasApproval && isDisapproved)
            //    return (int)InvestigationStatus.ForReInvestigation;

            //if (hasInvestigatorComments && hasRecommendation && !isRecommendationDisapproved && hasApproval && !isDisapproved)
            //    return (int)InvestigationStatus.Approved;

            return (int)InvestigationStatus.ForInvestigation;
        }

        private InvestigationModel InvestigationModel()
        {
            var model = new InvestigationModel
            {
                //Id = investigationId,
                //JobOrderId = _jobOrderId,
                //JobOrderNo = txtJONumber.Text.Trim(),
                //CustomerName = txtAccountName.Text.Trim(),
                //CustomerAddress = txtAddress.Text.Trim(),
                //CustomerAccountNumber = txtAccountNumber.Text.Trim(),
                //NatureOfComplaint = txtComplaint.Text.Trim(),
                //InvestigatorComments = txtInvestigatorComments.Text.Trim(),
                //DateOfInvestigation = cbxDateOfInvestigation.Checked ? (DateTime?)dtpDate.Value : null,
                //ApprovalMessage = txtApprovalMessage.Text.Trim(),
                //Recommendations = txtRecommendations.Text.Trim(),
                //imagePath = $"\\\\{Helper.serverStatisIPAddress}\\InvestigationImages\\Dacol\\{Path.GetFileName(imageFilePath)}",
                //secondaryImagePath = $"\\\\{Helper.serverStatisIPAddress}\\InvestigationImages\\Dacol\\{Path.GetFileName(secondaryImageFilePath)}",
                //IsApproved = GetInvestigationStatus(),
                //AlternativeSource = txtAlternativeSource.Text.Trim(),
                //MeterBrand = txtMeterBrand.Text,
                //MeterSize = txtMeterSize.Text,
                //MeterNumber = txtMeterNumber.Text,
                //ReadingBeforeTest = nudReadingBeforeTest.Value.ToString(),
                //ReadingAfterTest = nudReadingAfterTest.Value.ToString(),
                //CalibrationResult = txtCalibrationResult.Text,
                //ImmediateMembersOfFam = Convert.ToByte(nudImmediateFamily.Value),
                //HouseHelper = Convert.ToByte(nudHouseHelper.Value),
                //Relatives = Convert.ToByte(nudRelatives.Value),
                //HasAdjustment = cbxForAdjustment.Checked,
                //Boarders = Convert.ToByte(nudBoarders.Value),
                //NoOfHoursServed = Convert.ToByte(nudNoOfHoursServed.Value),
                //NoServiceOutlets = Convert.ToByte(nudNoServiceOfOutlets.Value),
                //HhPurpose = Convert.ToBoolean(cbHHPurpose.Checked),
                //Government = Convert.ToBoolean(cbGovernment.Checked),
                //PromoteTradeBusiness = Convert.ToBoolean(cbPromoteTrade.Checked),
                //SellToNeighbours = Convert.ToBoolean(cbSellToNeighbours.Checked),
                //UpdatedBy = Helper.UserId,

            };

            return model;
        }


        private void label21_Click(object sender, EventArgs e)
        {
            _ = new frmInvestigationImageViewer(imageFilePath, secondaryImageFilePath).ShowDialog();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbxDateOfInvestigation_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateInvestigated.Enabled = cbxDateOfInvestigation.Checked;
        }

        private void nudReadingBeforeTest_ValueChanged(object sender, EventArgs e)
        {
            CalibrationResult();
        }

        private void CalibrationResult()
        {
            decimal before = nudReadingBeforeTest.Value;
            decimal after = nudReadingAfterTest.Value;

            decimal difference = after - before;

            string result;

            if (difference == 0.020m)
                result = "Passed";
            else if (difference < 0.020m)
                result = "Failed Under";
            else
                result = "Failed Over";

            txtCalibrationResult.Text = result;
        }

        private void btnAdjustmentForm_Click(object sender, EventArgs e)
        {
            if (radAdjustment.Checked || radApproval.Checked || radReInvestigation.Checked)
            {
                _ = new frmInvestigationAdjustment(this).ShowDialog();
                ViewAdjustment();
            }

            Helper.MessageBoxSuccess("Adjustments cannot be made at this time. Please wait for further recommendations before proceeding.");
        }

        internal void ViewAdjustment()
        {
            var adjustments = Factory.InvestigationRepository().GetViewRecordById(_investigationId);

            if (adjustments.Count != 0)
            {
                decimal waterBill = Convert.ToDecimal(adjustments["water_bill"]);
                decimal waterBillAdjustment = Convert.ToDecimal(adjustments["water_bill_adjustment"]);
                decimal penalty = Convert.ToDecimal(adjustments["penalty"]);
                decimal extensionFee = Convert.ToDecimal(adjustments["extension_fee"]);
                decimal adjustedAmount = waterBill - waterBillAdjustment;
                decimal adjustedWaterBill = Convert.ToDecimal(adjustments["adjusted_water_bill"]);

                lblWaterBill.Text = waterBill.ToString("N2");
                lblWaterBIllAdjustment.Text = waterBillAdjustment.ToString("N2");
                lblExtensionFee.Text = extensionFee.ToString("N2");
                lblPenalty.Text = penalty.ToString("N2");
                lblAdjustedAmount.Text = adjustedAmount.ToString("N2");
                lblAdjustedWaterBill.Text = adjustedAmount.ToString("N2");
            }

            else
            {
                lblWaterBill.Text = "0.00";
                lblWaterBIllAdjustment.Text = "0.00";
                lblExtensionFee.Text = "0.00";
                lblPenalty.Text = "0.00";
                lblAdjustedAmount.Text = "0.00";
                lblAdjustedWaterBill.Text = "0.00";
            }
        }
    }
}
