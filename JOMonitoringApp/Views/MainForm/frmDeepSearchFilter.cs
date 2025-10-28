using AccountingSystem;
using System;
using System.Data;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.MainForm
{
    public partial class frmDeepSearchFilter : Form
    {
        public frmDeepSearchFilter()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }
        private DataTable EmployeesDataTable()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(object)),
                new DataColumn("full_name", typeof(string)),
            };

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(dataColumns);

            var datable = Factory.UsersRepository().GetRecords();

            dataTable.Rows.Add(null, string.Empty);
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
        private void frmDeepSearchFilter_Load(object sender, EventArgs e)
        {
            HelperLoadRecords.EmployeeCombobox(cmbxAccomplishedBy, EmployeesDataTable(), "id", "full_name");
            HelperLoadRecords.EmployeeCombobox(cmbxPreparedBy, EmployeesDataTable(), "id", "full_name");

            dtpDateFrom.Value = Helper.advanceSearchDateFrom;
            dtpDateTo.Value = Helper.advanceSearchDateTo;
            cmbxAccomplishedBy.SelectedValue = Helper.AdvanceSearchAccomplishedBy;
            cmbxPreparedBy.SelectedValue = Helper.AdvanceSearchPreparedBy;
            chbxJoWithRemarks.Checked = Helper.AdvanceSearchWithRemarks;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Helper.AdvanceSearchPreparedBy = cmbxPreparedBy.SelectedIndex == -1 || cmbxPreparedBy.SelectedValue == DBNull.Value ? 0 : Convert.ToInt32(cmbxPreparedBy.SelectedValue);
            Helper.AdvanceSearchAccomplishedBy = cmbxAccomplishedBy.SelectedIndex == -1 || cmbxAccomplishedBy.SelectedValue == DBNull.Value ? 0 : Convert.ToInt32(cmbxAccomplishedBy.SelectedValue);
            Helper.advanceSearchDateFrom = dtpDateFrom.Value;
            Helper.advanceSearchDateTo = dtpDateTo.Value;
            Helper.AdvanceSearchWithRemarks = chbxJoWithRemarks.Checked;


            Helper.AdvanceSearchPreparedByName = cmbxPreparedBy.Text;
            Helper.AdvanceSearchAccomplishedByName = cmbxAccomplishedBy.Text;

            this.Close();
        }
    }
}
