namespace WarehouseManagement.Domain.Entities
{
    public class CustomerOrderItem(int itemNumber) : Entity<int>(itemNumber)
    {
        public int TransactionNumber { get; init; }
        public int ProductNumber { get; init; }
        public int FormatNumber { get; init; }
        public int CarrierNumber { get; init; }
        public string CarrierServiceCode { get; init; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime TargetShipDate { get; set; }
        public short Status { get; set; }
        public short? SubStatus { get; set; }
        public decimal Resale { get; set; }
        public int QuantityShipped { get; set; }
        public int WarehouseNumber { get; init; }
        public int FreightChargeType { get; init; }
        public bool ShipAsap { get; init; }
        public bool PartialShipment { get; init; }
        public bool Taxable { get; init; }
        public bool InsureShipment { get; init; }
        public string ProductPartNumber { get; init; } = string.Empty;
        public string? ProductOriginCountry { get; init; }
        public int ManufacturerNumber { get; init; }
        public string? CarrierAccount { get; init; }
        public string CostCurrencyCode { get; set; } = string.Empty;
        public int? TaxType { get; init; }
        public decimal SourceCost { get; set; }
        public string? ManufacturerPartNumber { get; init; }
        public int TransactionTypeNumber { get; init; }
        public int TransactionSubTypeNumber { get; init; }
        public bool Hold { get; init; }
        public int ExportPhase { get; init; }
        public DateTime DockDate { get; init; }
        public DateTime RequestDate { get; init; }
        public decimal? CostConverted { get; set; }
        public int BranchNumber { get; init; }
    }
}
