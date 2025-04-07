using JOMonitoringApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Interface
{
    public interface IJobOrdersRepository : IRoleHasPermission<JobOrdersModel>
    {
        DataTable GetViewRecords();

        DataTable GetViewRecordsByParameters(string searchText, int rowFilter, int statusId, string particular);

        DataTable GetViewRecordsByMonth(int monthIndex);

        Dictionary<string, string> GetViewRecordsByJONumber(int joNumber);

        DataTable GetViewRecordsBySearch(int monthIndex, string particulars, string status, string orderBy);

        int GetSummaryByStatusId(DateTime dateFrom, DateTime dateTo, int statusId);

        //bool SoftDeleteJOById(int jobOrderId, int deleteBy);

        bool SoftDeleteJOById(List<JobOrdersModel> entityList);

        int GetLastInsertedID(int userId);
      
        bool UpdateStatus(int jobOrderId, int statusId);
        bool CheckPossibleDuplicate(string accountNumber, string particulars);
        bool JONumberExist(string joNumber);

        DataTable JOStatusPerParticular(DateTime dateFrom, DateTime dateTo);
    }
}