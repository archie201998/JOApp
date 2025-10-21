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
    public partial class frmRequestApprovalForm : Form
    {
        private int totalSeconds = 300; 
        private int remainingSeconds = 300;
        private int maxPanelWidth = 0;
        private DataTable dtRequests;

        private int requestId;

        public frmRequestApprovalForm(DataTable dtNewRequests)
        {
            InitializeComponent();
            maxPanelWidth = panelTimer.Width;

            dtRequests = dtNewRequests;  
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            bool approved = Factory.RequestRepository().UpdateRequestStatus(requestId, 1);

            if (approved)
                Close();
        }

        private void btnDisapproved_Click(object sender, EventArgs e)
        {
            bool approved = Factory.RequestRepository().UpdateRequestStatus(requestId, 2);
            if (approved)
                Close();
        }

        private void frmInvestigationApprovalForm_Load(object sender, EventArgs e)
        {
            foreach (DataRow row in dtRequests.Rows)
            {
                requestId = Convert.ToInt32(row["id"]);
                string requestedBy = row["requested_by"].ToString();
                string details = row["details"].ToString();
                DateTime dateRequested = Convert.ToDateTime(row["created_at"]);


                label3.Text = $"REQUESTED BY : {requestedBy.ToUpper()}";
                label2.Text = $"DATE TIME : " + dateRequested.ToString("MMMM dd, yyyy HH:MM:ss").ToUpper();

                approveTimer.Enabled = true;
                txtMessage.Text = details;

            }
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

            if (remainingSeconds == 0)
            {
                //Mark Request as Disapproved due to timeout    
                this.Close();
            }
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

        private void status_Tick(object sender, EventArgs e)
        {
            DataTable stillExist = Factory.RequestRepository().GetRequestsByIDAndStatus(requestId, 0);

            if (stillExist.Rows.Count == 0)
            {
                this.Close();
            }
        }
    }
}
