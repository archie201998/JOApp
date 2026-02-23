using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.Purok;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace JOMonitoringApp.Views.JobOrder.JobOrderRepairs
{
    public partial class ucJobOrderRepairs : UserControl
    {
        private bool isUpdate = false;

        public ucJobOrderRepairs()
        {
            InitializeComponent();
        }

        private void ucJobOrderRepairs_Load(object sender, EventArgs e)
        {
            if(!DesignMode)
            {
                CreateStatusButtons();
                HelperLoadRecords.BarangayCombobox(cmbxBarangay);
                LoadPurok();
            }
        }

        private void LoadPurok()
        {
            int barangayId = Factory.BarangayRepository().GetIdByName(cmbxBarangay.Text);
            HelperLoadRecords.PurokCombobox(barangayId, cmbxPurok);
        }

        private void CreateStatusButtons()
        {
            // Create buttons
            RadioButton rbAll = CreateRadioButton("All");
            RadioButton rbPending = CreateRadioButton("Pending");
            RadioButton rbProcessing = CreateRadioButton("Processing");
            RadioButton rbCancelled = CreateRadioButton("Cancelled");
            RadioButton rbAccomplished = CreateRadioButton("Accomplished");

            // Add to FlowLayoutPanel
            flpStatus.Controls.Add(rbAll);
            flpStatus.Controls.Add(rbPending);
            flpStatus.Controls.Add(rbProcessing);
            flpStatus.Controls.Add(rbCancelled);
            flpStatus.Controls.Add(rbAccomplished);

            // Default selection
            rbAll.Checked = true;
        }

        private RadioButton CreateRadioButton(string text)
        {
            RadioButton rb = new RadioButton();

            rb.Appearance = Appearance.Button;
            rb.Text = text;
            rb.TextAlign = ContentAlignment.MiddleCenter;
            rb.Width = 110;
            rb.Height = 30;
            rb.Margin = new Padding(10, 5, 10, 5);
            rb.FlatStyle = FlatStyle.Flat;
            rb.FlatAppearance.BorderSize = 1;
            rb.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            rb.AutoCheck = true;

            rb.CheckedChanged += Status_CheckedChanged;

            StyleButton(rb, false);

            return rb;
        }

        private void Status_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb.Checked)
            {
                rb.Text = "✔ " + rb.Text.Replace("✔ ", "");
                StyleButton(rb, true);
            }
            else
            {
                rb.Text = rb.Text.Replace("✔ ", "");
                StyleButton(rb, false);
            }
        }

        private void StyleButton(RadioButton rb, bool isChecked)
        {
            if (isChecked)
            {
                rb.BackColor = Color.DodgerBlue;
                rb.ForeColor = Color.White;
            }
            else
            {
                rb.BackColor = Color.White;
                rb.ForeColor = Color.Black;
            }
        }

        internal JobOrdersModel JobOrderModel()
        {
            string lot = txtLot.Text.Trim();
            string block = txtBlock.Text.Trim();
            string barangay = cmbxBarangay.Text.Trim();
            string purok = cmbxPurok.Text.Trim();
            string street = txtStreet.Text.Trim();
            string landMark = txtLandMark.Text.Trim();
            string moreDetails = txtMoreDetails.Text.Trim();

            string address = $"{lot} {block}, {street}, {purok}, {barangay}, {landMark}, {moreDetails}";
            DateTime date = dtpDate.Value;
            string jobOrderNumber = txtJobOrderNumber.Text;

            return new JobOrdersModel()
            {
                Address = address,  
                Date = date,
                JONUmber = jobOrderNumber,
                PreparedBy = Helper.CurrentUserID,
            };
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isInsertSuccessful = Factory.JobOrdersRepository().Insert(JobOrderModel());


            if (!isInsertSuccessful) return ;


            int lastInsertedJOID = Factory.JobOrdersRepository().GetLastInsertedID(Helper.CurrentUserID);
            if (!InsertJobOrderParticulars(lastInsertedJOID)) return ;

        }

        private bool InsertJobOrderParticulars(int jobOrderId)
        {
            if (isUpdate)
                Factory.JobOrdersRepository().DeleteJobOrderParticulars(jobOrderId);

            foreach (var item in clBoxParticulars.CheckedItems)
            {
                string particularName = item.ToString();
                int particularId = Factory.ParticularsRepository().GetIdByParticularName(particularName);

                bool success = Factory.JobOrderParticularsRepository().InsertJobOrdersParticulars(jobOrderId, particularId);
                if (!success)
                {
                    return false;
                }
            }
            return true;
        }

        private void gbAccountDetails_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _ = new frmAddPurok().ShowDialog();
        }

        private void cmbxBarangay_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadPurok();
        }
    }
}
