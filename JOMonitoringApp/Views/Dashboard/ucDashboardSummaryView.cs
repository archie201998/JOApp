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
            LoadAndDisplaySummary(Convert.ToInt32(nudYear.Value), Convert.ToInt32(cmbxMonth.SelectedIndex));
        }

        private void UcDashboardSummaryView_Load(object sender, EventArgs e)
        {
            LoadMonths();
        }

        private void LoadAndDisplaySummary(int year, int monthId)
        {
            int pending = Factory.JobOrdersRepository().GetSummaryByStatusId(year, monthId, 1);
            int onGoing = Factory.JobOrdersRepository().GetSummaryByStatusId(year, monthId, 2);
            int cancelled = Factory.JobOrdersRepository().GetSummaryByStatusId(year, monthId, 3);
            int accomplished = Factory.JobOrdersRepository().GetSummaryByStatusId(year, monthId, 4);

            txtPending.Text = pending.ToString();
            txtOnGoing.Text = onGoing.ToString();
            txtCancelled.Text = cancelled.ToString();
            txtAccomplished.Text = accomplished.ToString();
        }

        private void LoadMonths()
        {
            foreach (var item in Helper.MonthsDatasource().Values)
                cmbxMonth.Items.Add(item);
            cmbxMonth.SelectedIndex = DateTime.Now.Month;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CmbxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAndDisplaySummary(Convert.ToInt32(nudYear.Value), Convert.ToInt32(cmbxMonth.SelectedValue));
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            LoadAndDisplaySummary(Convert.ToInt32(nudYear.Value), Convert.ToInt32(cmbxMonth.SelectedIndex));
        }

    }
}
