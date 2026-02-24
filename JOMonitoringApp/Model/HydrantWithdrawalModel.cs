using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Model
{
    internal class HydrantWithdrawalModel
    {
        public int JobOrderNumber { get; set; }

        public decimal PreviousReading { get; set; }
        public decimal CurrentReading { get; set; }

        public string RequestedBy { get; set; }
        public string ORNumber { get; set; }
        public string Cashier { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }
        public decimal TotalVolume { get; set; }
    }
}
