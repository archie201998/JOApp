using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Interface
{
    internal interface IInvestigationAdjustmentOtherFeesRepository : IRepository<InvestigationAdjustmentOtherFeesModel>
    {
        bool DeleteAdjustments(int investigationID);
        DataTable GetInvestigationOtherFees(int investigationId);
    }
}
