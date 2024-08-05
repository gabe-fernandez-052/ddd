namespace WarehouseManagement.Domain.Entities
{
    public class OrderCustomerExpedite(int id) : Entity<int>(id)
    {
        public int ItemNumber { get; set; }

        public int Status { get; set; }

        public int? SubStatus { get; set; }
    }
}
