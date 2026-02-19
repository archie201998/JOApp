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

namespace JOMonitoringApp.Views.JobOrder.HydrantWithdrawal
{
    public partial class frmHydrantWithdrawalForm : Form
    {
        private string _jobOrder;
        private bool _isUpdate;

        public frmHydrantWithdrawalForm(string jobOrder, bool isUpdate)
        {
            InitializeComponent();
            _jobOrder = jobOrder;
            _isUpdate = isUpdate;
        }

        private void txtORNumber_TextChanged(object sender, EventArgs e)
        {
            //string ornumber = txtORNumber.Text;

            //if (ornumber.Length > 4) { 
            //    var otherPaymentDetails = Factory.CustomersRepository().GetOtherPaymentDetails(ornumber);

            //    if (otherPaymentDetails != null)
            //    {
            //        nudAmount.Value = Convert.ToDecimal(otherPaymentDetails["TotalAmount"]);
            //        txtCashier.Text = otherPaymentDetails["eUser"].ToString();
            //        dtpDate.Text = otherPaymentDetails["PaymentDate"].ToString();
            //    }
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string jobOrderNumber = _jobOrder;  
            string previousReading = txtPreviousReading.Text;
            string afterReading = txtCurrentReading.Text;
            string requestedBy = txtRequestedBy.Text;   
            string orNumber = txtORNumber.Text; 
            string cashier = txtCashier.Text;
            string date = dtpDate.Text;
            string amount = nudAmount.Value.ToString(); 
            string totalVolume = txtTotalVolume.Text;
            bool transactionSucceed = false;

            if (!_isUpdate) //save
            {
                transactionSucceed = Factory.CustomersRepository().InsertHydrantData(jobOrderNumber, previousReading, afterReading, requestedBy, orNumber, cashier, date, amount, totalVolume);
            }
            else
            {
                //transactionSucceed = Factory.CustomersRepository().InsertHydrantData(previousReading, afterReading, orNumber, cashier, date, amount, totalVolume);
            }

            if (transactionSucceed)
            {
                Helper.MessageBoxSuccess("Hydrant Withdrawal data has been saved successfully.");   
            }

            this.Close();
        }

        private void frmHydrantWithdrawalForm_Load(object sender, EventArgs e)
        {
            if (_isUpdate)
            {
                LoadHydrantWithdrawalData();
            }
        }

        private void LoadHydrantWithdrawalData()
        {
            string jobOrderNumber = _jobOrder;  
            Dictionary<string, string> hwData = Factory.CustomersRepository().GetHydrantWithdrawalData(jobOrderNumber);

            if (hwData != null)
            {

                txtCurrentReading.Text = hwData["previous_reading"];
                txtPreviousReading.Text = hwData["current_reading"];
                txtRequestedBy.Text = hwData["requested_by"];
                txtORNumber.Text = hwData["or_number"];
                txtCashier.Text = hwData["cashier"];
                dtpDate.Text = hwData["date"];
                nudAmount.Value = Convert.ToDecimal(hwData["amount"]);
                txtTotalVolume.Text = hwData["total_volume"];

            }
        }
    }
}
