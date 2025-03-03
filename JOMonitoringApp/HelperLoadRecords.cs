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

            
            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["customers_id"].Visible = false;
            dataGridView.Columns["particulars_id"].Visible = false;
            dataGridView.Columns["prepared_by_id"].Visible = false;
            dataGridView.Columns["materials_issued_by_id"].Visible = false;
            dataGridView.Columns["materials_returned_to_id"].Visible = false;
            dataGridView.Columns["status_id"].Visible = false;

            dataGridView.Columns["status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns["status"].HeaderText = "STATUS";
            dataGridView.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["status"].MinimumWidth = 30;


            dataGridView.Columns["date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["date"].HeaderText = "DATE";
            dataGridView.Columns["date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["date"].MinimumWidth = 50;
            dataGridView.Columns["date"].DefaultCellStyle.Format = "MM/dd/yyyy";


            dataGridView.Columns["account_number"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["account_number"].HeaderText = "ACCOUNT NO.";
            dataGridView.Columns["account_number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["account_number"].MinimumWidth = 100;

            dataGridView.Columns["account_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns["account_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["account_name"].HeaderText = "ACCOUNT NAME";

            dataGridView.Columns["address"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns["address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["address"].HeaderText = "ADDRESS";

            dataGridView.Columns["job_order_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["job_order_no"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["job_order_no"].HeaderText = "J.O NO.";

            dataGridView.Columns["or_number"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["or_number"].HeaderText = "OR NO.";
            dataGridView.Columns["or_number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["or_number"].MinimumWidth = 50;

            dataGridView.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["amount"].HeaderText = "AMOUNT";
            dataGridView.Columns["amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["amount"].MinimumWidth = 100;

            dataGridView.Columns["mris"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["mris"].HeaderText = "MRIS NO. ";
            dataGridView.Columns["mris"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["mris"].MinimumWidth = 100;

            dataGridView.Columns["mrs"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["mrs"].HeaderText = "MRIS NO. ";
            dataGridView.Columns["mrs"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["mrs"].MinimumWidth = 100;

            dataGridView.Columns["war"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["war"].HeaderText = "WAR NO. ";
            dataGridView.Columns["war"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["war"].MinimumWidth = 100;

            dataGridView.Columns["particular"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns["particular"].HeaderText = "PARTICULARS";
            dataGridView.Columns["particular"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["particular"].MinimumWidth = 150;


            dataGridView.Columns["prepared_by"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns["prepared_by"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["prepared_by"].HeaderText = "PREPARED BY";
            dataGridView.Columns["prepared_by"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["materials_issued_by"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns["materials_issued_by"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["materials_issued_by"].HeaderText = "MATERIALS ISSUED BY";
            dataGridView.Columns["materials_returned_to"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns["materials_returned_to"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["materials_returned_to"].HeaderText = "MATERIALS RETURNED TO";

  
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

        internal static void MaterialsIssuedByComboBox(ComboBox cmbxEmployee, DataTable dataTable, string valueMember, string displayMember)
        {
            cmbxEmployee.DataSource = dataTable;
            cmbxEmployee.ValueMember = valueMember;
            cmbxEmployee.DisplayMember = displayMember;
        }

        internal static void MaterialsReturnedByComboBox(ComboBox cmbxEmployee, DataTable dataTable, string valueMember, string displayMember)
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

            int[] values = { 10, 100, 1000, 2000 };

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

        internal static void StatusCombobox(ComboBox comboBox)
        {
            DataTable dataTable = new DataTable();

            dataTable = Factory.StatusRepository().GetRecords();

            comboBox.DataSource = dataTable;
            comboBox.ValueMember = "id";
            comboBox.DisplayMember = "status";
        }
    }
}
