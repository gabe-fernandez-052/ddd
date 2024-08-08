using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Domain.Aggregates
{
    public class Receiver(int receiverNumber) : AggregateRoot<int>(receiverNumber)
    {
        private readonly List<ReceiverItem> _receiverItems = [];

        public IReadOnlyCollection<ReceiverItem> ReceiverItems => _receiverItems;

        public void AddReceivedItem(ReceiverItem receiverItem) => _receiverItems.Add(receiverItem);
    }
}
