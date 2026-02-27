using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.Dashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Purok
{
    public partial class frmAddPurok : Form
    {
        private readonly ucPurok _purok;
        private int _barangayId;

        public frmAddPurok(int barangayId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _purok = ucPurok1;
            _barangayId = barangayId;  
        }


        private void frmAddPurok_Load(object sender, EventArgs e)
        {
            _purok.cmbxBarangay.SelectedValue = _barangayId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_purok.txtPurokName.Text))
            {
                MessageBox.Show("Please enter a purok name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(_purok.cmbxBarangay.Text))
            {
                MessageBox.Show("Please select a barangay", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string purokName = _purok.txtPurokName.Text;
            int barangayId = Convert.ToInt32(_purok.cmbxBarangay.SelectedValue);

            PurokModel purok = new PurokModel
            {
                PurokName = purokName,
                BarangayId = barangayId
            };

            bool isSaved = Factory.PurokRepository().Insert(purok);

            if (isSaved)
            {
                Helper.MessageBoxSuccess("Purok saved successfully.");
                Close();
            }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
            else
            {
                MessageBox.Show("Failed to save the purok. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
