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
        public int PreparedBy { get; set; }
        public int CustomerID { get; set; }
        public string AccountName{ get; set; }
        public string AccountNumber { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public int? MaterialsIssuedBy { get; set; }
        public int? AccomplishedBy { get; set; }
        public DateTime Date { get; set; }
        public string ORNumber{ get; set; }
        public string JONUmber { get; set; }
        public string MRIS { get; set; }
        public string MRS { get; set; }
        public string WAR { get; set; }
        public string Remarks { get; set; }
        public decimal Amount{ get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public int DeletedBy { get; set; }
    }
}
