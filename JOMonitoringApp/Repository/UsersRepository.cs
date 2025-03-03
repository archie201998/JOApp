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
        private readonly string viewTableName = "view_users";


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
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, Id},
                };

                string query = $"SELECT * FROM {tableName} WHERE id = @id";

                using (var reader = mySqlGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("roles_id", reader.Rows[0]["roles_id"].ToString());
                    record.Add("prefix", reader.Rows[0]["prefix"].ToString());
                    record.Add("first_name", reader.Rows[0]["first_name"].ToString());
                    record.Add("middle_name", reader.Rows[0]["middle_name"].ToString());
                    record.Add("last_name", reader.Rows[0]["last_name"].ToString());
                    record.Add("suffix", reader.Rows[0]["suffix"].ToString());
                    record.Add("user_name", reader.Rows[0]["user_name"].ToString());
                    record.Add("password", reader.Rows[0]["password"].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT id, prefix, first_name, middle_name, suffix, last_name FROM {tableName}";

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
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@username", DbType.String, username },
                    new object[] { "@password", DbType.String, password },
                };

                //string query = $"SELECT id FROM {tableName} WHERE BINARY username = @username AND password = sha2(@password, 224)";
                string query = $"SELECT id FROM {tableName} WHERE  user_name = @username AND password = @password";
                string userId = mySqlGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(userId)) return Convert.ToByte(userId);
            }
            catch (Exception)
            {
                throw;
            };

            return 0;
        }
    }
}