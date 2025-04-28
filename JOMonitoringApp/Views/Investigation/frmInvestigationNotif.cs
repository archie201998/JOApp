using AccountingSystem;
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
    public partial class frmInvestigationNotif : Form
    {
        private Dictionary<string, string> _forRecommendationDict = new Dictionary<string, string>();

        internal int jobOrderId = 0;
        internal string address = string.Empty;
        internal string remark = string.Empty;  
        public frmInvestigationNotif(Dictionary<string, string> forRecommendationDict)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            _forRecommendationDict = forRecommendationDict;
        }

        private void frmInvestigationNotif_Load(object sender, EventArgs e)
        {
            lblJONumber.Text = _forRecommendationDict["job_order_no"];
            lblComplaint.Text = _forRecommendationDict["nature_of_complaint"];
            lblAccountNumber.Text = _forRecommendationDict["account_number"];
            lblAccountName.Text = _forRecommendationDict["customer_name"];
            lblInvestigatorComment.Text = _forRecommendationDict["investigator_comments"];

            //customerAddress = _forRecommendationDict["customer_address"];

        }
        private void ShowAgainSettings()
        {
            bool dontShowAgain = cbxDontShowAgain.Checked;

            Properties.Settings.Default.SkipMyMessage = dontShowAgain;
            Properties.Settings.Default.Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ShowAgainSettings();
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

     
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            ShowAgainSettings();


            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "frmInvestigation") // Replace "MyFormName" with your form's name
                {
                    form.BringToFront(); // Optional: bring the form to front
                    form.Focus();        // Optional: focus the form
                    return;              // Already open, no need to open again
                }
            }

            // If not open, create a new instance

            //lblJONumber.Text = _forRecommendationDict["job_order_no"];
            //lblComplaint.Text = _forRecommendationDict["nature_of_complaint"];
            //lblAccountNumber.Text = _forRecommendationDict["account_number"];
            //lblAccountName.Text = _forRecommendationDict["customer_name"];
            //lblInvestigatorComment.Text = _forRecommendationDict["investigator_comments"];
            //frmInvestigation ucInvestigationForm = new frmInvestigation(false, lblJONumber.Text, lblAccountName.Text, lblAccountNumber.Text, customerAddress, remark);
       
            //ucInvestigationForm.Show();
        }
    }
}
