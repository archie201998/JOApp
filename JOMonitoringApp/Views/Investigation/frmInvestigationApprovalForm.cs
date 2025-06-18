using AccountingSystem;
using JOMonitoringApp.Model;
using Org.BouncyCastle.Pqc.Crypto.Falcon;
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
    public partial class frmInvestigationApprovalForm : Form
    {
        private int _investigationId;   
        private int _jobOrderId;

        public frmInvestigationApprovalForm(int investigationId, int jobOrderId)
        {
            InitializeComponent();
            _investigationId = investigationId;
            _jobOrderId = jobOrderId;

        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            string approvalMessage = txtMessage.Text.Trim();
            var investigationModel = new InvestigationModel
            {
                InvestigationId = _investigationId,
                JobOrderId = _jobOrderId,
                ApprovalMessage = approvalMessage
            };
            bool result = Factory.InvestigationRepository().InsertApprovalMessage(investigationModel);
            
            if (result)
            {
                Helper.MessageBoxSuccess("Investigation has been approved.");
                _ = Factory.InvestigationRepository().UpdateStatus(_investigationId, 4);
                _ = Factory.JobOrdersRepository().UpdateStatus(_jobOrderId, 4);
                Close();
            }
        }

        private void btnDisapproved_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMessage.Text.Trim()))
            {
                Helper.MessageBoxError("Please provide a reason for disapproval.");
                _ = Factory.InvestigationRepository().UpdateStatus(_investigationId, 5);
                return;
            }
        }

        private void frmInvestigationApprovalForm_Load(object sender, EventArgs e)
        {
            txtMessage.Text = Factory.InvestigationRepository().GetApprovalMessage(_investigationId);
            //admin view
            label2.Visible = Helper.UserId == 15;
            label3.Visible = Helper.UserId == 15;
            label2.Text = $"Job Order ID: {_jobOrderId}";
            label3.Text = $"Investigation ID: {_investigationId}";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
