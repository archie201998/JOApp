using AccountingSystem;
using Org.BouncyCastle.Security;
using System;
using System.Data;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.JobOrder
{
    public partial class frmJOProgressTracking : Form
    {
        string _joNumber;

        public frmJOProgressTracking(string jobOrderNumber)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgJobOrderStatusDetails);
            _joNumber = jobOrderNumber;
        }

        private void frmJOProgressTracking_Load(object sender, EventArgs e)
        {
            txtJONumber.Focus();
            txtJONumber.Text = _joNumber;

            if (!string.IsNullOrEmpty(_joNumber))
                ViewProgress();
        }

        private DataColumn[] JobOrdersColumns()
        {
            return new DataColumn[]
            {
                new DataColumn("log_id", typeof (int)),
                new DataColumn("date_and_time", typeof(string)),
                new DataColumn("transaction_event", typeof(string))
            };
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            ViewProgress();
        }

        private void ViewProgress()
        {
            try
            {
                _joNumber = txtJONumber.Text;

                if (string.IsNullOrEmpty(_joNumber))
                {
                    Helper.MessageBoxError("Please enter a job order number.");
                    return;
                }

                var dataTableJobOrderLogs = Factory.JOLogsRepository().GetRecordsByJONumber(Convert.ToInt32(_joNumber));
                var dataTable = new DataTable();
                dataTable.Columns.AddRange(JobOrdersColumns());

                foreach (DataRow row in dataTableJobOrderLogs.Rows)
                {
                    var newRow = dataTable.NewRow();
                    int id = Convert.ToInt32(row["log_id"]);
                    int joNumberId = Convert.ToInt32(row["job_orders_id"]);
                    string user = row["user_name"].ToString();

                    string dateAndTime = row["date_and_time"].ToString();
                    string transactionEvent = row["transaction_event"].ToString();
                    int joNumber = Convert.ToInt32(row["job_order_no"]);
                    DateTime joDate = Convert.ToDateTime(row["date"]);
                    string transEvent = $"J.O NUMBER. {joNumber} {transactionEvent} BY {user}";

                    newRow["log_id"] = id;
                    newRow["date_and_time"] = dateAndTime;
                    newRow["transaction_event"] = transEvent.ToUpper();

                    dataTable.Rows.Add(newRow);
                }

                HelperLoadRecords.JobOrderTrackingDataGrid(dgJobOrderStatusDetails, dataTable);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError("Something went wrong. Please contact your system administrator." + ex.Message);            }
            }
    }
}
