using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.Enums;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Infrastructure.Data.Extensions;
using WarehouseManagement.Infrastructure.Data.Scaffold;
using OrderLineItem = WarehouseManagement.Domain.Entities.OrderLineItem;

namespace WarehouseManagement.Infrastructure.Data.Repositories
{
    public class OrderRepository(WarehouseManagementContext dbContext) : IOrderRepository
    {
        public OrderLineItem? GetOrderLineItem(int orderNumber, int orderItemNumber)
        {
            var orderLineItem = dbContext.OrderLineItems.Find(orderNumber, orderItemNumber);

            return orderLineItem != null ? new OrderLineItem(orderLineItem.OrderItemNumber)
            {
                OrderNumber = orderLineItem.OrderNumber,
                Quantity = orderLineItem.OrderItemQuantity,
                QuantityShipped = orderLineItem.OrderItemQuantityShipped,
                SubStatus = orderLineItem.OrderItemSubStatus,
                IsPartial = orderLineItem.OrderItemPartialShipment,
                ShipAsap = orderLineItem.OrderItemShipAsap,
                TargetShipDate = orderLineItem.OrderItemTargetShipDate,
                DockDate = orderLineItem.OrderItemOnDockDate,
                RequestDate = orderLineItem.RequestDate
            } : null;
        }

        public void UpdateOrderLineItem(OrderLineItem orderLineItem)
        {
            var item = dbContext.OrderLineItems.Find(orderLineItem.OrderNumber, orderLineItem.Id);

            if (item != null)
            {
                item.OrderItemSubStatus = (short?)orderLineItem.SubStatus;
                item.OrderItemTargetShipDate = orderLineItem.TargetShipDate;
            }
        }

        public OrderAllocation? GetOrderInventoryAllocation(int orderNumber, int orderItemNumber, int allocationInventoryType, int warehouseNumber)
        {
            var existingInventoryAllocation = dbContext.SingleOrDefaultLocalOrDb<Allocation>(a => a.OrderOutType == (int)OrderType.CustomerOrder &&
                                                                                                  a.OrderOutNumber == orderNumber &&
                                                                                                  a.OrderOutItemNumber == orderItemNumber &&
                                                                                                  a.SourceType == allocationInventoryType &&
                                                                                                  a.WarehouseNumber == warehouseNumber);
            return existingInventoryAllocation != null
                ? new OrderAllocation(existingInventoryAllocation.AllocationNumber)
                {
                    Quantity = existingInventoryAllocation.AllocationQuantity,
                    SourceType = existingInventoryAllocation.SourceType,
                    OrderOutNumber = existingInventoryAllocation.OrderOutNumber,
                    OrderOutItemNumber = existingInventoryAllocation.OrderOutItemNumber
                } : null;
        }

        public void UpdateOrderInventoryAllocation(OrderAllocation orderAllocation)
        {
            var item = dbContext.Allocations.Find(orderAllocation.Id);

            if (item != null)
            {
                item.AllocationQuantity = orderAllocation.Quantity;
            }
        }

        public List<OrderCustomerExpedite> GetOrderCustomerExpedites(int orderNumber, int orderItemNumber, int expediteItemStatus)
        {
            var expediteListNumber = 96;
            var expedites = dbContext.CustomerExpedites.Include(e => e.CustomerExpediteItems.Where(ei => ei.ExpediteItemStatus == expediteItemStatus &&
                                                                                                         ei.OrderNumber == orderNumber &&
                                                                                                         ei.OrderItemNumber == orderItemNumber &&
                                                                                                         ei.OrderOutType == (int)OrderType.CustomerOrder))
                                                        .Join(dbContext.CdilistValues,
                                                              e => e.ExpediteType,
                                                              clv => clv.ListValue,
                                                              (e, clv) => new { CustomerExpedite = e, CDIListValue = clv })
                                                        .Where(x => x.CDIListValue.ListNumber == expediteListNumber &&
                                                              (x.CustomerExpedite.ExpediteType == (int)ExpediteType.ConfirmDockDate ||
                                                               x.CustomerExpedite.ExpediteType == (int)ExpediteType.RequestPullIn ||
                                                               x.CustomerExpedite.ExpediteType == (int)ExpediteType.ExpediteLateItem ||
                                                               x.CustomerExpedite.ExpediteType == (int)ExpediteType.ExpediteLineDown))
                                                        .Select(x => x.CustomerExpedite)
                                                        .ToList();

            return new List<OrderCustomerExpedite>(expedites.SelectMany(e => e.CustomerExpediteItems).Select(e => new OrderCustomerExpedite(e.ExpediteNumber)
            {
                ItemNumber = e.ExpediteItemNumber,
                Status = e.ExpediteItemStatus,
                SubStatus = e.ItemSubStatus
            }));
        }

        public void UpdateOrderCustomerExpedite(OrderCustomerExpedite expedite)
        {
            var item = dbContext.CustomerExpediteItems.Find(expedite.Id, expedite.ItemNumber);

            if (item != null)
            {
                item.ExpediteItemStatus = expedite.Status;
                item.ItemSubStatus = expedite.SubStatus;
            }
        }
    }
}
