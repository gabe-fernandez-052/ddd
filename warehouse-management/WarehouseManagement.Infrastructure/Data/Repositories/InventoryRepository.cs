using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Infrastructure.Data.Scaffold;
using ReceiverItem = WarehouseManagement.Domain.Entities.ReceiverItem;

namespace WarehouseManagement.Infrastructure.Data.Repositories
{
    public class InventoryRepository(WarehouseManagementContext dbContext) : IInventoryRepository
    {
        public void CreateInventory(ReceiverItem receiverItem, int warehouseNumber, int whoLastUpdated, int branchNumber, int companyNumber, string lotCode, string dateCode, string locationInfo, string thirdPartyReference)
        {
            if (dbContext.WarehouseInventories.Find(receiverItem.ProductNumber, receiverItem.FormatNumber, warehouseNumber) == null)
            {
                dbContext.WarehouseInventories.Add(new WarehouseInventory()
                {
                    ProductNumber = receiverItem.ProductNumber,
                    FormatNumber = receiverItem.FormatNumber,
                    WarehouseNumber = warehouseNumber,
                    DateLastUpdated = DateTime.Now.Date,
                    WhoLastUpdated = whoLastUpdated,
                    BranchLastUpdated = branchNumber
                });
            }

            var inventoryBin = new InventoryBin()
            {
                BinNumber = CreateUniqueEntityId("InventoryBin"),
                ReceiverNumber = receiverItem.ReceiverNumber,
                ReceiverItemNumber = receiverItem.Id,
                WarehouseNumber = warehouseNumber,
                ProductNumber = receiverItem.ProductNumber,
                FormatNumber = receiverItem.FormatNumber,
                BinDateReceived = receiverItem.Date,
                BinQuantityRemaining = receiverItem.Quantity,
                BinQuantityOriginal = receiverItem.Quantity,
                BinUnitCost = receiverItem.Cost,
                BinStatus = 0,
                DateLastUpdated = DateTime.Now.Date,
                WhoLastUpdated = whoLastUpdated,
                BranchLastUpdated = branchNumber,
                CdicompanyNumber = companyNumber,
                CurrencyCode = receiverItem.CurrencyCode,
                LotCode = lotCode,
                ManufacturerDateCode = dateCode,
                LocationInfo = locationInfo,
                ThirdPartyReference = thirdPartyReference
            };

            dbContext.InventoryBins.Add(inventoryBin);
        }

        public void CreateInventoryAllocation(ReceiverItem receiverItem, SupplierOrderAllocation supplierOrderAllocation, int allocationSourceType, int quantityToTransfer, int warehouseNumber)
        {
            var inventoryAllocation = new Allocation()
            {
                AllocationNumber = CreateUniqueEntityId("Allocation"),
                SourceType = allocationSourceType,
                AllocationQuantity = quantityToTransfer,
                ProductNumber = receiverItem.ProductNumber,
                FormatNumber = receiverItem.FormatNumber,
                OrderInReceiveDate = receiverItem.Date,
                WarehouseNumber = warehouseNumber,
                OrderOutType = supplierOrderAllocation.OrderOutType,
                OrderOutNumber = supplierOrderAllocation.OrderOutNumber,
                OrderOutItemNumber = supplierOrderAllocation.OrderOutItemNumber,
                OrderOutItemDate = supplierOrderAllocation.OrderOutItemDate,
                OrderOutEntityName = supplierOrderAllocation.OrderOutEntityName,
                OrderOutEntityReference = supplierOrderAllocation.OrderOutEntityReference,
                OrderOutEntityNumber = supplierOrderAllocation.OrderOutEntityNumber,
                OrderOutEntitySubNumber = supplierOrderAllocation.OrderOutEntitySubNumber,
                OrderOutTeamMemberNumber = supplierOrderAllocation.OrderOutTeamMemberNumber,
                OrderOutTargetShipDate = supplierOrderAllocation.OrderOutTargetShipDate,
                OrderOutOnDockdate = supplierOrderAllocation.OrderOutOnDockdate,
                OrderOutSor = supplierOrderAllocation.OrderOutSOR,
                CdicompanyNumber = supplierOrderAllocation.CompanyNumber
            };

            dbContext.Allocations.Add(inventoryAllocation);
        }

        private int CreateUniqueEntityId(string entityName)
        {
            var lastNumber = 0;
            var hostBranch = 3;

            using (var nextNumbersDbContext = new NextNumbersContext(dbContext.Database.GetConnectionString()!))
            {
                var nextNumber = nextNumbersDbContext.NextNumbers.FirstOrDefault(n => n.BranchNumber == hostBranch &&
                                                                       n.EntityName.ToLower().Equals(entityName.ToLower())) ?? throw new Exception($"Entity: {entityName} not found in next numbers table");
                if (nextNumber.LastNumber == nextNumber.MaxNumber)
                {
                    nextNumber.MaxNumber += 5000;
                }

                nextNumber.LastNumber += 1;
                lastNumber = nextNumber.LastNumber;

                nextNumbersDbContext.SaveChanges();
            }

            return lastNumber;
        }
    }
}
