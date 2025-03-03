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

            txtPending.Text = pending.ToString();
            txtOnGoing.Text = processing.ToString();
            txtCancelled.Text = cancelled.ToString();
            txtAccomplished.Text = accomplished.ToString();
        }

        private void LoadMonths()
        {
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
          
        }
    }
}
