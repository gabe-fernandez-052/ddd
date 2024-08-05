using WarehouseManagement.Domain.Aggregates;
using WarehouseManagement.Domain.ValueObjects;

namespace WarehouseManagement.Domain.Interfaces
{
    public interface IReceivingService
    {
        Receiver Receive(int supplierOrderNumber, Guid clientId, int warehouseNumber, string trackingNumber, string invoiceNumber, string packingListNumber, List<ReceiveItem> itemsToReceive);
    }
}
