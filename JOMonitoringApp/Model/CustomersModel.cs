using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Model
{
    public class CustomersModel
    {
        public int  Id{ get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string Address { get; set; }
        public int CreatedBy { get; set; }
    }
}
