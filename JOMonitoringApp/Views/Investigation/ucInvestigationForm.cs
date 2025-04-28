using AccountingSystem;
using Google.Apis.Auth.OAuth2;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.PromptBox;
using JOMonitoringApp.Views.Reports;
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
        internal int _customerId;
        internal bool isUpdate;
        private int selectedInvistigationID;
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
                GetInvestigationRecords();
            }
        }

        internal bool SaveData()
        {
            //TEMPORARY LANG TO
            //if (!ValidateChildren(ValidationConstraints.Enabled))
            //    return false;

            if (isCreate)
            {
                bool saveResults = Factory.InvestigationRepository().Insert(InvestigationModel());



                var statFindingsResult = Factory.InvestigationStatFindingsRepository().Insert(InvestigationStatFindingsModel());
                var conditionOfServiceFacilitiesResult = Factory.InvestigationConditionOfServiceFacilities().Insert(InvestigationConditionOfServiceFacilitiesModel());

                if (saveResults && statFindingsResult && conditionOfServiceFacilitiesResult )
                {
                    OnLoad();
                    return true;
                }

                return false;
            }

            if (Helper.MessageBoxConfirmCancel("Do you want to update this investigation record?"))
            {
                using (var scope = new TransactionScope())
                {
                    var investigationModel = InvestigationModel();
                    var statFindingsModel = InvestigationStatFindingsModel();
                    var conditionOfServiceFacilitiesModel = InvestigationConditionOfServiceFacilitiesModel();
                    var investigationResult = Factory.InvestigationRepository().Update(investigationModel);
                    var statFindingsResult = Factory.InvestigationStatFindingsRepository().Update(statFindingsModel);
                    var conditionOfServiceFacilitiesResult = Factory.InvestigationConditionOfServiceFacilities().Update(conditionOfServiceFacilitiesModel);

                    if (investigationResult && statFindingsResult && conditionOfServiceFacilitiesResult)
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

        private int InvestigationStatusLogic()
        {
            bool noInvestigatorComments = string.IsNullOrEmpty(txtInvestigatorComments.Text.Trim());
            bool noRecommendation = string.IsNullOrEmpty(txtRecommendations.Text.Trim());
            bool noApprovalMessage = string.IsNullOrEmpty(txtApprovalMessage.Text.Trim());
            bool isApproved = radioButton1.Checked;


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

            if (noInvestigatorComments == false && noRecommendation == false && noApprovalMessage == false && radioButton1.Checked)
            {
                return 3;
            }

            if (noInvestigatorComments == false && noRecommendation == false && noApprovalMessage == false && radioButton1.Checked == false)
            {
                return 4;
            }

            return 0;
        }

        private InvestigationModel InvestigationModel()
        {
            var model = new InvestigationModel
            {
                JobOrderId = _jobOrderId,
                JobOrderNo = txtJONumber.Text,
                CustomerId = _customerId,
                CustomerName = txtAccountName.Text,
                CustomerAddress = txtAddress.Text,
                CustomerAccountNumber = txtAccountNumber.Text,
                NatureOfComplaint = cmbxComplaint.Text,
                InvestigatorComments = txtInvestigatorComments.Text,
                DateOfInvestigation = dtpDate.Value,
                ApprovalMessage = string.Empty,
                Recommendations = txtRecommendations.Text,
                imagePath = $"\\\\192.168.18.183\\InvestigationImages\\Dacol\\{Path.GetFileName(imageFilePath)}",
                secondaryImagePath = $"\\\\192.168.18.183\\InvestigationImages\\Dacol\\{Path.GetFileName(secondaryImageFilePath)}",
                IsApproved = InvestigationStatusLogic(),
                CreatedBy = Helper.UserId
            };

            return model;
        }

        private int LastInserted()
        { 
            return Factory.InvestigationRepository().GetLastInsertedId(Helper.UserId);
        }

        private InvestigationConditionOfServiceFacilitiesModel InvestigationConditionOfServiceFacilitiesModel()
        {
            var model = new InvestigationConditionOfServiceFacilitiesModel
            {
                InvestigationId = isCreate == true ? LastInserted() : selectedInvistigationID,
                MeterBrand = cmbxMeterBrand.Text,
                MeterSize = cmbxMeterSize.Text,
                ReadingBeforeTest = nudReadingBeforeTest.Value.ToString(),
                ReadingAfterTest = nudReadingAfterTest.Value.ToString(),
                CalibrationResult = txtCalibrationResult.Text,
                OverRegistration = string.Empty,
                UnderRegistration = string.Empty,
                LeakingAfterTheMeter = txtServiceLineDefects.Text
            };
            return model;
        }

        private InvestigationStatFindingsModel InvestigationStatFindingsModel()
        {
            var model = new InvestigationStatFindingsModel
            {
                InvestigationId = isCreate == true ? LastInserted() : selectedInvistigationID,
                ImmediateMembersOfFam = Convert.ToByte(nudImmediateFamily.Value),
                HouseHelper = Convert.ToByte(nudHouseHelper.Value),
                Relatives = Convert.ToByte(nudRelatives.Value),
                Boarders = Convert.ToByte(nudBoarders.Value),
                NoOfHoursServed = Convert.ToByte(nudNoOfHoursServed.Value),
                NoServiceOutlets = Convert.ToByte(nudNoServiceOfOutlets.Value),
                HhPurpose = cbHHPurpose.Checked,
                PromoteTradeBusiness = cbPromoteTrade.Checked,
                SellToNeighbours = cbHHPurpose.Checked,
                AlternativeSource = txtAlternativeSource.Text
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

        private void nudImmediateFamily_Validating(object sender, CancelEventArgs e)
        {
            if (nudImmediateFamily.Value == 0)
            {
                e.Cancel = true;
                Helper.ShowErrorNumericUpDownZero(errorProvider1, nudImmediateFamily, "Immediate Family.");
            }
        }

        private void nudImmediateFamily_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudImmediateFamily);
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
                    Helper.MessageBoxSuccess("File I/O error: " + ioEx.Message);
                }
                catch (UnauthorizedAccessException unAuthEx)
                {
                    Helper.MessageBoxSuccess("Access error: " + unAuthEx.Message);
                }
                catch (Exception ex)
                {
                    Helper.MessageBoxSuccess("Unexpected error: " + ex.Message);
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

            var dtInvestigation = Factory.InvestigationRepository().GetViewRecordsBySearch(searchKey);
            HelperLoadRecords.InvestigationDatagridView(dgInvestigations, dtInvestigation);
        }

        internal void EnableControls(bool enable)
        {
            btnPrint.Enabled = enable;
            gbStatisticalFindings.Enabled = enable;
            gbAccountDetails.Enabled = enable;
            gbComments.Enabled = enable;
            gbConditionOfService.Enabled = enable;
            gbImage.Enabled = enable;
            gbApproval.Enabled = enable;
            gbComputation.Enabled = enable;
            dgInvestigations.Enabled = !enable;
        }

        private void ViewInvestigationDetails()
        {
            if (dgInvestigations.SelectedRows.Count > 0)
            {
                EnableControls(true);
                isUpdate = true;
                selectedInvistigationID = Convert.ToInt32(dgInvestigations.SelectedRows[0].Cells["id"].Value);
                dictInvestigation = Factory.InvestigationRepository().GetViewRecordById(selectedInvistigationID);

                // Assigning additional columns to variables
                //int csfId = Convert.ToInt32(dictInvestigation["id"]);
                int investigationId = Convert.ToInt32(dictInvestigation["id"]);
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
                int isfId = Convert.ToInt32(dictInvestigation["isf_id"]);
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

                //loading of picture box

                if (dictInvestigation.ContainsKey("image_path"))
                {
                    imageFilePath = dictInvestigation["image_path"]?.ToString();
                    if (!string.IsNullOrEmpty(imageFilePath) && File.Exists(imageFilePath))
                    {
                        pictureBox1.Image = Image.FromFile(imageFilePath);
                    }
                }

                if (dictInvestigation.ContainsKey("secondary_image_path"))
                {
                    secondaryImageFilePath = dictInvestigation["secondary_image_path"]?.ToString();
                    if (!string.IsNullOrEmpty(secondaryImageFilePath) && File.Exists(secondaryImageFilePath))
                    {
                        pictureBox2.Image = Image.FromFile(secondaryImageFilePath);
                    }
                }

            }
            else
            {
                MessageBox.Show("Please select a row to view details.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel? All unsaved changes will be lost.", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ResetForm();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dictInvestigation.Count != 0)
                _ = new frmInvestigationReport(_jobOrderId, _jobOrderNumber).ShowDialog();
        }

   

        #region Updating of Records for investigator

        private void dgInvestigations_DoubleClick(object sender, EventArgs e)
        {
            if (dgInvestigations.SelectedRows.Count == 0) return;

            ViewInvestigationDetails();
            UpdateSettings();



            DataGridDoubleClicked?.Invoke(this, EventArgs.Empty);
            EnableControls(true);
            isUpdate = true;

        }


        #endregion
        private void UpdateSettings()
        {
            isUpdate = true;
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
            if (Helper.UserId == 15)
            {

                _ = new frmInvestigationAdjustment(txtAccountNumber.Text).ShowDialog();
                return;
            }

            _ = new frmMessagePrompt().ShowDialog();
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

        private void dgInvestigations_DockChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetInvestigationRecords();

        }

        private void dgInvestigations_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
 
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
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    case "FOR RECOMMENDATION":
                        e.CellStyle.BackColor = Helper.InvestigationStatusColor("FOR RECOMMENDATION"); // recommendation color :contentReference[oaicite:1]{index=1}
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    case "FOR APPROVAL":
                        e.CellStyle.BackColor = Helper.InvestigationStatusColor("FOR APPROVAL"); // approval-pending color :contentReference[oaicite:2]{index=2}
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    case "APPROVED":
                        e.CellStyle.BackColor = Helper.InvestigationStatusColor("APPROVED"); // approved color :contentReference[oaicite:3]{index=3}
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    case "DISAPPROVED":
                        e.CellStyle.BackColor = Helper.InvestigationStatusColor("DISAPPROVED");    // disapproved color :contentReference[oaicite:4]{index=4}
                        e.CellStyle.ForeColor = Color.Black;
                        break;  
                    default:
                        e.CellStyle.BackColor = Color.LightGray;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
