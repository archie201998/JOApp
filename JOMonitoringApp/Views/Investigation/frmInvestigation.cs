using AccountingSystem;
using Google.Apis.Logging;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Common;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
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
                ucInvestigationForm.selectedInvestigationID = _selectedInvestigationID;
                ucInvestigationForm.ViewInvestigationDetails();
            }
        }

        internal void ResetForm()
        {
            this.SuspendLayout();
            ucInvestigationForm.SuspendLayout();

            // Clear text fields
            ucInvestigationForm.txtAccountName.Clear();
            ucInvestigationForm.txtAccountNumber.Clear();
            ucInvestigationForm.txtAddress.Clear();
            ucInvestigationForm.txtComplaint.Clear();
            ucInvestigationForm.txtInvestigatorComments.Clear();
            ucInvestigationForm.txtRecommendations.Clear();
            ucInvestigationForm.txtMeterBrand.Clear();
            ucInvestigationForm.txtMeterSize.Clear();
            ucInvestigationForm.txtJONumber.Clear();
            ucInvestigationForm.txtCalibrationResult.Clear();
            ucInvestigationForm.txtServiceLineDefects.Clear();
            ucInvestigationForm.txtAlternativeSource.Clear();

            // Reset numeric fields
            ucInvestigationForm.nudReadingAfterTest.Value = 0;
            ucInvestigationForm.nudReadingBeforeTest.Value = 0;
            ucInvestigationForm.nudImmediateFamily.Value = 0;
            ucInvestigationForm.nudHouseHelper.Value = 0;
            ucInvestigationForm.nudRelatives.Value = 0;
            ucInvestigationForm.nudBoarders.Value = 0;
            ucInvestigationForm.nudNoOfHoursServed.Value = 0;
            ucInvestigationForm.nudNoServiceOfOutlets.Value = 0;

            // Reset checkboxes
            ucInvestigationForm.cbHHPurpose.Checked = false;
            ucInvestigationForm.cbPromoteTrade.Checked = false;
            ucInvestigationForm.cbSellToNeighbours.Checked = false;
            ucInvestigationForm.cbGovernment.Checked = false;

            // Reset images only if different
            if (ucInvestigationForm.pictureBox1.Image != Properties.Resources.icons8_image_96)
                ucInvestigationForm.pictureBox1.Image = Properties.Resources.icons8_image_96;
            if (ucInvestigationForm.pictureBox2.Image != Properties.Resources.icons8_image_96)
                ucInvestigationForm.pictureBox2.Image = Properties.Resources.icons8_image_96;

            // Other resets
            ucInvestigationForm.lblAdjustedAmount.Text = "Result";
            ucInvestigationForm.btnCompute.Text = "Make Computations";
            ucInvestigationForm.isUpdate = false;
            ucInvestigationForm.EnableControls(false);

            // Reset save button UI
            btnSave.Text = "Save [Ctrl + S]";
            btnSave.BackColor = Color.DodgerBlue;
            btnSave.ForeColor = Color.White;

            ucInvestigationForm.ResumeLayout();
            this.ResumeLayout();
        }


        private void frmInvestigation_Load(object sender, EventArgs e)
        {
            ucInvestigationForm.DataGridDoubleClicked += MyUserControl_DataGridClicked;
        }

     

        private void MyUserControl_DataGridClicked(object sender, EventArgs e)
        {
            if (btnSave.InvokeRequired)
            {
                btnSave.Invoke(new Action(() =>
                {
                    btnSave.Text = "Update [Ctrl + S]";
                    btnSave.BackColor = Color.OrangeRed;
                    btnSave.ForeColor = Color.White;
                }));
            }
            else
            {
                btnSave.Text = "Update [Ctrl + S]";
                btnSave.BackColor = Color.OrangeRed;
                btnSave.ForeColor = Color.White;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirmCancel("Are you sure you want update this investigation record?"))
                SaveData();

            return;
        }

        private async void SaveData()
        {
            try
            {
                btnSave.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;

                bool success = await Task.Run(() => ucInvestigationForm.SaveData());

                if (success)
                {
                    Helper.MessageBoxSuccess("Investigation record has been updated successfully.");

                    await Task.Run(() => ucInvestigationForm.GetInvestigationRecords());
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError("Something went wrong. Please contact your system administrator.");
                // Optionally log the exception: Logger.Log(ex);
            }
            finally
            {
                btnSave.Enabled = true;
                Cursor.Current = Cursors.Default;
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
                ResetForm();
            }
        }
        
        private void frmInvestigation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveData();
            }

        }

        private void ucInvestigationForm1_Load(object sender, EventArgs e)
        {

        }
    }
}
