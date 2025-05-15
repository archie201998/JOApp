namespace JOMonitoringApp.Interface
{
    public class InvestigationAdjustmentModel
    {
        public int Id { get; set; }
        public string Particular  { get; set; }
        public string Value { get; set; }
        public int InvestigationId { get; set; }
    }
}