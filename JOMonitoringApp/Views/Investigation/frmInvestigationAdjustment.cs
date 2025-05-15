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

        bool updateAdjustment = false;
        bool manualComputeMode = false;
        bool _isUpdate;

        public frmInvestigationAdjustment(ucInvestigationForm ucInvestigationForm, string accountNumber)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            _accountNumber = accountNumber;
            txtAccountNumber.Text = _accountNumber;
            _ucInvestigationForm = ucInvestigationForm;
            locationX = 12;
            locationY = 182;
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
            var adjustments = Factory.InvestigationRepository().GetViewRecordById(investigationID);

            if (adjustments.Count != 0)
            {

                decimal amountDue = !string.IsNullOrWhiteSpace(adjustments["amount_due"]?.ToString()) ? Convert.ToDecimal(adjustments["amount_due"]) : 0;
                decimal penalty = !string.IsNullOrWhiteSpace(adjustments["penalty"]?.ToString()) ? Convert.ToDecimal(adjustments["penalty"]) : 0;
                decimal extensionFee = !string.IsNullOrWhiteSpace(adjustments["extension_fee"]?.ToString()) ? Convert.ToDecimal(adjustments["extension_fee"]) : 0;
                decimal adjustment = !string.IsNullOrWhiteSpace(adjustments["adjustment_amount"]?.ToString()) ? Convert.ToDecimal(adjustments["adjustment_amount"]) : 0;
                decimal adjustedAmount = (amountDue + penalty + extensionFee) - adjustment;
                string particular = adjustments["adjustment_particular"].ToString();

                cmbxParticular.SelectedItem = particular;
                txtAmountDue.Text = amountDue.ToString("N2");
                txtExtensionFee.Text = extensionFee.ToString("N2");
                txtPenalty.Text = penalty.ToString("N2");
                txtAdjustment.Text = adjustment.ToString("N2");
                txtAmountDueAfterAdjustment.Text = adjustedAmount.ToString("N2");


                txtPreviousReading.Text = adjustments["previous_reading"].ToString();
                txtPresentReading.Text = adjustments["present_reading"].ToString();
                txtActualReading.Text = adjustments["actual_reading"].ToString();
                txtConsumption .Text = adjustments["present_consumption"].ToString();

                txtConsOnDisconnection.Text = adjustments["previous_consumption"].ToString();
                txtConsAfterDisconnection.Text = adjustments["present_consumption"].ToString();

                //txtLeakingNotVisCurrentCons.Text = adjustments["last_three_months_consumption"].ToString();
                //txtAdjustmentConsumption.Text = adjustments["actual_consumption"].ToString();
                //txtAdjustedConsumption.Text = adjustments["actual_consumption"].ToString();

            }
        }


        private void ComputeIllegal()
        {

        }

        private void ComputeLeakingNotVisible()
        {
            gbLeakingNotVisible.Location = new System.Drawing.Point(locationX, locationY);

            var dictReadingDetails = Factory.CustomersRepository().GetBillingDetails(_accountNumber);

            if (dictReadingDetails.Count != 0)
            {
                decimal currentCons = Convert.ToDecimal(dictReadingDetails["CurrentCons"]);
                int averageCons = int.Parse(dictReadingDetails["AverageCons"]);
                decimal consumption = currentCons == 0 ? averageCons : currentCons;

                decimal adjustmentConsumption = (currentCons * 0.70m);
                decimal adjustedConsumption = (currentCons - adjustmentConsumption);

                txtLeakingNotVisCurrentCons.Text = consumption.ToString("N0");
                txtAdjustedConsumption.Text = adjustedConsumption.ToString("N0");
                txtAdjustmentConsumption.Text = adjustmentConsumption.ToString("N0");

                double amountDue = GetRateByConsumption((int)currentCons);
                txtAmountDue.Text = amountDue.ToString("N0");
            }

        }

        private void ComputeFailedCalibration()
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
                return isCommercial ? rate * 2 : rate;
            }

            throw new ArgumentException("Invalid quantity. Must be between 1 and 100.");
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
            SetFields();
        }

        private void SetFields()
        {
            string particular = cmbxParticular.Text;

            btnAutoCompute.Enabled = true;
            btnManualCompute.Enabled = true;
            gbErrorReading.Location = new System.Drawing.Point(1000, 1000);
            gbIllegal.Location = new System.Drawing.Point(1000, 1000);
            gbFailedCalibration.Location = new System.Drawing.Point(1000, 1000);
            gbLeakingNotVisible.Location = new System.Drawing.Point(1000, 1000);

            switch (particular)
            {
                case "Failed Calibration":

                    gbFailedCalibration.Location = new System.Drawing.Point(locationX, locationY);
                    break;

                case "Erroneous Reading":
                    gbErrorReading.Location = new System.Drawing.Point(locationX, locationY);
                    break;

                case "Leaking (Not Visible)":
                    gbLeakingNotVisible.Location = new System.Drawing.Point(locationX, locationY);
                    break;

                case "RFB + Illegal":
                    gbIllegal.Location = new System.Drawing.Point(locationX, locationY);
                    break;

                default:

                    gbErrorReading.Location = new System.Drawing.Point(1000, 1000);
                    gbIllegal.Location = new System.Drawing.Point(1000, 1000);
                    gbFailedCalibration.Location = new System.Drawing.Point(1000, 1000);
                    gbLeakingNotVisible.Location = new System.Drawing.Point(1000, 1000);
                    btnAutoCompute.Enabled = false;
                    btnManualCompute.Enabled = false;
                    break;
            }
        }

        private void btnManualCompute_Click(object sender, EventArgs e)
        {
            manualComputeMode = true;
            ClearFields();
            LoadAccountDetails();
            Helper.MessageBoxSuccess("Manual Computation Enabled.");
        }

        private void ClearFields()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (control is GroupBox groupBox)
                {
                    foreach (Control innerControl in groupBox.Controls)
                    {
                        if (innerControl is TextBox innerTextBox)
                        {
                            innerTextBox.Clear();
                        }
                    }
                }
            }

            txtAmountDue.Text = "0";
            txtAdjustment.Text = "0";
            txtPenalty.Text = "0";
            txtExtensionFee.Text = "0";
            txtAmountDueAfterAdjustment.Text = "0";
        }

        private void btnAutoCompute_Click(object sender, EventArgs e)
        {
            manualComputeMode = false;
            Compute();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (updateAdjustment)
                UpdateAdjustment();
            else
                SaveAdjustment();
        }

        private void UpdateAdjustment()
        {
            throw new NotImplementedException();
        }

        private void SaveAdjustment()
        {
            if (Helper.MessageBoxConfirmCancel("Do you confirm to save this adjustment?"))
            {
                bool result = Factory.InvestigationRepository().SaveComputation(InvestigationModel());

                if (result)
                {
                    Helper.MessageBoxSuccess("Adjustment has been successfully saved.");
                    Close();
                }
            }

            return;
        }

        private InvestigationModel InvestigationModel()
        {

            var investigationModel = new InvestigationModel
            {
                Id = _ucInvestigationForm.selectedInvistigationID,
                UpdatedBy = Helper.UserId
            };

            if (cmbxParticular.Text == "Leaking (Not Visible)")
            {
                investigationModel.AdjustmentParticular = "Leaking (Not Visible)";
                investigationModel.ActualConsumption = txtAdjustmentConsumption.Text;
            }

            if (cmbxParticular.Text == "Erroneous Reading")
            {
                investigationModel.AdjustmentParticular = "Erroneous Reading";
                investigationModel.ActualConsumption = txtConsumption.Text;
            }

            if (cmbxParticular.Text == "Failed Calibration")
            {
                investigationModel.AdjustmentParticular = "Failed Calibration";
            }

            if (cmbxParticular.Text == "RFB + ILLEGAL")
            {
                investigationModel.AdjustmentParticular = "RFB + ILLEGAL";
                investigationModel.ActualConsumption = txtConsAfterDisconnection.Text;
            }

            investigationModel.Penalty = Convert.ToDecimal(txtPenalty.Text.Trim());
            investigationModel.ExtensionFee = Convert.ToDecimal(txtExtensionFee.Text.Trim());
            investigationModel.AmountDue = Convert.ToDecimal(txtAmountDue.Text.Trim());
            investigationModel.Adjustment = Convert.ToDecimal(txtAdjustment.Text.Trim());
            investigationModel.AdjustmentAmount = Convert.ToDecimal(txtAmountDueAfterAdjustment.Text.Trim());
            return investigationModel;

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
            try
            {
                if (cbxPenalty.Checked)
                    txtPenalty.Text = (Convert.ToDecimal(txtAmountDue.Text) * 0.10m).ToString();
                else
                    txtPenalty.Text = "0";
            }
            catch (Exception) { }
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
            try
            {
                decimal amountDue = Convert.ToDecimal(txtAmountDue.Text.Trim());
                decimal penalty = Convert.ToDecimal(txtPenalty.Text.Trim());
                decimal extensionFee = Convert.ToDecimal(txtExtensionFee.Text.Trim());
                decimal adjustment = Convert.ToDecimal(txtAdjustment.Text.Trim());
                decimal adjustedAmount = ((amountDue - adjustment) + penalty + extensionFee);

                bool isCommercial = txtAccountType.Text != "RESIDENTIAL";

                txtAmountDueAfterAdjustment.Text = adjustedAmount.ToString("N2");
            }
            catch (Exception) { }
         
        }

        private void txtAdjustmentConsumption_TextChanged(object sender, EventArgs e)
        {
            if (!manualComputeMode)
            {
                ComputeLeakingNotVisible();
            }
        }

        private void txtConsumption_TextChanged(object sender, EventArgs e)
        {
            if (!manualComputeMode)
                ComputeErrorReading();
        }

        private void txtLast3Month_TextChanged(object sender, EventArgs e)
        {
            if (!manualComputeMode)
                ComputeFailedCalibration();
        }

        private void txtConsOnDisconnection_TextChanged(object sender, EventArgs e)
        {
            if (!manualComputeMode)
                ComputeIllegal();
        }

    }
}
