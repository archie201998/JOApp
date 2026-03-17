using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;
using MySqlX.XDevAPI.Relational;
using System.Collections.Generic;
using System.Data;

namespace JOMonitoringApp
{
    internal class JobOrdersLogsRepository : IJOLogsRepository
    {

        private GenericCommands mySqlGenericCommands;
        private readonly string tableName = "tbl_job_orders_logs";
        private readonly string viewTableName = "view_job_orders_logs";

        public JobOrdersLogsRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<JOLogsModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecordsByJONumber(int JONumber)
        {
            var parameters = new object[][]
            {
                new object[] { "@job_order_no", DbType.Int32, JONumber }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE job_order_no = @job_order_no ORDER BY log_id";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(JOLogsModel entity)
        {
            var parameter = new object[][] {
                new object[]{"@transaction_event", DbType.String, entity.TransactionEvent},
                new object[]{"@users_id", DbType.Int32, entity.UserId},
                new object[]{"@job_orders_id", DbType.Int32, entity.JobOrderId},
                new object[]{"@date_and_time", DbType.DateTime2, entity.DateAndTime},
            };

            string query = $"INSERT INTO {tableName} (transaction_event,  users_id, job_orders_id, date_and_time) VALUES (@transaction_event,  @users_id, @job_orders_id, @date_and_time)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameter);
        }

        public bool Update(JOLogsModel entity)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetLogsByJONumber(int JONumber)
        {
            var recordDictionary = new Dictionary<string, string>();
            var parameters = new object[][]
            {
                new object[] { "@job_order_no", DbType.Int32, JONumber }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE job_order_no = @job_order_no";

            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public bool RecordLog(string v)
        {
            throw new System.NotImplementedException();
        }
    }
}