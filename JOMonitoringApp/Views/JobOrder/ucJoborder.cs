using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JOMonitoringApp.Model;
using AccountingSystem;

namespace JOMonitoringApp.Views.JobOrder
{
    public partial class ucJoborder : UserControl
    {
        internal int jobOrderId = 0;
        internal int statusId = 1;
        internal bool isNewAccount = true;

        internal int accountId = 0;
        internal string accountNumber = string.Empty;
        internal string accountName = string.Empty;
        internal bool isUpdate = false;

        public ucJoborder()
        {
            if (!DesignMode)
            {
                InitializeComponent();
            }
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtAccountName),
                errorProvider1.GetError(dtpDate),
                errorProvider1.GetError(txtJONumber),
                errorProvider1.GetError(txtMRISNumber),
                errorProvider1.GetError(txtMRSNumber),
                errorProvider1.GetError(txtWARNumber),
                errorProvider1.GetError(cmbxMaterialsIssuedBy),
                errorProvider1.GetError(cmbxAccomplishedBy),

            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void OnLoad()
        {
            LoadParticulars();
            LoadEmployee();
            cmbxMaterialsIssuedBy.SelectedIndex = -1;
        }

        private void LoadEmployee()
        {
            HelperLoadRecords.EmployeeCombobox(cmbxMaterialsIssuedBy, EmployeesDataTable(), "id", "full_name");
            HelperLoadRecords.EmployeeCombobox(cmbxAccomplishedBy, EmployeesDataTable(), "id", "full_name");
        }

        private DataTable EmployeesDataTable()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("full_name", typeof(string)),
            };

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(dataColumns);

            var datable = Factory.UsersRepository().GetRecords();

            dataTable.Rows.Add(0, string.Empty);
            foreach (DataRow row in datable.Rows)
            {
                var newRow = dataTable.NewRow();
                string fullName = Helper.GenerateFullName(row["prefix"].ToString(), row["first_name"].ToString(), row["middle_name"].ToString(), row["last_name"].ToString(), row["suffix"].ToString());
                newRow["id"] = row["id"];
                newRow["full_name"] = fullName;
                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }


        internal CustomersModel CustomersModel()
        {
            string accountNumber = txtAccountNumber.Text.Trim();
            string accountName = txtAccountName.Text.Trim();
            string accountAddress = txtAddress.Text.Trim();
            int createdBy = Helper.UserId;

            return new CustomersModel()
            {
                Id = isUpdate ? accountId : 0,
                AccountNumber = accountNumber,
                AccountName = accountName,
                Address = accountAddress,
                CreatedBy = createdBy
            };
        }

        internal JobOrdersModel JobOrderModel()
        {
            int customerId = isUpdate ? accountId : (isNewAccount ? Factory.CustomersRepository().GetLastInsertedID(Helper.UserId) : accountId);
            int particularId = Convert.ToInt32(cmbxParticulars.SelectedValue);
            string jobOrderNumber = txtJONumber.Text;
            DateTime date = dtpDate.Value;
            string orNumber = txtORNumber.Text;
            decimal amount = nudAmount.Value;
            string MRIS = txtMRISNumber.Text;
            string MRS = txtMRSNumber.Text;
            string WAR = txtWARNumber.Text;
            int preparedById = Helper.UserId;
            int? materialsIssuedById = cmbxMaterialsIssuedBy.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbxMaterialsIssuedBy.SelectedValue);
            int? accomplishedBy = cmbxAccomplishedBy.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbxAccomplishedBy.SelectedValue);
            int statusId = this.statusId;

            return new JobOrdersModel()
            {
                ID = jobOrderId,
                CustomerID = customerId,
                ParticularID = particularId,
                PreparedBy = preparedById,
                JONUmber = jobOrderNumber,
                Date = date,
                ORNumber = orNumber,
                Amount = amount,
                MRIS = MRIS,
                MRS = MRS,
                WAR = WAR,
                MaterialsIssuedBy = materialsIssuedById == 0 ? null : materialsIssuedById,
                AccomplishedBy = accomplishedBy,
                StatusId = statusId,
                UserId = Helper.UserId
            };
        }

        internal void LoadParticulars()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("particular", typeof(string))
            };

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(dataColumns);

            var dtAccoutnableForm = Factory.ParticularsRepository().GetRecords();
            foreach (DataRow row in dtAccoutnableForm.Rows)
            {
                var newRow = dataTable.NewRow();
                newRow["id"] = row["id"];
                newRow["particular"] = row["particular"];
                dataTable.Rows.Add(newRow);
            }

            HelperLoadRecords.ParticularsCombobox(cmbxParticulars, dataTable, "id", "particular");
        }

        private void UcJoborder_Load(object sender, EventArgs e)
        {

        }


        #region Validation

        private void TxtJONumber_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtJONumber, "J.O Number.");
        }

        private void TxtJONumber_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtJONumber);
        }

        #endregion

        private void TxtMRISNumber_Validating(object sender, CancelEventArgs e)
        {
            if (radAccomplished.Checked)
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtMRISNumber, "MRIS Number.");
        }

        private void TxtMRISNumber_Validated(object sender, EventArgs e)
        {
            if (radAccomplished.Checked)
                Helper.ClearErrorTextBox(errorProvider1, txtMRISNumber);
        }

        private void TxtWARNumber_Validating(object sender, CancelEventArgs e)
        {
            if (radAccomplished.Checked)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtWARNumber, "WAR Number.");
            }
        }

        private void TxtWARNumber_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtWARNumber);
        }


        private void RadPending_CheckedChanged(object sender, EventArgs e)
        {
            statusId = Convert.ToInt16(radPending.Tag);
        }

        private void RadProcessing_CheckedChanged(object sender, EventArgs e)
        {
            statusId = Convert.ToInt16(radProcessing.Tag);
        }

        private void RadCancel_CheckedChanged(object sender, EventArgs e)
        {
            statusId = Convert.ToInt16(radCancel.Tag);
        }

        private void RadAccomplished_CheckedChanged(object sender, EventArgs e)
        {
            statusId = Convert.ToInt16(radAccomplished.Tag);
        }


        internal void BtnSearch_Click(object sender, EventArgs e)
        {
            _ = new frmSearchAccount(this).ShowDialog();
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {

            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtAddress, "Address.");
        }

        private void txtAddress_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtAddress);
        }

        private void TxtAccountName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtAccountName, "Account Name.");
        }

        private void TxtAccountName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtAccountName);
        }

        private void NumberOnly(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        internal void UcJoborder_KeyPress(object sender, KeyPressEventArgs e)
        {
            _ = new frmSearchAccount(this).ShowDialog();
        }

        private void txtAccountNumber_Validating(object sender, CancelEventArgs e)
        {
            if (!cbxNA.Checked)
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtAccountNumber, "Account Name.");
        }

        private void txtAccountNumber_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtAccountNumber);
        }

        private void cbxNA_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxNA.Checked)
            {
                txtAccountNumber.Clear();
                txtAccountNumber.ReadOnly = true;
                return;
            }

            txtAccountNumber.ReadOnly = false;
        }

        private void cmbxAccomplishedBy_Validating(object sender, CancelEventArgs e)
        {
            if (radAccomplished.Checked && !string.IsNullOrEmpty(txtWARNumber.Text.Trim()))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxAccomplishedBy, "Accomplished By.");
        }

        private void cmbxAccomplishedBy_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxAccomplishedBy);
        }

        private void cmbxMaterialsIssuedBy_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMRISNumber.Text.Trim()))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxMaterialsIssuedBy, "Issued By.");
        }

        private void cmbxMaterialsIssuedBy_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxMaterialsIssuedBy);
        }
    }
}
