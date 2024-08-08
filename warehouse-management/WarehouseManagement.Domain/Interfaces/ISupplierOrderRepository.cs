using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Domain.Interfaces
{
    public interface ISupplierOrderRepository
    {
        SupplierOrder? GetSupplierOrder(int supplierOrderNumber, int companyNumber);

        void UpdateSupplierOrderItem(int supplierOrderNumber, SupplierOrderItem supplierOrderItem);

        List<SupplierOrderAllocation> GetSupplierOrderAllocations(int supplierOrderNumber, int supplierOrderItemNumber);

        void UpdateSupplierOrderAllocation(SupplierOrderAllocation supplierOrderAllocation);

        void DeleteSupplierOrderAllocation(SupplierOrderAllocation allocation);
    }
}
