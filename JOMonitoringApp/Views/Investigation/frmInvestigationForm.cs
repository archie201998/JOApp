using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.Investigation.Attachment;
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

namespace JOMonitoringApp.Views.Investigation
{
    public partial class frmInvestigationForm : Form
    {

        string imageFilePath = string.Empty;
        string secondaryImageFilePath = string.Empty;

        internal readonly int _investigationId;
        private readonly frmInvestigation _frmInvestigation;
        private int _jobOrderId;
        internal bool _hasAdjustment;
        private bool _billAdjustmentIsAllowed = false;
        private frmInvestigation frmInvestigation;

       
        public frmInvestigationForm(frmInvestigation frmInvestigation, int investigationId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            this.frmInvestigation = frmInvestigation;
            _investigationId = investigationId;
            _frmInvestigation = frmInvestigation;
        }

        public frmInvestigationForm(int investigationId)
        {
            _investigationId = investigationId;
            Helper.LoadFormIcon(this);
            _investigationId = investigationId;
            _frmInvestigation = frmInvestigation;
        }

        private void frmInvestigationForm_Load(object sender, EventArgs e)
        {
            OnLoad();

            if (radInvestigation.Checked || radReInvestigation.Checked)
            {
                cmbxInvestigationFindings.Visible = true;
                LoadInvestigationFindings();
            }
        }

        private void OnLoad()
        {
            if (!DesignMode)
            {
                LoadSelectedRecord();
                lblImage.Text = string.IsNullOrEmpty(imageFilePath) ? "Attach Image" : (imageFilePath.StartsWith("http") ? "View Link" : "View Image");

                //transfer to reset form 
                dtpDateInvestigated.Enabled = cbxDateOfInvestigation.Checked;
                ViewAdjustment();
            }
        }

        private void LoadInvestigationFindings()
        {
            var dtFindings = Factory.InvestigationFindingsRepository().Reasons();

            if (dtFindings != null && dtFindings.Rows.Count > 0)
            {
                DataRow blankRow = dtFindings.NewRow();
                blankRow["id"] = DBNull.Value; 
                blankRow["reason"] = "SELECT FINDINGS";
                dtFindings.Rows.InsertAt(blankRow, 0);
            }

            cmbxInvestigationFindings.DataSource = dtFindings;
            cmbxInvestigationFindings.DisplayMember = "reason";
            cmbxInvestigationFindings.ValueMember = "id";
            cmbxInvestigationFindings.SelectedIndex = 0;
        }

        private void LoadInvestigationExplanation(int reasonId)
        {
            int _reasonId = reasonId;
            string explanation = Factory.InvestigationFindingsRepository().ReasonsExplanation(_reasonId);
            
            txtInvestigatorComments.Text = explanation;
        }

        private void LoadSelectedRecord()
        {
            try
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

                this.ResumeLayout();
                Cursor.Current = Cursors.Default;
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
                    _billAdjustmentIsAllowed = false;
                    break;
                case 1:
                    radRecommendation.Checked = true;
                    _billAdjustmentIsAllowed = false;
                    break;
                case 2:
                    radAdjustment.Checked = true;
                    _billAdjustmentIsAllowed = true;
                    break;
                case 3:
                    radApproval.Checked = true;
                    _billAdjustmentIsAllowed = true;
                    break;
                case 4:
                    radApproved.Checked = true;
                    _billAdjustmentIsAllowed = true;
                    break;
                case 5:
                    radReInvestigation.Checked = true;
                    _billAdjustmentIsAllowed = false;
                    break;
            }
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
                    Close();
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
                {
                    return false;
                }
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

            Factory.JobOrdersRepository().UpdateStatus(_jobOrderId, jobOrderStatus); 
        }

        private void UploadImage()
        {
            try
            {
                if (!string.IsNullOrEmpty(imageFilePath) || !string.IsNullOrEmpty(secondaryImageFilePath))
                {
                    string sharedFolderPath = @"\\PWCServerPag\InvestigationImage";

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
            if (radInvestigation.Checked)
                return 0;
            if (radRecommendation.Checked)
                return 1;
            if (radAdjustment.Checked)
                return 2;
            if (radApproval.Checked)
                return 3;
            if (radApproved.Checked)
                return 4;
            if (radReInvestigation.Checked)
                return 5;
            return 0;
        }

        private InvestigationModel InvestigationModel()
        {

            string folderPath = "\\\\" + Helper.ServerName + "\\InvestigationImage\\";
            string secondFolderPath = "\\\\" + Helper.ServerName + "\\InvestigationImage\\";

            string _ImagePath = string.IsNullOrEmpty(imageFilePath) ? string.Empty : folderPath + Path.GetFileName(imageFilePath);
            string _SecondaryImagePath = string.IsNullOrEmpty(secondaryImageFilePath) ? string.Empty : secondFolderPath + Path.GetFileName(secondaryImageFilePath);


            if (Helper.attachLink)
            {
                _ImagePath = Helper.imageLink1;
                _SecondaryImagePath = Helper.imageLink2; 
            }

            var model = new InvestigationModel
            {
                Id = _investigationId,
                JobOrderId = _jobOrderId,
                JobOrderNo = txtJONumber.Text.Trim(),
                CustomerName = txtAccountName.Text.Trim(),
                CustomerAddress = txtAddress.Text.Trim(),
                CustomerAccountNumber = txtAccountNumber.Text.Trim(),
                NatureOfComplaint = txtComplaint.Text.Trim(),
                InvestigatorComments = txtInvestigatorComments.Text,
                DateOfInvestigation = cbxDateOfInvestigation.Checked ? (DateTime?)dtpDateInvestigated.Value : null,
                ApprovalMessage = txtApprovalMessage.Text.Trim(),
                Recommendations = txtRecommendations.Text.Trim(),
                ImagePath = _ImagePath,
                SecondaryImagePath = _SecondaryImagePath,
                IsApproved = GetInvestigationStatus(),
                AlternativeSource = txtAlternativeSource.Text.Trim(),
                MeterBrand = txtMeterBrand.Text,
                MeterSize = txtMeterSize.Text,
                MeterNumber = txtMeterNumber.Text,
                ReadingBeforeTest = nudReadingBeforeTest.Value.ToString(),
                ReadingAfterTest = nudReadingAfterTest.Value.ToString(),
                CalibrationResult = txtCalibrationResult.Text,
                ImmediateMembersOfFam = Convert.ToByte(txtImmediateFamily.Text),
                HouseHelper = Convert.ToByte(txtHouseHelper.Text),
                Relatives = Convert.ToByte(txtRelatives.Text),
                Boarders = Convert.ToByte(txtBoarders.Text),
                NoOfHoursServed = Convert.ToByte(txtHoursServed.Text),
                NoServiceOutlets = Convert.ToByte(txtServiceOutlets.Text),
                HhPurpose = Convert.ToBoolean(cbHHPurpose.Checked),
                Government = Convert.ToBoolean(cbGovernment.Checked),
                PromoteTradeBusiness = Convert.ToBoolean(cbPromoteTrade.Checked),
                SellToNeighbours = Convert.ToBoolean(cbSellToNeighbours.Checked),
                InvestigatedBy = cmbxInvestigator.Text.Trim(),
                UpdatedBy = Helper.CurrentUserID
            };

            return model;
        }

        private void AttachImage()
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
                    secondaryImageFilePath = selectedCount == 2 ? openFileDialog.FileNames[1] : null;
                    lblImage.Text = "View Image";
                }
            }
        }   

        private void label21_Click(object sender, EventArgs e)
        {
            if (lblImage.Text == "Attach Image") //view file
            {
                _ = new frmAttachmentSelector().ShowDialog();

                if (Helper.attachLink)
                {
                    _ = new frmLinkAttachment(string.Empty, string.Empty).ShowDialog();
                }
                else
                {
                    AttachImage();
                }

            }
            else if (lblImage.Text == "View Link")
            {
                _ = new frmLinkAttachment(imageFilePath, secondaryImageFilePath).ShowDialog();   
            }
            else
            {
                _ = new frmInvestigationImageViewer(imageFilePath, secondaryImageFilePath, _investigationId).ShowDialog();
                imageFilePath = Helper.ImagePath;
                secondaryImageFilePath = Helper.SecondaryImagePath;
                lblImage.Text = imageFilePath == string.Empty ? "Attach Image" : "View Image";

                lblImage.Text = string.IsNullOrEmpty(imageFilePath) ? "Attach Image" : (imageFilePath.StartsWith("http") ? "View Link" : "View Image");

            }
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
            if (_billAdjustmentIsAllowed)
            {
                var adjustmentForm = new frmInvestigationAdjustment(_frmInvestigation, this);
                ShowMdiChildForm(adjustmentForm);
                ViewAdjustment();
                return;
            }

            Helper.MessageBoxSuccess("Adjustments cannot be made at this time. Please wait for further recommendations before proceeding.");
        }

        private void ShowMdiChildForm(Form form)
        {
            form.MdiParent = _frmInvestigation;
            form.Show();
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        
        internal void ViewAdjustment()
        {
            var adjustments = Factory.InvestigationRepository().GetViewRecordById(_investigationId);

            if (adjustments.Count != 0) 
            {
                decimal waterBill = Convert.ToDecimal(adjustments["water_bill"]);
                decimal waterBillAdjustedAmount = Convert.ToDecimal(adjustments["adjusted_water_bill"]);
                decimal waterBillAdjustment = Convert.ToDecimal(adjustments["water_bill_adjustment"]);

                lblWaterBill.Text = waterBill.ToString("N2");
                lblAdjusted.Text = waterBillAdjustedAmount.ToString("N2");
                lblAdjustment.Text = waterBillAdjustment.ToString("N2");
                lblOtherFees.Text = "0.00";
                return;
            }

            lblWaterBill.Text = "0.00";
            lblAdjusted.Text = "0.00";
            lblAdjustment.Text = "0.00";
            lblOtherFees.Text = "0.00";
        }

        private void radInvestigation_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmbxInvestigator_Validating(object sender, CancelEventArgs e)
        {

        }

        private void cmbxInvestigator_Validated(object sender, EventArgs e)
        {

        }

        private void frmInvestigationForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveClick();
            }

            if (e.Control && e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }

        private void cmbxInvestigationFindings_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbxInvestigationFindings.SelectedValue != null &&
            cmbxInvestigationFindings.SelectedValue != DBNull.Value)
            {
                int reasonId = Convert.ToInt32(cmbxInvestigationFindings.SelectedValue);
                if (reasonId != 0)
                    LoadInvestigationExplanation(reasonId);
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
