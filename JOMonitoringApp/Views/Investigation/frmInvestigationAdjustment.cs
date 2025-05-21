using AccountingSystem;
using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.PromptBox;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Investigation
{
    public partial class frmInvestigationAdjustment : Form
    {

        private readonly string _accountNumber;
        private readonly ucInvestigationForm _ucInvestigationForm;
   
        int locationX = 0;
        int locationY = 0;

        bool updateAdjustment = false;
        bool manualComputeMode = false;
        bool _isUpdate;

        private bool isUpdating = false;
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

            //initial load.
            string accountNumber = txtAccountNumber.Text.Trim();
            var dictReadingDetails = Factory.CustomersRepository().GetBillingDetails(accountNumber);
            txtAmountDue.Text = Convert.ToDecimal(dictReadingDetails["AmountDue"]).ToString("N2");

            //initial load.

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
            var adjustmentDetails = Factory.InvestigationAdjustmentRepository().GetRecordsBySearch(investigationID.ToString());

            if (adjustments.Count != 0)
            {

                decimal amountDue = !string.IsNullOrWhiteSpace(adjustments["amount_due"]?.ToString()) ? Convert.ToDecimal(adjustments["amount_due"]) : 0;
                decimal penalty = !string.IsNullOrWhiteSpace(adjustments["penalty"]?.ToString()) ? Convert.ToDecimal(adjustments["penalty"]) : 0;
                decimal extensionFee = !string.IsNullOrWhiteSpace(adjustments["extension_fee"]?.ToString()) ? Convert.ToDecimal(adjustments["extension_fee"]) : 0;
                decimal adjustment = !string.IsNullOrWhiteSpace(adjustments["adjustment_amount"]?.ToString()) ? Convert.ToDecimal(adjustments["adjustment_amount"]) : 0;
                decimal adjustedAmount = (amountDue - adjustment) + penalty + extensionFee;
                string particular = adjustments["adjustment_particular"].ToString();
                decimal _adjustedAmount = !string.IsNullOrWhiteSpace(adjustments["adjusted_amount"]?.ToString()) ? Convert.ToDecimal(adjustments["adjusted_amount"]) : 0;

                cmbxParticular.SelectedItem = particular;
                txtAmountDue.Text = amountDue.ToString("N2");


                txtAdjustedDue.Text  = (_adjustedAmount - extensionFee - penalty).ToString("N2");
                txtExtensionFee.Text = extensionFee.ToString("N2");
                txtPenalty.Text = penalty.ToString("N2");
                txtAdjustment.Text = adjustment.ToString("N2");
                txtAmountDueAfterAdjustment.Text = adjustedAmount.ToString("N2");



                var itemsCopy = particularFactors.Items.Cast<object>().ToList();
                foreach (var item in itemsCopy)
                {
                    foreach (DataRow row in adjustmentDetails.Rows)
                    {
                        if (row["particular"].ToString() == item.ToString())
                        {
                            particularFactors.SetItemChecked(particularFactors.Items.IndexOf(item), true);
                        }
                    }
                }

            }
        }


        private void ComputeIllegal()
        {

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


        private void cmbxParticular_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAutoCompute_Click(object sender, EventArgs e)
        {
            ComputeFactors();
        }


        public decimal GetAverageCons(string accountNumber)
        {
            DataTable dt = Factory.CustomersRepository().GetAverageCons(accountNumber);

            decimal totalCons = 0;
            foreach (DataRow item in dt.Rows)
            {
                totalCons += Convert.ToDecimal(item["CurrentCons"]);
            }

            return totalCons/3;
        }
        private void ComputeFactors()
        {
            foreach (DataGridViewRow dgvRow in dgParticularAdjustment.Rows)
            {
                
                if (dgvRow.IsNewRow) continue;

                var particular = dgvRow.Cells["particular"].Value?.ToString();

                if (particular == "Average Consumption (Last 3 Months)")
                {

                }
                else if (particular == "Previous Reading (Previous Month)")
                {

                }
                else if (particular == "Present Reading (Current Month)")
                {

                }

                else if (particular == "Present Consumption")
                {

                }  

                else if (particular == "Actual Consumption")
                {
        
                }

                else if (particular == "30% of Current Consumption")
                {
                  
                }

                else if (particular == "70% of Current Consumption")
                {
                    
                }

                else if (particular == "Illegal Connection")
                {
                    dgvRow.Cells["_value"].Value = Helper.illegalConnectionFee.ToString("N2");

                    decimal adjustedAmount = Convert.ToDecimal(txtAmountDueAfterAdjustment.Text.Trim());
                    adjustedAmount += Helper.illegalConnectionFee;
                    txtAmountDueAfterAdjustment.Text = adjustedAmount.ToString("N2");
                }
                else if (particular == "+ VAT (12%)")
                {
                    dgvRow.Cells["_value"].Value = Helper.illegalConnectionFeeVAT.ToString("N2");


                    decimal adjustedAmount = Convert.ToDecimal(txtAmountDueAfterAdjustment.Text.Trim());
                    adjustedAmount +=  Helper.illegalConnectionFeeVAT;
                    txtAmountDueAfterAdjustment.Text = adjustedAmount.ToString("N2");   
                }
                else if (particular == "Previous Consumption")
                {
                  
                }
                else
                {
                  
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Factory.InvestigationRepository().SaveComputation(InvestigationModel());

                if (updateAdjustment)
                    UpdateAdjustment();
               
                if (SaveAdjustment())
                {
                    Helper.MessageBoxSuccess("Adjustment has been successfully saved.");
                    Close();
                }
            }
            catch (Exception)
            {
                Helper.MessageBoxError("Something went wrong. Please contact your system administrator.");
            }
        }

        private void UpdateAdjustment()
        {
            int investigationID = _ucInvestigationForm.selectedInvestigationID;
            if (Factory.InvestigationAdjustmentRepository().DeleteAdjustments(investigationID))
            {
                return;
            }
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
            }
            if (cmbxParticular.Text == "Erroneous Reading")
            {
                investigationModel.AdjustmentParticular = "Erroneous Reading";
            }

            if (cmbxParticular.Text == "Failed Calibration")
            {
                investigationModel.AdjustmentParticular = "Failed Calibration";
            }

            if (cmbxParticular.Text == "RFB + ILLEGAL")
            {
                investigationModel.AdjustmentParticular = "RFB + ILLEGAL";
            }

            investigationModel.Penalty = Convert.ToDecimal(txtPenalty.Text.Trim());
            investigationModel.ExtensionFee = Convert.ToDecimal(txtExtensionFee.Text.Trim());
            investigationModel.AmountDue = Convert.ToDecimal(txtAmountDue.Text.Trim());
            investigationModel.AdjustmentAmount = Convert.ToDecimal(txtAdjustment.Text.Trim());
            investigationModel.AdjustedAmountDue = Convert.ToDecimal(txtAmountDueAfterAdjustment.Text.Trim());
            return investigationModel;

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cbxExtensionFee_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void cbxPenalty_CheckedChanged(object sender, EventArgs e)
        {
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
            if (isUpdating) return;

            try
            {
                isUpdating = true;

                decimal amountDue = decimal.Parse(txtAmountDue.Text.Trim());

                decimal textAdjustedDue = decimal.Parse(txtAdjustedDue.Text.Trim());
                decimal penalty = decimal.Parse(txtPenalty.Text.Trim());
                decimal extensionFee = decimal.Parse(txtExtensionFee.Text.Trim());
                decimal adjustedDue = textAdjustedDue + penalty + extensionFee;



                decimal adjustment = decimal.Parse(txtAdjustment.Text.Trim());

                decimal adjustedAmount = amountDue - adjustment;

                txtAdjustment.Text = (amountDue - adjustedDue).ToString("N2");
                txtAmountDueAfterAdjustment.Text = adjustedAmount.ToString("N2");
            }
            catch (FormatException)
            {
                //MessageBox.Show("Please enter valid numbers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isUpdating = false;
            }
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
                if (_ucInvestigationForm.hasAdjustment)
                {
                    updateAdjustment = true;
                    dgParticularAdjustment.Rows.Add(itemText, Factory.InvestigationAdjustmentRepository().GetValueByInvestigationParticularAndID(itemText, _ucInvestigationForm.selectedInvestigationID));
                }
                else 
                {
                    dgParticularAdjustment.Rows.Add(itemText);
                }
                
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
                    ComputeFactors();
                }
                   
            }
        }

        private void particularFactors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAdjustment_Leave(object sender, EventArgs e)
        {
            txtAdjustment.Text = Convert.ToDecimal(txtAdjustment.Text).ToString("N2");
        }

        private void txtAmountDue_Leave(object sender, EventArgs e)
        {
            txtAmountDue.Text = Convert.ToDecimal(txtAmountDue.Text).ToString("N2");
        }

        private void txtAdjustedDue_Leave(object sender, EventArgs e)
        {
            txtAdjustedDue.Text = Convert.ToDecimal(txtAdjustedDue.Text).ToString("N2");
        }
    }
}
