using AccountingSystem;
using JOMonitoringApp.Views.Reports;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Investigation
{
    public partial class frmInvestigationList : Form
    {
        public frmInvestigationList()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgInvestigations);
            Helper.LoadFormIcon(this);
        }


        private void InvestigationForm()
        {
            int investigationId = Convert.ToInt32(dgInvestigations.SelectedRows[0].Cells["id"].Value);
            string jobOrderNumber = dgInvestigations.SelectedRows[0].Cells["job_order_no"].Value.ToString();

            _ = new frmInvestigationReport(investigationId, jobOrderNumber).ShowDialog();
        }

        private void dgInvestigations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgInvestigations.Columns[e.ColumnIndex].Name == "approval_status" && e.Value != null)
            {
                string status = e.Value.ToString();

                switch (status)
                {
                    case "FOR INVESTIGATION":
                        e.CellStyle.BackColor = Helper.InvestigationStatusColor("FOR INVESTIGATION");    // investigation color :contentReference[oaicite:0]{index=0}
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    case "FOR RECOMMENDATION":
                        e.CellStyle.BackColor = Helper.InvestigationStatusColor("FOR RECOMMENDATION"); // recommendation color :contentReference[oaicite:1]{index=1}
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    case "FOR APPROVAL":
                        e.CellStyle.BackColor = Helper.InvestigationStatusColor("FOR APPROVAL"); // approval-pending color :contentReference[oaicite:2]{index=2}
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    case "APPROVED":
                        e.CellStyle.BackColor = Helper.InvestigationStatusColor("APPROVED"); // approved color :contentReference[oaicite:3]{index=3}
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    case "FOR REINVESTIGATION":
                        e.CellStyle.BackColor = Helper.InvestigationStatusColor("FOR REINVESTIGATION");    // disapproved color :contentReference[oaicite:4]{index=4}
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    default:
                        e.CellStyle.BackColor = Color.LightGray;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }

        internal void GetInvestigationRecords()
        {
            string searchKey = txtSearch.Text.Trim();
            int statusId = Convert.ToInt32(cmbxStatus.SelectedValue);
            int rowFilter = Convert.ToInt32(cmbxRowLimit.SelectedValue);
            var dtInvestigation = Factory.InvestigationRepository().GetViewRecordsBySearch(statusId, rowFilter, searchKey);
   
            lblRecordCount.Text = $"{dtInvestigation.Rows.Count.ToString()} OUT OF {Factory.InvestigationRepository().RecordCount()} RECORDS.";
            HelperLoadRecords.InvestigationDatagridView(dgInvestigations, dtInvestigation);
        }

        private void frmInvestigationList_Load(object sender, EventArgs e)
        {
            HelperLoadRecords.InvestigationStatusCombobox(cmbxStatus);
            HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowLimit);

            cmbxRowLimit.SelectedIndex = 1;
            cmbxStatus.SelectedValue = 6;
            GetInvestigationRecords();


        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            ViewDetails();
        }
        private void dgInvestigations_DoubleClick(object sender, EventArgs e)
        {
            if (Helper.UserHasPermission("INVESTIGATION_APPROVAL"))
            {
                // Get investigationId and jobOrderId from the selected row
                int investigationId = Convert.ToInt32(dgInvestigations.SelectedRows[0].Cells["id"].Value);
                int jobOrderId = Convert.ToInt32(dgInvestigations.SelectedRows[0].Cells["job_orders_id"].Value);

                _ = new frmInvestigationApprovalForm(investigationId, jobOrderId).ShowDialog();
                return;
            }

            ViewDetails();
        }

        private void ViewDetails()
        {
            int investigationId = Convert.ToInt32(dgInvestigations.SelectedRows[0].Cells["id"].Value);
            var investigationForm = new frmInvestigationForm(investigationId);
            investigationForm.ShowDialog();
            GetInvestigationRecords();
        }
            
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetInvestigationRecords();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InvestigationForm();
        }

        private void lblRecordCount_Click(object sender, EventArgs e)
        {

        }

        private void dgInvestigations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void viewBAMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmInvestigationAdjustment(string.Empty).ShowDialog();
        }

        private void seeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmInvestigationImageViewer(string.Empty).ShowDialog();
        }
    }
}
