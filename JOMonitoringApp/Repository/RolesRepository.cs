using JOMonitoringApp.Repository;
using System.Collections.Generic;
using System.Data;

namespace JOMonitoringApp
{
    internal class RolesRepository : IRolesRepository
    {

        private GenericCommands mySqlGenericCommands;
        private readonly string tableName = "tbl_roles";

        public RolesRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<RolesModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName} WHERE id != 1";
            DataTable dataTable = new DataTable();
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

        public bool Insert(RolesModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(RolesModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}