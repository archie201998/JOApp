using System.Collections.Generic;
using System.Data;
using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;

namespace JOMonitoringApp
{
    internal class ParticularsRepository : IParticularsRepository
    {
        private GenericCommands mySqlGenericCommands;
        private readonly string tableName = "tbl_particulars";

        public ParticularsRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<ParticularsModel> entityList)
        {
            bool result = true;
            foreach (var entity in entityList)
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, entity.Id }
                };

                string query = $"DELETE FROM {tableName} WHERE id = @id";

                if (!mySqlGenericCommands.ExecuteNonQuery(query, parameters))
                {
                    result = false;
                }
            }
            return result;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName} ORDER BY particular ASC";

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

        public bool Insert(ParticularsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@particular", DbType.String ,entity.Name },
                new object[] { "@description", DbType.String, entity.Description },
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy },
            };

            string query = $"INSERT INTO {tableName} (particular, description, created_by) VALUES (@particular, @description, @created_by)";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(ParticularsModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}