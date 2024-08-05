namespace WarehouseManagement.Domain.Entities
{
    public class SupplierOrder(int id) : Entity<int>(id)
    {
        public string DocumentLanguage { get; init; } = string.Empty;

        public string CurrencyCode { get; init; } = string.Empty;

        public List<SupplierOrderItem> SupplierOrderItems { get; init; } = [];
    }
}
