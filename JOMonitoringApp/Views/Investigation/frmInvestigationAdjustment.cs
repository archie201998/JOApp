using AccountingSystem;
using JOMonitoringApp.Interface;
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
            Helper.DatagridFullRowSelectStyleEditable(dgParticularAdjustment);
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
            int investigationID = _ucInvestigationForm.selectedInvestigationID;
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
                    break;
            }
        }


        private void btnAutoCompute_Click(object sender, EventArgs e)
        {
            ComputeFactors();
        }

        private void ComputeFactors()
        {
            string accountNumber = txtAccountNumber.Text.Trim();
            var dictReadingDetails = Factory.CustomersRepository().GetBillingDetails(accountNumber);


            foreach (DataGridViewRow dgvRow in dgParticularAdjustment.Rows)
            {
                
                if (dgvRow.IsNewRow) continue;

                var particular = dgvRow.Cells["particular"].Value?.ToString();

                if (particular == "Average Consumption (Last 3 Months)")
                {
                    dgvRow.Cells["_value"].Value = dictReadingDetails["AverageCons"];
                }
                else if (particular == "Previous Reading (Previous Month)")
                {
                    dgvRow.Cells["_value"].Value = dictReadingDetails["Prev"];
                }
                else if (particular == "Present Reading (Current Month)")
                {
                    dgvRow.Cells["_value"].Value = dictReadingDetails["Pres"];
                }
                
                else if (particular == "Illegal Connection")
                {
                    dgvRow.Cells["_value"].Value = "6000";
                }
                else if (particular == "VAT (12%)")
                {
                    dgvRow.Cells["_value"].Value = "720";
                }


                txtAmountDue.Text = dictReadingDetails["AmountDue"];
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (updateAdjustment)
                UpdateAdjustment();
            else
            {
                if (SaveAdjustment())
                {
                    Helper.MessageBoxSuccess("Adjustment has been successfully saved.");
                    Close();
                }
               
            }
                
        }

        private void UpdateAdjustment()
        {
            throw new NotImplementedException();
        }

        private bool SaveAdjustment()
        {
            if (Helper.MessageBoxConfirmCancel("Do you confirm to save this adjustment?"))
            {
                foreach (DataGridViewRow dgvRow in dgParticularAdjustment.Rows)
                {
                    string particular = dgvRow.Cells["particular"].Value?.ToString();
                    string value = dgvRow.Cells["_value"].Value?.ToString();

                    var investigationAdjustmentModel = new InvestigationAdjustmentModel
                    {
                        Particular = particular,
                        Value = value,
                        InvestigationId = _ucInvestigationForm.selectedInvestigationID,
                    };

                    bool result = Factory.InvestigationAdjustmentRepository().Insert(investigationAdjustmentModel);

                    if (!result) return false;
                }
                return true;
            }

            return false;
        }

        private InvestigationModel InvestigationModel()
        {

            var investigationModel = new InvestigationModel
            {
                Id = _ucInvestigationForm.selectedInvestigationID,
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

        private void particularFactors_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string itemText = particularFactors.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked)
            {
                dgParticularAdjustment.Rows.Add(itemText);
            }
            else
            {
                foreach (DataGridViewRow row in dgParticularAdjustment.Rows)
                {
                    if (row.Cells[0].Value.ToString() == itemText)
                    {
                        dgParticularAdjustment.Rows.Remove(row);
                        break;
                    }
                }
            }

        }

        private void dgParticularAdjustment_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                // Get the value entered in the cell
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string cellValue = dgParticularAdjustment.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                    // Proceed with the rest of the logic
                    if (!decimal.TryParse(cellValue, out decimal numericValue))
                    {
                        Helper.MessageBoxWarning("Please enter a valid numeric value.");
                        dgParticularAdjustment.CancelEdit();
                    }

                }
                   
            }
        }

        private void particularFactors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
