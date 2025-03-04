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
        internal bool newApplication = false;
        internal int jobOrderId ;
        internal int statusId = 1;
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
                errorProvider1.GetError(txtAccountNumber),
                errorProvider1.GetError(cmbxCustomers),
                errorProvider1.GetError(dtpDate),
                errorProvider1.GetError(txtJONumber),
                errorProvider1.GetError(txtMRISNumber),
                errorProvider1.GetError(txtMRSNumber),
                errorProvider1.GetError(txtWARNumber),

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

        internal void LoadCustomers(string searchKey)
        {
            var dtCustomer = Factory.CustomersRepository().GetCustomersName(searchKey);
            var text = cmbxCustomers.Text;
            if (dtCustomer.Rows.Count > 0)
            {
                cmbxCustomers.DataSource = dtCustomer;

                var sText = cmbxCustomers.Items[0].ToString();
                cmbxCustomers.SelectionStart = text.Length;
                cmbxCustomers.SelectionLength = sText.Length - text.Length;
                cmbxCustomers.DroppedDown = true;

                cmbxCustomers.ValueMember = "id";
                cmbxCustomers.DisplayMember = "account_name";


                // Restore default cursor
                Cursor.Current = Cursors.Default;
                return; 
            }
            {
                cmbxCustomers.DroppedDown = false;
                cmbxCustomers.SelectionStart = text.Length;
            }
           
        }

        internal JobOrdersModel JobOrderModel()
        {
            int customerId = newApplication == true ? Factory.CustomersRepository().GetLastInsertedID(Helper.UserId) : Convert.ToInt32(cmbxCustomers.SelectedValue);
            int particularId = Convert.ToInt32(cmbxParticulars.SelectedValue);
            string jobOrderNumber = txtJONumber.Text;
            DateTime date = dtpDate.Value;
            string orNumber = txtORNumber.Text;
            decimal amount = nudAmount.Value;
            string MRIS = txtMRISNumber.Text;
            string MRS = txtMRSNumber.Text;
            string WAR = txtWARNumber.Text;    
            int preparedById = Helper.UserId;
            int ? materialsIssuedById = cmbxMaterialsIssuedBy.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbxMaterialsIssuedBy.SelectedValue);
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

        private void CmbxCustomers_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxCustomers, "Account Name.");

        }

        private void CmbxCustomers_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxCustomers);
        }

        private void CbxNewApplication_CheckedChanged(object sender, EventArgs e)
        {
            newApplication = cbxNewApplication.Checked;
            cmbxCustomers.DataSource = null;
            cmbxCustomers.Items.Clear();

            if (!newApplication && cmbxCustomers.Text.Trim().Length >= 3)
                LoadCustomers("");
       
        }
        private void TxtMRSNumber_Validating(object sender, CancelEventArgs e)
        {
            if (radAccomplished.Checked)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtMRSNumber, "MRS Number.");
            }
        }

        private void TxtMRSNumber_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtMRSNumber);
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

        private void CmbxCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void CmbxCustomers_TextChanged(object sender, EventArgs e)
        {
            if (!newApplication && cmbxCustomers.Text.Trim().Length >= 3)
            {
                string searchKey = cmbxCustomers.Text.Trim();
                LoadCustomers(searchKey);

            }
        }

        private void TxtAccountNumber_Validating(object sender, CancelEventArgs e)
        {
            if (newApplication == false)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtAccountNumber, "Account Number.");
            }
        }

        private void TxtAccountNumber_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtAccountNumber);
        }
    }
}
