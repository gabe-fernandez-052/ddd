using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Domain.Interfaces
{
    public interface ICustomerOrderRepository
    {
        CustomerOrder GetCustomerOrder(int orderNumber);

        List<OrderAllocation> GetItemAllocations(int orderType, int orderNumber, int itemNumber);
    }
}
