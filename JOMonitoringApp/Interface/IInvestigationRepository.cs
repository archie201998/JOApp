using JOMonitoringApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Interface
{
    public interface IInvestigationRepository : IRoleHasPermission<InvestigationModel>
    {
        Dictionary<string, string> GetForRecommendation();
        int GetLastInsertedId(int userId);
        Dictionary<string, string> GetViewRecordById(int selectedId);
        Dictionary<string, string> GetViewRecordByJobOrderId(int? jobOrderId);
        Dictionary<string, string> GetViewRecordByJobOrderNo(string jobOrderNumber);
        DataTable GetViewRecordsBySearch(int statusId, string searchKey);
    }
}
