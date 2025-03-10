using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;
using System.Collections.Generic;
using System.Data;

namespace JOMonitoringApp
{
    internal class JobOrdersParticularsRepository : IJobOrdersParticulars
    {

        private GenericCommands mySqlGenericCommands;

        internal string tableName = "tbl_job_orders_particulars";

        public JobOrdersParticularsRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<JobOrdersParticularModel> entityList)
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

        public bool Insert(JobOrdersParticularModel entity)
        {
            var parameter = new object[][] {
                new object[]{"@particulars_id", DbType.Int32, entity.ParticularId},
                new object[]{"@job_orders_id", DbType.DateTime, entity.JobOrdersId},
            };

            string query = $"INSERT INTO {tableName} (particulars_id, job_orders_id, date, job_order_no, or_number, amount, mris, mrs, war, materials_issued_by, prepared_by, accomplished_by, status_id) VALUES (@customers_id, @particulars_id, @date, @job_order_no, @or_number, @amount, @mris, @mrs, @war, @materials_issued_by, @prepared_by, @accomplished_by, @status_id)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameter);
        }

        public bool Update(JobOrdersParticularModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}