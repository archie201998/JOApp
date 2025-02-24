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
            string query = $"SELECT * FROM {viewTableName} WHERE account_number LIKE @search_text OR account_name LIKE @search_text OR date LIKE @search_text ORDER BY date ASC LIMIT @row_filter";
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
            throw new System.NotImplementedException();
        }

        public bool Update(JobOrdersModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}