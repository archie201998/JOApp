using JOMonitoringApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Interface
{
    internal interface IRequestRepository : IRepository<RequestModel>
    {
        bool CancelRequest(int requestId);
        bool CreateRequest(RequestModel requestModel);
        int GetLastInsertedID(byte userId);
        DataTable GetRequestsByIDAndStatus(int requestId, int v);
        DataTable GetRequestsByStatus(int requestStatus);
        DataTable GetRequestStatusById(int requestId);
        bool UpdateRequestStatus(int requestId, int v);
    }
}
