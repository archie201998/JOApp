using AccountingSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Customers
{
    public partial class frmCustomerLedger : Form
    {
        public frmCustomerLedger()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgvLedger);
        }

        private void frmCustomerLedger_Load(object sender, EventArgs e)
        {
        }

        private void OnLoad()
        {
            LoadLedger();
            //FormatLedgerGrid();
        }

        private void FormatLedgerGrid()
        {
            dgvLedger.ReadOnly = true;
            dgvLedger.AllowUserToAddRows = false;
            dgvLedger.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLedger.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvLedger.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLedger.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvLedger.Columns["Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLedger.Columns["Description"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLedger.Columns["Debit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLedger.Columns["Credit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLedger.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLedger.Columns["Balance"].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Format date

            // Highlight negative balances in red
            foreach (DataGridViewRow row in dgvLedger.Rows)
            {
                if (decimal.TryParse(row.Cells["Balance"].Value.ToString(), out decimal balance))
                {
                    if (balance < 0)
                        row.Cells["Balance"].Style.ForeColor = Color.Red;
                }
            }
        }

        private void LoadLedger()
        {

            using (SqlDataReader reader = Factory.CustomersRepository().LoadLedgerByCustomerId(11623, dateTimePicker1.Value, dateTimePicker2.Value))
            {
                DataTable dt = new DataTable();
                dt.Load(reader); // Load reader results into DataTable quickly
                dgvLedger.DataSource = dt;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            OnLoad();
        }
    }
}
