using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.PromptBox;
using Mysqlx.Crud;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Investigation
{
    public partial class frmInvestigationAdjustment : Form
    {

        private readonly string _accountNumber;
        private readonly ucInvestigationForm _ucInvestigationForm;
        private bool _hasAdjustment;

        int locationX = 0;
        int locationY = 0;

        public frmInvestigationAdjustment(ucInvestigationForm ucInvestigationForm, string accountNumber)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            _accountNumber = accountNumber;
            txtAccountNumber.Text = _accountNumber;
            _ucInvestigationForm = ucInvestigationForm;

            locationX = gbLeakingNotVisible.Location.X;
            locationY = gbLeakingNotVisible.Location.Y;
        }

        private void frmInvestigationAdjustment_Load(object sender, EventArgs e)
        {
            LoadAccountDetails();

            if (_ucInvestigationForm.hasAdjustment)
                LoadAdjustments();
        }
        private void LoadAccountDetails()
        {

            var dictCustomerAccountDetails = Factory.CustomersRepository().GetCustomerAccountDetails(_accountNumber);

            if (dictCustomerAccountDetails.Count != 0)
            {
                txtAccountType.Text = dictCustomerAccountDetails["Category"];
                txtAccountName.Text = dictCustomerAccountDetails["AccountName"];
                txtAccountNumber.Text = _accountNumber;
            }
        }

        private void LoadAdjustments()
        {
            int investigationID = _ucInvestigationForm.selectedInvistigationID;
            var adjustmentDict = Factory.InvestigationRepository().GetViewRecordById(investigationID);

            if (adjustmentDict.Count != 0)
            {
                cmbxParticular.Text = adjustmentDict["adjustment_particular"];
                
            }

        }


        private void ComputeIllegal()
        {
            gbIllegal.Location = new System.Drawing.Point(locationX, locationY);
        }

        private void ComputeLeakingNotVisible()
        {
            gbLeakingNotVisible.Location = new System.Drawing.Point(locationX, locationY);

            var dictReadingDetails = Factory.CustomersRepository().GetBillingDetails(_accountNumber);

            if (dictReadingDetails.Count != 0 )
            {
                decimal currentCons = Convert.ToDecimal(dictReadingDetails["CurrentCons"]);
                int averageCons = int.Parse(dictReadingDetails["AverageCons"]);
                decimal consumption = currentCons == 0 ? averageCons : currentCons;

                decimal adjustmentConsumption = (currentCons * 0.70m);
                decimal adjustedConsumption = (currentCons - adjustmentConsumption );


                txtLeakingNotVisCurrentCons.Text = consumption.ToString("N0");
                txtAdjustedConsumption.Text = adjustedConsumption.ToString("N0");
                txtAdjustmentConsumption.Text = adjustmentConsumption.ToString("N0");

                double amountDue = GetRateByConsumption((int)adjustmentConsumption);
                txtAmountDue.Text = amountDue.ToString("N0");
            }

        }

        private void ComputeFailedCalibration()
        {
            gbFailedCalibration.Location = new System.Drawing.Point(locationX, locationY);

            int last3Month, last2Month = 0, lastMonth = 0;

            // Validate and parse all inputs safely
            bool isValid =
                int.TryParse(txtLast3Month.Text, out last3Month) &&
                int.TryParse(txtLast2Month.Text, out last2Month) &&
                int.TryParse(txtLastMonth.Text, out lastMonth);

            if (isValid)
            {
                int average = (lastMonth + last2Month + last3Month) / 3;
                txtNewAverageCons.Text = average.ToString();

            }
            else
            {
                //MessageBox.Show("Please enter valid numeric values for all three months.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewAverageCons.Text = ""; // Clear output if invalid
            }

        }
        private void GetPreviusReadingDetails()
        {
            try
            {
                gbErrorReading.Location = new System.Drawing.Point(locationX, locationY);

                if (_accountNumber != string.Empty)
                {
                    var readingDetails = Factory.CustomersRepository().GetBillingDetails(_accountNumber);

                    txtPreviousReading.Text = readingDetails["Prev"].ToString();
                    txtPresentReading.Text = readingDetails["Pres"].ToString();
                    txtActualReading.Focus();
                }
            }
            catch (Exception)
            {
            }
        }


        private void ComputeErrorReading()
        {
            int previousReading, actualReading;
            double adjustedAmount = 0.0;

            double overHundredRate = 0.0;


            if (int.TryParse(txtPreviousReading.Text, out previousReading) &&
                int.TryParse(txtActualReading.Text, out actualReading))
            {
                int consumption = actualReading - previousReading;
                double underHundredRate = 0;

                if (consumption < 100 && consumption > 1)
                    underHundredRate = GetRateByConsumption(consumption);

                txtConsumption.Text = consumption.ToString();

                adjustedAmount = underHundredRate;


                
                //6720
            }
            else
                txtConsumption.Text = "";
        }

        private double GetRateByConsumption(int consumption)
        {
            var rateDict = Helper.WaterRates();

            if (rateDict.TryGetValue(consumption, out double rate))
            {

                bool isCommercial = txtAccountType.Text != "RESIDENTIAL";
                return isCommercial ? rate * 2: rate;
            }

            throw new ArgumentException("Invalid quantity. Must be between 1 and 100.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Compute();
            //ComputePenaltyAndExtensionFee();
           
        }

        private void Compute()
        {
            string particular = cmbxParticular.Text;

            switch (particular)
            {
                case "Failed Calibration":
                    ComputeFailedCalibration();
                    break;

                case "Erroneous Reading":
                    GetPreviusReadingDetails();
                    ComputeErrorReading();
                    break;

                case "Leaking (Not Visible)":
                    ComputeLeakingNotVisible();
                    break;

                case "RFB + Illegal":
                    ComputeIllegal();
                    break;

                default:
                    break;
            }
        }

        private void cmbxParticular_SelectedIndexChanged(object sender, EventArgs e)
        {
            Compute();

            gbErrorReading.Location = new System.Drawing.Point(1000, 1000);
            gbLeakingNotVisible.Location = new System.Drawing.Point(1000, 1000);
            gbIllegal.Location = new System.Drawing.Point(1000, 1000);
            gbFailedCalibration.Location = new System.Drawing.Point(1000, 1000);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Helper.adjustmentParticular = cmbxParticular.Text;

            _ucInvestigationForm.lblAdjustedAmount.Text = Helper.adjustedAmount;


            bool result = Factory.InvestigationRepository().SaveComputation(InvestigationModel());

            if (result)
            {
                Helper.MessageBoxSuccess("Adjustment has been successfully saved.");
                Close();
            }
        }

        private InvestigationModel InvestigationModel()
        {
            if (cmbxParticular.Text == "Erroneous Reading")
            {
                var investigationModel = new InvestigationModel()
                {
                    Id = _ucInvestigationForm.selectedInvistigationID,
                    PreviousReading = txtPreviousReading.Text,
                    PresentReading = txtPresentReading.Text,
                    ActualReading = txtActualReading.Text,
                    PresentConsumption = txtConsumption.Text,

                    Penalty = Convert.ToDecimal(txtPenalty.Text),
                    ExtensionFee = Convert.ToDecimal(txtExtensionFee.Text),
                    AmountDue = Convert.ToDecimal(txtAmountDue.Text),
                    AdjustmentParticular = "Erroneous Reading",
                    UpdatedBy = Helper.UserId,
                };

                return investigationModel;
            }


            if (cmbxParticular.Text == "Failed Calibration")
            {
                var investigationModel = new InvestigationModel()
                {
                    Id = _ucInvestigationForm.selectedInvistigationID,
                    AverageConsumption = txtNewAverageCons.Text,

                    Penalty = Convert.ToDecimal(txtPenalty.Text),
                    ExtensionFee = Convert.ToDecimal(txtExtensionFee.Text),
                    AmountDue = Convert.ToDecimal(txtAmountDue.Text),
                    AdjustmentParticular = "Failed Calibration",
                    UpdatedBy = Helper.UserId,
                };

                return investigationModel;
            }

            if (cmbxParticular.Text == "Leaking (Not Visible)")
            {
                var investigationModel = new InvestigationModel()
                {
                    Id = _ucInvestigationForm.selectedInvistigationID,
                    PresentConsumption = txtLeakingNotVisCurrentCons.Text,
                    ActualConsumption = txtAdjustmentConsumption.Text,

                    Penalty = Convert.ToDecimal(txtPenalty.Text),
                    ExtensionFee = Convert.ToDecimal(txtExtensionFee.Text),
                    AmountDue = Convert.ToDecimal(txtAmountDue.Text),
                    AdjustmentParticular = "Leaking (Not Visible)",
                    UpdatedBy = Helper.UserId,
                };

                return investigationModel;
            }

            if (cmbxParticular.Text == "RFB + ILLEGAL")
            {
                var investigationModel = new InvestigationModel()
                {
                    Id = _ucInvestigationForm.selectedInvistigationID,

                    PreviousConsumption = txtConsOnDisconnection.Text,
                    ActualReading = txtConsAfterDisconnection.Text,

                    Penalty = Convert.ToDecimal(txtPenalty.Text),
                    ExtensionFee = Convert.ToDecimal(txtExtensionFee.Text),
                    AmountDue = Convert.ToDecimal(txtAmountDue.Text),
                    AdjustmentParticular = "RFB + Illegal",
                    UpdatedBy = Helper.UserId,
                };

                return investigationModel;
            }


            return null;
        }

        private void txtLastMonth_Leave(object sender, EventArgs e)
        {
            int last3Month, last2Month = 0, lastMonth = 0;

            // Validate and parse all inputs safely
            bool isValid =
                int.TryParse(txtLast3Month.Text, out last3Month) &&
                int.TryParse(txtLast2Month.Text, out last2Month) &&
                int.TryParse(txtLastMonth.Text, out lastMonth);

            if (isValid)
            {
                int average = (lastMonth + last2Month + last3Month) / 3;
                txtNewAverageCons.Text = average.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cbxExtensionFee_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxExtensionFee.Checked)
                txtExtensionFee.Text = "30";
            else
                txtExtensionFee.Text = "0";
        }

        private void cbxPenalty_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPenalty.Checked)
                txtPenalty.Text = (Convert.ToDecimal(txtAmountDue.Text) * 0.10m).ToString();
            else
                txtPenalty.Text = "0";
        }

        private void txtActualReading_Leave(object sender, EventArgs e)
        {
            try
            {
                txtConsumption.Text = (Convert.ToDecimal(txtActualReading.Text) - Convert.ToDecimal(txtPreviousReading.Text)).ToString();
            }
            catch (Exception)
            {
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void txtPenalty_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal amountDue = Convert.ToDecimal(txtAmountDue.Text);
            decimal penalty = Convert.ToDecimal(txtPenalty.Text);
            decimal extensionFee = Convert.ToDecimal(txtExtensionFee.Text);


            bool isCommercial = txtAccountType.Text != "RESIDENTIAL";

            txtAmountDueAfterAdjustment.Text = (amountDue + penalty + extensionFee).ToString("N2");
        }
    }
}
