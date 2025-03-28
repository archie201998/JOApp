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
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Error");

            }
        }

        private bool SaveData()
        {
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
                ReadingBeforeTest = Convert.ToDecimal(txtReadingBeforeTest.Text),
                ReadingAfterTest = Convert.ToDecimal(txtReadingAfterTest.Text),
                CalibrationResult = txtCalibrationResult.Text,
                OverRegistration = 124,
                UnderRegistration = 142,
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

    }
}
