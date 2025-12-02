using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;
using System;
using System.Collections.Generic;
using System.Data;

namespace JOMonitoringApp
{

    internal class JobOrderParticularsRepository : IJobOrderParticularsRepository
    {
        private GenericCommands mySqlGenericCommands;

        private string tableName = "tbl_job_orders_particular";
        private string viewTableName = "view_job_order_particulars"; 
        public JobOrderParticularsRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<JobOrdersParticularsModel> entityList)
        {
            throw new System.NotImplementedException();

        }

        public bool InsertJobOrdersParticulars(int jobOrderId, int particularId)
        {
            var parameter = new object[][] {

                new object[]{"@job_order_id", DbType.Int32, jobOrderId},
                new object[]{"@particular_id", DbType.Int32, particularId},
            };

            string query = $"INSERT INTO {tableName} (job_order_id, particular_id) VALUES (@job_order_id, @particular_id)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameter);
        }

        public DataTable GetParticularIdByJOId(int jobOrderId)
        {
            var recordDictionary = new Dictionary<string, string>();
            var parameters = new object[][]
            {
                new object[] { "@job_order_id", DbType.Int32, jobOrderId }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE job_order_id = @job_order_id";

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
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


        public bool DeleteJobOrderParticulars(int jobOrderId)
        {
            var parameters = new object[][]
            {
                new object[] { "@job_order_id", DbType.Int32, jobOrderId},
            };

            string query = $"DELETE FROM tbl_job_orders_particular WHERE job_order_id = @job_order_id";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public DataTable GetRecordsByParticular(string particular)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetJOSummary(JobOrdersParticularsModel parameters)
        {
            var _parameters = new object[][]
            {
                new object[] { "@starting_date", DbType.Date, parameters.StartingDate},
                new object[] { "@ending_date", DbType.Date, parameters.EndingDate },
                new object[] { "@particular", DbType.String, parameters.Particular },
                new object[] { "@status", DbType.String, parameters.Status},

                //Filters
                new object[] { "@limit", DbType.Int16, parameters.Limit},
                new object[] { "@order_by", DbType.String, parameters.OrderBy},
            };

            string query = $"SELECT date, account_number, account_name, job_order_no, particular, mris, mrs, war, status FROM view_job_orders_particulars WHERE particular = 'Change Meter - Stuck-up' AND date >= @starting_date AND date <= @ending_date ORDER BY @order_by LIMIT @limit";

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, _parameters);
        }
    }
}