using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.JobOrder
{
    public partial class ucJoborder : UserControl
    {


        private DataTable dtCustomers;

        public ucJoborder()
        {
            InitializeComponent();
        }

        private void UcJoborder_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void OnLoad()
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

            var dtAccoutnableForm = Factory.CustomersRepository().GetRecords();
            foreach (DataRow row in dtAccoutnableForm.Rows)
            {
                var newRow = dataTable.NewRow();
                newRow["id"] = row["id"];
                newRow["account_name"] = row["account_name"];
                dataTable.Rows.Add(newRow);
            }

            HelperLoadRecords.CustomersCombobox(cmbxCustomers, dataTable, "id", "account_name");
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
