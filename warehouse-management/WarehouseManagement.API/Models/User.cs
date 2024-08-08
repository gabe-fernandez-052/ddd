namespace WarehouseManagement.Infrastructure.Models
{
    public record User()
    {
        public Guid ClientId { get; init; }
        public string[] Roles { get; init; } = [];
    }
}
