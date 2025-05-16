using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Interface
{
    internal interface IInvestigationAdjustmentRepository : IRepository<InvestigationAdjustmentModel>
    {
        bool DeleteAdjustments(int investigationID);
        string GetValueByInvestigationParticularAndID(string itemText, int selectedInvestigationID);
    }
}
