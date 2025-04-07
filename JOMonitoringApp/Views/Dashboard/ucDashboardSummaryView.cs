using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountingSystem;

namespace JOMonitoringApp.Views.Dashboard
{
    public partial class ucDashboardSummaryView : UserControl
    {
        public ucDashboardSummaryView()
        {
            if (!DesignMode)
            {
                InitializeComponent();
                Helper.DatagridFullRowSelectStyle(dgStatPerParticular);
            }
        }

        internal void LoadJobOrdersSummary()
        {
            LoadMonths();
            LoadAndDisplaySummary(Convert.ToInt32(nudYear.Value), Convert.ToInt32(cmbxMonth.SelectedIndex));
        }

        internal void LoadAndDisplaySummary(int year, int monthId)
        {
            int pending = Factory.JobOrdersRepository().GetSummaryByStatusId(year, monthId + 1, 1);
            int processing = Factory.JobOrdersRepository().GetSummaryByStatusId(year, monthId + 1, 2);
            int cancelled = Factory.JobOrdersRepository().GetSummaryByStatusId(year, monthId + 1, 3);
            int accomplished = Factory.JobOrdersRepository().GetSummaryByStatusId(year, monthId + 1, 4);
            int total = pending + processing + cancelled + accomplished;
            float percentage = (((float)accomplished) / ((float)total) * 100);
            percentage = float.IsNaN(percentage) ? 0 : percentage;

            txtTotal.Text = total.ToString();
            txtPending.Text = pending.ToString();
            txtOnGoing.Text = processing.ToString();
            txtCancelled.Text = cancelled.ToString();
            txtAccomplished.Text = accomplished.ToString();
            lblPercentage.Text = percentage.ToString() + "%";
        }

        private void LoadMonths()
        {
            cmbxMonth.Items.Clear();
            foreach (var item in Helper.MonthsDatasource().Values)
                cmbxMonth.Items.Add(item);
            cmbxMonth.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CmbxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAndDisplaySummary(Convert.ToInt32(nudYear.Value), Convert.ToInt32(cmbxMonth.SelectedIndex));
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            LoadAndDisplaySummary(Convert.ToInt32(nudYear.Value), Convert.ToInt32(cmbxMonth.SelectedIndex));
        }

        private void UcDashboardSummaryView_Load(object sender, EventArgs e)
        {
            LoadStatusPerParticular();
        }

        private DataColumn[] JobOrdersColumns()
        {
            return new DataColumn[]
            {
                new DataColumn("particular", typeof (string)),
                new DataColumn("total_count", typeof(int)),
                new DataColumn("pending", typeof(int)),
                new DataColumn("cancelled", typeof(int)),
                new DataColumn("processing", typeof(int)),
                new DataColumn("accomplished", typeof(int)),
            };
        }


        private void LoadStatusPerParticular()
        {
            var dtStatusPerParticular = Factory.JobOrdersRepository().JOStatusPerParticular();

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
                newRow["total_count"] = total;
                newRow["pending"] = pending;
                newRow["processing"] = processing;
                newRow["cancelled"] = cancelled;
                newRow["accomplished"] = accomplished;
                dataTable.Rows.Add(newRow);

            }
            HelperLoadRecords.JOStatusPerParticular(dgStatPerParticular, dataTable);
        }
    }
}
