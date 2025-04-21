using AccountingSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

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
            ucInvestigationForm.EnableControls(create);
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
    }
}
