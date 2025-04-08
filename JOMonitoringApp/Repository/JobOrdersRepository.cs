using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JOMonitoringApp
{
    internal class JobOrdersRepository : IJobOrdersRepository
    {
        private GenericCommands mySqlGenericCommands;
        private readonly string tableName = "tbl_job_orders";
        private readonly string viewTableName = "view_job_orders";

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
            string query = $"SELECT * FROM {tableName} WHERE is_deleted = 0";
            var dataTable = new DataTable();
            return mySqlGenericCommands.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public int GetSummaryByStatusId(DateTime dateFrom, DateTime dateTo, int statusId)
        {
            var parameters = new object[][]
            {
                new object[] { "@date_from", DbType.DateTime, dateFrom },
                new object[] { "@date_to", DbType.DateTime, dateTo },
                new object[] { "@status_id", DbType.String, statusId },
            };

            string query = $"SELECT COUNT(status_id) FROM {viewTableName} WHERE date BETWEEN @date_from AND @date_to AND status_id = @status_id AND is_deleted = 0";

            if (string.IsNullOrWhiteSpace(mySqlGenericCommands.ExecuteScalar(query, parameters)))
                return 0;
            else
                return int.Parse(mySqlGenericCommands.ExecuteScalar(query, parameters));
        }

        public DataTable GetViewRecords()
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetViewRecordsByJONumber(int monthIndex)
        {
            var parameters = new object[][]
            {
                new object[] { "@job_order_no", DbType.Int32, monthIndex }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE job_order_no = @job_order_no AND is_deleted = 0 LIMIT 1";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetViewRecordsByMonth(int monthIndex)
        {
            var parameters = new object[][]
            {
                new object[] { "@month_index", DbType.Int32, monthIndex }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE MONTH(date) = @month_index AND is_deleted = 0 ORDER BY job_order_no DESC";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetViewRecordsByParameters(string searchText, int rowFilter, int statusId, string particular)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%" },
                new object[] { "@status_id", DbType.Int32, statusId},
                new object[] { "@row_filter", DbType.Int32, rowFilter},
                new object[] { "@particular", DbType.String, $"%{particular}%"},
            };

            string statusFilter = statusId == 5 ? string.Empty : $"AND status_id = {statusId}";
            string particularFilter = particular == "All" ? string.Empty : $"AND particular LIKE @particular";

            string query = $"SELECT * FROM {viewTableName} WHERE (job_order_no LIKE @search_text OR account_number LIKE @search_text OR account_name LIKE @search_text) {statusFilter} AND is_deleted = 0 {particularFilter} ORDER BY id DESC LIMIT @row_filter ";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetViewRecordsBySearch(DateTime dateFrom, DateTime dateTo, string particulars, string status, string orderBy)
        {

            if (particulars == "All") particulars = "%%";

            var parameters = new object[][]
            {
                new object[] { "@date_from", DbType.DateTime, dateFrom },
                new object[] { "@date_to", DbType.DateTime, dateTo },
                new object[] { "@particular", DbType.String, $"%{particulars}%" },
            };


            string query = $"SELECT * FROM {viewTableName} WHERE ({status}) AND particular LIKE @particular AND date BETWEEN @date_from AND @date_to AND is_deleted = 0  ORDER BY {orderBy} DESC";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(JobOrdersModel entity)
        {
            var parameter = new object[][] {

                new object[]{"@account_name", DbType.String, entity.AccountName},
                new object[]{"@account_number", DbType.String, entity.AccountNumber},
                new object[]{"@address", DbType.String, entity.Address},
                new object[]{"@contact_number", DbType.String, entity.ContactNumber},
                new object[]{"@date", DbType.DateTime, entity.Date},
                new object[]{"@job_order_no", DbType.String, entity.JONUmber},
                new object[]{"@particular", DbType.String, entity.Particulars},
                new object[]{"@or_number", DbType.String, entity.ORNumber},
                new object[]{"@amount", DbType.Decimal, entity.Amount},
                new object[]{"@mris", DbType.String, entity.MRIS},
                new object[]{"@mrs", DbType.String, entity.MRS},
                new object[]{"@war", DbType.String, entity.WAR},
                new object[]{"@remarks", DbType.String, entity.Remarks},
                new object[]{"@prepared_by", DbType.Int32, entity.PreparedBy},
                new object[]{"@materials_issued_by", DbType.Int32, entity.MaterialsIssuedBy == 0 ? null : entity.MaterialsIssuedBy },
                new object[]{"@accomplished_by", DbType.Int32, entity.AccomplishedBy == 0 ? null : entity.AccomplishedBy },
                new object[]{"@status_id", DbType.Int16, entity.StatusId},
            };

            string query = $"INSERT INTO {tableName} (account_name, account_number, address, contact_number,  particular, date, job_order_no, or_number, amount, mris, mrs, war, remarks, materials_issued_by, prepared_by, accomplished_by, status_id, created_by) VALUES (@account_name, @account_number, @address, @contact_number, @particular, @date, @job_order_no, @or_number, @amount, @mris, @mrs, @war, @remarks, @materials_issued_by, @prepared_by, @accomplished_by, @status_id, @prepared_by)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameter);
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

                    string query = $"1 {tableName} SET is_deleted = 1,  deleted_by = @deleted_by WHERE id = @job_order_id";
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
                new object[]{"@particular", DbType.String, entity.Particulars},
                new object[]{"@account_number", DbType.String, entity.AccountNumber},
                new object[]{"@account_name", DbType.String, entity.AccountName},
                new object[]{"@address", DbType.String, entity.Address},
                new object[]{"@contact_number", DbType.String, entity.ContactNumber},
                new object[]{"@date", DbType.DateTime, entity.Date},
                new object[]{"@job_order_no", DbType.String, entity.JONUmber},
                new object[]{"@or_number", DbType.String, entity.ORNumber},
                new object[]{"@amount", DbType.Decimal, entity.Amount},
                new object[]{"@mris", DbType.String, entity.MRIS},
                new object[]{"@mrs", DbType.String, entity.MRS},
                new object[]{"@war", DbType.String, entity.WAR},
                new object[]{"@remarks", DbType.String, entity.Remarks},
                new object[]{"@prepared_by", DbType.String, entity.PreparedBy},
                new object[]{"@materials_issued_by", DbType.Int32, entity.MaterialsIssuedBy == 0 ? null : entity.MaterialsIssuedBy },
                new object[]{"@accomplished_by", DbType.Int32, entity.AccomplishedBy == 0 ? null : entity.AccomplishedBy },
                new object[]{"@status_id", DbType.Int16, entity.StatusId},
            };

            string query = $"UPDATE {tableName} SET  particular=@particular, account_number = @account_number, account_name = @account_name, contact_number = @contact_number, address = @address, date=@date, job_order_no=@job_order_no, or_number=@or_number, amount=@amount, mris=@mris,  mrs=@mrs, war=@war, remarks=@remarks, materials_issued_by=@materials_issued_by, accomplished_by = @accomplished_by, prepared_by=@prepared_by, status_id=@status_id WHERE id = @id";

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

        Dictionary<string, string> IJobOrdersRepository.GetViewRecordsByJONumber(int joNumber)
        {
            var recordDictionary = new Dictionary<string, string>();
            var parameters = new object[][]
            {
                new object[] { "@jo_number", DbType.Int32, joNumber}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE job_order_no = @jo_number";

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

        public int GetLastInsertedID(int userId)
        {
            var parameters = new object[][]
            {  new object[] { "@user_id", DbType.Int32, userId}, };

            string query = $"SELECT MAX(id) FROM {tableName} WHERE created_by = @user_id";

            return int.Parse(mySqlGenericCommands.ExecuteScalar(query, parameters));
        }

        public bool CheckPossibleDuplicate(string accountNumber, string particulars)
        {
            var parameters = new object[][]
            {
                new object[] { "@account_number", DbType.String, accountNumber },
                new object[] { "@particulars", DbType.String, $"%{particulars}%" }
            };

            string query = $"SELECT COUNT(*) FROM {viewTableName} WHERE account_number = @account_number AND particular LIKE @particulars AND is_deleted = 0";

            int count = int.Parse(mySqlGenericCommands.ExecuteScalar(query, parameters));

            return count > 0;
        }

        public bool JONumberExist(string joNumber)
        {
            var parameters = new object[][]
            {
                new object[] { "@jo_number", DbType.String, joNumber }
            };

            string query = $"SELECT COUNT(*) FROM {tableName} WHERE job_order_no = @jo_number AND is_deleted = 0";

            int count = int.Parse(mySqlGenericCommands.ExecuteScalar(query, parameters));

            return count > 0;
        }

        public DataTable JOStatusPerParticular(DateTime dateFrom, DateTime dateTo)
        {

            var parameters = new object[][]
            {
                new object[] { "@date_from", DbType.DateTime, dateFrom },
                new object[] { "@date_to", DbType.DateTime, dateTo },
            };

            string query = $"SELECT particular, COUNT(*) AS total_count, SUM(CASE WHEN status_id = 1 THEN 1 ELSE 0 END) AS pending, SUM(CASE WHEN status_id = 2 THEN 1 ELSE 0 END) AS processing, SUM(CASE WHEN status_id = 3 THEN 1 ELSE 0 END) AS cancelled, SUM(CASE WHEN status_id = 4 THEN 1 ELSE 0 END) AS accomplished FROM view_job_orders WHERE date BETWEEN @date_from AND @date_to AND is_deleted = 0 GROUP BY particular ORDER BY total_count DESC;";

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }
    }
}