using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Infrastructure.Data.Repositories;
using WarehouseManagement.Infrastructure.Data.Scaffold;

namespace WarehouseManagement.Infrastructure.Data.UnitOfWork
{
    public class ReceivingUnitOfWork(WarehouseManagementContext dbContext) : IReceivingUnitOfWork
    {
        public IWarehouseManagementRepository WarehouseManagementRepository { get; } = new WarehouseManagementRepository(dbContext);

        public IReceivingRepository ReceivingRepository { get; } = new ReceivingRepository(dbContext);

        public ISupplierOrderRepository SupplierOrderRepository { get; } = new SupplierOrderRepository(dbContext);

        public IInventoryRepository InventoryRepository { get; } = new InventoryRepository(dbContext);

        public IOrderRepository OrderRepository { get; } = new OrderRepository(dbContext);

        public IEventRepository EventRepository { get; } = new EventRepository(dbContext);

        public void SaveChanges() => dbContext.SaveChanges();

        public void ClearChanges() => dbContext.ChangeTracker.Clear();
    }
}
