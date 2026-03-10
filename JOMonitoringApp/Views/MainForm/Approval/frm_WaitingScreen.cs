using AccountingSystem;
using Google.Apis.Auth.OAuth2;
using JOMonitoringApp.Views.Admin;
using JOMonitoringApp.Views.Investigation;
using K4os.Compression.LZ4.Encoders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.MainForm.Approval
{

    public partial class frm_WaitingScreen : Form
    {

        private List<Keys> keySequence = new List<Keys>();
        int requestId = 0;
        int secondsRemaining = 5;

        public frm_WaitingScreen(int requestID)
        {
            InitializeComponent();
            this.requestId = requestID;
        }

        private void btnDisapproved_Click(object sender, EventArgs e) //cancel request 
        {
            if (!Helper.RequestApproved) 
            {
                bool cancelRequest = Factory.RequestRepository().CancelRequest(requestId);
                if (cancelRequest)
                {
                    Helper.RequestApproved = false;
                    Close();
                }
            }

            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           var requestStatus = Factory.RequestRepository().GetRequestStatusById(requestId);

            if (requestStatus.Rows.Count > 0)
            {
                foreach (DataRow row in requestStatus.Rows)
                {
                    int status = Convert.ToInt32(row["status"]);

                    if (status == 1)
                    {
                        Helper.RequestApproved = true;
                        btnDisapproved.BackColor = Color.Green;
                        btnDisapproved.Text = $"REQUEST APPROVED";
                        pictureBox1.Visible = false;
                        picDisapproved.Visible = false;
                        picApproved.Visible = true;

                        closeTimer.Enabled = true;

                    }
                    else if (status == 2)
                    {
                        Helper.RequestApproved = false;
                        pictureBox1.Visible = false;
                        picDisapproved.Visible = true;
                        picApproved.Visible = false;
                        btnDisapproved.Text = $"REQUEST DISAPPROVED";

                        closeTimer.Enabled = true;
                    }
                }

            }
        }

        private void frm_WaitingScreen_Load(object sender, EventArgs e)
        {

        }

        private void closeTimer_Tick(object sender, EventArgs e)
        {
            secondsRemaining--;

            if (secondsRemaining > 0)
            {
                label1.Text = $"Closing in {secondsRemaining} seconds...";
                if (secondsRemaining <= 5)
                {
                    label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
                }
            }
            else
            {
                timer1.Stop();
                this.Close();
            }
        }

        private void frm_WaitingScreen_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frm_WaitingScreen_KeyDown(object sender, KeyEventArgs e)
        {
            keySequence.Add(e.KeyCode);

            if (keySequence.Count > 6)
            {
                keySequence.RemoveAt(0);
            }

            if (keySequence.SequenceEqual(new List<Keys> { Keys.Z, Keys.Z, Keys.X, Keys.X }))
            {

                DialogResult pinMatch = new frmPassKey().ShowDialog();

                if (DialogResult.OK == pinMatch)
                {
                    bool approved = Factory.RequestRepository().UpdateRequestStatus(requestId, 1);
                    if (approved)
                        Helper.MessageBoxSuccess("Approved by System Admin.");
                }
                else {
                    Helper.MessageBoxSuccess("Invalid PIN.");
                    Close();
                    return;
                }
                keySequence.Clear();
            }
        }

        private void frm_WaitingScreen_InputLanguageChanging(object sender, InputLanguageChangingEventArgs e)
        {

        }
    }
}
