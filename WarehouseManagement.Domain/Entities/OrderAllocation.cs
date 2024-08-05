namespace WarehouseManagement.Domain.Entities
{
    public class OrderAllocation(int id) : Entity<int>(id)
    {
        public int Quantity { get; set; }

        public int SourceType { get; init; }

        public int OrderOutNumber { get; init; }

        public int OrderOutItemNumber { get; init; }

        public int? BinNumber { get; init; }

        public DateTime? OrderInConfirmDate { get; init; }
    }
}
