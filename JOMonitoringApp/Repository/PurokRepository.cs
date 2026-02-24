using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;
using System.Collections.Generic;
using System.Data;

namespace JOMonitoringApp
{
    internal class PurokRepository : IPurokRepository
    {
        private object tableName = "tbl_purok";

        private GenericCommands mySqlGenericCommands;
        public PurokRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }


        public bool Delete(List<PurokModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetPurokByBarangayId(int barangayId)
        {
            var parameters = new object[][]
            {
                new object[] { "@barangay_id", DbType.Int32, barangayId }
            };

            string query = $"SELECT * FROM {tableName} WHERE barangay_id = @barangay_id ORDER BY purok_name";

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName} ORDER BY purok_name";

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

        public bool Insert(PurokModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@purok_name", DbType.String, entity.PurokName },
                new object[] { "@barangay_id", DbType.Int32, entity.BarangayId }
            };

            string query = $"INSERT INTO {tableName} (purok_name, barangay_id) VALUES (@purok_name, @barangay_id)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);

        }

        public bool Update(PurokModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}