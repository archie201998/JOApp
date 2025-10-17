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
        private int totalSeconds = 300; 
        private int remainingSeconds = 300;
        private int maxPanelWidth = 0;

        public frmInvestigationApprovalForm()
        {
            InitializeComponent();
            maxPanelWidth = panelTimer.Width;
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            string approvalMessage = txtMessage.Text.Trim();
            var investigationModel = new InvestigationModel
            {
                ApprovalMessage = approvalMessage
            };
            bool result = Factory.InvestigationRepository().InsertApprovalMessage(investigationModel);
            
            if (result)
            {
                Helper.MessageBoxSuccess("Investigation has been approved.");
                Close();
            }
        }

        private void btnDisapproved_Click(object sender, EventArgs e)
        {

        }

        private void frmInvestigationApprovalForm_Load(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void approveTimer_Tick(object sender, EventArgs e)
        {
            remainingSeconds--;

            if (remainingSeconds <= 0)
            {
                approveTimer.Stop();
                remainingSeconds = 0;
            }

            UpdateDisplay();
            UpdatePanelColor();
            UpdatePanelWidth();
        }

        private void UpdatePanelWidth()
        {
            float percentage = (float)remainingSeconds / totalSeconds;
            int newWidth = (int)(maxPanelWidth * percentage);

            // Ensure minimum width of 1 pixel
            if (newWidth < 1 && remainingSeconds > 0)
                newWidth = 1;

            panelTimer.Width = newWidth;
        }

        private void UpdateDisplay()
        {
            int minutes = remainingSeconds / 60;
            int seconds = remainingSeconds % 60;
        }

        private void UpdatePanelColor()
        {
            if (remainingSeconds <= 80)
            {
                panelTimer.BackColor = Color.Tomato; 
            }
            else if (remainingSeconds <= 150)
            {
                panelTimer.BackColor = Color.Orange; 
            }
            else
            {
                panelTimer.BackColor = Color.DodgerBlue;
            }
        }
    }
}
