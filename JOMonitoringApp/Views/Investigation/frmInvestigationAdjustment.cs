using AccountingSystem;
using System;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Investigation
{
    public partial class frmInvestigationAdjustment : Form
    {

        private readonly string _accountNumber;
        private readonly ucInvestigationForm _ucInvestigationForm;
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
            cmbxParticular.SelectedIndex = -1;
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
            Komputadora();
            ComputePenaltyAndExtensionFee();
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
            _ucInvestigationForm.lblAdjustedAmount.Text = lblAdjustedAmount.Text;
            Close();
        }
    }
}
