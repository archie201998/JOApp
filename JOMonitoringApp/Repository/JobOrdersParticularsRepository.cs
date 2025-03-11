using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;

namespace JOMonitoringApp
{
    public  class JobOrdersParticularsRepository : IJobOrdersParticulars
    {
        private GenericCommands mySqlGenericCommands;
        private string tableName = "tbl_job_orders_particulars";
        private string viewTableName = "view_job_orders_particulars";

        public JobOrdersParticularsRepository(GenericCommands mySqlGenericCommands)
        {

            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<JobOrdersParticularsModel> entityList)
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

        public bool Insert(JobOrdersParticularsModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(JobOrdersParticularsModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}