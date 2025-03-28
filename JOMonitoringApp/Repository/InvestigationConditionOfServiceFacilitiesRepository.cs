using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;
using System.Collections.Generic;
using System.Data;

namespace JOMonitoringApp
{

    internal class InvestigationConditionOfServiceFacilitiesRepository : IInvestigationConditionOfServiceFacilities
    {
        private readonly GenericCommands mySqlGenericCommands;
        private readonly string tableName = "tbl_condition_of_service_facilities";

        public InvestigationConditionOfServiceFacilitiesRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<InvestigationConditionOfServiceFacilitiesModel> entityList)
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

        public bool Insert(InvestigationConditionOfServiceFacilitiesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@investigation_id", DbType.Int32, entity.InvestigationId },
                new object[] { "@meter_brand", DbType.String, entity.MeterBrand },
                new object[] { "@meter_size", DbType.String, entity.MeterSize },
                new object[] { "@reading_before_test", DbType.String, entity.ReadingBeforeTest },
                new object[] { "@reading_after_test", DbType.String, entity.ReadingAfterTest },
                new object[] { "@calibration_result", DbType.String, entity.CalibrationResult },
                new object[] { "@over_registration", DbType.String, entity.OverRegistration },
                new object[] { "@under_registration", DbType.String, entity.UnderRegistration },
                new object[] { "@leaking_after_the_meter", DbType.String, entity.LeakingAfterTheMeter }
            };

            string query = $"INSERT INTO {tableName} (investigation_id, meter_brand, meter_size,reading_before_test, reading_after_test, calibration_result, over_registration, under_registration, leaking_after_the_meter) " +
                           "VALUES (@investigation_id, @meter_brand, @meter_size, @reading_before_test, @reading_after_test, @calibration_result, @over_registration, @under_registration, @leaking_after_the_meter)";

         

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(InvestigationConditionOfServiceFacilitiesModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}