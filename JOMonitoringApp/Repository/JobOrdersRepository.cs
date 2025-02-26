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

        public DataTable GetViewRecords()
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetViewRecordsByParameters(string searchText, bool showInactiveTaxpayers, int rowFilter)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%" },
                new object[] { "@row_filter", DbType.Int32, rowFilter}
            };

            //string subQuery = showInactiveTaxpayers ? string.Empty : "is_active = 1 AND";

            //string query = $"SELECT * FROM {viewTableName} WHERE {subQuery} (account_number LIKE @search_text OR or_number LIKE @search_text OR date LIKE @search_text) ORDER BY date ASC LIMIT @row_filter";
            string query = $"SELECT id, date, account_number, customers_id, account_name, address, particulars_id, particular, or_number, amount, prepared_by_id, prepared_by FROM {viewTableName} WHERE account_number LIKE @search_text OR account_name LIKE @search_text OR date LIKE @search_text ORDER BY id ASC LIMIT @row_filter";
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
                new object[]{"@employee_id", DbType.Int32, entity.EmployeeId},
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