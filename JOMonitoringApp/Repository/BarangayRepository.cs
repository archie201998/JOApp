using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using Twilio.TwiML.Voice;

namespace JOMonitoringApp
{
    internal class BarangayRepository : IBarangayRepository
    {
        private object tableName = "tbl_barangay";

        private GenericCommands mySqlGenericCommands;

        public BarangayRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public GenericCommands MySqlGenericCommands { get; }

        public bool Delete(List<BarangayModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public int GetIdByName(string text)
        {
            var parameters = new object[][]
            {
                new object[] { "@barangay_name", DbType.String, text }
            };

            string query = $"SELECT id FROM {tableName} WHERE barangay_name = @barangay_name LIMIT 1";

            object result = mySqlGenericCommands.ExecuteScalar(query, parameters);

            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToInt32(result);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName} ORDER BY barangay_name";

            var dataTable = new DataTable();
            return mySqlGenericCommands.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(BarangayModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(BarangayModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}