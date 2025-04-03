using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Interface
{
    public interface IStatusRepository : IRoleHasPermission<StatusModel>
    {
    }
}
