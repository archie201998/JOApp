using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using Org.BouncyCastle.Tls.Crypto.Impl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Repository
{

    internal class InvestigationFindingsRepository : IInvestigationFindings
    {

        private GenericCommands mySqlGenericCommands;
        private readonly string tableName = "tbl_investigation_findings";

        public InvestigationFindingsRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }


        public bool Delete(List<InvestigationFindingsModel> entityList)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(InvestigationFindingsModel entity)
        {
            throw new NotImplementedException();
        }

        public DataTable Reasons()
        {
            string query = $"SELECT * FROM {tableName}";

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable);

        }

        public bool Update(InvestigationFindingsModel entity)
        {
            throw new NotImplementedException();
        }

        public string ReasonsExplanation(int reasonId)
        {
            var parameters = new object[][]
            {
                new object[] { "@reasonId", DbType.Int32, reasonId }
            };

            string query = $"SELECT explanation FROM {tableName} WHERE id = @reasonId";

            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);
       
            if (dataTable.Rows.Count > 0)
            {
                return dataTable.Rows[0]["explanation"].ToString();
            }
            return string.Empty;

        }
    }

}
