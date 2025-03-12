using AccountingSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.JobOrder
{
    public partial class frmSearchAccount : Form
    {
        ucJoborder _ucJobOrder;
        public frmSearchAccount(ucJoborder ucJoborder)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgAccounts, true);
            _ucJobOrder = ucJoborder;
        }

        private void FrmSearchAccount_Load(object sender, EventArgs e)
        {
            txtAccountName.Focus();
            LoadAccounts();
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

        private void LoadAccounts()
        {
            string searchKey = txtAccountName.Text.Trim();
            int charCount = searchKey.Length;
            if (charCount <= 3)
                return;

            var dataTable = new DataTable();
            DataTable dtJobOrders = Factory.CustomersRepository().GetRecordsBySearchByAccountNumberAndAccountName(searchKey);
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
            LoadAccounts();
        }

        private void DgAccounts_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void DgAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
     
        }

        private void DgAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectData();
        }

        private void SelectData()
        {
            if (dgAccounts.SelectedRows.Count == 0)
                return; 

            int selectedAccountId = Convert.ToInt32(dgAccounts.SelectedRows[0].Cells["id"].Value);
            string selectedAccountName = dgAccounts.SelectedRows[0].Cells["account_name"].Value.ToString();
            string selectedAccountNumber = dgAccounts.SelectedRows[0].Cells["account_number"].Value.ToString();
            string selectedAddress = dgAccounts.SelectedRows[0].Cells["address"].Value.ToString();

            _ucJobOrder.isNewAccount = false;
            _ucJobOrder.accountId = selectedAccountId;
            _ucJobOrder.txtAccountName.Text = selectedAccountName;
            _ucJobOrder.txtAccountNumber.Text = selectedAccountNumber;
            _ucJobOrder.txtAddress.Text = selectedAddress;
            _ucJobOrder.txtJONumber.Focus();

            Close();
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
    }
}
