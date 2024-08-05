namespace WarehouseManagement.Domain.Entities
{
    public class SupplierOrderItem(int id) : Entity<int>(id)
    {
        public int AmountReceived { get; set; }

        public int Quantity { get; init; }

        public DateTime ReceiveDate { get; set; }

        public int Status { get; set; }

        public bool IsPartial { get; init; }

        public string ProductPartNumber { get; init; } = string.Empty;

        public int ProductNumber { get; init; }

        public int FormatNumber { get; init; }

        public decimal UnitCost { get; init; }

        public string? ProductOriginCountry { get; init; }

        public int WarehouseNumber { get; init; }
    }
}
