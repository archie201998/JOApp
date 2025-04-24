using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;
using System.Collections.Generic;
using System.Data;

namespace JOMonitoringApp
{
    public class InvestigationRepository : IInvestigationRepository
    {
        private readonly GenericCommands mySqlGenericCommands;
        private readonly string tableName = "tbl_investigation";
        private readonly string viewTableName = "view_investigation";   

        public InvestigationRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<InvestigationModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(InvestigationModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@job_orders_id", DbType.Int32,  entity.JobOrderId },
                new object[] { "@customer_name", DbType.String, entity.CustomerName },
                new object[] { "@customer_address", DbType.String, entity.CustomerAddress },
                new object[] { "@account_number", DbType.String, entity.CustomerAccountNumber },
                new object[] { "@nature_of_complaint", DbType.String, entity.NatureOfComplaint },
                new object[] { "@date_of_investigation", DbType.DateTime, entity.DateOfInvestigation },
                new object[] { "@approval_message", DbType.String, entity.ApprovalMessage },
                new object[] { "@investigator_comments", DbType.String, entity.InvestigatorComments },
                new object[] { "@recommendations", DbType.String, entity.Recommendations },
                new object[] { "@image_path", DbType.String, entity.imagePath },
                new object[] { "@secondary_image_path", DbType.String, entity.secondaryImagePath },
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy }
            };

            string query = $"INSERT INTO {tableName} (job_orders_id,  customer_name, customer_address, account_number, nature_of_complaint,  date_of_investigation, approval_message, investigator_comments, recommendations, image_path, secondary_image_path, created_by) " +
                           "VALUES (@job_orders_id, @customer_name, @customer_address, @account_number, @nature_of_complaint, @date_of_investigation, @approval_message,  @investigator_comments, @recommendations, @image_path, @secondary_image_path, @created_by)";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(InvestigationModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id },
                new object[] { "@job_orders_id", DbType.Int32, entity.JobOrderId },
                new object[] { "@job_order_no", DbType.String, entity.JobOrderNo },
                new object[] { "@customer_name", DbType.String, entity.CustomerName },
                new object[] { "@customer_address", DbType.String, entity.CustomerAddress },
                new object[] { "@account_number", DbType.String, entity.CustomerAccountNumber },
                new object[] { "@nature_of_complaint", DbType.String, entity.NatureOfComplaint },
                new object[] { "@date_of_investigation", DbType.DateTime, entity.DateOfInvestigation },
                new object[] { "@approval_message", DbType.String, entity.ApprovalMessage },
                new object[] { "@investigator_comments", DbType.String, entity.InvestigatorComments },
                new object[] { "@recommendations", DbType.String, entity.Recommendations },
                new object[] { "@image_path", DbType.String, entity.imagePath },
                new object[] { "@secondary_image_path", DbType.String, entity.secondaryImagePath },
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy }
            };

            string query = $"UPDATE {tableName} SET " +
                           "job_orders_id = @job_orders_id, " +
                           "job_order_no = @job_order_no, " +
                           "customer_name = @customer_name, " +
                           "customer_address = @customer_address, " +
                           "account_number = @account_number, " +
                           "nature_of_complaint = @nature_of_complaint, " +
                           "date_of_investigation = @date_of_investigation, " +
                           "approval_message = @approval_message, " +
                           "investigator_comments = @investigator_comments, " +
                           "recommendations = @recommendations, " +
                           "image_path = @image_path, " +
                           "secondary_image_path = @secondary_image_path, " +
                           "created_by = @created_by " +
                           "WHERE id = @id";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public int GetLastInsertedId(int userId)
        {
            var parameters = new object[][]
            {  new object[] { "@user_id", DbType.Int32, userId}, };

            string query = $"SELECT MAX(id) FROM {tableName}";

            return int.Parse(mySqlGenericCommands.ExecuteScalar(query, parameters));
        }

        public Dictionary<string, string> GetViewRecordById(int selectedId)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, selectedId }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE id = @id";

            var dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count == 0)
            {
                return null;
            }

            var result = new Dictionary<string, string>();
            foreach (DataColumn column in dataTable.Columns)
            {
                result[column.ColumnName] = dataTable.Rows[0][column].ToString();
            }

            return result;
        }

        public Dictionary<string, string> GetViewRecordByJobOrderId(int? jobOrderId)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetViewRecordByJobOrderNo(string jobOrderNumber)
        {
            var recordDictionary = new Dictionary<string, string>();
            var parameters = new object[][]
            {
                new object[] { "@jo_number", DbType.Int32, jobOrderNumber }
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

        public DataTable GetViewRecordsBySearch(string searchKey)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchKey}%" },
            };

            string query = $"SELECT id, job_orders_id,  CASE is_approved WHEN 0 THEN 'FOR APPROVAL' WHEN 1 THEN 'APPROVED BY BM' WHEN 2 THEN 'DISAPPROVED' ELSE 'UNKNOWN' END AS approval_status,job_order_no, customer_name, account_number, customer_address, nature_of_complaint, date_of_investigation FROM {viewTableName} WHERE (job_order_no LIKE @search_text OR account_number LIKE @search_text OR customer_name LIKE @search_text) ORDER BY created_at DESC; ";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }
    }
}