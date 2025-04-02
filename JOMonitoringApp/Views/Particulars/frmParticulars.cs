using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.JobOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Particulars
{
    public partial class frmParticulars : Form
    {
        private ucParticulars ucParticulars;
        public frmParticulars()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgvParticulars);
            ucParticulars = ucParticulars1;
        }

        private void frmParticulars_Load(object sender, EventArgs e)
        {
            LoadParticulars();
        }

        private void LoadParticulars()
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dtParticulars = Factory.ParticularsRepository().GetRecords();

            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(1);
                backgroundWorker1.ReportProgress(i, dtParticulars);
            }

            e.Result = dtParticulars;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;

            DataTable dt = (DataTable)e.UserState;
            toolStripStatusLabel2.Text = $"Fetching  : {e.ProgressPercentage}%";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("An error occurred: " + e.Error.Message);
            }
            else
            {
                dgvParticulars.DataSource = e.Result as DataTable;
                progressBar1.Value = 100;
                toolStripStatusLabel2.Text = $"Records : {((DataTable)e.Result).Rows.Count.ToString()}";
                HelperLoadRecords.ParticularsDataGridView(dgvParticulars);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ucParticulars1.ValidateChildren())
            {
                string particularName = ucParticulars.textBox1.Text;
                string particularDescription = ucParticulars.textBox2.Text;

                var particularModel = new ParticularsModel
                {
                    Name = particularName,
                    Description = particularDescription,
                };

                bool successSave = Factory.ParticularsRepository().Insert(particularModel);


                if (!successSave)
                {
                    Helper.MessageBoxError("Failed to save particular.");
                    return;
                }

                Helper.MessageBoxSuccess("Particular saved successfully.");
                ucParticulars.textBox1.Clear();
                ucParticulars.textBox2.Clear();

                LoadParticulars();
            }
            else
                Helper.MessageBoxError(ucParticulars.GetFormErrors());
        }

        private void dgvParticulars_SelectionChanged(object sender, EventArgs e)
        {
            int recordsCount = dgvParticulars.SelectedRows.Count;   
            if (recordsCount != 0)
                btnDelete.Text = $"DELETE ({recordsCount})";    

          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirmDelete(dgvParticulars.SelectedRows.Count))
            {
                var particularModels = new List<ParticularsModel>();

                foreach (DataGridViewRow row in dgvParticulars.SelectedRows)
                {
                    int id = Convert.ToInt32(row.Cells["id"].Value);
                    particularModels.Add(new ParticularsModel { Id = id });
                }

                bool isDeleted = Factory.ParticularsRepository().Delete(particularModels);

                if (isDeleted)
                {
                    Helper.MessageBoxSuccess("Particular(s) has been deleted.");
                    LoadParticulars();
                    return;
                }
            }

            return;
        }

        private void dgvParticulars_DoubleClick(object sender, EventArgs e)
        {
            int id = dgvParticulars.SelectedRows[0].Index;
            string particularName = dgvParticulars.Rows[id].Cells["name"].Value.ToString();
            string particularDescription = dgvParticulars.Rows[id].Cells["description"].Value.ToString();



        }
    }
}
