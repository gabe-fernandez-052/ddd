namespace WarehouseManagement.Domain.Interfaces
{
    public interface IReceivingUnitOfWork
    {
        IWarehouseManagementRepository WarehouseManagementRepository { get; }

        IReceivingRepository ReceivingRepository { get; }

        ISupplierOrderRepository SupplierOrderRepository { get; }

        IInventoryRepository InventoryRepository { get; }

        IOrderRepository OrderRepository { get; }

        IEventRepository EventRepository { get; }

        void SaveChanges();

        void ClearChanges();
    }
}
