using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Model
{
    public class RequestModel
    {
        public int ID { get; set; }

        public string Details { get; set; }

        public string RequestedBy { get; set; }

        public int Status { get; set; }

        public int CreatedBy { get; set; }
    }
}
