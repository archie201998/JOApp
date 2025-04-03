using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
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
        private readonly string viewTableName2 = "view_roles_has_permission";


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

        public Dictionary<string, string> GetRecordsbyUserName(string userName)
        {
            var record = new Dictionary<string, string>();
            var parameters = new object[][]
            {
                new object[] { "@user_name", DbType.String, userName },
            };

            string query = $"SELECT * FROM {tableName} WHERE user_name = @user_name";

            using (var reader = mySqlGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                record.Add("id", reader.Rows[0]["id"].ToString());
                record.Add("roles_id", reader.Rows[0]["roles_id"].ToString());
                record.Add("prefix", reader.Rows[0]["prefix"].ToString());
                record.Add("first_name", reader.Rows[0]["first_name"].ToString());
                record.Add("middle_name", reader.Rows[0]["middle_name"].ToString());
                record.Add("last_name", reader.Rows[0]["last_name"].ToString());
                record.Add("suffix", reader.Rows[0]["suffix"].ToString());
                record.Add("user_name", reader.Rows[0]["user_name"].ToString());
                record.Add("password", string.Empty);

            }

            return record;
        }

        public int GetUserRoleId(byte userId)
        {
            var parameters = new object[][]
            {
                new object[] { "@user_id", DbType.Byte, userId }
            };

            string query = $"SELECT roles_id FROM {tableName} WHERE id = @user_id";
            string result = mySqlGenericCommands.ExecuteScalar(query, parameters);

            if (int.TryParse(result, out int roleId))
            {
                return roleId;
            }

            return -1; 
        }

        public bool HasPermission(byte userId, string permissionName)
        {
            var parameters = new object[][]
            {
                new object[] { "@user_id", DbType.Byte, userId },
                new object[] { "@permission", DbType.String, permissionName},
            };

            string query = $"SELECT role_id FROM {viewTableName2} WHERE user_id = @user_id AND permission = @permission";
            string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(UsersModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@prefix", DbType.String, entity.Prefix },
                new object[] { "@first_name", DbType.String, entity.FirstName },
                new object[] { "@middle_name", DbType.String, entity.MiddleName },
                new object[] { "@last_name", DbType.String, entity.LastName },
                new object[] { "@suffix", DbType.String, entity.Suffix },
                new object[] { "@user_name", DbType.String, entity.UserName },
                new object[] { "@password", DbType.String, entity.Password },
                new object[] { "@role_id", DbType.Int32, entity.RolesId }
            };

            string query = $"INSERT INTO {tableName} (prefix, first_name, middle_name, last_name, suffix, user_name, password, roles_id) " +
                            "VALUES (@prefix, @first_name, @middle_name, @last_name, @suffix, @user_name, sha2(@password, 224), @role_id)";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(UsersModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id },
                new object[] { "@prefix", DbType.String, entity.Prefix },
                new object[] { "@first_name", DbType.String, entity.FirstName },
                new object[] { "@middle_name", DbType.String, entity.MiddleName },
                new object[] { "@last_name", DbType.String, entity.LastName },
                new object[] { "@suffix", DbType.String, entity.Suffix },
                new object[] { "@user_name", DbType.String, entity.UserName },
                new object[] { "@password", DbType.String, entity.Password },
                new object[] { "@role_id", DbType.Int32, entity.RolesId }
            };

            string query = $"UPDATE {tableName} SET prefix = @prefix, first_name = @first_name, middle_name = @middle_name, last_name = @last_name, suffix = @suffix, user_name = @user_name, password = sha2(@password, 224), roles_id = @role_id WHERE id = @id";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
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

                string query = $"SELECT id FROM {tableName} WHERE BINARY user_name = @username AND password = sha2(@password, 224)";
                //string query = $"SELECT id FROM {tableName} WHERE  user_name = @username AND password = @password";
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