using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.PromptBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
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
        internal int selectedInvistigationID;
        string originalFileName = string.Empty;
        private string trimedAccountName;
        private string newFileName;
        string selectedFilePath = string.Empty;
        private Dictionary<string, string> dictInvestigation;
        internal string particular = string.Empty;

        internal bool isCreate = false;

        string imageFilePath = string.Empty;
        string secondaryImageFilePath = string.Empty;

        private Dictionary<string, string> originalValues = new Dictionary<string, string>();
        private string _jobOrderNumber;

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
                GetInvestigationRecords();
            }
        }

        private void ValidateFormPermission()
        {
            bool adminMode = Helper.temporaryAdminMode;
           gbAccountDetails.Enabled = adminMode ? true : Helper.UserHasPermission("INVESTIGATION_DATA");
           gbStatisticalFindings.Enabled = adminMode ? true : Helper.UserHasPermission("STATISTICAL_FINDINGS");
           gbConditionOfService.Enabled = adminMode ? true : Helper.UserHasPermission("CONDITION_OF_SERVICE_FACILITIES");
           txtInvestigatorComments.Enabled = adminMode ? true : Helper.UserHasPermission("INVESTIGATION_COMMENTS");
           txtRecommendations.Enabled = adminMode ? true : Helper.UserHasPermission("INVESTIGATION_RECOMMENDATION");
           btnCompute.Enabled = adminMode ? true : Helper.UserHasPermission("INVESTIGATION_ADJUSTMENT_COMPUTATION");
           btnAttachedImage.Enabled = adminMode ? true : Helper.UserHasPermission("INVESTIGATION_ATTACHED_IMAGE");
           pictureBox1.Enabled = adminMode ? true : Helper.UserHasPermission("INVESTIGATION_VIEW_ATTACHED_IMAGE");
           pictureBox2.Enabled = adminMode ? true : Helper.UserHasPermission("INVESTIGATION_VIEW_ATTACHED_IMAGE");
           gbApproval.Enabled = adminMode ? true : Helper.UserHasPermission("INVESTIGATION_APPROVAL");
        }

        internal bool SaveData()
        {
            if (Helper.MessageBoxConfirmCancel("Do you want to update this investigation data?"))
            {
                using (var scope = new TransactionScope())
                {
                    var investigationModel = InvestigationModel();
                    var investigationResult = Factory.InvestigationRepository().Update(investigationModel);
                 
                    if (investigationResult)
                    {
                        UploadImage();
                        ResetForm();
                        scope.Complete();
                        return true;
                    }
                    else
                        return false;
                }
            }

            return false;
          
        }

        internal int InvestigationStatusLogic()
        {
            bool noInvestigatorComments = string.IsNullOrEmpty(txtInvestigatorComments.Text.Trim());
            bool noRecommendation = string.IsNullOrEmpty(txtRecommendations.Text.Trim());
            bool noApprovalMessage = string.IsNullOrEmpty(txtApprovalMessage.Text.Trim());
            bool isApproved = radApproved.Checked;


            if (noInvestigatorComments && noRecommendation)
            {
                return 0;
            }

            if (noInvestigatorComments == false && noRecommendation)
            {
                return 1; 
            }

            if (noInvestigatorComments == false && noRecommendation == false && noApprovalMessage)
            {
                return 2;
            }

            if (noInvestigatorComments == false && noRecommendation == false && noApprovalMessage == false && radApproved.Checked)
            {
                return 3;
            }

            if (noInvestigatorComments == false && noRecommendation == false && noApprovalMessage == false && radDisapproved.Checked == false)
            {
                return 4;
            }

            return 0;
        }

        private InvestigationModel InvestigationModel()
        {
            var model = new InvestigationModel
            {
                Id = selectedInvistigationID,
                JobOrderId = _jobOrderId,
                JobOrderNo = txtJONumber.Text,
                CustomerName = txtAccountName.Text,
                CustomerAddress = txtAddress.Text,
                CustomerAccountNumber = txtAccountNumber.Text,
                NatureOfComplaint = cmbxComplaint.Text,
                InvestigatorComments = txtInvestigatorComments.Text,
                DateOfInvestigation = dtpDate.Value,
                ApprovalMessage = txtApprovalMessage.Text,
                Recommendations = txtRecommendations.Text,
                imagePath = $"\\\\{Helper.serverStatisIPAddress}\\InvestigationImages\\Dacol\\{Path.GetFileName(imageFilePath)}",
                secondaryImagePath = $"\\\\{Helper.serverStatisIPAddress}\\InvestigationImages\\Dacol\\{Path.GetFileName(secondaryImageFilePath)}",
                IsApproved = InvestigationStatusLogic(),
                AlternativeSource = txtAlternativeSource.Text,
                MeterBrand = cmbxMeterBrand.Text,
                MeterSize = cmbxMeterSize.Text,
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
                PromoteTradeBusiness = Convert.ToBoolean(cbPromoteTrade.Checked),
                SellToNeighbours = Convert.ToBoolean(cbSellToNeighbours.Checked),
                CreatedBy = Helper.UserId,

            };

            return model;
        }

        private void cmbxComplaint_Validating(object sender, CancelEventArgs e)
        {
            if (cmbxComplaint.Text == string.Empty)
            {
                e.Cancel = true;
                Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxComplaint, "Nature of Complain.");
            }
        }

        private void cmbxComplaint_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxComplaint);
        }

        private void txtInvestigatorComments_Validating(object sender, CancelEventArgs e)
        {
            if (txtInvestigatorComments.Text.Trim() == string.Empty)
            {
                e.Cancel = true;
                Helper.ShowErrorTextBoxEmpty(errorProvider1, txtInvestigatorComments, "Investigator Comment.");
            }
        }

        private void txtInvestigatorComments_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtInvestigatorComments);
        }

        internal void ResetForm()
        {
            txtAccountName.Clear();
            txtAccountNumber.Clear();
            txtAddress.Clear();
            cmbxComplaint.SelectedIndex = -1;
            txtInvestigatorComments.Clear();
            txtRecommendations.Clear();
            cmbxMeterBrand.SelectedIndex = -1;
            cmbxMeterSize.SelectedIndex = -1;
            nudReadingAfterTest.Value = 0 ;
            txtJONumber.Clear();
            nudReadingBeforeTest.Value = 0;
            txtCalibrationResult.Clear();
            txtServiceLineDefects.Clear();
            nudImmediateFamily.Value = 0;
            nudHouseHelper.Value = 0;
            nudRelatives.Value = 0;
            nudBoarders.Value = 0;
            nudNoOfHoursServed.Value = 0;
            nudNoServiceOfOutlets.Value = 0;
            cbHHPurpose.Checked = false;
            cbPromoteTrade.Checked = false;
            cbSellToNeighbours.Checked = false;
            txtAlternativeSource.Clear();
            isUpdate = false;
            pictureBox1.Image = Properties.Resources.icons8_image_96;
            pictureBox2.Image = Properties.Resources.icons8_image_96;
            cmbxStatus.SelectedValue = 5;
        }


        private void btnAttachedImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.FileNames.Length > 2)
                    {
                        Helper.MessageBoxSuccess("Please select 2 images");
                        return;
                    }

                    imageFilePath = openFileDialog.FileNames[0];
                    secondaryImageFilePath = openFileDialog.FileNames.Length == 1
                        ? openFileDialog.FileNames[0]
                        : openFileDialog.FileNames[1];

                    pictureBox1.Image = Image.FromFile(imageFilePath);
                    pictureBox2.Image = Image.FromFile(secondaryImageFilePath);

                }
            }
        }

        private void UploadImage()
        {
            if (!string.IsNullOrEmpty(imageFilePath) && !string.IsNullOrEmpty(secondaryImageFilePath))
            {
                string sharedFolderPath = @"\\192.168.18.183\InvestigationImages\Dacol";

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
                Helper.MessageBoxSuccess("One or both file paths are empty or null.");
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        internal void OnLoad()
        {
            GetInvestigationRecords();
        }


        private void GetInvestigationRecords()
        {
            string searchKey = txtSearch.Text.Trim();
            int statusId = Convert.ToInt32(cmbxStatus.SelectedValue);


            var dtInvestigation = Factory.InvestigationRepository().GetViewRecordsBySearch(statusId, searchKey);
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
        }

        private void dgInvestigations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewInvestigationDetails();
        }

        internal void ViewInvestigationDetails()
        {

            if (selectedInvistigationID == 0)
            {
                selectedInvistigationID = Convert.ToInt32(dgInvestigations.SelectedRows[0].Cells["id"].Value);
            }

            dictInvestigation = Factory.InvestigationRepository().GetViewRecordById(selectedInvistigationID);

            string meterBrand = dictInvestigation["meter_brand"];
            string meterSize = dictInvestigation["meter_size"];
            decimal readingBeforeTest = string.IsNullOrEmpty(dictInvestigation["reading_before_test"]) ?  0 : Convert.ToDecimal(dictInvestigation["reading_before_test"]);
            decimal readingAfterTest = string.IsNullOrEmpty(dictInvestigation["reading_after_test"]) ? 0 :  Convert.ToDecimal(dictInvestigation["reading_after_test"]);
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

            cmbxComplaint.Text = dictInvestigation["nature_of_complaint"];
            txtInvestigatorComments.Text = dictInvestigation["investigator_comments"];
            txtRecommendations.Text = dictInvestigation["recommendations"];
            cmbxMeterBrand.Text = meterBrand;
            cmbxMeterSize.Text = meterSize;
            nudReadingBeforeTest.Value = readingBeforeTest;
            nudReadingAfterTest.Value = readingAfterTest;
            txtCalibrationResult.Text = calibrationResult;
            txtServiceLineDefects.Text = leakingAfterTheMeter;
            nudImmediateFamily.Value = immediateMembersOfFam;
            nudHouseHelper.Value = houseHelper;
            nudRelatives.Value = relatives;
            nudBoarders.Value = boarders;
            txtApprovalMessage.Text = approvalMessage;
            radApproved.Checked = dictInvestigation["is_approved"].ToString() == "3";
            radDisapproved.Checked = dictInvestigation["is_approved"].ToString() == "4";

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

        }
   
        #region Updating of Records for investigator

        private void dgInvestigations_DoubleClick(object sender, EventArgs e)
        {
            if (dgInvestigations.SelectedRows.Count == 0) return;

            ViewInvestigationDetails();
            UpdateSettings();
            EnableControls(true);
            ValidateFormPermission();
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
            _ = new frmInvestigationAdjustment(txtAccountNumber.Text).ShowDialog();
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

        private void btnSearch_Click(object sender, EventArgs e)
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
                    case "DISAPPROVED":
                        e.CellStyle.BackColor = Helper.InvestigationStatusColor("DISAPPROVED");    // disapproved color :contentReference[oaicite:4]{index=4}
                        e.CellStyle.ForeColor = Color.White;
                        break;  
                    default:
                        e.CellStyle.BackColor = Color.LightGray;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }

     
    }
}
