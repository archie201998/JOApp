using JOMonitoringApp.Model.GenericModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Model
{
    public class JobOrdersParticularsModel : FilterModel
    {
        public int Id { get; set; }
        public int JobOrdersId { get; set; }
        public int ParticularsId { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string Particular { get; set; }
        public string Status { get; set; }
    }
}
