using JOMonitoringApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Interface
{
    public interface IJobOrdersRepository : IRepository<JobOrdersModel>
    {
        DataTable GetViewRecords();

        DataTable GetViewRecordsByParameters(string searchText, bool showInactiveTaxpayers, int rowFilter);


        DataTable GetViewRecordsBySearch(string searchText);
        int GetSummaryByStatusId(int statusId);
    }
}
