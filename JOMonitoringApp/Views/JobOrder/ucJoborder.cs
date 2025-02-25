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
            LoadEmployees();
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
            DateTime date = dtpDate.Value;
            string orNumber = txtORNumber.Text;
            decimal amount = nudAmount.Value;
            int employeeId = Convert.ToInt32(cmbxEmployee.SelectedValue);

            return new JobOrdersModel()
            {
                CustomerID = customerId,
                ParticularID = particularId,
                EmployeeId = employeeId,
                Date = date,
                ORNumber = orNumber,
                Amount = amount,
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

        private void LoadEmployees()
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

            HelperLoadRecords.EmployeeCombobox(cmbxEmployee, dataTable, "id", "employee_full_name");
        }

    }
}
