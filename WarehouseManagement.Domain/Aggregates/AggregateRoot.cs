using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Domain.Aggregates
{
    public abstract class AggregateRoot<TId>(TId id) : Entity<TId>(id)
    {
    }
}
