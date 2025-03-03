using AccountingSystem;
using JOMonitoringApp.Model;
using JOMonitoringApp.Views.MainForm;
using JOMonitoringApp.Views.MessageBox;
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
    public partial class frmAddJobOrders : Form
    {
        internal readonly ucJoborder ucJoborder;
        internal frmMain _frmMain;

        public frmAddJobOrders(frmMain frmMain)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            ucJoborder = ucJoborder2;
            _frmMain = frmMain;
            ucJoborder.OnLoad();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
      
        }



        private void FrmAddJobOrders_Load(object sender, EventArgs e)
        {

        }
    }
}
