using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp
{
    public class HelperLoadRecords
    {

        public static void JobOrdersDataGridView(DataGridView dataGridView, DataTable dataTable)
        {

            dataGridView.DataSource = dataTable;

            dataGridView.Columns["job_orders_id"].Visible = false;
            dataGridView.Columns["customers_id"].Visible = false;
            dataGridView.Columns["date"].HeaderText = "Date";
            dataGridView.Columns["date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["date"].MinimumWidth = 30;
            dataGridView.Columns["date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dataGridView.Columns["customers_account_number"].HeaderText = "Account Number";
            dataGridView.Columns["customers_account_number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["customers_account_number"].MinimumWidth = 100;
            dataGridView.Columns["customers_full_name"].HeaderText = "Account Name";
            dataGridView.Columns["customers_address"].HeaderText = "Address";
            dataGridView.Columns["particulars_id"].Visible = false;
            dataGridView.Columns["particulars"].HeaderText = "Particulars";
            dataGridView.Columns["particulars"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["particulars"].MinimumWidth = 150;
            dataGridView.Columns["or_number"].HeaderText = "OR Number";
            dataGridView.Columns["or_number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["or_number"].MinimumWidth = 100;
            dataGridView.Columns["amount"].HeaderText = "Amount";
            dataGridView.Columns["amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["amount"].MinimumWidth = 100;
            dataGridView.Columns["prepared_by_user_id"].Visible = false;
            dataGridView.Columns["prepared_by_user_full_name"].HeaderText = "Prepared By";

        }

        internal static void CustomersCombobox(ComboBox cmbx, DataTable dataTable, string valueMember, string displayMember)
        {
            cmbx.DataSource = dataTable;
            cmbx.ValueMember = valueMember;
            cmbx.DisplayMember = displayMember;
        }

        internal static void ParticularsCombobox(ComboBox cmbx, DataTable dataTable, string valueMember, string displayMember)
        {
            cmbx.DataSource = dataTable;
            cmbx.ValueMember = valueMember;
            cmbx.DisplayMember = displayMember;
        }

        internal static void EmployeeCombobox(ComboBox cmbxEmployee, DataTable dataTable, string valueMember, string displayMember)
        {
            cmbxEmployee.DataSource = dataTable;
            cmbxEmployee.ValueMember = valueMember;
            cmbxEmployee.DisplayMember = displayMember;
        }
        
        internal static void ComboboxRowLimitFilter(ComboBox comboBox)
        {
            DataTable dataTable = new DataTable();

            // Add columns to the DataTable using AddRange
            DataColumn[] columns =
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("description", typeof(string))
            };

            dataTable.Columns.AddRange(columns);

            int[] values = { 100, 1000, 2000 };

            foreach (int value in values)
            {
                var newRow = dataTable.NewRow();

                newRow["id"] = value;
                newRow["description"] = $"Limit to {value} rows";
                dataTable.Rows.Add(newRow);
            }

            comboBox.DataSource = dataTable;
            comboBox.ValueMember = "id";
            comboBox.DisplayMember = "description";
        }

        
    }
}
