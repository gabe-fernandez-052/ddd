namespace WarehouseManagement.Domain.Enums
{
    public enum OrderLineItemSubStatus
    {
        AllocatedConfirmed = 2,
        NeedProduct = 3,
        AllocatedPartialInventory = 4,
        Allocated = 5,
        ReadyToShip = 6
    }
}
