using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.Reports;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.Crmf;
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
        private readonly frmInvestigation _frmInvestigation;
        public frmInvestigationList(frmInvestigation frmInvestigation)
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgInvestigations);
            Helper.LoadFormIcon(this);
            _frmInvestigation = frmInvestigation;
        }

        private void InvestigationForm(string whatToPrint)
        {
            int investigationId = Convert.ToInt32(dgInvestigations.SelectedRows[0].Cells["id"].Value);
            string jobOrderNumber = dgInvestigations.SelectedRows[0].Cells["job_order_no"].Value.ToString();
            int jobOrderId = Convert.ToInt32(dgInvestigations.SelectedRows[0].Cells["job_orders_id"].Value);


            //Log Print
            _ = Factory.JOLogsRepository().Insert(Helper.LogJO("Printed", jobOrderId));

            _ = new frmInvestigationReport(investigationId, jobOrderNumber, whatToPrint).ShowDialog();
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
            string particular = cmbxParticular.Text == "All" ? string.Empty : cmbxParticular.Text;  
            var dtInvestigation = Factory.InvestigationRepository().GetViewRecordsBySearch(statusId, rowFilter, searchKey, particular);
   
            lblRecordCount.Text = $"{dtInvestigation.Rows.Count.ToString()} OUT OF {Factory.InvestigationRepository().RecordCount()} RECORDS.";
            HelperLoadRecords.InvestigationDatagridView(dgInvestigations, dtInvestigation);
        }

        private void frmInvestigationList_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void LoadParticulars()
        {
            DataTable dtParticulars = Factory.ParticularsRepository().GetRecords();

            const string investigationPrefix = "Investigation - ";

            DataTable filteredParticulars = dtParticulars.Clone(); 


            foreach (DataRow dr in dtParticulars.Rows)
            {
                string particular = dr["particular"]?.ToString() ?? string.Empty;

                if (particular.StartsWith(investigationPrefix, StringComparison.OrdinalIgnoreCase))
                {
                    // Add the original row or create new row with trimmed value
                    DataRow newRow = filteredParticulars.NewRow();
                    newRow["id"] = dr["id"];
                    newRow["particular"] = particular;
                    filteredParticulars.Rows.Add(newRow);
                }
            }

            filteredParticulars.Rows.Add(0, "All");
            filteredParticulars.DefaultView.Sort = "id ASC";
            cmbxParticular.DataSource = filteredParticulars;
            cmbxParticular.DisplayMember = "particular";
            cmbxParticular.ValueMember = "id";


        }

        private void OnLoad()
        {
            HelperLoadRecords.InvestigationStatusCombobox(cmbxStatus);
            HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowLimit);

            cmbxRowLimit.SelectedIndex = 1;
            cmbxStatus.SelectedValue = 6;
            GetInvestigationRecords();
            LoadParticulars();   


            if (Helper.CurrentUserID == 15)
            {
                dgInvestigations.MultiSelect = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ViewDetails();
        }

        private void dgInvestigations_DoubleClick(object sender, EventArgs e)
        {
            //if (Helper.UserHasPermission("INVESTIGATION_APPROVAL"))
            //{
            //    // Get investigationId and jobOrderId from the selected row
            //    int investigationId = Convert.ToInt32(dgInvestigations.SelectedRows[0].Cells["id"].Value);
            //    int jobOrderId = Convert.ToInt32(dgInvestigations.SelectedRows[0].Cells["job_orders_id"].Value);

            //    return;
            //}

            ViewDetails();
        }

        private void ViewDetails()
        {
            int rowIndex = dgInvestigations.CurrentRow.Index;   
            int investigationId = Convert.ToInt32(dgInvestigations.SelectedRows[0].Cells["id"].Value);
            //var investigationForm = new frmInvestigationForm(investigationId);
            //investigationForm.ShowDialog();
            //GetInvestigationRecords();
            //dgInvestigations.CurrentCell = dgInvestigations.Rows[rowIndex].Cells[2];

            var investigationForm = new frmInvestigationForm(_frmInvestigation, investigationId);
            ShowMdiChildForm(investigationForm);

        }

        private void ShowMdiChildForm(Form form)
        {
            form.MdiParent = _frmInvestigation;
            form.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetInvestigationRecords();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            contextMenuStrip2.Show(btnPrint, new Point(0, btnPrint.Height));
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

        }

        private void dgInvestigations_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (Helper.temporaryAdminMode)
                {
                    if (Helper.MessageBoxConfirmDelete(dgInvestigations.SelectedRows.Count))
                    {
                        var investigationModel = new List<InvestigationModel>();

                        foreach (DataGridViewRow row in dgInvestigations.SelectedRows)
                        {
                            int id = Convert.ToInt32(row.Cells["id"].Value);
                            investigationModel.Add(new InvestigationModel { Id = id });
                        }

                        bool isDeleted = Factory.InvestigationRepository().Delete(investigationModel);

                        if (isDeleted)
                        {
                            Helper.MessageBoxSuccess("Investigation/s has been deleted.");
                            OnLoad();
                            return;
                        }
                    }
                }
                
                return;
            }
        }

        private void wholePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvestigationForm("FULL_REPORT");
        }

        private void investigatorCommentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvestigationForm("INVESTIGATOR_COMMENT");
        }

        private void recommendationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvestigationForm("RECOMMENDATION");
        }

        private void adjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvestigationForm("ADJUSTMENT");
        }

        private void addToRecipientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get investigationId and jobOrderId from the selected row
            int investigationId = Convert.ToInt32(dgInvestigations.SelectedRows[0].Cells["id"].Value);
            int jobOrderId = Convert.ToInt32(dgInvestigations.SelectedRows[0].Cells["job_orders_id"].Value);
            string jobOrderNumber = dgInvestigations.SelectedRows[0].Cells["job_order_no"].Value.ToString();
            string contactNumber = dgInvestigations.SelectedRows[0].Cells["contact_number"].Value.ToString();
            string accountName = dgInvestigations.SelectedRows[0].Cells["customer_name"].Value.ToString();
            string accountNumber = dgInvestigations.SelectedRows[0].Cells["account_number"].Value.ToString();
            string particular = dgInvestigations.SelectedRows[0].Cells["nature_of_complaint"].Value.ToString();

            var results = Factory.InvestigationRepository().AddToRecipient(jobOrderNumber, contactNumber, accountNumber, accountName, particular);

            if (results)
            {
                Helper.MessageBoxSuccess("Added to recipient list.");
            }
            else
            {
                Helper.MessageBoxError("Failed to add to recipient list.");
            }
        }

    }
}
