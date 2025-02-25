using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Model
{
    public class JobOrdersModel
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int ParticularID { get; set; }
        public DateTime Date { get; set; }
        public string ORNumber{ get; set; }
        public decimal Amount{ get; set; }
        public int UserId { get; set; }
    }
}
