using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Model
{
    public class InvestigationStatFindingsModel
    {
        public int Id { get; set; }
        public byte ImmediateMembersOfFam { get; set; }
        public byte HouseHelper { get; set; }
        public byte Relatives { get; set; }
        public byte Boarders { get; set; }
        public byte NoOfHoursServed { get; set; }
        public byte NoServiceOutlets { get; set; }
        public bool HhPurpose { get; set; }
        public bool PromoteTradeBusiness { get; set; }
        public bool SellToNeighbours { get; set; }
        public string AlternativeSource { get; set; }
        public int InvestigationId { get; set; }
    }
}
