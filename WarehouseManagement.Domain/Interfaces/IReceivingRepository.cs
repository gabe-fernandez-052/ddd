using WarehouseManagement.Domain.Aggregates;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.ValueObjects;

namespace WarehouseManagement.Domain.Interfaces
{
    public interface IReceivingRepository
    {
        Receiver CreateReceiver(int whoLastUpdated, int branchNumber, int warehouseNumber, int companyNumber, int supplierOrderNumber,
                                       string trackingNumber, string invoiceNumber, string packingListNumber, string documentLanguage);

        ReceiverItem CreateReceiverItem(SupplierOrder supplierOrder, SupplierOrderItem supplierOrderItem, ReceiveItem itemToReceive, int whoLastUpdated, int branchNumber, int receiverNumber, int receiverItemNumber);
    }
}
