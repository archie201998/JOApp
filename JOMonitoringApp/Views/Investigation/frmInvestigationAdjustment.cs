using AccountingSystem;
using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using System;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Investigation
{
    public partial class frmInvestigationAdjustment : Form
    {

        private readonly string _accountNumber;
        private readonly frmInvestigationForm _frmInvestigationForm;

        bool updateAdjustment = false;
        private bool isUpdating = false;


        public frmInvestigationAdjustment(frmInvestigation frmInvestigation, frmInvestigationForm frmInvestigationForm)
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyleEditable(dgOtherFees);
            Helper.LoadFormIcon(this);
            _frmInvestigationForm = frmInvestigationForm;
            _accountNumber = frmInvestigationForm.txtAccountNumber.Text;
        }

        public frmInvestigationAdjustment(string accountNo)
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyleEditable(dgOtherFees);
            Helper.LoadFormIcon(this);
            _accountNumber = accountNo; 
        }

        private void frmInvestigationAdjustment_Load(object sender, EventArgs e)
        {
            LoadAccountDetails();
            LoadOtherFees();

            //initial load.
            if (_frmInvestigationForm._hasAdjustment)
                LoadAdjustments();
        }

        private void LoadOtherFees()
        {
            var dtOtherFees = Factory.InvestigationAdjustmentRepository().GetInvestigationOtherFees(_frmInvestigationForm._investigationId);
            if (dtOtherFees.Rows.Count == 0)
                return;

            dgOtherFees.DataSource = null;
            dgOtherFees.Columns.Clear(); // Clear existing columns
            dgOtherFees.DataSource = dtOtherFees;

            dgOtherFees.Columns["id"].Visible = false;
            dgOtherFees.Columns["investigation_id"].Visible = false;

            dgOtherFees.Columns["particular"].HeaderText = "Description";
            dgOtherFees.Columns["particular"].Width = 200;
            dgOtherFees.Columns["value"].HeaderText = "Amount";
            dgOtherFees.Columns["value"].DefaultCellStyle.Format = "N2";

            Helper.DatagridFullRowSelectStyle(dgOtherFees, true);
        }

        private void LoadAccountDetails()
        {

            var dictCustomerAccountDetails = Factory.CustomersRepository().GetCustomerAccountDetails(_accountNumber);

            if (dictCustomerAccountDetails.Count != 0)
            {

            }
        }

        private void LoadAdjustments()
        {
            int investigationID = _frmInvestigationForm._investigationId;
            var adjustments = Factory.InvestigationRepository().GetViewRecordById(investigationID);

            if (adjustments.Count != 0)
            {
                string particular = adjustments["adjustment_particular"].ToString();
                decimal waterBill = !string.IsNullOrWhiteSpace(adjustments["water_bill"]?.ToString()) ? Convert.ToDecimal(adjustments["water_bill"]) : 0;
                decimal adjustedAmount = !string.IsNullOrWhiteSpace(adjustments["adjusted_water_bill"]?.ToString()) ? Convert.ToDecimal(adjustments["adjusted_water_bill"]) : 0;
                decimal adjustment = !string.IsNullOrWhiteSpace(adjustments["water_bill_adjustment"]?.ToString()) ? Convert.ToDecimal(adjustments["water_bill_adjustment"]) : 0;
               
                cmbxParticular.SelectedItem = particular;
                txtWaterBill.Text = waterBill.ToString("N2");
                txtAdjustedAmount.Text = adjustedAmount.ToString("N2");
                txtAdjustment.Text = adjustment.ToString("N2");

            }

            return;
        }


        private void cmbxParticular_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               

                bool adjustmentResult = Factory.InvestigationRepository().SaveComputation(InvestigationModel());

                if (!SaveOtherFeesAdjustment() )
                {
                    Helper.MessageBoxSuccess("Failed to save other fees.");
                }

                if (adjustmentResult)
                {
                    Helper.MessageBoxSuccess("Adjustment has been successfully saved.");
                    LoadAdjustments();
                }
            }
            catch (Exception)
            {
                Helper.MessageBoxError("Something went wrong. Please contact your system administrator.");
            }
        }

        private bool RemoveOtherFees()
        {
            int investigationID = _frmInvestigationForm._investigationId;
            if (Factory.InvestigationAdjustmentRepository().DeleteAdjustments(investigationID)) return true ;

            return false;
        }

        private bool SaveOtherFeesAdjustment()
        {

            if (!RemoveOtherFees())
            {
                Helper.MessageBoxSuccess("Error on removing other fees.");
                return false;
            }

            if (Helper.MessageBoxConfirmCancel("Do you confirm to save this adjustment?"))
            {
                foreach (DataGridViewRow dgvRow in dgOtherFees.Rows)
                {
                    string description = dgvRow.Cells["particular"].Value?.ToString();
                    string amount = dgvRow.Cells["value"].Value?.ToString();

                    var investigationAdjustmentModel = new InvestigationAdjustmentOtherFeesModel
                    {
                        Description = description,
                        Amount = amount,
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
                AdjustmentParticular = cmbxParticular.Text,
                WaterBill = Convert.ToDecimal(txtWaterBill.Text.Trim()),
                AdjustedWaterBill = Convert.ToDecimal(txtAdjustedAmount.Text.Trim()),
                WaterBillAdjustment = txtAdjustment.Text != string.Empty ? Convert.ToDecimal(txtAdjustment.Text.Trim()) : 0,
                UpdatedBy = Helper.CurrentUserID,
            };

            return investigationModel;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
          
        }

        private void btnNewOtherFees_Click(object sender, EventArgs e)
        {
            EnableDisableOtherFees(true);
            txtOtherFessDescription.Focus();
        }

        private void EnableDisableOtherFees(bool enable)
        { 
            txtOtherFeesAmount.Enabled = enable;
            txtOtherFessDescription.Enabled = enable;
            btnAddOtherFees.Enabled = enable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOtherFessDescription.Text) || string.IsNullOrEmpty(txtOtherFeesAmount.Text))
            {
                Helper.MessageBoxWarning("Please enter description and amount.");
                return;
            }

            string description = txtOtherFessDescription.Text.Trim();
            decimal amount = Convert.ToDecimal(txtOtherFeesAmount.Text.Trim()); 

            dgOtherFees.Rows.Add(description, amount);

            txtOtherFeesAmount.Clear();
            txtOtherFessDescription.Clear();
            txtOtherFessDescription.Focus();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgOtherFees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            byte rowIndex = (byte)dgOtherFees.CurrentCell.RowIndex; 
            dgOtherFees.Rows.RemoveAt(rowIndex);
            dgOtherFees.Focus();
        }

        private void dgOtherFees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgOtherFees.SelectedRows.Count == 1 || dgOtherFees.Rows.Count != 0)
            {
                btnRemove.Enabled = true;
                return;
            }

            btnRemove.Enabled = false;
        }
    }
}
