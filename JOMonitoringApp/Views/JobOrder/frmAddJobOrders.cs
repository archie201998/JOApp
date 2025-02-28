using AccountingSystem;
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
            try
            {
                if (SaveData())
                {
                    _ = new ConfirmMessageBox("Job order is successfully created.").ShowDialog();
                    _frmMain.OnLoad();
                    this.Close();
                }
            }
            catch (Exception ex) { _ = new ConfirmMessageBox(ex.Message).ShowDialog(); }
        }



        private bool SaveData()
        {
            if (!ucJoborder.ValidateChildren())
            {
                Helper.MessageBoxError(ucJoborder.GetFormErrors());
                return false;
            }

            return Factory.JobOrdersRepository().Insert(ucJoborder.JobOrderModel());
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
