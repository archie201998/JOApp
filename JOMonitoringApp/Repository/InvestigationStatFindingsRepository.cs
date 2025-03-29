using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;
using System.Collections.Generic;
using System.Data;

namespace JOMonitoringApp
{
    internal class InvestigationStatFindingsRepository : IInvestigationStatFindingsRepository
    {

        private GenericCommands mySqlGenericCommands;
        private readonly string tableName = "tbl_investigation_stat_finding";

        public InvestigationStatFindingsRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<InvestigationStatFindingsModel> entityList)
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

        public bool Insert(InvestigationStatFindingsModel entity)
        {

            var parameters = new object[][]
            {
                new object[] { "@immediate_members_of_fam", DbType.Int16, entity.ImmediateMembersOfFam },
                new object[] { "@house_helper", DbType.Int16, entity.HouseHelper },
                new object[] { "@relatives", DbType.Int16, entity.Relatives },
                new object[] { "@boarders", DbType.Int16, entity.Boarders },
                new object[] { "@no_of_hours_served", DbType.Int16, entity.NoOfHoursServed },
                new object[] { "@no_service_outlets", DbType.Int16, entity.NoServiceOutlets },
                new object[] { "@hh_purpose", DbType.Int16, entity.HhPurpose },
                new object[] { "@promote_trade_business", DbType.Int16, entity.PromoteTradeBusiness },
                new object[] { "@sell_to_neighbours", DbType.Int16, entity.SellToNeighbours },
                new object[] { "@alternative_source", DbType.String, entity.AlternativeSource },
                new object[] { "@investigation_id", DbType.Int16, entity.InvestigationId }
            };


            string query = $"INSERT INTO {tableName} (immediate_members_of_fam, house_helper, relatives, boarders, no_of_hours_served, no_service_outlets, hh_purpose, promote_trade_business, sell_to_neighbours, alternative_source, investigation_id) " +
                           "VALUES (@immediate_members_of_fam, @house_helper, @relatives, @boarders, @no_of_hours_served, @no_service_outlets, @hh_purpose, @promote_trade_business, @sell_to_neighbours, @alternative_source, @investigation_id)";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(InvestigationStatFindingsModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}