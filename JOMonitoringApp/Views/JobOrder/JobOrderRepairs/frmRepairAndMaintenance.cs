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

namespace JOMonitoringApp.Views.JobOrder.JobOrderRepairs
{
    public partial class frmRepairAndMaintenance : Form
    {
        private ucJobOrderRepairs ucJoborder;

        public frmRepairAndMaintenance()
        {
            InitializeComponent();
            ucJoborder = ucJobOrderRepairs1;
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(ucJoborder.dgJobOrderRepairAndMaintenanceList);
        }

        private void frmRepairAndMaintenance_Load(object sender, EventArgs e)
        {

        }

        private void ucJobOrderRepairs1_Load(object sender, EventArgs e)
        {
            
        }

    

    }
}
