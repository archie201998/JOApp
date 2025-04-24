using AccountingSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Investigation
{
    
    public partial class frmInvestigationAdjustment : Form
    {

        private readonly string _accountNumber; 

        public frmInvestigationAdjustment(string accountNumber)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            _accountNumber = accountNumber;

            lblAccountNumber.Text = _accountNumber;
        }

        private void frmInvestigationAdjustment_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void frmInvestigationAdjustment_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string particular = cmbxParticular.Text;
            //Leaking
            //Leaking(Not Visible)
            //Failed Calibration
            //Erroneous Reading
            //RFB + Illegal


            switch (particular)
            {
                case "Leaking":
                    ComputeLeaking();
                    break;
                case "Failed Calibration":
                    ComputeFailedCalibration();
                    break;

                case "Erroneous Reading":
                    ComputeErroneousReading();
                    break;

                case "Leaking (Not Visible)":
                    ComputeLeakingNotVisible();
                    break;

                default:
                    break;
            }
        }

        private void ComputeLeaking()
        {
            MessageBox.Show("ComputeLeaking");
        }

        private void ComputeLeakingNotVisible()
        {
            MessageBox.Show("ComputeLeakingNotVisible");
        }

        private void ComputeErroneousReading()
        {
            if (_accountNumber != string.Empty)
            {
                var readingDetails = Factory.CustomersRepository().GetBillingDetails(_accountNumber);

                txtPreviousReading.Text = readingDetails["Prev"].ToString();
                txtPresentReading.Text = readingDetails["Pres"].ToString();
                txtActualReading.Focus();
            }
            
        }

        private void ComputeFailedCalibration()
        {
            MessageBox.Show("ComputeFailedCalibration");
        }

        private void txtActualReading_TextChanged(object sender, EventArgs e)
        {
            Compute();
        }

        private void Compute()
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

                if (cbxPenalty.Checked) 
                    adjustedAmount += adjustedAmount * 0.10;

                if (cbxExtensionFee.Checked)
                    adjustedAmount += 30;


                lblAdjustedAmount.Text = adjustedAmount.ToString("N2");

                


            }
            else
            {
                MessageBox.Show("Please enter valid numeric readings.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConsumption.Text = "";
            }
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


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Compute();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Compute();
        }
    }
}
