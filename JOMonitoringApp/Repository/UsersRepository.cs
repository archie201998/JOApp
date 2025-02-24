using System;
using System.Collections.Generic;
using System.Data;
using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;

namespace JOMonitoringApp
{
    internal class UsersRepository : IUsersRepository
    {
        private readonly GenericCommands mySqlGenericCommands;
        readonly string tableName = "tbl_users";

        public UsersRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<UsersModel> entityList)
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

        public bool Insert(UsersModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(UsersModel entity)
        {
            throw new System.NotImplementedException();
        }

        public byte ValidateLogin(string username, string password)
        {
            var parameters = new object[][]
            {
                    new object[] { "@username", DbType.String, username },
                    new object[] { "@password", DbType.String, password },
            };

            //string query = $"SELECT id FROM {tableName} WHERE BINARY username = @username AND password = sha2(@password, 224)";
            string query = $"SELECT id FROM {tableName} WHERE  username = @username AND password = @password";
            string userId = mySqlGenericCommands.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(userId)) return Convert.ToByte(userId);

            try
            {
            
            }
            catch (Exception)
            {
                throw;
            };

            return 0;
        }
    }
}