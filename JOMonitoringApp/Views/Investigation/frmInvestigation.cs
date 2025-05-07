using AccountingSystem;
using Google.Apis.Logging;
using MySqlX.XDevAPI.Common;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
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
                    Helper.MessageBoxSuccess("Investigation record has been updated successfully.");

                    btnSave.Text = "Save [Ctrl + S]";
                    btnSave.BackColor = Color.DodgerBlue;
                    btnSave.ForeColor = Color.White;

                    ucInvestigationForm.OnLoad();
                    ucInvestigationForm.ResetForm();
                    ucInvestigationForm.isUpdate = false;

                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError("Something went wrong. Please contact your system administrator.");
            }
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
                ucInvestigationForm.isUpdate = false;
            }
        }
        
        private void frmInvestigation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveData();
            }

            if (e.Control && e.KeyCode == Keys.Enter)
            {
                ucInvestigationForm.GetInvestigationRecords();
            }
        }


    }
}
