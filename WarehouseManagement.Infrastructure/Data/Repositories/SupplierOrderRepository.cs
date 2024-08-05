using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Domain.Enums;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Infrastructure.Data.Extensions;
using WarehouseManagement.Infrastructure.Data.Scaffold;
using SupplierOrder = WarehouseManagement.Domain.Entities.SupplierOrder;
using SupplierOrderAllocation = WarehouseManagement.Domain.Entities.SupplierOrderAllocation;
using SupplierOrderItem = WarehouseManagement.Domain.Entities.SupplierOrderItem;

namespace WarehouseManagement.Infrastructure.Data.Repositories
{
    public class SupplierOrderRepository(WarehouseManagementContext dbContext) : ISupplierOrderRepository
    {
        public SupplierOrder? GetSupplierOrder(int supplierOrderNumber, int companyNumber)
        {
            var supplierOrder = dbContext.SupplierOrders.Include(so => so.SupplierOrderItems)
                                           .ThenInclude(soi => soi.ProductNumberNavigation)
                                           .Include(so => so.SupplierNumberNavigation)
                                           .Where(so => so.SupplierOrderNumber == supplierOrderNumber && so.CdicompanyNumber == companyNumber)
                                           .SingleOrDefault();

            if (supplierOrder != null)
            {
                var supplierOrderItems = new List<SupplierOrderItem>();

                foreach (var supplierOrderItem in supplierOrder.SupplierOrderItems)
                {
                    supplierOrderItems.Add(new SupplierOrderItem(supplierOrderItem.SupplierOrderItemNumber)
                    {
                        AmountReceived = supplierOrderItem.SupplierOrderItemReceived,
                        Quantity = supplierOrderItem.SupplierOrderItemQuantity,
                        ReceiveDate = supplierOrderItem.SupplierOrderItemReceiveDate,
                        Status = supplierOrderItem.SupplierOrderItemStatus,
                        IsPartial = supplierOrderItem.SupplierOrderItemPartial,
                        ProductPartNumber = supplierOrderItem.ProductNumberNavigation.ProductPartNumber,
                        ProductNumber = supplierOrderItem.ProductNumber,
                        FormatNumber = supplierOrderItem.FormatNumber,
                        UnitCost = supplierOrderItem.SupplierOrderItemUnitCost,
                        ProductOriginCountry = supplierOrderItem.ProductNumberNavigation.ProductOriginCountry,
                        WarehouseNumber = supplierOrderItem.WarehouseNumber
                    });
                }

                return new SupplierOrder(supplierOrderNumber)
                {
                    DocumentLanguage = supplierOrder.DocumentLanguage,
                    CurrencyCode = !string.IsNullOrEmpty(supplierOrder.CurrencyCode) ? supplierOrder.CurrencyCode : supplierOrder.SupplierNumberNavigation.CurrencyCode,
                    SupplierOrderItems = supplierOrderItems,
                };
            }

            return null;
        }

        public void UpdateSupplierOrderItem(int supplierOrderNumber, SupplierOrderItem supplierOrderItem)
        {
            var item = dbContext.SupplierOrderItems.Find(supplierOrderNumber, supplierOrderItem.Id);

            if (item != null)
            {
                item.SupplierOrderItemReceived = supplierOrderItem.AmountReceived;
                item.SupplierOrderItemReceiveDate = supplierOrderItem.ReceiveDate;
                item.SupplierOrderItemStatus = (short)supplierOrderItem.Status;
            }
        }

        public List<SupplierOrderAllocation> GetSupplierOrderAllocations(int supplierOrderNumber, int supplierOrderItemNumber)
        {
            var allocationInventoryType = 0;

            var supplierOrderAllocations = dbContext.WhereLocalOrDb<Allocation>(a => a.OrderInType == (int)OrderType.SupplierOrder &&
                                                                            a.OrderInNumber == supplierOrderNumber &&
                                                                            a.OrderInItemNumber == supplierOrderItemNumber &&
                                                                            a.SourceType != allocationInventoryType &&
                                                                            a.OrderOutType == (int)OrderType.CustomerOrder)
                                                                .OrderBy(a => a.OrderOutTargetShipDate).ToList();

            return new List<SupplierOrderAllocation>(supplierOrderAllocations.Select(a => new SupplierOrderAllocation(a.AllocationNumber)
            {
                Quantity = a.AllocationQuantity,
                OrderOutNumber = a.OrderOutNumber,
                OrderOutItemNumber = a.OrderOutItemNumber,
                BinNumber = a.BinNumber,
                SourceType = a.SourceType,
                OrderInReceiveDate = a.OrderInReceiveDate,
                OrderInNumber = a.OrderInNumber,
                OrderOutType = a.OrderOutType,
                OrderOutItemDate = a.OrderOutItemDate,
                OrderOutEntityName = a.OrderOutEntityName,
                OrderOutEntityReference = a.OrderOutEntityReference,
                OrderOutEntityNumber = a.OrderOutEntityNumber,
                OrderOutEntitySubNumber = a.OrderOutEntitySubNumber,
                OrderOutTeamMemberNumber = a.OrderOutTeamMemberNumber,
                OrderOutTargetShipDate = a.OrderOutTargetShipDate,
                OrderOutOnDockdate = a.OrderOutOnDockdate,
                OrderOutSOR = a.OrderOutSor,
                CompanyNumber = a.CdicompanyNumber
            }));
        }

        public void UpdateSupplierOrderAllocation(SupplierOrderAllocation allocation)
        {
            var item = dbContext.Allocations.Find(allocation.Id);

            if (item != null)
            {
                item.AllocationQuantity = allocation.Quantity;
                item.BinNumber = allocation.BinNumber;
                item.SourceType = allocation.SourceType;
                item.OrderInReceiveDate = allocation.OrderInReceiveDate;
                item.OrderInNumber = allocation.OrderInNumber;
            }
        }

        public void DeleteSupplierOrderAllocation(SupplierOrderAllocation allocation)
        {
            var item = dbContext.Allocations.Find(allocation.Id);

            if (item != null)
            {
                dbContext.Remove(item);
            }
        }
    }
}
