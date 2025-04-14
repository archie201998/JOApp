using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Model
{
    public class JOLogsModel
    {
        public int LogId { get; set; }
        public string TransactionEvent { get; set; }
        public string DateAndTime { get; set; }
        public int JobOrderId { get; set; }
        public int UserId { get; set; }

    }
}
