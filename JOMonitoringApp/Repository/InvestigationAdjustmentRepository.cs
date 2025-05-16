using JOMonitoringApp.Interface;
using JOMonitoringApp.Repository;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System.Collections.Generic;
using System.Data;

namespace JOMonitoringApp
{
    internal class InvestigationAdjustmentRepository : IInvestigationAdjustmentRepository
    {
        private GenericCommands mySqlGenericCommands;
        private readonly string tableName = "tbl_investigation_adjustment";


        public InvestigationAdjustmentRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<InvestigationAdjustmentModel> entityList)
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

        public DataTable GetRecordsBySearch(string Id)
        {
            var parameters = new object[][]
            {
                new object[] { "@investigation_id", DbType.Int32, Id }
            };

            string query = $"SELECT * FROM {tableName} WHERE investigation_id = @investigation_id";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(InvestigationAdjustmentModel entity)
        {
            var parameter = new object[][] {

                new object[]{ "@particular", DbType.String, entity.Particular},
                new object[]{ "@value", DbType.String, entity.Value},
                new object[]{ "@investigation_id", DbType.Int32, entity.InvestigationId},
            };

            string query = $"INSERT INTO {tableName} (particular, value, investigation_id) VALUES (@particular, @value, @investigation_id)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameter);
        }

        public bool Update(InvestigationAdjustmentModel entity)
        {
            throw new System.NotImplementedException();
        }

        public string GetValueByInvestigationParticularAndID(string itemText, int selectedInvestigationID)
        {
            var parameters = new object[][]
            {  
                new object[] { "@particular", DbType.String, itemText}, 
                new object[] { "@investigation_id", DbType.Int32, selectedInvestigationID}, 
            };

            string query = $"SELECT value FROM {tableName} WHERE particular = @particular AND investigation_id = @investigation_id";

            return mySqlGenericCommands.ExecuteScalar(query, parameters).ToString();
        }

        public bool DeleteAdjustments(int investigationID)
        {
            var parameters = new object[][]
            {
                new object[] { "@investigation_id", DbType.Int32, investigationID},
            };

            string query = $"DELETE FROM {tableName} WHERE investigation_id = @investigation_id";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}