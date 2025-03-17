using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;
using MySqlX.XDevAPI.Relational;
using System.Collections.Generic;
using System.Data;

namespace JOMonitoringApp
{
    internal class JOLogsRepository : IJOLogsRepository
    {

        private GenericCommands mySqlGenericCommands;
        private readonly string tableName = "tbl_jo_logs";
        private readonly string viewTableName = "view_jo_logs";

        public JOLogsRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<JOLogsModel> entityList)
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

        public DataTable GetRecordsByJONumber(int JONumber)
        {
            var parameters = new object[][]
            {
                new object[] { "@job_order_no", DbType.Int32, JONumber }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE job_order_no = @job_order_no";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(JOLogsModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(JOLogsModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}