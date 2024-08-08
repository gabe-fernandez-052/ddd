using WarehouseManagement.Domain.Aggregates;

namespace WarehouseManagement.API.Responses
{
    public record ReceiveResponseDto
    {
        public ReceiveResponseDto(Receiver receiver)
        {
            ReceivedNumber = receiver.Id;
            ReceivedItems = receiver.ReceiverItems.Select(x => new ReceiveItemResponseDto(x.Id, x.SupplierOrderItemNumber)).ToList();
        }

        public int ReceivedNumber { get; }

        public List<ReceiveItemResponseDto> ReceivedItems { get; }
    }

    public record ReceiveItemResponseDto(int ReceivedItemNumber, int SupplierOrderItemNumber) { }
}
