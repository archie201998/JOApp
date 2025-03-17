using AccountingSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.JobOrder
{
    public partial class frmJOProgressTracking: Form
    {
        public frmJOProgressTracking()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DataGrivBlankStyle(dgJobOrderStatusDetails);
        }

        private void frmJOProgressTracking_Load(object sender, EventArgs e)
        {

        }

        private void txtJONumber_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
