using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Domain.Interfaces
{
    public interface IInventoryRepository
    {
        void CreateInventory(ReceiverItem receiverItem, int warehouseNumber, int whoLastUpdated, int branchNumber, int companyNumber, string lotCode, string dateCode, string locationInfo, string thirdPartyReference);

        void CreateInventoryAllocation(ReceiverItem receiverItem, SupplierOrderAllocation allocation, int allocationSourceType, int quantityToTransfer, int warehouseNumber);
    }
}
