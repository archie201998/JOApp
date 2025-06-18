using JOMonitoringApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Interface
{
    public interface IInvestigationRepository : IRepository<InvestigationModel>
    {
        int GetLastInsertedId(int userId);
        Dictionary<string, string> GetViewRecordById(int selectedId);
        Dictionary<string, string> GetViewRecordByJobOrderId(int? jobOrderId);
        Dictionary<string, string> GetViewRecordByJobOrderNo(string jobOrderNumber);
        DataTable GetViewRecordsBySearch(int statusId, string searchKey);
        DataTable GetViewRecordsBySearch(int statusId, int rowLimit, string searchKey);
        bool SaveComputation(InvestigationModel investigationModel);
        bool UpdateInvestigation(InvestigationModel investigationModel);

        int RecordCount();
        bool InsertApprovalMessage(InvestigationModel investigationModel);
        string GetApprovalMessage(int investigationId);
    }
}
