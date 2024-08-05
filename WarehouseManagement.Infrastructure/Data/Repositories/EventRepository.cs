using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Domain.Enums;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Infrastructure.Data.Scaffold;

namespace WarehouseManagement.Infrastructure.Data.Repositories
{
    public class EventRepository(WarehouseManagementContext dbContext) : IEventRepository
    {
        /// <inheritdoc />
        public void CreateEvent(EventType eventType, string eventKey, string? eventNote, int? whoLastUpdated, int? branchNumber)
        {
            var eventAlert = new Event()
            {
                EventId = CreateUniqueEntityId(),
                EventType = (int)eventType,
                EventKey = eventKey,
                DateLastUpdated = DateTime.Now.Date,
                WhoLastUpdated = whoLastUpdated,
                BranchLastUpdated = branchNumber
            };

            dbContext.Events.Add(eventAlert);

            if (!string.IsNullOrWhiteSpace(eventNote))
            {
                dbContext.EventNotes.Add(new EventNote()
                {
                    EventId = eventAlert.EventId,
                    Note = eventNote.Length > 256 ? eventNote[..256] : eventNote
                });
            }
        }

        private int CreateUniqueEntityId()
        {
            var lastNumber = 0;
            var hostBranch = 3;
            var eventEntityName = "Event";

            using (var nextNumbersDbContext = new NextNumbersContext(dbContext.Database.GetConnectionString()!))
            {
                var nextNumber = nextNumbersDbContext.NextNumbers.FirstOrDefault(n => n.BranchNumber == hostBranch &&
                                                                           n.EntityName.ToLower().Equals(eventEntityName.ToLower())) ?? throw new Exception($"Entity: {eventEntityName} not found in next numbers table");
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
