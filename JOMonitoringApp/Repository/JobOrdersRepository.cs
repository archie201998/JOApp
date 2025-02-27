using System.Collections.Generic;
using System.Data;
using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;

namespace JOMonitoringApp
{
    internal class JobOrdersRepository : IJobOrdersRepository
    {
        private GenericCommands mySqlGenericCommands;
        private string tableName = "tbl_job_orders";
        private string viewTableName = "view_job_orders";

        public JobOrdersRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<JobOrdersModel> entityList)
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

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public int GetSummaryByStatusId(int statusId)
        {
            var parameters = new object[][] { new object[] { "@status_id", DbType.Int32, statusId } };

            string query = $"SELECT COUNT(status_id) FROM {viewTableName} WHERE status_id = @status_id";

            if (string.IsNullOrWhiteSpace(mySqlGenericCommands.ExecuteScalar(query, parameters)))
                return 0;
            else
                return int.Parse(mySqlGenericCommands.ExecuteScalar(query, parameters));
        }

        public DataTable GetViewRecords()
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetViewRecordsByParameters(string searchText, int rowFilter, int statusId)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%" },
                new object[] { "@status_id", DbType.Int32, statusId},
                new object[] { "@row_filter", DbType.Int32, rowFilter},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE (job_order_no LIKE @search_text OR account_number LIKE @search_text OR account_name LIKE @search_text) AND status_id = @status_id ORDER BY job_order_no ASC LIMIT @row_filter";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetViewRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(JobOrdersModel entity)
        {
            var parameter = new object[][] {
                new object[]{"@customers_id", DbType.Int32, entity.CustomerID},
                new object[]{"@particulars_id", DbType.Int32, entity.ParticularID},
                new object[]{"@date", DbType.DateTime, entity.Date},
                new object[]{"@or_number", DbType.String, entity.ORNumber},
                new object[]{"@amount", DbType.Decimal, entity.Amount},
                new object[]{"@employee_id", DbType.Int32, entity.PreparedBy},
                new object[]{"@prepared_by", DbType.Int32, entity.UserId}
            };

            string query = $"INSERT INTO {tableName} (customers_id, particulars_id, date, or_number, amount, employee_id, prepared_by) VALUES (@customers_id, @particulars_id, @date, @or_number, @amount, @employee_id, @prepared_by)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameter);
        }

        public bool Update(JobOrdersModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}