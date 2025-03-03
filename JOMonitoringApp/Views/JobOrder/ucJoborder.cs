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
        internal bool newApplication = true;
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
                errorProvider1.GetError(cmbxCustomers),
                errorProvider1.GetError(dtpDate),
                errorProvider1.GetError(txtJONumber),
                errorProvider1.GetError(txtMRISNumber),

            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void OnLoad()
        {
            LoadCustomers();
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

        internal void LoadCustomers()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("account_name", typeof(string))
            };

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(dataColumns);

            var dtCustomers = Factory.CustomersRepository().GetRecords();
            foreach (DataRow row in dtCustomers.Rows)
            {
                var newRow = dataTable.NewRow();
                newRow["id"] = row["id"];
                newRow["account_name"] = row["account_name"];
                dataTable.Rows.Add(newRow);
            }

            HelperLoadRecords.CustomersCombobox(cmbxCustomers, dataTable, "id", "account_name");
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
            int materialsIssuedById = Convert.ToInt32(cmbxMaterialsIssuedBy.SelectedValue);
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
                MaterialsIssuedBy = materialsIssuedById,
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
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtMRISNumber, "MRIS Number.");
        }

        private void TxtMRISNumber_Validated(object sender, EventArgs e)
        {
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
        }
    }
}
