using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Model
{
    public class InvestigationModel
    {
        public int Id { get; set; }
        public int JobOrderId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress{ get; set; }
        public string CustomerAccountNumber { get; set; }
        public string NatureOfComplaint { get; set; }
        public string InvestigatorComments { get; set; }
        public string Recommendations { get; set; }

    }
}
