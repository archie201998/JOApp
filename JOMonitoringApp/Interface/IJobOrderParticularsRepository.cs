using JOMonitoringApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Interface
{
    internal interface IJobOrderParticularsRepository : IRepository<JobOrdersParticularsModel>
    {
        bool ForwardDocument(int jobOrderId, string sender, string receiver);
        DataTable GetJOSummary(JobOrdersParticularsModel parameters);
        DataTable GetParticularIdByJOId(int jobOrderId);
        DataTable GetRecordsByParticular(string particular);
        bool InsertJobOrdersParticulars(int jobOrdersId, int particularId);
    }
}
