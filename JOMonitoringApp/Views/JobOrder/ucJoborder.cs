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
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void OnLoad()
        {
            LoadCustomers();
            LoadParticulars();
            LoadEmployee();

            cmbxMaterialsIssuedBy.SelectedIndex = -1;
            cmbxMaterialsReturnedTo.SelectedIndex = -1;
            cmbxAssignedWork.SelectedIndex = -1;
        }

        private void LoadEmployee()
        {
            HelperLoadRecords.EmployeeCombobox(cmbxAssignedWork, EmployeesDataTable(), "id", "employee_full_name");
            HelperLoadRecords.EmployeeCombobox(cmbxMaterialsReturnedTo, EmployeesDataTable(), "id", "employee_full_name");
            HelperLoadRecords.EmployeeCombobox(cmbxMaterialsIssuedBy, EmployeesDataTable(), "id", "employee_full_name");
        }

        private DataTable EmployeesDataTable()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("employee_full_name", typeof(string)),
            };

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(dataColumns);

            var datable = Factory.EmployeeRepository().GetRecords();
            foreach (DataRow row in datable.Rows)
            {
                var newRow = dataTable.NewRow();
                newRow["id"] = row["id"];
                newRow["employee_full_name"] = $"{ row["first_name"] } { row["middle_name"] } { row["last_name"] }";
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
            int customerId = Convert.ToInt32(cmbxCustomers.SelectedValue);
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
            int assignedWorkedId = Convert.ToInt32(cmbxAssignedWork.SelectedValue);
            int materialsReturnedToId = Convert.ToInt32(cmbxMaterialsReturnedTo.SelectedValue);

            return new JobOrdersModel()
            {
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
                AssignedWorkEmployeeId = assignedWorkedId,
                MaterialsIssuedBy = materialsIssuedById,
                MaterialsReturnedTo = materialsReturnedToId,
                StatusId = 2,
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
    }
}
