namespace JOMonitoringApp
{
    internal class MaterialsModel
    {
        public int Id { get; set; }

        public string ItemNo { get; set; }
        public string ItemName { get; set; }
        public double InStock { get; set; }
        public string IsInventoryItem { get; set; }

        public double StockPrice { get; set; }
        public int DateImportedId { get; set; }

    }
}