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
            lblAccountNumber.Text = _accountNumber;
            _ucInvestigationForm = ucInvestigationForm;

            locationX = gbLeakingVisible.Location.X;
            locationY = gbLeakingVisible.Location.Y;
        }

        private void frmInvestigationAdjustment_Load(object sender, EventArgs e)
        {
            if (_ucInvestigationForm.hasAdjustment)
            {
                LoadAdjustments();
            }
        }

        private void LoadAdjustments()
        {
            int investigationID = _ucInvestigationForm.selectedInvistigationID;
            var adjustmentDict = Factory.InvestigationRepository().GetViewRecordById(investigationID);

            if (adjustmentDict.Count != 0)
            {
                cmbxParticular.Text = adjustmentDict["adjustment_particular"];
                lblAdjustedAmount.Text = adjustmentDict["adjusted_amount"];
            }

        }


        private void ComputeIllegal()
        {
            gbIllegal.Location = new System.Drawing.Point(locationX, locationY);
        }

        private void ComputeLeaking()
        {
            gbLeakingVisible.Location = new System.Drawing.Point(locationX, locationY);
        }

        private void ComputeLeakingNotVisible()
        {
            gbLeakingNotVisible.Location = new System.Drawing.Point(locationX, locationY);

            // Parse input values safely
            if (int.TryParse(txtLeakingCurrentCons.Text.Trim(), out int currentCons) &&
                int.TryParse(txtLeakingCorrectCons.Text.Trim(), out int correctCons))
            {
                decimal adjustedCons = currentCons * 0.7m;

                lblAdjustedAmount.Text = GetRateByConsumption(Convert.ToInt32(adjustedCons)).ToString("N2");
            }
            else
            {
                //MessageBox.Show("Please enter valid numeric values for current and correct consumption.",
                //                "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                lblAdjustedAmount.Text = GetRateByConsumption(average).ToString("N2");
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

                lblAdjustedAmount.Text = adjustedAmount.ToString("N2");

                
                //6720
            }
            else
                txtConsumption.Text = "";
        }

        static double GetRateByConsumption(int consumption)
        {
            var rateDict = Helper.DomesticRate();

            if (rateDict.TryGetValue(consumption, out double rate))
            {
                return rate;
            }

            throw new ArgumentException("Invalid quantity. Must be between 1 and 100.");
        }

        private void ComputePenaltyAndExtensionFee()
        {
            decimal adjustedAmount;

            if (!decimal.TryParse(lblAdjustedAmount.Text, out adjustedAmount))
            {
                return;
            }

            if (cbxPenalty.Checked)
                adjustedAmount += adjustedAmount * 0.10m;

            if (cbxExtensionFee.Checked)
                adjustedAmount += 30;

            lblAdjustedAmount.Text = adjustedAmount.ToString("0.00");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Komputadora();
            //ComputePenaltyAndExtensionFee();
            _ = new frmMessagePrompt().ShowDialog();
        }

        private void Komputadora()
        {
            string particular = cmbxParticular.Text;

            gbErrorReading.Location = new System.Drawing.Point(1000, 1000);
            gbLeakingNotVisible.Location = new System.Drawing.Point(1000, 1000);
            gbLeakingVisible.Location = new System.Drawing.Point(1000);
            gbIllegal.Location = new System.Drawing.Point(1000, 1000);
            gbFailedCalibration.Location = new System.Drawing.Point(1000, 1000);

            switch (particular)
            {
                case "Leaking":
                    ComputeLeaking();
                    break;
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
            Komputadora();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Helper.adjustedAmount = lblAdjustedAmount.Text;
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
                    AdjustedAmount = Convert.ToDecimal(lblAdjustedAmount.Text),
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
                    AdjustedAmount = Convert.ToDecimal(lblAdjustedAmount.Text),
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
                    ActualConsumption = txtLeakingNotVisNewCons.Text,

                    Penalty = Convert.ToDecimal(txtPenalty.Text),
                    ExtensionFee = Convert.ToDecimal(txtExtensionFee.Text),
                    AmountDue = Convert.ToDecimal(txtAmountDue.Text),
                    AdjustedAmount = Convert.ToDecimal(lblAdjustedAmount.Text),
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
                    AdjustedAmount = Convert.ToDecimal(lblAdjustedAmount.Text),
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
            decimal adjustmentAmount = Convert.ToDecimal(lblAdjustedAmount.Text);
            if (cbxPenalty.Checked)
                txtPenalty.Text = (adjustmentAmount * 0.10m).ToString("N2");
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
    }
}
