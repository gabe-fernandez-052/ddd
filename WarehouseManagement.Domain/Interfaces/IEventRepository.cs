using WarehouseManagement.Domain.Enums;

namespace WarehouseManagement.Domain.Interfaces
{
    public interface IEventRepository
    {
        /// <summary>
        /// Create a new event alert.
        /// </summary>
        /// <remarks>
        /// A null or whitespace <paramref name="eventNote"/> will not be added.
        /// </remarks>
        /// <param name="eventType"></param>
        /// <param name="eventKey"></param>
        /// <param name="eventNote">Optional note to add to the event.</param>
        /// <param name="whoLastUpdated"></param>
        /// <param name="branchNumber"></param>
        void CreateEvent(EventType eventType, string eventKey, string? eventNote, int? whoLastUpdated, int? branchNumber);
    }
}
