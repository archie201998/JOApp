using JOMonitoringApp.Interface;
using JOMonitoringApp.Repository;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace JOMonitoringApp
{
    internal class IInvestigationAdjustmentOtherFeesRepository : Interface.IInvestigationAdjustmentOtherFeesRepository
    {
        private GenericCommands mySqlGenericCommands;
        private readonly string tableName = "tbl_investigation_adjustment";


        public IInvestigationAdjustmentOtherFeesRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<InvestigationAdjustmentOtherFeesModel> entityList)
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

        public bool Insert(InvestigationAdjustmentOtherFeesModel entity)
        {
            var parameter = new object[][] {

                new object[]{ "@particular", DbType.String, entity.Description},
                new object[]{ "@value", DbType.String, entity.Amount},
                new object[]{ "@investigation_id", DbType.Int32, entity.InvestigationId},
            };

            string query = $"INSERT INTO {tableName} (particular, value, investigation_id) VALUES (@particular, @value, @investigation_id)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameter);
        }

        public bool Update(InvestigationAdjustmentOtherFeesModel entity)
        {
            throw new System.NotImplementedException();
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

        public DataTable GetInvestigationOtherFees(int investigationId)
        {
            var parameters = new object[][]
            {
                new object[] { "@investigation_id", DbType.Int32, investigationId }
            };

            string query = $"SELECT * FROM {tableName} WHERE investigation_id = @investigation_id ORDER BY id";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }
    }
}