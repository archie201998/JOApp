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
        DataTable GetParticularIdByJOId(int jobOrderId);
        bool InsertJobOrdersParticulars(int jobOrdersId, int particularId);
    }
}
