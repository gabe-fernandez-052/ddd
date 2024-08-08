namespace WarehouseManagement.Domain.Entities
{
    public abstract class Entity<TId>(TId id)
    {
        public TId Id { get; } = id;
    }
}
