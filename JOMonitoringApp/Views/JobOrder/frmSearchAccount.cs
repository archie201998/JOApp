using AccountingSystem;
using System;
using System.Data;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.JobOrder
{
    public partial class frmSearchAccount : Form
    {
        readonly ucJoborder _ucJobOrder;
        public frmSearchAccount(ucJoborder ucJobOrder)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgAccounts);
            _ucJobOrder = ucJobOrder;
        }

        private void FrmSearchAccount_Load(object sender, EventArgs e)
        {
            txtAcc1.Focus();
            LoadCustomerByAccountNumber();
        }


        private DataColumn[] JobOrdersColumns()
        {
            return new DataColumn[]
            {
                new DataColumn("id", typeof (int)),
                new DataColumn("account_name", typeof(string)),
                new DataColumn("account_number", typeof(string)),
                new DataColumn("address", typeof(string)),
            };
        }

        private void LoadCustomerByAccountNumber()
        {
            string searchKey = $"{txtAcc1.Text}-{txtAcc2.Text}-{txtAcc3.Text}-{txtAcc4.Text}";
            int charCount = searchKey.Length;
            if (charCount <= 3)
                return;

            var dataTable = new DataTable();
            DataTable dtJobOrders = Factory.CustomersRepository().GetRecordsBySearchByAccountNumber(searchKey);

            dataTable.Columns.AddRange(JobOrdersColumns());

            foreach (DataRow row in dtJobOrders.Rows)
            {

                var newRow = dataTable.NewRow();
                int id = Convert.ToInt32(row["id"]);
                string accountName = $"{row["account_name"]}";
                string accountNumber = $"{row["account_number"]}";
                string address = $"{row["address"]}";

                newRow["id"] = id;
                newRow["account_name"] = accountName;
                newRow["account_number"] = string.IsNullOrEmpty(accountNumber) ? "-" : accountNumber;
                newRow["address"] = address;
                dataTable.Rows.Add(newRow);
            }

            HelperLoadRecords.AccountsDataGridView(dgAccounts, dataTable);
        }

        private void LoadCustomerByAccountsByName()
        {
            string searchKey = $"{txtAccountName.Text.Trim()}";
            int charCount = searchKey.Length;
            if (charCount <= 3)
                return;

            var dataTable = new DataTable();
            DataTable dtJobOrders = Factory.CustomersRepository().GetRecordsBySearchByAccountNumber(searchKey);

            dataTable.Columns.AddRange(JobOrdersColumns());

            foreach (DataRow row in dtJobOrders.Rows)
            {

                var newRow = dataTable.NewRow();
                int id = Convert.ToInt32(row["id"]);
                string accountName = $"{row["account_name"]}";
                string accountNumber = $"{row["account_number"]}";
                string address = $"{row["address"]}";

                newRow["id"] = id;
                newRow["account_name"] = accountName;
                newRow["account_number"] = string.IsNullOrEmpty(accountNumber) ? "-" : accountNumber;
                newRow["address"] = address;
                dataTable.Rows.Add(newRow);
            }

            HelperLoadRecords.AccountsDataGridView(dgAccounts, dataTable);
        }

        private void TxtAccountNumber_TextChanged(object sender, EventArgs e)
        {
            LoadCustomerByAccountsByName();
        }

        private void DgAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectData();
        }

        private void SelectData()
        {

            int selectedRowCount = dgAccounts.SelectedRows.Count;
            if (selectedRowCount == 0 || selectedRowCount > 1)
                Helper.MessageBoxWarning("Please select at least one record to proceed.");
            else
            {
                int selectedAccountId = Convert.ToInt32(dgAccounts.SelectedRows[0].Cells["id"].Value);
                string selectedAccountName = dgAccounts.SelectedRows[0].Cells["account_name"].Value.ToString();
                string selectedAccountNumber = dgAccounts.SelectedRows[0].Cells["account_number"].Value.ToString();
                string selectedAddress = dgAccounts.SelectedRows[0].Cells["address"].Value.ToString();

                char[] delimiter = new char[] { '-' };
                string[] accountNumber = selectedAccountNumber.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                _ucJobOrder.txtAcc1.Text = accountNumber[0];
                _ucJobOrder.txtAcc2.Text = accountNumber[1];
                _ucJobOrder.txtAcc3.Text = accountNumber[2];
                _ucJobOrder.txtAcc4.Text = accountNumber[3];

                _ucJobOrder.isNewAccount = false;
                _ucJobOrder.accountId = selectedAccountId;
                _ucJobOrder.txtAccountName.Text = selectedAccountName;
                _ucJobOrder.txtAccountNumber.Text = selectedAccountNumber;
                _ucJobOrder.txtAddress.Text = selectedAddress;
                _ucJobOrder.cbxNA.Checked = false;
                _ucJobOrder.txtJONumber.Focus();

                Close();
            }
        }

        private void TxtAccountName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectData();
            }
        }


        private void FrmSearchAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Escape == e.KeyData)
                Close();
        }

        private void txtAcc4_TextChanged(object sender, EventArgs e)
        {
            string searchKey = $"{txtAcc1.Text}-{txtAcc2.Text}-{txtAcc3.Text}-{txtAcc4.Text}";

            var txtBox = sender as TextBox;

            if (txtAcc1.Text.Length == 3 && txtBox == txtAcc1)
                txtAcc2.Focus();
            else if (txtAcc2.Text.Length == 3 && txtBox == txtAcc2)
                txtAcc3.Focus();
            else if (txtAcc3.Text.Length == 3 && txtBox == txtAcc3)
                txtAcc4.Focus();

            LoadCustomerByAccountNumber();
        }

        private void txtAcc4_KeyDown(object sender, KeyEventArgs e)
        {
            var txtBox = sender as TextBox;

            // Handle Backspace key
            if (e.KeyCode == Keys.Back)
            {
                if (txtBox == txtAcc2 && txtAcc2.Text.Length <= 1)
                    txtAcc1.Focus();
                else if (txtBox == txtAcc3 && txtAcc3.Text.Length <= 1)
                    txtAcc2.Focus();
                else if (txtBox == txtAcc4 && txtAcc4.Text.Length <= 1)
                    txtAcc3.Focus();
            }
            // Handle Enter key
            else if (e.KeyCode == Keys.Enter)
            {
                SelectData();
            }
            // Handle Left Arrow key
            else if (e.KeyCode == Keys.Left)
            {
                if (txtBox == txtAcc2)
                    txtAcc1.Focus();
                else if (txtBox == txtAcc3)
                    txtAcc2.Focus();
                else if (txtBox == txtAcc4)
                    txtAcc3.Focus();
            }
            // Handle Right Arrow key
            else if (e.KeyCode == Keys.Right)
            {
                if (txtBox == txtAcc1)
                    txtAcc2.Focus();
                else if (txtBox == txtAcc2)
                    txtAcc3.Focus();
                else if (txtBox == txtAcc3)
                    txtAcc4.Focus();
            }
            // Handle Down Arrow key
            else if (e.KeyCode == Keys.Down)
            {
                dgAccounts?.Focus(); // null check in case dgAccounts is not initialized
            }
        }

        private void txtAcc4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
