using JOMonitoringApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Interface
{
    public interface IJOLogsRepository : IRepository<JOLogsModel>
    {
        DataTable GetRecordsByJONumber(int JONumber);

        Dictionary<string, string> GetLogsByJONumber(int JONumber);
        bool RecordLog(string v);
    }
}
