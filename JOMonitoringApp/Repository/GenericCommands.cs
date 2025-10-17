
using JOMonitoringApp.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Repository
{
    public class GenericCommands : IGenericCommands
    {
        private readonly string connectionString;
        private GenericCommands mySqlGenericCommands;

        public GenericCommands(string connectionName)
        {
            connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public GenericCommands(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        private void AddDbParameter(MySqlCommand command, object[] param)
        {
            DbParameter dbParameter = command.CreateParameter();
            dbParameter.ParameterName = param[0].ToString();
            dbParameter.DbType = (DbType)param[1];
            dbParameter.Value = param[2];
            command.Parameters.Add(dbParameter);
        }

        public DataTable Fill(string query, DataTable dataTable)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(query, connection);
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public DataTable MainDB_Fill(string query, DataTable dataTable)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(query, connection);
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public DataTable FillBySearch(string query, DataTable dataTable, params object[][] parameters)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var adapter = new MySqlDataAdapter();
                using (adapter.SelectCommand = new MySqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                        AddDbParameter(adapter.SelectCommand, param);

                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
        public DataTable SQLFillBySearch(string query, DataTable dataTable, params object[][] parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var adapter = new SqlDataAdapter();
                using (adapter.SelectCommand = new SqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                    {
                        DbParameter dbParameter = adapter.SelectCommand.CreateParameter();
                        dbParameter.ParameterName = param[0].ToString();
                        dbParameter.DbType = (DbType)param[1];
                        dbParameter.Value = param[2];
                        adapter.SelectCommand.Parameters.Add(dbParameter);
                    }

                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
        public bool ExecuteNonQuery(string query, params object[][] parameters)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                        AddDbParameter(command, param);

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        return true;

                    return false;
                }
            }
        }

        public int ExecuteNonQueryId(string query, params object[][] parameters)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                        AddDbParameter(command, param);

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        return int.Parse(command.LastInsertedId.ToString());
                    return 0;
                }
            }
        }

        public DataTable ExecuteReader(string query, object[][] parameters)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                        AddDbParameter(command, param);

                    connection.Open();
                    var reader = command.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    return dataTable;
                }
            }
        }

        public string ExecuteScalar(string query, params object[][] parameters)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                        AddDbParameter(command, param);

                    connection.Open();
                    if (command.ExecuteScalar() != null)
                        return command.ExecuteScalar().ToString();

                    return string.Empty;
                }
            }
        }

        public bool TestConnection(string testConnectionName)
        {
            try
            {
                string testConnectionString = ConfigurationManager.ConnectionStrings[testConnectionName].ConnectionString;
                using (SqlConnection connection = new SqlConnection(testConnectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (SqlException) { return false; }
        }
    }
}
