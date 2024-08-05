namespace WarehouseManagement.Domain.Entities
{
    public class OrderLineItem(int id) : Entity<int>(id)
    {
        public int OrderNumber { get; set; }

        public int Quantity { get; init; }

        public int QuantityShipped { get; init; }

        public int? SubStatus { get; set; }

        public bool IsPartial { get; init; }

        public bool ShipAsap { get; init; }

        public DateTime TargetShipDate { get; set; }

        public DateTime DockDate { get; init; }

        public DateTime RequestDate { get; init; }

        public int QuantityAllocatedToInventory { get; set; }
    }
}
