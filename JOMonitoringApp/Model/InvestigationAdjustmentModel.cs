namespace JOMonitoringApp.Interface
{
    public class InvestigationAdjustmentOtherFeesModel
    {
        public int Id { get; set; }
        public string Description  { get; set; }
        public string Amount { get; set; }
        public int InvestigationId { get; set; }
    }
}