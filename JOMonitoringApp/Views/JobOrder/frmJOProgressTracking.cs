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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JOMonitoringApp.Views.JobOrder
{
    public partial class frmJOProgressTracking: Form
    {
        string _joNumber;
        public frmJOProgressTracking()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgJobOrderStatusDetails, true, true);
        }

        private void frmJOProgressTracking_Load(object sender, EventArgs e)
        {
            txtJONumber.Focus();
        }

        private void txtJONumber_TextChanged(object sender, EventArgs e)
        {
            
        }

        private DataColumn[] JobOrdersColumns()
        {
            return new DataColumn[]
            {
                new DataColumn("log_id", typeof (int)),
                new DataColumn("date_and_time", typeof(DateTime)),
                new DataColumn("transaction_event", typeof(string))
            };
        }


        private void btnSearch_Click(object sender, EventArgs e)
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

                DateTime dateAndTime = Convert.ToDateTime(row["date_and_time"]);
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
    }
}
