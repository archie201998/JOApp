using AccountingSystem;
using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using Twilio.TwiML.Voice;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JOMonitoringApp
{
    internal class RequestRepository : IRequestRepository
    {

        private GenericCommands mySqlGenericCommands;
        private readonly string tableName = "tbl_request";

        public RequestRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<RequestModel> entityList)
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

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(RequestModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(RequestModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateRequest(RequestModel entity)
        {
            var parameter = new object[][] {
                new object[]{"@details", DbType.String, entity.Details},
                new object[]{"@status", DbType.Int32, entity.Status},
                new object[]{"@requested_by", DbType.String, entity.RequestedBy},
                new object[]{"@created_by", DbType.Int32, entity.CreatedBy},
            };

            string query = $"INSERT INTO {tableName} (details, status, requested_by, created_by) VALUES (@details, @status, @requested_by, @created_by)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameter);
        }

        public DataTable GetRequestsByStatus(int requestStatus)
        {
            var parameters = new object[][]
            {
                new object[] { "@status", DbType.Int32, requestStatus }
            };

            string query = $"SELECT * FROM {tableName} WHERE status = @status LIMIT 1";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public int GetLastInsertedID(byte userId)
        {
            var parameters = new object[][]
            {  new object[] { "@user_id", DbType.Int32, userId}, };

            string query = $"SELECT MAX(id) FROM {tableName} WHERE created_by = @user_id";

            return int.Parse(mySqlGenericCommands.ExecuteScalar(query, parameters));
        }

        public bool CancelRequest(int requestId)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, requestId }
            };

            string query = $"DELETE FROM {tableName} WHERE id = @id";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);

        }

        public DataTable GetRequestStatusById(int requestId)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, requestId }
            };

            string query = $"SELECT * FROM {tableName} WHERE id = @id LIMIT 1";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public bool UpdateRequestStatus(int requestId, int status)
        {
            var parameter = new object[][] {
                new object[]{"@id", DbType.Int32, requestId},
                new object[]{"@status", DbType.String, status},
            };

            string query = $"UPDATE {tableName} SET  status = @status WHERE id = @id";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameter);
        }

        public DataTable GetRequestsByIDAndStatus(int requestId, int status)
        {
            var parameter = new object[][] {
                new object[]{"@id", DbType.Int32, requestId},
                new object[]{"@status", DbType.String, status},
            };

            string query = $"SELECT * FROM {tableName} WHERE id = @id AND status = @status";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameter);
        }
    }
}