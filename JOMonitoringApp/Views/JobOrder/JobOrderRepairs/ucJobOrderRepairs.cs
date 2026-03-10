using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.Barangay;
using JOMonitoringApp.Views.Purok;
using Org.BouncyCastle.Asn1.Crmf;
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
        private int _radStatusId;
        private int lastInsertedJOID = 0;

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
                HelperLoadRecords.BarangayCombobox(cmbxBarangayFilter);
                HelperLoadRecords.ParticularComboboxRepairAndMaintenance(cmbxParticularFilter);    
                LoadPurok();
                LoadParticulars();
                
                LoadRepairsAndMaintenance();
            }
        }

        internal void LoadParticulars()
        {
            // Store checked items
            var checkedItems = clBoxParticulars.CheckedItems
                                .Cast<object>()
                                .Select(x => x.ToString())
                                .ToHashSet();

            clBoxParticulars.Items.Clear();

            var dtParticulars = Factory.ParticularsRepository().GetRepairAndMaintenanceParticular();

            var excludedItems = new HashSet<string> { "Investigation", "Change Meter" };

            foreach (DataRow item in dtParticulars.Rows)
            {
                var particular = item["particular"]?.ToString();

                if (!string.IsNullOrEmpty(particular) && !excludedItems.Contains(particular))
                {
                    int index = clBoxParticulars.Items.Add(particular);

                    // Restore checked state if previously checked
                    if (checkedItems.Contains(particular))
                    {
                        clBoxParticulars.SetItemChecked(index, true);
                    }
                }
            }

        }
        private void LoadRepairsAndMaintenance()
        {
            string particulars = clBoxParticulars.Text;
            //address filter
            string barangay = cmbxBarangayFilter.Text;
            string purok = cmbxBarangayFilter.Text;

            string completeAddress = barangay + " " + purok;
            int status = _radStatusId;

            DataTable dtRepairAndMaintenance = Factory.JobOrdersRepository().GetAllRepairAndMaintenanceRecords(status, particulars, completeAddress);
            dgJobOrderRepairAndMaintenanceList.DataSource = dtRepairAndMaintenance;

        }

        private void LoadPurok()
        {
            int barangayId = Factory.BarangayRepository().GetIdByName(cmbxBarangay.Text);
            HelperLoadRecords.PurokCombobox(barangayId, cmbxPurok);

            int barangayIdFilter = Factory.BarangayRepository().GetIdByName(cmbxBarangayFilter.Text);
            HelperLoadRecords.PurokCombobox(barangayIdFilter, cmbxPurokFilter);
        }

        private void CreateStatusButtons()
        {
            // Create buttons
            RadioButton rbAll = CreateRadioButton("All", 5);
            RadioButton rbPending = CreateRadioButton("Pending", 1);
            RadioButton rbProcessing = CreateRadioButton("Processing", 2);
            RadioButton rbCancelled = CreateRadioButton("Cancelled", 3);
            RadioButton rbAccomplished = CreateRadioButton("Accomplished", 4);

            // Add to FlowLayoutPanel
            flpStatus.Controls.Add(rbAll);
            flpStatus.Controls.Add(rbPending);
            flpStatus.Controls.Add(rbProcessing);
            flpStatus.Controls.Add(rbCancelled);
            flpStatus.Controls.Add(rbAccomplished);

            // Default selection
            rbAll.Checked = true;
        }

        private RadioButton CreateRadioButton(string text, int statusTag)
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
            rb.Tag= statusTag;
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
                _radStatusId = Convert.ToInt32(rb.Tag);
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

        private string GetSelectedParticulars()
        {
            StringBuilder particularsBuilder = new StringBuilder();
            bool moreThanOneItem = clBoxParticulars.CheckedItems.Count > 1;

            foreach (var item in clBoxParticulars.CheckedItems)
            {
                particularsBuilder.Append($"{item.ToString()}");

                if (moreThanOneItem)
                    particularsBuilder.Append("\\");
            }

            string particular = particularsBuilder.ToString().TrimEnd();

            if (moreThanOneItem)
                particular = particular.Substring(0, particular.Length - 2);

            return particular;
        }

        internal JobOrdersModel JobOrderModel()
        {
            string accountNumber = string.Empty;
            string accountName = string.Empty;

            string lot = txtLot.Text.Trim();
            string block = txtBlock.Text.Trim();
            string barangay = cmbxBarangay.Text.Trim();
            string purok = cmbxPurok.Text.Trim();
            string street = txtStreet.Text.Trim();
            string landMark = txtLandMark.Text.Trim();
            string moreDetails = txtMoreDetails.Text.Trim();

            string address = $"{lot} {block}, {street}, {purok}, {barangay}, {landMark}, {moreDetails}";
            DateTime date = dtpDate.Value;

            string contact = string.Empty;
            string jobOrderNumber = txtJobOrderNumber.Text.Trim();
            string orNumber = string.Empty;
            decimal amount = 0;
            string MRIS = string.Empty;
            string MRS = string.Empty;
            string WAR = string.Empty; 
            string remarks = string.Empty;
            int preparedById = Helper.CurrentUserID;
            int? materialsIssuedById = 0;
            int? accomplishedBy = 0;
            int statusId = 1;
            string particular = GetSelectedParticulars();


            return new JobOrdersModel()
            {
                AccountNumber = accountNumber,
                AccountName = address,
                Address = string.Empty,
                ContactNumber = contact,
                PreparedBy = preparedById,
                JONUmber = jobOrderNumber,
                Date = date,
                ORNumber = orNumber,
                Amount = amount,
                MRIS = MRIS,
                MRS = MRS,
                WAR = WAR,
                Remarks = remarks,
                MaterialsIssuedBy = materialsIssuedById == 0 ? null : materialsIssuedById,
                AccomplishedBy = accomplishedBy == 0 ? null : accomplishedBy,
                StatusId = statusId,
                UserId = Helper.CurrentUserID
            };
        }


        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (Save())
            {
                Helper.MessageBoxSuccess("Repair and Maintenance Job Order successfully created.");
                LoadRepairsAndMaintenance();
            }
        }

        private bool Save()
        {
            bool InsertJobOrderAsync()
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    bool isInsertSuccessful = Factory.JobOrdersRepository().Insert(JobOrderModel());

                    if (!isInsertSuccessful) return false;

                    lastInsertedJOID = Factory.JobOrdersRepository().GetLastInsertedID(Helper.CurrentUserID);
                    if (!InsertJobOrderParticulars(lastInsertedJOID)) return false;

                    scope.Complete();
                    return true;
                }
            }


            if (InsertJobOrderAsync())
            {
                return true;
            }
            return false;
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
            int barangayId = Convert.ToInt32(cmbxBarangay.SelectedValue);
            _ = new frmAddPurok(barangayId).ShowDialog();
        }

        private void cmbxBarangay_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadPurok();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _ = new frmAddBarangay().ShowDialog();
        }

        private void cmbxBarangayFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadPurok();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadRepairsAndMaintenance();
        }

   
    }
}
