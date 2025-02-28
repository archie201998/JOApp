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
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Job order is successfully created.");
                _frmMain.OnLoad();
                this.Close();
            }
            try
            {
                
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

            //Run this code if new application
            bool isApplicaitonJO = ucJoborder.cbxNewApplication.Checked;
            if (isApplicaitonJO)
            {
                if (SaveNewCustomer())
                {
                    return Factory.JobOrdersRepository().Insert(ucJoborder.JobOrderModel());
                }
            }
            //Run this code if new application

            return Factory.JobOrdersRepository().Insert(ucJoborder.JobOrderModel());
        }


        private bool SaveNewCustomer()
        {
            var customerModel = new CustomersModel() {
                AccountName = ucJoborder.cmbxCustomers.Text,
                Address = ucJoborder.txtAddress.Text,
                CreatedBy = Helper.UserId
            };

            return Factory.CustomersRepository().Insert(customerModel);
        }

        internal CustomersModel CustomersModel()
        {
            string accountNumber = ucJoborder.txtAccountNumber.Text.Trim();
            string accountName = ucJoborder.cmbxCustomers.Text.Trim();
            string accountAddress = ucJoborder.txtAddress.Text.Trim();

            return new CustomersModel()
            {
                AccountNumber = accountNumber,
                AccountName = accountName,
                Address = accountAddress,
            };

        }

        private void FrmAddJobOrders_Load(object sender, EventArgs e)
        {

        }
    }
}
