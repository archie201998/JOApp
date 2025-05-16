using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp.Model
{
    public class InvestigationModel
    {
        public int Id { get; set; }
        public int JobOrderId { get; set; }
        public string JobOrderNo { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress{ get; set; }
        public string CustomerAccountNumber { get; set; }
        public string CustomerContactNumber { get; set; }
        public string NatureOfComplaint { get; set; }
        public DateTime DateOfInvestigation { get; set; }
        public int IsApproved { get; set; }
        public string ApprovalMessage { get; set; }
        public string InvestigatorComments { get; set; }
        public string Recommendations { get; set; }
        public string imagePath { get; set; }
        public string secondaryImagePath { get; set; }

        //amount
        public decimal AmountDue { get; set; }
        public decimal Penalty { get; set; }
        public decimal ExtensionFee { get; set; }
        public decimal AdjustmentAmount { get; set; }
        public decimal AdjustedAmountDue { get; set; }

        //amount
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        //service condition
        public int InvestigationId { get; set; }
        public string MeterBrand { get; set; }
        public string MeterSize { get; set; }
        public string MeterNumber { get; set; }   
        public string ReadingBeforeTest { get; set; }
        public string ReadingAfterTest { get; set; }
        public string CalibrationResult { get; set; }
        public string OverRegistration { get; set; }
        public string UnderRegistration { get; set; }
        public string LeakingAfterTheMeter { get; set; }

        //stat finding
        public byte ImmediateMembersOfFam { get; set; }
        public byte HouseHelper { get; set; }
        public byte Relatives { get; set; }
        public byte Boarders { get; set; }
        public byte NoOfHoursServed { get; set; }
        public byte NoServiceOutlets { get; set; }
        public bool HhPurpose { get; set; }
        public bool Government { get; set; }
        public bool PromoteTradeBusiness { get; set; }
        public bool SellToNeighbours { get; set; }
        public string AlternativeSource { get; set; }

        //adjustment details 
        public bool HasAdjustment { get; set; }
        public string PreviousReading { get; set; }
        public string PresentReading { get; set; }
        public string ActualReading { get; set; }
        public string PreviousConsumption { get; set; }
        public string PresentConsumption { get; set; }

        public string ActualConsumption{ get; set; }
        public string AverageConsumption { get; set; }
        public string AdjustmentParticular { get; set; }

    }
}
