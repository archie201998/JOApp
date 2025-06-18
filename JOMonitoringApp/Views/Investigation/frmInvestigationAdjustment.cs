using AccountingSystem;
using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.PromptBox;
using Mysqlx.Crud;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Investigation
{
    public partial class frmInvestigationAdjustment : Form
    {

        private readonly string _accountNumber;
        private readonly frmInvestigationForm _frmInvestigationForm;

        bool updateAdjustment = false;
        private bool isUpdating = false;


        public frmInvestigationAdjustment(frmInvestigationForm frmInvestigationForm)
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyleEditable(dgParticularAdjustment);
            Helper.LoadFormIcon(this);
            _frmInvestigationForm = frmInvestigationForm;
            _accountNumber = frmInvestigationForm.txtAccountNumber.Text;
        }

        public frmInvestigationAdjustment(string accountNo)
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyleEditable(dgParticularAdjustment);
            Helper.LoadFormIcon(this);
            _accountNumber = accountNo; 
        }

        private void frmInvestigationAdjustment_Load(object sender, EventArgs e)
        {
            LoadAccountDetails();

            //initial load.
            if (_frmInvestigationForm._hasAdjustment)
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
            int investigationID = _frmInvestigationForm._investigationId;
            var adjustments = Factory.InvestigationRepository().GetViewRecordById(investigationID);
            var adjustmentDetails = Factory.InvestigationAdjustmentRepository().GetRecordsBySearch(investigationID.ToString());

            if (adjustments.Count != 0)
            {

                decimal amountDue = !string.IsNullOrWhiteSpace(adjustments["water_bill"]?.ToString()) ? Convert.ToDecimal(adjustments["water_bill"]) : 0;
                decimal penalty = !string.IsNullOrWhiteSpace(adjustments["penalty"]?.ToString()) ? Convert.ToDecimal(adjustments["penalty"]) : 0;
                decimal extensionFee = !string.IsNullOrWhiteSpace(adjustments["extension_fee"]?.ToString()) ? Convert.ToDecimal(adjustments["extension_fee"]) : 0;
                decimal adjustment = !string.IsNullOrWhiteSpace(adjustments["water_bill_adjustment"]?.ToString()) ? Convert.ToDecimal(adjustments["water_bill_adjustment"]) : 0;
                
                string particular = adjustments["adjustment_particular"].ToString();
                decimal _adjustedAmount = !string.IsNullOrWhiteSpace(adjustments["adjusted_water_bill"]?.ToString()) ? Convert.ToDecimal(adjustments["adjusted_water_bill"]) : 0;

                cmbxParticular.SelectedItem = particular;

                txtWaterBill.Text = amountDue.ToString("N2");
                txtWaterBillAdjustment.Text  = adjustment.ToString("N2");
                txtExtensionFee.Text = extensionFee.ToString("N2");
                txtPenalty.Text = penalty.ToString("N2");
                txtWaterBillAdjustedAamount.Text = _adjustedAmount.ToString("N2");
                txtAdjustedWaterBill.Text = (_adjustedAmount + penalty + extensionFee).ToString("N2");



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


        private void cmbxParticular_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            int investigationID = _frmInvestigationForm._investigationId;
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
                        InvestigationId = _frmInvestigationForm._investigationId,
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
                Id = _frmInvestigationForm._investigationId,
                UpdatedBy = Helper.UserId,
                AdjustmentParticular = cmbxParticular.Text,
                WaterBill = Convert.ToDecimal(txtWaterBill.Text.Trim()),
                WaterBillAdjustment = Convert.ToDecimal(txtWaterBillAdjustment.Text.Trim()),
                Penalty = Convert.ToDecimal(txtPenalty.Text.Trim()),
                ExtensionFee = Convert.ToDecimal(txtExtensionFee.Text.Trim()),
                AdjustedWaterBill = Convert.ToDecimal(txtWaterBillAdjustedAamount.Text.Trim())
            };

            investigationModel.AdjustedAmount = investigationModel.WaterBill - investigationModel.WaterBillAdjustment;
            return investigationModel;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
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

                decimal waterBill = decimal.Parse(txtWaterBill.Text.Trim());
                decimal waterBillAdjustment = decimal.Parse(txtWaterBillAdjustment.Text.Trim());
                decimal waterBillAdjustedAmount = decimal.Parse(txtWaterBillAdjustedAamount.Text.Trim());
                decimal penalty = decimal.Parse(txtPenalty.Text.Trim());
                decimal extensionFee = decimal.Parse(txtExtensionFee.Text.Trim());

                waterBillAdjustedAmount = waterBillAdjustedAmount + penalty + extensionFee;

                decimal adjustedAmount = waterBill - waterBillAdjustedAmount;
                decimal adjustedWaterBill = adjustedAmount + penalty + extensionFee;

                txtAdjustedWaterBill.Text = waterBillAdjustedAmount.ToString("N2");
                txtWaterBillAdjustment.Text = adjustedAmount.ToString("N2");

            }
            catch (FormatException) { }
            finally
            {
                isUpdating = false;
            }
        }

        private void particularFactors_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string itemText = particularFactors.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked)
            {
                if (_frmInvestigationForm._hasAdjustment)
                {
                    updateAdjustment = true;
                    dgParticularAdjustment.Rows.Add(itemText, Factory.InvestigationAdjustmentRepository().GetValueByInvestigationParticularAndID(itemText, _frmInvestigationForm._investigationId));
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
                }

            }
        }
     
        private void txtAdjustment_Leave(object sender, EventArgs e)
        {
            //txtWaterBillAdjustedAmount.Text = Convert.ToDecimal(txtWaterBillAdjustedAmount.Text).ToString("N2");
        }

        private void txtAmountDue_Leave(object sender, EventArgs e)
        {
            txtWaterBill.Text = Convert.ToDecimal(txtWaterBill.Text).ToString("N2");
        }

        private void txtAdjustedDue_Leave(object sender, EventArgs e)
        {
            txtWaterBillAdjustment.Text = Convert.ToDecimal(txtWaterBillAdjustment.Text).ToString("N2");
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
          
        }
    }
}
