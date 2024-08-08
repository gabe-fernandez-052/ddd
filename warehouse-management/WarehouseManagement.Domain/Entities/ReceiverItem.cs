namespace WarehouseManagement.Domain.Entities
{
    public class ReceiverItem(int id) : Entity<int>(id)
    {
        public int SupplierOrderItemNumber { get; init; }

        public int ProductNumber { get; init; }

        public int FormatNumber { get; init; }

        public int ReceiverNumber { get; init; }

        public DateTime Date { get; init; }

        public int Quantity { get; init; }

        public decimal Cost { get; init; }

        public string CurrencyCode { get; init; } = string.Empty;
    }
}
