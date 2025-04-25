using AccountingSystem;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Math.EC.Multiplier;
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

namespace JOMonitoringApp.Views.Dashboard
{
    public partial class ucDashboardSummaryView : UserControl
    {
        public ucDashboardSummaryView()
        {
            if (!DesignMode)
            {
                InitializeComponent();
                Helper.DatagridFullRowSelectStyle(dgStatPerParticular, true);
                Helper.DatagridFullRowSelectStyle(dataGridView1, true);
            }
        }

        internal void LoadAndDisplaySummary()
        {
            DateTime dateFrom = dtpFrom.Value;
            DateTime dateTo = dtpTo.Value;  

            int pending = Factory.JobOrdersRepository().GetSummaryByStatusId(dateFrom, dateTo, 1);
            int processing = Factory.JobOrdersRepository().GetSummaryByStatusId(dateFrom, dateTo, 2);
            int cancelled = Factory.JobOrdersRepository().GetSummaryByStatusId(dateFrom, dateTo, 3);
            int accomplished = Factory.JobOrdersRepository().GetSummaryByStatusId(dateFrom, dateTo, 4);

            int total = pending + processing + cancelled + accomplished;
            float percentage = 0;

            if (total > 0)
                percentage = ((float)accomplished / total) * 100;

            this.Invoke((MethodInvoker)delegate {
                txtTotal.Text = total.ToString();
                txtPending.Text = pending.ToString();
                txtOnGoing.Text = processing.ToString();
                txtCancelled.Text = cancelled.ToString();
                txtAccomplished.Text = accomplished.ToString();
                lblPercentage.Text = percentage.ToString("0.00") + "%";
            });


        }

    
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void UcDashboardSummaryView_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtpTo.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                
            }
        }

        private DataColumn[] JobOrdersColumns()
        {
            return new DataColumn[]
            {
                new DataColumn("particular", typeof (string)),
                new DataColumn("pending", typeof(int)),
                new DataColumn("cancelled", typeof(int)),
                new DataColumn("processing", typeof(int)),
                new DataColumn("accomplished", typeof(int)),
                new DataColumn("total_count", typeof(int)),
            };
        }


        #region Job Order Phrase Summary
        private DataColumn[] JobOrderPhaseColumns()
        {
            return new DataColumn[]
            {
                new DataColumn("id", typeof (int)),
                new DataColumn("job_order_no", typeof(string)),
                new DataColumn("particular", typeof(string)),
                new DataColumn("created_at", typeof(DateTime)),
                new DataColumn("created_by", typeof(string)),
            };
        }

        private void btnCountPending_Click(object sender, EventArgs e)
        {
            string status = cmbxStatus.SelectedText;
            int countDetails = Convert.ToInt32(cmbxCount.SelectedValue);
            string period = cmbxPeriod.SelectedText;

            int daysMultiplier = 1;
            switch (period)
            {
                case "Day/s":
                    daysMultiplier = countDetails;
                    break;
                case "Week/s":
                    daysMultiplier = countDetails * 7;
                    break;
                case "Months":
                    daysMultiplier = countDetails * 30;
                    break;
                case "Year/s":
                    daysMultiplier = countDetails * 365;
                    break;
            }
            
            
            LoadJOPhase(daysMultiplier);
        }

        private void LoadJOPhase(int daysMultiplier)
        {
            string status = cmbxStatus.Text;
            string period = cmbxPeriod.SelectedText;
            string number = cmbxCount.SelectedText;

          
            DataTable dtPhase = Factory.JobOrdersRepository().JOPhasePerPeriod(status, daysMultiplier);

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(JobOrderPhaseColumns());

            foreach (DataRow row in dtPhase.Rows)
            {

                var newRow = dataTable.NewRow();

                int id = Convert.ToInt32(row["id"]);
                string jobNumber = row["job_order_no"].ToString() ;
                string particular = row["particular"].ToString();
                DateTime dateCreated = Convert.ToDateTime(row["created_at"]);
                string createdBy = row["prepared_by"].ToString();

                newRow["id"] = id;
                newRow["job_order_no"] = jobNumber;
                newRow["particular"] = particular;
                newRow["created_at"] = dateCreated;
                newRow["created_by"] = createdBy;
                dataTable.Rows.Add(newRow);
            }


            HelperLoadRecords.JOStatusPhase(dataGridView1, dataTable);
            lblRecentMovement.Text = $"{cmbxStatus.Text} J.O FOR THE LAST {cmbxCount.Text} {cmbxPeriod.Text} : {dataTable.Rows.Count}";
        }
        

        #endregion




        private void btnSearch_Click(object sender, EventArgs e)
        {
  
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadAndDisplaySummary();

            DateTime dateFrom = dtpFrom.Value;
            DateTime dateTo = dtpTo.Value;

            //STATUS PER PARTICULAR
            var dtStatusPerParticular = Factory.JobOrdersRepository().JOStatusPerParticular(dateFrom, dateTo);

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(JobOrdersColumns());

            foreach (DataRow row in dtStatusPerParticular.Rows)
            {

                var newRow = dataTable.NewRow();
                string particular = row["particular"].ToString();
                int total = Convert.ToInt32(row["total_count"]);
                int pending = Convert.ToInt32(row["pending"]);
                int processing = Convert.ToInt32(row["processing"]);
                int cancelled = Convert.ToInt32(row["cancelled"]);
                int accomplished = Convert.ToInt32(row["accomplished"]);

                newRow["particular"] = particular;
                newRow["pending"] = pending;
                newRow["processing"] = processing;
                newRow["cancelled"] = cancelled;
                newRow["accomplished"] = accomplished;
                newRow["total_count"] = total;
                dataTable.Rows.Add(newRow);

            }

            (sender as BackgroundWorker).ReportProgress(100); // Done

            e.Result = dtStatusPerParticular;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataTable result = e.Result as DataTable;
            dgStatPerParticular.DataSource = result;

            progressBar1.Value = 100;

            HelperLoadRecords.JOStatusPerParticular(dgStatPerParticular, result);
        }


    }
}
