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

        DataTable GetViewRecordsByParameters(string searchText, int rowFilter, int statusId);


        DataTable GetViewRecordsBySearch(string searchText);

        int GetSummaryByStatusId(int year, int monthId, int statusId);

        //bool SoftDeleteJOById(int jobOrderId, int deleteBy);

        bool SoftDeleteJOById(List<JobOrdersModel> entityList);


        
    }
}
