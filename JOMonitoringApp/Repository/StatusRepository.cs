using System.Collections.Generic;
using System.Data;
using JOMonitoringApp.Interface;
using JOMonitoringApp.Repository;

namespace JOMonitoringApp
{
    internal class StatusRepository : IStatusRepository
    {
        private GenericCommands mySqlGenericCommands;
        private readonly string tableName = "tbl_status";

        public StatusRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<StatusModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT id, status FROM {tableName}";

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

        public bool Insert(StatusModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(StatusModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}