using AccountingSystem;
using MySqlX.XDevAPI.Common;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Investigation
{
    public partial class frmInvestigation : Form
    {
        private readonly string jobOrderNumber;
        private readonly int jobOderId;
        private readonly string accountName;
        private readonly string accountNumber;
        private readonly string customerAddress;
        private readonly string particular;
        internal ucInvestigationForm ucInvestigationForm;
        private readonly bool create;
        internal int _selectedInvestigationID;

        public frmInvestigation()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            ucInvestigationForm = ucInvestigationForm1;

            if (_selectedInvestigationID != 0)
            {
                ucInvestigationForm.selectedInvistigationID = _selectedInvestigationID;
                ucInvestigationForm.ViewInvestigationDetails();
            }
        }

        private void frmInvestigation_Load(object sender, EventArgs e)
        {
            ucInvestigationForm.DataGridDoubleClicked += MyUserControl_DataGridClicked;
        }

        private void MyUserControl_DataGridClicked(object sender, EventArgs e)
        {
            btnSave.Text = "Update [Ctrl + S]";
            btnSave.BackColor = Color.OrangeRed;
            btnSave.ForeColor = Color.White;
        }

        private void UpdateJobOrderStatus()
        {
            int jobOrderId = ucInvestigationForm._jobOrderId;
            int statusId = 2;
            Factory.JobOrdersRepository().UpdateStatus(jobOrderId, statusId);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            try
            {
                if (ucInvestigationForm.SaveData())
                {
                    UpdateJobOrderStatus();
                    Helper.MessageBoxSuccess("Investigation record has been updated successfully.");
                    ucInvestigationForm.OnLoad();
                    ucInvestigationForm.ResetForm();

                    btnSave.Text = "Save [Ctrl + S]";
                    btnSave.BackColor = Color.DodgerBlue;
                    btnSave.ForeColor = Color.White;
                    ucInvestigationForm.ResetForm();
                    ucInvestigationForm.EnableControls(false);
                    ucInvestigationForm.isUpdate = false;

                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError("Something went wrong. Please contact your system administrator." + ex.Message);
            }
        }

        private void ucInvestigationForm1_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void Cancel()
        {
            if (Helper.MessageBoxConfirmCancel("Are you sure you want to cancel the update transaction?"))
            {
                btnSave.Text = "Save [Ctrl + S]";
                btnSave.BackColor = Color.DodgerBlue;
                btnSave.ForeColor = Color.White;
                ucInvestigationForm.ResetForm();
                ucInvestigationForm.EnableControls(false);
                ucInvestigationForm.isUpdate = false;
            }
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmInvestigation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveData();
            }
            else if (e.KeyData == Keys.Escape)
            {
                if (Helper.MessageBoxConfirmCancel("Do you want to clear all inputs?"))
                    Cancel();
                return;
            }
        }

        private void frmInvestigation_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void ucInvestigationForm1_Click(object sender, EventArgs e)
        {

        }
    }
}
