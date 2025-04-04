using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.JobOrder;
using JOMonitoringApp.Views.PromptBox;
using JOMonitoringApp.Views.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Investigation
{
    public partial class ucInvestigationForm : UserControl
    {
        internal int _jobOrderId;
        internal string _customerAddress;
        internal int _customerId;
        internal bool isUpdate;

        string originalFileName = string.Empty;
        private string trimedAccountName;
        private string newFileName;
        string selectedFilePath = string.Empty;
        private Dictionary<string, string> dictInvestigation;

        string imageFilePath = string.Empty;
        string secondaryImageFilePath = string.Empty;

        public ucInvestigationForm()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgInvestigations);
        }

        private void gbAccountDetails_Enter(object sender, EventArgs e)
        {
                                
        }

        private void ucInvestigation_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                GetInvestigationRecords();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                UploadImage();
                Helper.MessageBoxSuccess("Investigation record has been saved successfully.");
                ResetForm();
            }
            try
            {
               
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError("Please complete necessary fields." + ex.Message);
            }
           
        }

        private bool SaveData()
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
                return false;


            using (var scope = new TransactionScope())
            {
                var investigationModel = InvestigationModel();
                var investigationIResult = Factory.InvestigationRepository().Insert(investigationModel);

                if (investigationIResult)
                {
                    var statFindingsModel = InvestigationStatFindingsModel();
                    var conditionOfServiceFacilitiesModel = InvestigationConditionOfServiceFacilitiesModel();

                    int lastInsertedId = Factory.InvestigationRepository().GetLastInsertedId(Helper.UserId);

                    statFindingsModel.InvestigationId = lastInsertedId;
                    conditionOfServiceFacilitiesModel.InvestigationId = lastInsertedId;

                    var statFindingsResult = Factory.InvestigationStatFindingsRepository().Insert(statFindingsModel);
                    var conditionOfServiceFacilitiesResult = Factory.InvestigationConditionOfServiceFacilities().Insert(conditionOfServiceFacilitiesModel); 

                    if (statFindingsResult && conditionOfServiceFacilitiesResult)
                    {
                        scope.Complete();
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
        }

        private InvestigationModel InvestigationModel()
        {
            var model = new InvestigationModel
            {
                JobOrderId = _jobOrderId,
                CustomerId = _customerId,
                CustomerName = txtAccountName.Text,
                CustomerAddress = _customerAddress,
                CustomerAccountNumber = txtAccountNumber.Text,
                NatureOfComplaint = cmbxComplaint.Text,    
                InvestigatorComments = txtInvestigatorComments.Text,
                Recommendations = txtRecommendations.Text,
                imagePath = imageFilePath,
                secondaryImagePath = secondaryImageFilePath
            };

            return model;
        }


        private InvestigationConditionOfServiceFacilitiesModel InvestigationConditionOfServiceFacilitiesModel()
        {
            var model = new InvestigationConditionOfServiceFacilitiesModel
            {
                MeterBrand = cmbxMeterBrand.Text,
                MeterSize = txtMeterSize.Text,
                ReadingBeforeTest = txtReadingBeforeTest.Text,
                ReadingAfterTest = txtReadingAfterTest.Text,
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

        private void cmbxComplaint_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void cmbxComplaint_Validating(object sender, CancelEventArgs e)
        {
            if (cmbxComplaint.Text == string.Empty )
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


        private void ResetForm()
        {
            txtAccountName.Clear();
            txtAccountNumber.Clear();
            txtJORemarks.Clear();
            cmbxComplaint.SelectedIndex = -1;
            txtInvestigatorComments.Clear();
            txtRecommendations.Clear();
            cmbxMeterBrand.SelectedIndex = -1;
            txtMeterSize.Clear();
            txtReadingBeforeTest.Clear();
            txtJONumber.Clear();
            txtReadingAfterTest.Clear();
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
            lblFileName.Text = "---";
            isUpdate = false;
            btnSave.BackColor = Color.DodgerBlue;
            btnSave.Text = "Save";
        }

        private void btnViewImages_Click(object sender, EventArgs e)
        {
            _ = new frmInvestigationImageViewer().ShowDialog();
          
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
                        MessageBox.Show("Please select only 2 images", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    imageFilePath   = openFileDialog.FileNames[0];
                    secondaryImageFilePath = openFileDialog.FileNames[1];

                    lblFileName.Text = $"{imageFilePath.Remove(4, 1)} / {secondaryImageFilePath.Remove(4, 1)}";
                }
            }
        }

        private void UploadImage()
        {
            // Implement the logic to upload the image to the server or save it locally
            // Example: Save the file to a specific directory

            string sharedFolderPath = @"\\192.168.18.183\InvestigationImages\Dacol"; // Replace with your shared folder path
            File.Copy(imageFilePath, Path.Combine(sharedFolderPath, imageFilePath), true);
            File.Copy(imageFilePath, Path.Combine(sharedFolderPath, secondaryImageFilePath), true);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnAttachedImage_Validating(object sender, CancelEventArgs e)
        {
            if (lblFileName.Text == "---")
            {
                errorProvider1.SetError(btnAttachedImage, "PLease insert at least one image.");
                e.Cancel = true;    
            }
        }

        internal void OnLoad()
        {
            GetInvestigationRecords();
        }

        private void GetInvestigationRecords()
        {
            var dtInvestigation = Factory.InvestigationRepository().GetRecords();
            HelperLoadRecords.InvestigationDatagridView(dgInvestigations, dtInvestigation);
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            ViewInvestigationDetails();
            UpdateSettings();
        }

        private void UpdateSettings()
        {
            btnSave.BackColor = Color.OrangeRed;
            btnSave.Text = "Update";
            isUpdate = true;
        }

        private void ViewInvestigationDetails()
        {
            if (dgInvestigations.SelectedRows.Count > 0)
            {
                isUpdate = true;
                int selectedId = Convert.ToInt32(dgInvestigations.SelectedRows[0].Cells["id"].Value);
                dictInvestigation = Factory.InvestigationRepository().GetViewRecordById(selectedId);

         
                // Assigning additional columns to variables
                int csfId = Convert.ToInt32(dictInvestigation["csf_id"]);
                int investigationId = Convert.ToInt32(dictInvestigation["investigation_id"]);
                string meterBrand = dictInvestigation["meter_brand"];
                string meterSize = dictInvestigation["meter_size"];
                string readingBeforeTest = dictInvestigation["reading_before_test"];
                string readingAfterTest = dictInvestigation["reading_after_test"];
                string calibrationResult = dictInvestigation["calibration_result"];
                string overRegistration = dictInvestigation["over_registration"];
                string underRegistration = dictInvestigation["under_registration"];
                string leakingAfterTheMeter = dictInvestigation["leaking_after_the_meter"];
                int jobOrdersId = Convert.ToInt32(dictInvestigation["job_orders_id"]);
                int customersId = Convert.ToInt32(dictInvestigation["customers_id"]);
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
                cmbxComplaint.Text = dictInvestigation["nature_of_complaint"];
                txtInvestigatorComments.Text = dictInvestigation["investigator_comments"];
                txtRecommendations.Text = dictInvestigation["recommendations"];
                cmbxMeterBrand.Text = meterBrand;
                txtMeterSize.Text = meterSize;
                txtReadingBeforeTest.Text = readingBeforeTest;
                txtReadingAfterTest.Text = readingAfterTest;
                txtCalibrationResult.Text = calibrationResult;
                txtServiceLineDefects.Text = leakingAfterTheMeter;
                nudImmediateFamily.Value = immediateMembersOfFam;
                nudHouseHelper.Value = houseHelper;
                nudRelatives.Value = relatives;
                nudBoarders.Value = boarders;
                

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
            if (dictInvestigation.Count !=  0)
                _ = new frmInvestigationReport(dictInvestigation).ShowDialog();

        }
        public string GetSelectedImagePath()
        {
            return imageFilePath;
        }

        public string GetSecondaryImagePath()
        {
            return secondaryImageFilePath;
        }
    }
}
