using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Domain.ValueObjects;
using WarehouseManagement.Infrastructure.Data.Scaffold;
using Receiver = WarehouseManagement.Domain.Aggregates.Receiver;
using SupplierOrder = WarehouseManagement.Domain.Entities.SupplierOrder;
using SupplierOrderItem = WarehouseManagement.Domain.Entities.SupplierOrderItem;

namespace WarehouseManagement.Infrastructure.Data.Repositories
{
    public class ReceivingRepository(WarehouseManagementContext dbContext) : IReceivingRepository
    {
        private const int OPEN_STATUS = 0;
        private const int RECEIVER_SHIPMENT_TYPE = 2;

        public Receiver CreateReceiver(int whoLastUpdated, int branchNumber,
                                       int warehouseNumber, int companyNumber, int supplierOrderNumber,
                                       string trackingNumber, string invoiceNumber, string packingListNumber, string documentLanguage)
        {
            var receiver = new Scaffold.Receiver
            {
                WhoLastUpdated = whoLastUpdated,
                BranchLastUpdated = branchNumber,
                DateLastUpdated = DateTime.Now.Date,
                ReceiverType = RECEIVER_SHIPMENT_TYPE,
                ReceiverNumber = CreateUniqueEntityId(),
                WarehouseNumber = warehouseNumber,
                ReceiverDate = DateTime.Now.Date,
                CdicompanyNumber = companyNumber,
                ReceiverStatus = OPEN_STATUS,
                TrackingNumber = !string.IsNullOrWhiteSpace(trackingNumber) ? trackingNumber : invoiceNumber,
                ReceiverPackingList = packingListNumber,
                DocumentLanguage = documentLanguage
            };

            dbContext.Receivers.Add(receiver);
            dbContext.ReceiverSupplierOrders.Add(new ReceiverSupplierOrder()
            {
                ReceiverNumber = receiver.ReceiverNumber,
                SupplierOrderNumber = supplierOrderNumber,
                ReceiverInvoiceNumber = invoiceNumber,
                DateLastUpdated = DateTime.Now.Date,
                WhoLastUpdated = whoLastUpdated,
                BranchLastUpdated = branchNumber
            });

            return new Receiver(receiver.ReceiverNumber);
        }

        public Domain.Entities.ReceiverItem CreateReceiverItem(SupplierOrder supplierOrder,
                                                SupplierOrderItem supplierOrderItem, ReceiveItem itemToReceive, int whoLastUpdated, int branchNumber, int receiverNumber,
                                                int receiverItemNumber)
        {
            var receiverItem = new ReceiverItem()
            {
                WhoLastUpdated = whoLastUpdated,
                BranchLastUpdated = branchNumber,
                DateLastUpdated = DateTime.Now.Date,
                ReceiverNumber = receiverNumber,
                ReceiverItemNumber = receiverItemNumber,
                ProductNumber = supplierOrderItem.ProductNumber,
                FormatNumber = supplierOrderItem.FormatNumber,
                ReceiverType = RECEIVER_SHIPMENT_TYPE,
                ReceiverItemCost = supplierOrderItem.UnitCost,
                ReceiverItemMatchCost = supplierOrderItem.UnitCost,
                ReceiverItemQuantity = itemToReceive.Quantity,
                ReceiverItemStatus = OPEN_STATUS,
                ReceiverItemDate = itemToReceive.DateReceived,
                CostCurrencyCode = supplierOrder.CurrencyCode,
                CountryOfOrigin = supplierOrderItem.ProductOriginCountry,
                CostExchangeRate = 1m
            };

            dbContext.ReceiverItems.Add(receiverItem);
            dbContext.ReceiverOrderItems.Add(new ReceiverOrderItem()
            {
                ReceiverNumber = receiverNumber,
                ReceiverItemNumber = receiverItemNumber,
                SupplierOrderNumber = supplierOrder.Id,
                SupplierOrderItemNumber = supplierOrderItem.Id,
                DateLastUpdated = DateTime.Now.Date,
                WhoLastUpdated = whoLastUpdated,
                BranchLastUpdated = branchNumber
            });

            return new Domain.Entities.ReceiverItem(receiverItem.ReceiverItemNumber)
            {
                SupplierOrderItemNumber = supplierOrderItem.Id,
                ProductNumber = receiverItem.ProductNumber,
                FormatNumber = receiverItem.FormatNumber,
                ReceiverNumber = receiverItem.ReceiverNumber,
                Date = receiverItem.ReceiverItemDate,
                Quantity = receiverItem.ReceiverItemQuantity,
                Cost = receiverItem.ReceiverItemCost,
                CurrencyCode = receiverItem.CostCurrencyCode
            };
        }

        private int CreateUniqueEntityId()
        {
            var lastNumber = 0;
            var hostBranch = 3;
            var receiverEntityName = "Receiver";

            using (var nextNumbersDbContext = new NextNumbersContext(dbContext.Database.GetConnectionString()!))
            {
                var nextNumber = nextNumbersDbContext.NextNumbers.FirstOrDefault(n => n.BranchNumber == hostBranch &&
                                                                       n.EntityName.ToLower().Equals(receiverEntityName.ToLower())) ?? throw new Exception($"Entity: {receiverEntityName} not found in next numbers table");
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
