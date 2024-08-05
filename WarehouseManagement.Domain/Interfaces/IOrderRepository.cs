using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Domain.Interfaces
{
    public interface IOrderRepository
    {
        OrderLineItem? GetOrderLineItem(int orderNumber, int orderItemNumber);

        void UpdateOrderLineItem(OrderLineItem orderLineItem);

        OrderAllocation? GetOrderInventoryAllocation(int orderNumber, int orderItemNumber, int allocationInventoryType, int warehouseNumber);

        void UpdateOrderInventoryAllocation(OrderAllocation orderAllocation);

        List<OrderCustomerExpedite> GetOrderCustomerExpedites(int orderNumber, int orderItemNumber, int expediteItemStatus);

        void UpdateOrderCustomerExpedite(OrderCustomerExpedite expedite);
    }
}
