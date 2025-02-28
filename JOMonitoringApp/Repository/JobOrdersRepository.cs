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

        public int GetSummaryByStatusId(int year, int monthId, int statusId)
        {
            var parameters = new object[][]
            {
                new object[] { "@status_id", DbType.String, statusId },
                new object[] { "@month", DbType.Int16, year },
                new object[] { "@year", DbType.Int16, monthId },
            };

            string query = $"SELECT COUNT(status_id) FROM {viewTableName} WHERE (YEAR(date) = @year OR MONTH(date) = @month) AND status_id = @status_id";

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
                new object[]{"@job_order_no", DbType.String, entity.JONUmber},
                new object[]{"@or_number", DbType.String, entity.ORNumber},
                new object[]{"@amount", DbType.Decimal, entity.Amount},
                new object[]{"@mris", DbType.String, entity.MRIS},
                new object[]{"@mrs", DbType.String, entity.MRS},
                new object[]{"@war", DbType.String, entity.WAR},
                new object[]{"@prepared_by", DbType.String, entity.PreparedBy},
                new object[]{"@materials_issued_by", DbType.String, entity.MaterialsIssuedBy},
                new object[]{"@materials_returned_to", DbType.String, entity.MaterialsReturnedTo},
                new object[]{"@employee_id", DbType.String, entity.AssignedWorkEmployeeId},
                new object[]{"@status_id", DbType.String, entity.StatusId},
            };

            string query = $"INSERT INTO {tableName} (customers_id, particulars_id, date, job_order_no, or_number, amount, mris, mrs, war, prepared_by, materials_issued_by, materials_returned_to, employee_id, status_id) VALUES (@customers_id, @particulars_id, @date, @job_order_no, @or_number, @amount, @mris, @mrs, @war, @prepared_by, @materials_issued_by, @materials_returned_to, @employee_id, @status_id)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameter);
        }

        public bool Update(JobOrdersModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}