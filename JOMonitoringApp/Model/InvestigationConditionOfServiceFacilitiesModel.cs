using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Model
{
    public class InvestigationConditionOfServiceFacilitiesModel
    {
        public int Id { get; set; }
        public int InvestigationId { get; set; }
        public string MeterBrand { get; set; }
        public string MeterSize { get; set; }
        public decimal ReadingBeforeTest { get; set; }
        public decimal ReadingAfterTest { get; set; }
        public string CalibrationResult { get; set; }
        public decimal OverRegistration { get; set; }
        public decimal UnderRegistration { get; set; }
        public string LeakingAfterTheMeter { get; set; }
    }
}
