namespace WarehouseManagement.Domain.Enums
{
    public enum EventType
    {
        DealQtyLimitExceeded = 10,
        InventoryReceivedEarly = 14,
        PmExpediteResponse = 17,
        InventoryReceivedSuccess = 43,
        InventoryReceivedWarning = 44,
        InventoryReceivedError = 45,
        InventoryShippedSuccess = 46,
        InventoryShippedError = 47,
    }
}
