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

namespace JOMonitoringApp.Views.Customers
{
    public partial class frmCustomerLedger : Form
    {
        public frmCustomerLedger()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }
    }
}
