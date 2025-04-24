using AccountingSystem;
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
        private readonly string remark;
        private ucInvestigationForm ucInvestigationForm;
        private readonly bool create;

        public frmInvestigation(bool create, string jobOrderNumber, int jobOrderId, string accountName, string accountNumber, string customerAddress, string remark)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            ucInvestigationForm = ucInvestigationForm1;

            this.jobOrderNumber = jobOrderNumber;
            this.jobOderId = jobOrderId;
            this.accountName = accountName;
            this.accountNumber = accountNumber;
            this.customerAddress = customerAddress;
            this.remark = remark;
            this.create = create;

        }

        private void frmInvestigation_Load(object sender, EventArgs e)
        {
            ucInvestigationForm.txtAccountName.Text = accountName;
            ucInvestigationForm.txtAccountNumber.Text = accountNumber;
            ucInvestigationForm.txtJONumber.Text = jobOrderNumber;
            ucInvestigationForm.txtJORemarks.Text = remark;
            ucInvestigationForm._jobOrderId = jobOderId;
            ucInvestigationForm._customerAddress = customerAddress;
            ucInvestigationForm.OnLoad();
            //ucInvestigationForm.EnableControls(create);
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
            try
            {
                if (ucInvestigationForm.isUpdate == false)
                {
                    Helper.MessageBoxSuccess("Nothing to save. Please select record to update.");
                    return;
                }


                if (Helper.MessageBoxConfirmCancel("Do you want to save this investigation form?"))
                {
                    if (ucInvestigationForm.SaveData())
                    {
                        UpdateJobOrderStatus();
                        Helper.MessageBoxSuccess("Investigation record has been saved successfully.");
                        ucInvestigationForm.OnLoad();
                    }
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
    }
}
