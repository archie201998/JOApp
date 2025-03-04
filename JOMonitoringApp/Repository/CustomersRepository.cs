using System.Collections.Generic;
using System.Data;
using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;

namespace JOMonitoringApp
{
    internal class CustomersRepository : ICustomersRepository
    {
        private GenericCommands mySqlGenericCommands;
        private readonly string tableName = "tbl_customers";

        public CustomersRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<CustomersModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT id, account_name FROM {tableName}";

            var dataTable = new DataTable();
            return mySqlGenericCommands.Fill(query, dataTable);
        }

        public int GetLastInsertedID(int userId)
        {
            var parameters = new object[][]
            {  new object[] { "@user_id", DbType.Int32, userId}, };

            string query = $"SELECT MAX(id) FROM {tableName} WHERE created_by = @user_id";
            return int.Parse(mySqlGenericCommands.ExecuteScalar(query, parameters));
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(CustomersModel entity)
        {
            var parameter = new object[][] {
                new object[]{"@account_number", DbType.String, entity.AccountNumber},
                new object[]{"@account_name", DbType.String, entity.AccountName},
                new object[]{"@address", DbType.String, entity.Address},
                new object[]{"@created_by", DbType.Int32, entity.CreatedBy},
            };

            string query = $"INSERT INTO {tableName} (account_number, account_name, address, created_by) VALUES (@account_number, @account_name, @address, @created_by)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameter);
        }

        public bool Update(CustomersModel entity)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetCustomersName()
        {
            string query = $"SELECT id, account_number, account_name FROM {tableName}";

            var dataTable = new DataTable();
            return mySqlGenericCommands.Fill(query, dataTable);
        }
    }
}