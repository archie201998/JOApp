using JOMonitoringApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Interface
{
    internal interface IInvestigationFindings : IRepository<InvestigationFindingsModel>
    {
        DataTable Reasons();
        string ReasonsExplanation(int reasonId);
    }
}
