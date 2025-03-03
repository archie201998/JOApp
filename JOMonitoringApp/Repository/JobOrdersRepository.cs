using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
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
            var recordDictionary = new Dictionary<string, string>();
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE id = @id";

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
                new object[] { "@month", DbType.Int16, monthId },
                new object[] { "@year", DbType.Int16, year },
            };

            string query = $"SELECT COUNT(status_id) FROM {viewTableName} WHERE YEAR(date) = @year AND MONTH(date) = @month AND status_id = @status_id AND is_deleted = 0";

            if (string.IsNullOrWhiteSpace(mySqlGenericCommands.ExecuteScalar(query, parameters)))
                return 0;
            else
                return int.Parse(mySqlGenericCommands.ExecuteScalar(query, parameters));
        }

        public DataTable GetViewRecords()
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetViewRecordsByMonth()
        {
            var parameters = new object[][]
            {
                new object[] { "@month", DbType.String, string.Empty }
            };

            string query = $"SELECT * FROM {viewTableName} ";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetViewRecordsByParameters(string searchText, int rowFilter, int statusId)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%" },
                new object[] { "@status_id", DbType.Int32, statusId},
                new object[] { "@row_filter", DbType.Int32, rowFilter},
            };

            string statusFilter = statusId == 5 ? string.Empty : $"AND status_id = {statusId}";

            string query = $"SELECT * FROM {viewTableName} WHERE (job_order_no LIKE @search_text OR account_number LIKE @search_text OR account_name LIKE @search_text) {statusFilter} AND is_deleted = 0 ORDER BY job_order_no  ASC LIMIT @row_filter ";
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
                new object[]{"@status_id", DbType.String, entity.StatusId},
            };

            string query = $"INSERT INTO {tableName} (customers_id, particulars_id, date, job_order_no, or_number, amount, mris, mrs, war, materials_issued_by, prepared_by, status_id) VALUES (@customers_id, @particulars_id, @date, @job_order_no, @or_number, @amount, @mris, @mrs, @war, @materials_issued_by, @prepared_by,  @status_id)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameter);
        }


        public bool SoftDeleteJOById(int jobOrderId, int deletedBy)
        {
            var parameters = new object[][]
            {
                new object[] { "@job_order_id", DbType.Int32, jobOrderId},
                new object[] { "@deleted_by", DbType.Int32, deletedBy},
            };

            string query = $"UPDATE {tableName} SET is_deleted = 1,  deleted_by = @deleted_by WHERE id = @job_order_id";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool SoftDeleteJOById(List<JobOrdersModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][]
                     {
                        new object[] { "@job_order_id", DbType.Int32, entity.ID},
                        new object[] { "@deleted_by", DbType.Int32, entity.DeletedBy},
                     };

                    string query = $"UPDATE {tableName} SET is_deleted = 1,  deleted_by = @deleted_by WHERE id = @job_order_id";
                    _ = mySqlGenericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public bool Update(JobOrdersModel entity)
        {
            var parameter = new object[][] {
                new object[]{"@id", DbType.Int32, entity.ID},
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
                new object[]{"@status_id", DbType.String, entity.StatusId},
            };

            string query = $"UPDATE {tableName} SET customers_id=@customers_id, particulars_id=@particulars_id, date=@date, job_order_no=@job_order_no, or_number=@or_number, amount=@amount, mris=@mris,  mrs=@mrs, war=@war, materials_issued_by=@materials_issued_by,  prepared_by=@prepared_by,  status_id=@status_id WHERE id = @id";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameter);
        }

        public bool UpdateStatus(int jobOrderId, int statusId)
        {
            var parameters = new object[][]
            {
                new object[] { "@job_order_id", DbType.Int32, jobOrderId},
                new object[] { "@status_id", DbType.Int32, statusId},
            };

            string query = $"UPDATE {tableName} SET status_id = @status_id WHERE id = @job_order_id";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}