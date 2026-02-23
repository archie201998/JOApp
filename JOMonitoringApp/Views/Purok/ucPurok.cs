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

namespace JOMonitoringApp.Views.Purok
{
    public partial class ucPurok : UserControl
    {
        public ucPurok()
        {
            InitializeComponent();
        }

        private void ucPurok_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                HelperLoadRecords.BarangayCombobox(cmbxBarangay);
            }
        }
    }
}
