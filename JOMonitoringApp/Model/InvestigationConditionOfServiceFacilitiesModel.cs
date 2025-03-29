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
        public string ReadingBeforeTest { get; set; }
        public string ReadingAfterTest { get; set; }
        public string CalibrationResult { get; set; }
        public string OverRegistration { get; set; }
        public string UnderRegistration { get; set; }
        public string LeakingAfterTheMeter { get; set; }
    }
}
