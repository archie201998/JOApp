using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.PromptBox;
using JOMonitoringApp.Views.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Investigation
{

    public partial class ucInvestigationForm : UserControl
    {

        public event EventHandler DataGridDoubleClicked;

        internal int _jobOrderId;
        internal string _customerAddress;
        internal bool isUpdate;
        internal int selectedInvestigationID;
        private Dictionary<string, string> dictInvestigation;
        internal string particular = string.Empty;
        internal bool isCreate = false;
        string imageFilePath = string.Empty;
        string secondaryImageFilePath = string.Empty;

        private string _jobOrderNumber;
        internal bool hasAdjustment;

        public ucInvestigationForm()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgInvestigations);
        }

        private void ucInvestigation_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                HelperLoadRecords.InvestigationStatusCombobox(cmbxStatus);
                cmbxStatus.SelectedValue = 6;
                EnableControls(false);
                GetInvestigationRecords();
            }
        }
      

        private bool IsImageFile(string path)
        {
            string ext = Path.GetExtension(path).ToLower();
            return ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp" || ext == ".gif";
        }

        private void ValidateFormPermission()
        {
            bool adminMode = Helper.temporaryAdminMode;
            gbAccountDetails.Enabled = adminMode || Helper.UserHasPermission("INVESTIGATION_DATA");
            gbStatisticalFindings.Enabled = adminMode || Helper.UserHasPermission("STATISTICAL_FINDINGS");
            gbConditionOfService.Enabled = adminMode || Helper.UserHasPermission("CONDITION_OF_SERVICE_FACILITIES");
            txtInvestigatorComments.Enabled = adminMode || Helper.UserHasPermission("INVESTIGATION_COMMENTS");
            txtRecommendations.Enabled = adminMode || Helper.UserHasPermission("INVESTIGATION_RECOMMENDATION");
            btnCompute.Enabled = adminMode || Helper.UserHasPermission("INVESTIGATION_ADJUSTMENT_COMPUTATION");
            btnAttachedImage.Enabled = adminMode || Helper.UserHasPermission("INVESTIGATION_ATTACHED_IMAGE");
            pictureBox1.Enabled = adminMode || Helper.UserHasPermission("INVESTIGATION_VIEW_ATTACHED_IMAGE");
            pictureBox2.Enabled = adminMode || Helper.UserHasPermission("INVESTIGATION_VIEW_ATTACHED_IMAGE");
            gbApproval.Enabled = adminMode || Helper.UserHasPermission("INVESTIGATION_APPROVAL");
        }

        internal void UpdateJobOrderStatus()
        {
            int jobOrderId = _jobOrderId;
            int jobOrderStatus = 1;
            int investigationStatusID = InvestigationStatusLogic();

            if (investigationStatusID == 4)
                jobOrderStatus = 4;

            if (investigationStatusID == 1 || investigationStatusID == 2 || investigationStatusID == 3 || investigationStatusID == 5) 
                jobOrderStatus = 2;

            Factory.JobOrdersRepository().UpdateStatus(jobOrderId, jobOrderStatus);
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

        public enum InvestigationStatus
        {
            ForInvestigation = 0,
            ForRecommendation = 1,
            ForAdjustment = 2,
            ForApproval = 3,
            Approved = 4,
            ForReInvestigation = 5,
        }

        internal int InvestigationStatusLogic()
        {
            bool hasInvestigatorComments = !string.IsNullOrEmpty(txtInvestigatorComments.Text.Trim());
            bool hasRecommendation = !string.IsNullOrEmpty(txtRecommendations.Text.Trim());
            bool hasApproval = !string.IsNullOrEmpty(txtApprovalMessage.Text.Trim());

            bool isDisapproved = cbxDisapproved.Checked;
            bool isRecommendationDisapproved = cbxRecommendationDisapproved.Checked;
            bool hasNoAdjustment = cbxForAdjustment.Checked;

            if (hasInvestigatorComments && !hasRecommendation && !hasApproval)
                return (int)InvestigationStatus.ForRecommendation;

            if (hasInvestigatorComments && hasRecommendation && isRecommendationDisapproved)
                return (int)InvestigationStatus.ForReInvestigation;

            if (hasInvestigatorComments && hasRecommendation && !isRecommendationDisapproved && !hasNoAdjustment)
                return (int)InvestigationStatus.ForAdjustment;

            if (hasInvestigatorComments && hasRecommendation && !isRecommendationDisapproved && hasNoAdjustment)
                return (int)InvestigationStatus.ForApproval;

            if (hasInvestigatorComments && hasRecommendation && !isRecommendationDisapproved && hasApproval && isDisapproved)
                return (int)InvestigationStatus.ForReInvestigation;

            if (hasInvestigatorComments && hasRecommendation && !isRecommendationDisapproved && hasApproval && !isDisapproved)
                return (int)InvestigationStatus.Approved;

            return (int)InvestigationStatus.ForInvestigation;
        }

        private InvestigationModel InvestigationModel()
        {
            var model = new InvestigationModel
            {
                Id = selectedInvestigationID,
                JobOrderId = _jobOrderId,
                JobOrderNo = txtJONumber.Text.Trim(),
                CustomerName = txtAccountName.Text.Trim(),
                CustomerAddress = txtAddress.Text.Trim(),
                CustomerAccountNumber = txtAccountNumber.Text.Trim(),
                NatureOfComplaint = txtComplaint.Text.Trim(),
                InvestigatorComments = txtInvestigatorComments.Text.Trim(),
                DateOfInvestigation = dtpDate.Value,
                ApprovalMessage = txtApprovalMessage.Text.Trim(),
                Recommendations = txtRecommendations.Text.Trim(),
                imagePath = $"\\\\{Helper.serverStatisIPAddress}\\InvestigationImages\\Dacol\\{Path.GetFileName(imageFilePath)}",
                secondaryImagePath = $"\\\\{Helper.serverStatisIPAddress}\\InvestigationImages\\Dacol\\{Path.GetFileName(secondaryImageFilePath)}",
                IsApproved = InvestigationStatusLogic(),
                AlternativeSource = txtAlternativeSource.Text.Trim(),
                MeterBrand = txtMeterBrand.Text,
                MeterSize = txtMeterSize.Text,
                MeterNumber = txtMeterNumber.Text,
                ReadingBeforeTest = nudReadingBeforeTest.Value.ToString(),
                ReadingAfterTest = nudReadingAfterTest.Value.ToString(),
                CalibrationResult = txtCalibrationResult.Text,
                OverRegistration = txtServiceLineDefects.Text,
                UnderRegistration = txtServiceLineDefects.Text,
                LeakingAfterTheMeter = txtServiceLineDefects.Text,
                ImmediateMembersOfFam = Convert.ToByte(nudImmediateFamily.Value),
                HouseHelper = Convert.ToByte(nudHouseHelper.Value),
                Relatives = Convert.ToByte(nudRelatives.Value),
                Boarders = Convert.ToByte(nudBoarders.Value),
                NoOfHoursServed = Convert.ToByte(nudNoOfHoursServed.Value),
                NoServiceOutlets = Convert.ToByte(nudNoServiceOfOutlets.Value),
                HhPurpose = Convert.ToBoolean(cbHHPurpose.Checked),
                Government = Convert.ToBoolean(cbGovernment.Checked),
                PromoteTradeBusiness = Convert.ToBoolean(cbPromoteTrade.Checked),
                SellToNeighbours = Convert.ToBoolean(cbSellToNeighbours.Checked),
                HasAdjustment = cbxForAdjustment.Checked,
                UpdatedBy = Helper.UserId,
                
            };

            return model;
        }

        private void btnAttachedImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    int selectedCount = openFileDialog.FileNames.Length;

                    if (selectedCount > 2)
                    {
                        Helper.MessageBoxSuccess("Please select only 1 or 2 images.");
                        return;
                    }

                    imageFilePath = openFileDialog.FileNames[0];
                    secondaryImageFilePath = selectedCount == 2
                        ? openFileDialog.FileNames[1]
                        : null;

                    pictureBox1.Image = Image.FromFile(imageFilePath);
                    pictureBox2.Image = secondaryImageFilePath != null
                        ? Image.FromFile(secondaryImageFilePath)
                        : null;
                }
            }
        }

        private void UploadImage()
        {
            if (!string.IsNullOrEmpty(imageFilePath) && !string.IsNullOrEmpty(secondaryImageFilePath))
            {
                string sharedFolderPath = @"\\192.168.18.68\InvestigationImages\Dacol";

                try
                {
                    if (!Directory.Exists(sharedFolderPath))
                    {
                        Helper.MessageBoxSuccess("Shared folder not found: " + sharedFolderPath);
                        return;
                    }

                    // Ensure image files are not locked by the app
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    // Copy original image
                    string destination1 = Path.Combine(sharedFolderPath, Path.GetFileName(imageFilePath));
                    File.Copy(imageFilePath, destination1, true);

                    // Copy secondary image
                    string destination2 = Path.Combine(sharedFolderPath, Path.GetFileName(secondaryImageFilePath));
                    File.Copy(secondaryImageFilePath, destination2, true);

                }
                catch (IOException ioEx)
                {
                    //Helper.MessageBoxSuccess("File I/O error: " + ioEx.Message);
                }
                catch (UnauthorizedAccessException unAuthEx)
                {
                    //Helper.MessageBoxSuccess("Access error: " + unAuthEx.Message);
                }
                catch (Exception ex)
                {
                    //Helper.MessageBoxSuccess("Unexpected error: " + ex.Message);
                }
            }
            else
            {
                Helper.MessageBoxSuccess("No image uploaded. Click Ok to continue.");
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        internal void GetInvestigationRecords()
        {
            string searchKey = txtSearch.Text.Trim();
            int statusId = 0;

            if (cmbxStatus.InvokeRequired)
            {
                cmbxStatus.Invoke(new Action(() =>
                {
                    statusId = Convert.ToInt32(cmbxStatus.SelectedValue);
                }));
            }
            else
            {
                statusId = Convert.ToInt32(cmbxStatus.SelectedValue);
            }

            var dtInvestigation = Factory.InvestigationRepository().GetViewRecordsBySearch(statusId, searchKey);
            lblRecordCount.Text = dtInvestigation.Rows.Count.ToString();
            HelperLoadRecords.InvestigationDatagridView(dgInvestigations, dtInvestigation);
        }

        internal void EnableControls(bool enable)
        {
            gbStatisticalFindings.Enabled = enable;
            gbAccountDetails.Enabled = enable;
            gbComments.Enabled = enable;
            gbConditionOfService.Enabled = enable;
            gbImage.Enabled = enable;
            gbApproval.Enabled = enable;
            gbComputation.Enabled = enable;
            dgInvestigations.Enabled = !enable;
            btnSearch.Enabled = !enable;
            cmbxStatus.Enabled = !enable;
            txtSearch.Enabled = !enable;
            btnPrint.Enabled = enable;
        }

        private void dgInvestigations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewInvestigationDetails();
            ViewAdjustment();
        }

        internal void ViewInvestigationDetails()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.SuspendLayout();

            selectedInvestigationID = Convert.ToInt32(dgInvestigations.SelectedRows[0].Cells["id"].Value);
            dictInvestigation = Factory.InvestigationRepository().GetViewRecordById(selectedInvestigationID);

            if (dictInvestigation.Count == 0) return;


            decimal readingBeforeTest = string.IsNullOrEmpty(dictInvestigation["reading_before_test"]) ? 0 : Convert.ToDecimal(dictInvestigation["reading_before_test"]);
            decimal readingAfterTest = string.IsNullOrEmpty(dictInvestigation["reading_after_test"]) ? 0 : Convert.ToDecimal(dictInvestigation["reading_after_test"]);
            string calibrationResult = dictInvestigation["calibration_result"];
            string overRegistration = dictInvestigation["over_registration"];
            string underRegistration = dictInvestigation["under_registration"];
            string leakingAfterTheMeter = dictInvestigation["leaking_after_the_meter"];
            int jobOrdersId = Convert.ToInt32(dictInvestigation["job_orders_id"]);
            string customerAddress = dictInvestigation["customer_address"];
            byte immediateMembersOfFam = Convert.ToByte(dictInvestigation["immediate_members_of_fam"]);
            byte houseHelper = Convert.ToByte(dictInvestigation["house_helper"]);
            byte relatives = Convert.ToByte(dictInvestigation["relatives"]);
            byte boarders = Convert.ToByte(dictInvestigation["boarders"]);
            byte noOfHoursServed = Convert.ToByte(dictInvestigation["no_of_hours_served"]);
            byte noServiceOutlets = Convert.ToByte(dictInvestigation["no_service_outlets"]);
            byte hhPurpose = Convert.ToByte(dictInvestigation["hh_purpose"]);
            byte promoteTradeBusiness = Convert.ToByte(dictInvestigation["promote_trade_business"]);
            byte sellToNeighbours = Convert.ToByte(dictInvestigation["sell_to_neighbours"]);
            string alternativeSource = dictInvestigation["alternative_source"];
            string approvalMessage = dictInvestigation["approval_message"];
            string natureOfComplaint = dictInvestigation["nature_of_complaint"];
            string adjustmentParticular = dictInvestigation["adjustment_particular"];
            int noAdjustment = string.IsNullOrEmpty(dictInvestigation["has_adjustment"]) ? 0 : Convert.ToInt32(dictInvestigation["has_adjustment"]);

         
            cbHHPurpose.Checked = Convert.ToBoolean(hhPurpose);
            cbPromoteTrade.Checked = Convert.ToBoolean(promoteTradeBusiness);
            cbSellToNeighbours.Checked = Convert.ToBoolean(sellToNeighbours);
            txtAlternativeSource.Text = alternativeSource;
            nudNoOfHoursServed.Value = noOfHoursServed;
            nudNoServiceOfOutlets.Value = noServiceOutlets;
            txtAccountName.Text = dictInvestigation["customer_name"];
            txtAccountNumber.Text = dictInvestigation["account_number"];
            txtJONumber.Text = dictInvestigation["job_order_no"];
            txtAddress.Text = dictInvestigation["customer_address"];
            _jobOrderId = jobOrdersId;
            _jobOrderNumber = txtJONumber.Text;
            hasAdjustment = string.IsNullOrEmpty(dictInvestigation["adjustment_amount"]) ? false : true;
            txtComplaint.Text = natureOfComplaint;
            txtInvestigatorComments.Text = dictInvestigation["investigator_comments"];
            txtRecommendations.Text = dictInvestigation["recommendations"];

            Dictionary<string, string> meterDict = Factory.CustomersRepository().GetCustomerMeterDetails(txtAccountNumber.Text);
            if (meterDict.Count != 0)
            {
                txtMeterBrand.Text = meterDict["MeterBrand"];
                txtMeterNumber.Text = meterDict["MeterSize"];
                txtMeterSize.Text = meterDict["MeterNumber"];
            }

            nudReadingBeforeTest.Value = readingBeforeTest;
            nudReadingAfterTest.Value = readingAfterTest;
            txtCalibrationResult.Text = calibrationResult;
            txtServiceLineDefects.Text = leakingAfterTheMeter;
            nudImmediateFamily.Value = immediateMembersOfFam;
            nudHouseHelper.Value = houseHelper;
            nudRelatives.Value = relatives;
            nudBoarders.Value = boarders;
            txtApprovalMessage.Text = approvalMessage;
            cbxDisapproved.Checked = dictInvestigation["is_approved"].ToString() == "3";
            cbxRecommendationDisapproved.Checked = dictInvestigation["is_approved"].ToString() == "5";
            cbxForAdjustment.Checked = noAdjustment != 0;

            //loading of picture box
            if (dictInvestigation.ContainsKey("image_path"))
            {
                imageFilePath = dictInvestigation["image_path"]?.ToString();
                if (!string.IsNullOrEmpty(imageFilePath) && File.Exists(imageFilePath))
                {
                    pictureBox1.Image = Image.FromFile(imageFilePath);
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.icons8_image_96;
                }

            }

            if (dictInvestigation.ContainsKey("secondary_image_path"))
            {
                secondaryImageFilePath = dictInvestigation["secondary_image_path"]?.ToString();
                if (!string.IsNullOrEmpty(secondaryImageFilePath) && File.Exists(secondaryImageFilePath))
                {
                    pictureBox2.Image = Image.FromFile(secondaryImageFilePath);
                }
                else
                {
                    pictureBox2.Image = Properties.Resources.icons8_image_96;
                }
            }

            this.ResumeLayout();
            Cursor.Current = Cursors.Default;
        }

        #region Updating of Records for investigator

        private async void dgInvestigations_DoubleClick(object sender, EventArgs e)
        {
            if (dgInvestigations.SelectedRows.Count == 0) return;

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                await Task.Run(() =>
                {
                    ViewInvestigationDetails();
                    UpdateSettings();
                });

                ValidateFormPermission();
                EnableControls(true);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError("Error loading investigation details.");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion
        private void UpdateSettings()
        {
            isUpdate = true;
            DataGridDoubleClicked?.Invoke(this, EventArgs.Empty);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _ = new frmInvestigationImageViewer(imageFilePath).ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _ = new frmInvestigationImageViewer(secondaryImageFilePath).ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var model = new InvestigationModel
            {
                Id = selectedInvestigationID,
            };

            var frmAdjustment = new frmInvestigationAdjustment(this, txtAccountNumber.Text).ShowDialog();
            ViewAdjustment();
        }

        internal void ViewAdjustment()
        {
            var adjustments = Factory.InvestigationRepository().GetViewRecordById(selectedInvestigationID);

            if (adjustments.Count != 0)
            {
                decimal amountDue = !string.IsNullOrWhiteSpace(adjustments["amount_due"]?.ToString()) ? Convert.ToDecimal(adjustments["amount_due"]) : 0;
                decimal penalty = !string.IsNullOrWhiteSpace(adjustments["penalty"]?.ToString()) ? Convert.ToDecimal(adjustments["penalty"]) : 0;
                decimal extensionFee = !string.IsNullOrWhiteSpace(adjustments["extension_fee"]?.ToString()) ? Convert.ToDecimal(adjustments["extension_fee"]) : 0;
                decimal adjustment = !string.IsNullOrWhiteSpace(adjustments["adjustment_amount"]?.ToString()) ? Convert.ToDecimal(adjustments["adjustment_amount"]) : 0;
                decimal adjustedAmount = (amountDue + penalty + extensionFee) - adjustment;
                string adjustedConsumption = adjustments["actual_consumption"];

                lblAmountDue.Text = amountDue.ToString("N2");
                lblExtensionFee.Text = extensionFee.ToString("N2");
                lblPenalty.Text = penalty.ToString("N2");

                lblAdjustedAmount.Text = adjustment.ToString("N2"); 
                lblAdjustment.Text = adjustedAmount.ToString("N2");

            }
        }

        private void CalibrationResult()
        {
            decimal before = nudReadingBeforeTest.Value;
            decimal after = nudReadingAfterTest.Value;

            decimal difference = after - before;

            string result;

            if (difference == 0.20m)
                result = "Passed";
            else if (difference < 0.20m)
                result = "Failed Under";
            else
                result = "Failed Over";

            txtCalibrationResult.Text = result; 
        }

        private void nudReadingAfterTest_ValueChanged(object sender, EventArgs e)
        {
            CalibrationResult();
        }

        internal void btnSearch_Click(object sender, EventArgs e)
        {
            GetInvestigationRecords();
        }

        private void dgInvestigations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dgInvestigations.Columns[e.ColumnIndex].Name == "approval_status" && e.Value != null)
            {
                string status = e.Value.ToString();

                switch (status)
                {
                    case "FOR INVESTIGATION":
                        e.CellStyle.BackColor = Helper.InvestigationStatusColor("FOR INVESTIGATION");    // investigation color :contentReference[oaicite:0]{index=0}
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    case "FOR RECOMMENDATION":
                        e.CellStyle.BackColor = Helper.InvestigationStatusColor("FOR RECOMMENDATION"); // recommendation color :contentReference[oaicite:1]{index=1}
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    case "FOR APPROVAL":
                        e.CellStyle.BackColor = Helper.InvestigationStatusColor("FOR APPROVAL"); // approval-pending color :contentReference[oaicite:2]{index=2}
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    case "APPROVED":
                        e.CellStyle.BackColor = Helper.InvestigationStatusColor("APPROVED"); // approved color :contentReference[oaicite:3]{index=3}
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    case "FOR REINVESTIGATION":
                        e.CellStyle.BackColor = Helper.InvestigationStatusColor("FOR REINVESTIGATION");    // disapproved color :contentReference[oaicite:4]{index=4}
                        e.CellStyle.ForeColor = Color.White;
                        break;  
                    default:
                        e.CellStyle.BackColor = Color.LightGray;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgInvestigations_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void txtApprovalMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetInvestigationRecords();
            }
        }

        private void cbxForAdjustment_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            InvestigationForm();
        }

        private void investigationFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvestigationForm();
        }

        private void InvestigationForm()
        {
            int investigationId = Convert.ToInt32(dgInvestigations.SelectedRows[0].Cells["id"].Value);
            string jobOrderNumber = dgInvestigations.SelectedRows[0].Cells["job_order_no"].Value.ToString();

            _ = new frmInvestigationReport(investigationId, jobOrderNumber).ShowDialog();
        }
    }
}
