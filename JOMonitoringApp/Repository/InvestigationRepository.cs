using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;
using System.Collections.Generic;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JOMonitoringApp
{
    public class InvestigationRepository : IInvestigationRepository
    {
        private readonly GenericCommands mySqlGenericCommands;
        private readonly string tableName = "tbl_investigation";

        public InvestigationRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<InvestigationModel> entityList)
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

        public bool Insert(InvestigationModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@job_orders_id", DbType.Int32,  entity.JobOrderId },
                new object[] { "@customers_id", DbType.Int32, entity.CustomerId },
                new object[] { "@customer_name", DbType.String, entity.CustomerName },
                new object[] { "@customer_address", DbType.String, entity.CustomerAddress },
                new object[] { "@account_number", DbType.String, entity.CustomerAccountNumber },
                new object[] { "@nature_of_complaint", DbType.String, entity.NatureOfComplaint },
                new object[] { "@investigator_comments", DbType.String, entity.InvestigatorComments },
                new object[] { "@recommendations", DbType.String, entity.Recommendations }
            };

            string query = $"INSERT INTO {tableName} (job_orders_id, customers_id, customer_name, customer_address, account_number, nature_of_complaint, investigator_comments, recommendations) " +
                           "VALUES (@job_orders_id, @customers_id, @customer_name, @customer_address, @account_number, @nature_of_complaint, @investigator_comments, @recommendations)";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(InvestigationModel entity)
        {
            throw new System.NotImplementedException();
        }

        public int GetLastInsertedId(int userId)
        {
            var parameters = new object[][]
            {  new object[] { "@user_id", DbType.Int32, userId}, };

            string query = $"SELECT MAX(id) FROM {tableName}";

            return int.Parse(mySqlGenericCommands.ExecuteScalar(query, parameters));
        }
    }
}