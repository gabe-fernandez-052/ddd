using WarehouseManagement.Domain.Aggregates;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.Enums;
using WarehouseManagement.Domain.Exceptions;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Domain.ValueObjects;

namespace WarehouseManagement.Domain.Services
{
    public class ReceivingService(IReceivingUnitOfWork unitOfWork) : IReceivingService
    {
        private int _warehouseNumber;
        private int _branchNumber;
        private int _whoLastUpdated;
        private const int OPEN_STATUS = 0;
        private const int ORDER_TRANSACTION_TYPE = 1;

        public Receiver Receive(int supplierOrderNumber, Guid clientId, int warehouseNumber, string trackingNumber, string invoiceNumber, string packingListNumber, List<ReceiveItem> itemsToReceive)
        {
            var companyNumber = unitOfWork.WarehouseManagementRepository.GetCompany(clientId) ?? throw new Exception($"No company record found for client id provided");

            _whoLastUpdated = unitOfWork.WarehouseManagementRepository.GetWhoLastUpdatedIdentity(companyNumber) ?? throw new Exception($"No API identity configuration found");
            _warehouseNumber = warehouseNumber;
            _branchNumber = unitOfWork.WarehouseManagementRepository.GetBranchNumber(_warehouseNumber);

            try
            {
                var itemReceivedStatus = 2;
                var supplierOrder = unitOfWork.SupplierOrderRepository.GetSupplierOrder(supplierOrderNumber, companyNumber) ?? throw new ReceivingException("Supplier order not found");
                var itemsToReceiveAndSupplierOrderItems = new List<Tuple<ReceiveItem, SupplierOrderItem>>();

                foreach (var itemToReceive in itemsToReceive)
                {
                    var itemQuantityToReceive = itemToReceive.Quantity;
                    var supplierOrderItems = supplierOrder.SupplierOrderItems.Where(soi => soi.ProductPartNumber.ToLower().Equals(itemToReceive.PartNumber.ToLower()) &&
                                                                                   soi.WarehouseNumber == _warehouseNumber &&
                                                                                   soi.Status == OPEN_STATUS)
                                                                             .OrderBy(soi => soi.ReceiveDate).ToList();

                    foreach (var supplierOrderItem in supplierOrderItems)
                    {
                        if (itemQuantityToReceive + supplierOrderItem.AmountReceived >= supplierOrderItem.Quantity)
                        {
                            var itemQuantityReceived = supplierOrderItem.Quantity - supplierOrderItem.AmountReceived;
                            itemQuantityToReceive -= itemQuantityReceived;

                            supplierOrderItem.AmountReceived = supplierOrderItem.Quantity;
                            supplierOrderItem.ReceiveDate = itemToReceive.DateReceived;
                            supplierOrderItem.Status = itemReceivedStatus;

                            unitOfWork.SupplierOrderRepository.UpdateSupplierOrderItem(supplierOrderNumber, supplierOrderItem);

                            itemsToReceiveAndSupplierOrderItems.Add(new Tuple<ReceiveItem, SupplierOrderItem>(new ReceiveItem(itemToReceive.PartNumber, itemQuantityReceived, itemToReceive.LotCode, itemToReceive.DateCode, itemToReceive.LocationInfo, itemToReceive.ThirdPartyReference, itemToReceive.DateReceived), supplierOrderItem));
                        }
                        else if (itemQuantityToReceive > 0)
                        {
                            itemsToReceiveAndSupplierOrderItems.Add(new Tuple<ReceiveItem, SupplierOrderItem>(new ReceiveItem(itemToReceive.PartNumber, itemQuantityToReceive, itemToReceive.LotCode, itemToReceive.DateCode, itemToReceive.LocationInfo, itemToReceive.ThirdPartyReference, itemToReceive.DateReceived), supplierOrderItem));

                            var eventNote = $"{itemQuantityToReceive} quantity received. {supplierOrderItem.Quantity - supplierOrderItem.AmountReceived} expected for part number: {supplierOrderItem.ProductPartNumber}.";

                            if (!supplierOrderItem.IsPartial)
                            {
                                eventNote += " Supplier order item is not marked as partial.";
                            }

                            unitOfWork.EventRepository.CreateEvent(EventType.InventoryReceivedWarning,
                                                                   $"{ORDER_TRANSACTION_TYPE},{(int)OrderType.SupplierOrder},{supplierOrder.Id},{supplierOrderItem.Id}",
                                                                   eventNote,
                                                                   _whoLastUpdated,
                                                                   _branchNumber);

                            supplierOrderItem.AmountReceived += itemQuantityToReceive;
                            itemQuantityToReceive = 0;

                            unitOfWork.SupplierOrderRepository.UpdateSupplierOrderItem(supplierOrderNumber, supplierOrderItem);
                        }

                        if (itemQuantityToReceive != 0 && supplierOrderItem == supplierOrderItems.Last())
                        {
                            unitOfWork.EventRepository.CreateEvent(EventType.InventoryReceivedWarning,
                                                                   $"{ORDER_TRANSACTION_TYPE},{(int)OrderType.SupplierOrder},{supplierOrder.Id},{supplierOrderItem.Id}",
                                                                   $"Excessive quantity amount provided for part number: {supplierOrderItem.ProductPartNumber}.",
                                                                   _whoLastUpdated,
                                                                   _branchNumber);
                        }
                    }
                }

                if (itemsToReceiveAndSupplierOrderItems.Count == 0)
                {
                    throw new ReceivingException($"No supplier order items found to be received. " +
                        $"Please validate part number, warehouse number, quantity and supplier order item status");
                }

                var receiver = unitOfWork.ReceivingRepository.CreateReceiver(_whoLastUpdated, _branchNumber, _warehouseNumber, companyNumber, supplierOrder.Id, trackingNumber, invoiceNumber, packingListNumber, supplierOrder.DocumentLanguage);
                var receiverItemNumberSeed = 1;

                foreach (var itemToReceiveAndSupplierOrderItem in itemsToReceiveAndSupplierOrderItems)
                {
                    var itemToReceive = itemToReceiveAndSupplierOrderItem.Item1;
                    var supplierOrderItem = itemToReceiveAndSupplierOrderItem.Item2;

                    var receiverItem = unitOfWork.ReceivingRepository.CreateReceiverItem(supplierOrder, supplierOrderItem, itemToReceive, _whoLastUpdated, _branchNumber, receiver.Id, receiverItemNumberSeed);
                    receiverItemNumberSeed++;

                    unitOfWork.InventoryRepository.CreateInventory(receiverItem, warehouseNumber, _whoLastUpdated, _branchNumber, companyNumber, itemToReceive.LotCode, itemToReceive.DateCode, itemToReceive.LocationInfo, itemToReceive.ThirdPartyReference);

                    foreach (var orderLineItem in TransferAllocations(receiverItem, supplierOrder.Id, supplierOrderItem.Id).DistinctBy(oli => oli.Id))
                    {
                        UpdateOrderItemStatusAndGenerateEvents(orderLineItem);
                    }

                    receiver.AddReceivedItem(receiverItem);

                    unitOfWork.EventRepository.CreateEvent(EventType.InventoryReceivedSuccess,
                                                   $"{ORDER_TRANSACTION_TYPE},{(int)OrderType.SupplierOrder},{supplierOrder.Id},{supplierOrderItem.Id}",
                                                   string.Empty,
                                                   _whoLastUpdated,
                                                   _branchNumber);
                }

                unitOfWork.SaveChanges();

                return receiver;
            }
            catch (Exception e)
            {
                unitOfWork.ClearChanges();

                unitOfWork.EventRepository.CreateEvent(EventType.InventoryReceivedError,
                                                       $"{ORDER_TRANSACTION_TYPE},{(int)OrderType.SupplierOrder},{supplierOrderNumber}",
                                                       $"The following error has occurred for supplier order {supplierOrderNumber}: {e.GetBaseException().Message}",
                                                       _whoLastUpdated,
                                                       _branchNumber);

                unitOfWork.SaveChanges();

                throw;
            }
        }

        private List<OrderLineItem> TransferAllocations(ReceiverItem receiverItem, int supplierOrderNumber, int supplierOrderItemNumber)
        {
            var orderLineItems = new List<OrderLineItem>();
            var quantityRemaining = receiverItem.Quantity;

            foreach (var supplierOrderAllocation in unitOfWork.SupplierOrderRepository.GetSupplierOrderAllocations(supplierOrderNumber, supplierOrderItemNumber))
            {
                var inventorySourceType = 0;
                var transferAll = supplierOrderAllocation.Quantity <= quantityRemaining;
                var quantityToTransfer = transferAll ? supplierOrderAllocation.Quantity : quantityRemaining;

                if (quantityRemaining <= 0)
                {
                    break;
                }

                var existingInventoryAllocation = unitOfWork.OrderRepository.GetOrderInventoryAllocation(supplierOrderAllocation.OrderOutNumber, supplierOrderAllocation.OrderOutItemNumber, inventorySourceType, _warehouseNumber);

                if (existingInventoryAllocation != null)
                {
                    var orderLineItem = unitOfWork.OrderRepository.GetOrderLineItem(existingInventoryAllocation.OrderOutNumber, existingInventoryAllocation.OrderOutItemNumber);

                    existingInventoryAllocation.Quantity = Math.Min(existingInventoryAllocation.Quantity + quantityToTransfer, orderLineItem!.Quantity - orderLineItem.QuantityShipped);

                    orderLineItem.QuantityAllocatedToInventory = existingInventoryAllocation.Quantity;
                    orderLineItems.Add(orderLineItem);

                    unitOfWork.OrderRepository.UpdateOrderInventoryAllocation(existingInventoryAllocation);

                    if (transferAll)
                    {
                        unitOfWork.SupplierOrderRepository.DeleteSupplierOrderAllocation(supplierOrderAllocation);
                        quantityRemaining -= quantityToTransfer;

                        continue;
                    }
                    else
                    {
                        supplierOrderAllocation.Quantity -= quantityToTransfer;
                    }
                }
                else
                {
                    if (transferAll)
                    {
                        var orderLineItem = unitOfWork.OrderRepository.GetOrderLineItem(supplierOrderAllocation.OrderOutNumber, supplierOrderAllocation.OrderOutItemNumber);

                        orderLineItem!.QuantityAllocatedToInventory = supplierOrderAllocation.Quantity;
                        orderLineItems.Add(orderLineItem);

                        supplierOrderAllocation.SourceType = inventorySourceType;
                        supplierOrderAllocation.OrderInReceiveDate = DateTime.Now.Date;
                        supplierOrderAllocation.OrderInNumber = null;
                    }
                    else
                    {
                        supplierOrderAllocation.Quantity -= quantityToTransfer;
                        unitOfWork.InventoryRepository.CreateInventoryAllocation(receiverItem, supplierOrderAllocation, inventorySourceType, quantityToTransfer, _warehouseNumber);
                    }
                }

                quantityRemaining -= quantityToTransfer;

                unitOfWork.SupplierOrderRepository.UpdateSupplierOrderAllocation(supplierOrderAllocation);
            }

            return orderLineItems;
        }

        private void UpdateOrderItemStatusAndGenerateEvents(OrderLineItem orderLineItem)
        {
            var expediteClosedStatus = 1;
            var expeditePMResponseSubStatus = 1;

            if (orderLineItem.QuantityAllocatedToInventory == (orderLineItem.Quantity - orderLineItem.QuantityShipped))
            {
                orderLineItem.SubStatus = (int)OrderLineItemSubStatus.ReadyToShip;
            }
            else if (orderLineItem.QuantityAllocatedToInventory > 0)
            {
                orderLineItem.SubStatus = (int)OrderLineItemSubStatus.AllocatedPartialInventory;
            }

            if (orderLineItem.SubStatus == (int)OrderLineItemSubStatus.ReadyToShip &&
               (orderLineItem.ShipAsap || orderLineItem.RequestDate < DateTime.Now.Date))
            {
                orderLineItem.TargetShipDate = DateTime.Now.Date;
            }

            var isOverdueOrAsap = orderLineItem.TargetShipDate <= DateTime.Now.Date || orderLineItem.ShipAsap;
            var isPartialOrReadyToShip = orderLineItem.IsPartial || orderLineItem.SubStatus == (int)OrderLineItemSubStatus.ReadyToShip;

            var wouldShipNormally = isOverdueOrAsap && isPartialOrReadyToShip;

            if (orderLineItem.DockDate > orderLineItem.RequestDate && !wouldShipNormally)
            {
                unitOfWork.EventRepository.CreateEvent(EventType.InventoryReceivedEarly,
                                                       $"{(int)OrderType.CustomerOrder},{orderLineItem.OrderNumber},{orderLineItem.Id}",
                                                       string.Empty,
                                                       _whoLastUpdated,
                                                       _branchNumber);
            }

            if (orderLineItem.SubStatus == (int)OrderLineItemSubStatus.ReadyToShip)
            {
                var expedites = unitOfWork.OrderRepository.GetOrderCustomerExpedites(orderLineItem.OrderNumber, orderLineItem.Id, OPEN_STATUS);

                foreach (var expediteItem in expedites)
                {
                    expediteItem.Status = expediteClosedStatus;
                    expediteItem.SubStatus = expeditePMResponseSubStatus;

                    unitOfWork.OrderRepository.UpdateOrderCustomerExpedite(expediteItem);
                }

                if (expedites.Any())
                {
                    unitOfWork.EventRepository.CreateEvent(EventType.PmExpediteResponse,
                                                           $"{(int)OrderType.CustomerOrder},{orderLineItem.OrderNumber},{orderLineItem.Id}",
                                                           string.Empty,
                                                           _whoLastUpdated,
                                                           _branchNumber);
                }
            }

            unitOfWork.OrderRepository.UpdateOrderLineItem(orderLineItem);
        }
    }
}
