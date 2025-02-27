using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
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
            }
        }

        internal void LoadJobOrdersSummary()
        {
            int pending = Factory.JobOrdersRepository().GetSummaryByStatusId(1);
            int onGoing = Factory.JobOrdersRepository().GetSummaryByStatusId(2);
            int cancelled = Factory.JobOrdersRepository().GetSummaryByStatusId(3);
            int accomplished = Factory.JobOrdersRepository().GetSummaryByStatusId(4);

            txtPending.Text = pending.ToString();
            txtOnGoing.Text = onGoing.ToString();
            txtCancelled.Text = cancelled.ToString();
            txtAccomplished.Text = accomplished.ToString();
        }

        private void UcDashboardSummaryView_Load(object sender, EventArgs e)
        {
           
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
