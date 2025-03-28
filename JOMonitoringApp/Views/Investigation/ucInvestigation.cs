using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.JobOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Investigation
{
    public partial class ucInvestigation : UserControl
    {
        private int _jobOrderId = 53;   
        public ucInvestigation()
        {
            InitializeComponent();
        }

        private void gbAccountDetails_Enter(object sender, EventArgs e)
        {
                                
        }

        private void ucInvestigation_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Investigation has been saved successfully.");
                ResetForm();
            }
            try
            {
               
            }
            catch (Exception)
            {
                Helper.MessageBoxError("Please complete necessary fields.");
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

                CustomerId = 10,
                CustomerName = "CustomerName",
                CustomerAddress = "CustomerAddress",
                CustomerAccountNumber = "CustomerAccountNumber",
                NatureOfComplaint = cmbxComplaint.Text,    
                InvestigatorComments = txtInvestigatorComments.Text,
                Recommendations = txtRecommendations.Text
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
            cmbxComplaint.SelectedIndex = -1;
            txtInvestigatorComments.Clear();
            txtRecommendations.Clear();
            cmbxMeterBrand.SelectedIndex = -1;
            txtMeterSize.Clear();
            txtReadingBeforeTest.Clear();
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
        }

        private void btnViewImages_Click(object sender, EventArgs e)
        {
            _ = new frmInvestigationImageViewer().ShowDialog();
          
        }

    }
}
