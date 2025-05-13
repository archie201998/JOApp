using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Model
{
    internal class JobOrderParticularsModel
    {
        public int Id { get; set; }
        public int JobOrderId { get; set; }
        public int ParticularId { get; set; }
    }
}
