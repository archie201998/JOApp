using AccountingSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp
{
    public class HelperLoadRecords
    {
        public static void JobOrderTrackingDataGrid(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;

            dataGridView.Columns["log_id"].Visible = false;

            dataGridView.Columns["date_and_time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns["date_and_time"].HeaderText = "DATE AND TIME";
            dataGridView.Columns["date_and_time"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["date_and_time"].MinimumWidth = 150;

            dataGridView.Columns["transaction_event"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns["transaction_event"].HeaderText = "EVENT DETAILS";
            dataGridView.Columns["transaction_event"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["transaction_event"].MinimumWidth = 300;
        }

        public static void JOStatusPerParticular(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;

            dataGridView.Columns["particular"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns["particular"].HeaderText = "PARTICULAR";
            dataGridView.Columns["particular"].MinimumWidth = 120;
            

            dataGridView.Columns["pending"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["pending"].HeaderText = "PENDING";
            dataGridView.Columns["pending"].MinimumWidth = 20;

            dataGridView.Columns["processing"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["processing"].HeaderText = "PROCESSING";
            dataGridView.Columns["processing"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["processing"].MinimumWidth = 20;

            dataGridView.Columns["cancelled"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["cancelled"].HeaderText = "CANCELLED";
            dataGridView.Columns["cancelled"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["cancelled"].MinimumWidth = 20;

            dataGridView.Columns["accomplished"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["accomplished"].HeaderText = "ACCOMPLISHED";
            dataGridView.Columns["accomplished"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["accomplished"].MinimumWidth = 20;

            dataGridView.Columns["total_count"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["total_count"].HeaderText = "TOTAL";
            dataGridView.Columns["total_count"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["total_count"].MinimumWidth = 20;
        }
        public static void JOStatusPhase(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;

            dataGridView.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns["id"].HeaderText = "id";
            dataGridView.Columns["id"].Visible = false;


            dataGridView.Columns["job_order_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["job_order_no"].HeaderText = "JO Number";
            dataGridView.Columns["job_order_no"].MinimumWidth =10;

            dataGridView.Columns["particular"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["particular"].HeaderText = "Particular";
            dataGridView.Columns["particular"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["particular"].MinimumWidth = 80;

            dataGridView.Columns["created_at"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["created_at"].HeaderText = "Date Created";
            dataGridView.Columns["created_at"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["created_at"].MinimumWidth = 80;

            dataGridView.Columns["created_by"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["created_by"].HeaderText = "Created By";
            dataGridView.Columns["created_by"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["created_by"].MinimumWidth = 80;

        }

        public static void JobOrdersDataGridView(DataGridView dataGridView, DataTable dataTable)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.HeaderText = column.HeaderText.ToUpper();
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridView.DataSource = dataTable;

            dataGridView.DefaultCellStyle.Font = new Font("Segiou", 8);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segiou", 8, FontStyle.Regular);
            dataGridView.EnableHeadersVisualStyles = false;

            dataGridView.Columns["id"].Visible = true;
            dataGridView.Columns["id"].HeaderText = "NO. ";
            dataGridView.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns["id"].MinimumWidth = 50;



            dataGridView.Columns["prepared_by_id"].Visible = false;
            dataGridView.Columns["materials_issued_by_id"].Visible = false;
            dataGridView.Columns["status_id"].Visible = false;
            dataGridView.Columns["address"].Visible = false;
            dataGridView.Columns["remarks"].Visible = false;

            dataGridView.Columns["status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns["status"].HeaderText = "STATUS";
            dataGridView.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["status"].MinimumWidth = 30;

            dataGridView.Columns["date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["date"].HeaderText = "PREPARED DATE";
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
            dataGridView.Columns["amount"].DefaultCellStyle.Format = "N2";
            dataGridView.Columns["amount"].MinimumWidth = 80;

            dataGridView.Columns["mris"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["mris"].HeaderText = "MRIS NO. ";
            dataGridView.Columns["mris"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["mris"].MinimumWidth = 80;

            dataGridView.Columns["mrs"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["mrs"].HeaderText = "MRS NO. ";
            dataGridView.Columns["mrs"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["mrs"].MinimumWidth = 80;

            dataGridView.Columns["war"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["war"].HeaderText = "WAR NO. ";
            dataGridView.Columns["war"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["war"].MinimumWidth = 80;

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
        }

        public static void AccountsDataGridView(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;

            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["address"].Visible = false;

            dataGridView.Columns["account_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.Columns["account_name"].HeaderText = "ACCOUNT NAME";
            dataGridView.Columns["account_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["account_name"].MinimumWidth = 120;

            dataGridView.Columns["account_number"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["account_number"].HeaderText = "ACCOUNT NUMBER";
            dataGridView.Columns["account_number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["account_number"].MinimumWidth = 100;
        }


        internal static void ParticularsCombobox(ComboBox cmbx)
        {

            var dataTable = Factory.ParticularsRepository().GetRecords();
            DataRow newRow = dataTable.NewRow();

            newRow["id"] = "0";
            newRow["particular"] = "All"; 
            dataTable.Rows.InsertAt(newRow, 0);

            cmbx.DataSource = dataTable;
            cmbx.ValueMember = "id";
            cmbx.DisplayMember = "particular";
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

            int[] values = { 10, 50, 100, 250, 500, 1000, 10000 };

            foreach (int value in values)
            {
                var newRow = dataTable.NewRow();

                newRow["id"] = value;
                newRow["description"] = $" {value} records";
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

        internal static void InvestigationDatagridView(DataGridView dgInvestigations, DataTable dtInvestigation)
        {
            if (dtInvestigation != null && dtInvestigation.Rows.Count > 0)
            {
                dgInvestigations.DataSource = dtInvestigation;
            }
            else
            {
                dgInvestigations.DataSource = null;
                return;
            }

            dgInvestigations.Columns["id"].Visible = false;
            dgInvestigations.Columns["job_orders_id"].Visible = false;

            dgInvestigations.Columns["approval_status"].HeaderText = "INV. STATUS";
            dgInvestigations.Columns["nature_of_complaint"].HeaderText = "COMPLAINT";
            dgInvestigations.Columns["job_order_no"].HeaderText = "J.O. Number";
            dgInvestigations.Columns["account_number"].HeaderText = "ACCOUNT NUMBER";
            dgInvestigations.Columns["customer_name"].HeaderText = "NAME";
            dgInvestigations.Columns["customer_name"].HeaderText = "ADDRESS";
            dgInvestigations.Columns["date_of_investigation"].HeaderText = "DATE OF INVESTIGATION";

            dgInvestigations.Columns["customer_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgInvestigations.Columns["account_number"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvestigations.Columns["nature_of_complaint"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn column in dgInvestigations.Columns)
            {
                column.HeaderText = column.HeaderText.ToUpper();
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        internal static void ParticularsDataGridView(DataGridView dgvParticulars)
        {
            // Set header text and width

            dgvParticulars.Columns[0].Visible = false;
            dgvParticulars.Columns[0].HeaderText = "ID";
            dgvParticulars.Columns[0].Width = 30;
            dgvParticulars.Columns[1].HeaderText = "NAME";
            dgvParticulars.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvParticulars.Columns[1].Width = 100;
            dgvParticulars.Columns[3].HeaderText = "DESCRIPTION";
            dgvParticulars.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvParticulars.Columns[3].Width = 200;
        }

        internal static void RolesDatagridView(DataGridView dgRoles, DataTable dataTable)
        {
            dgRoles.DataSource = dataTable;

            dgRoles.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray; // Set background color

            dgRoles.Columns["id"].Visible = false;
            dgRoles.Columns["role"].HeaderText = "ROLES";
            dgRoles.Columns["role"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgRoles.Columns["role"].Width = 200;
        }
    }
}
