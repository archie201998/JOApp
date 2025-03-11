using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Model
{
    public class JobOrdersParticularsModel
    {
        public int Id { get; set; }

        public int JobOrdersId { get; set; }

        public int ParticularsId { get; set; }
    }
}
