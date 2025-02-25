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
    public partial class frmAddJobOrders : Form
    {
        internal readonly ucJoborder ucJoborder;

        public frmAddJobOrders()
        {
            InitializeComponent();
            ucJoborder = ucJoborder1;
            ucJoborder.OnLoad();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Job order has been created");
                    this.Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

    }
}
