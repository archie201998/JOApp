namespace JOMonitoringApp
{
    internal class MaterialsModel
    {
        public int Id { get; set; }

        public string ItemNo { get; set; }
        public string ItemName { get; set; }
        public decimal InStock { get; set; }
        public bool IsInventoryItem { get; set; }

    }
}