using System.ComponentModel.DataAnnotations;
using WarehouseManagement.API.ValidationAttributes;

namespace WarehouseManagement.API.Requests
{
    public record ReceiveRequestDto
    {
        [Range(1, int.MaxValue)]
        public int SupplierOrderNumber { get; init; }

        [Range(1, int.MaxValue)]
        public int WarehouseNumber { get; init; }

        [StringLength(50)]
        public string TrackingNumber { get; init; } = string.Empty;

        [StringLength(30)]
        public string InvoiceNumber { get; init; } = string.Empty;

        [StringLength(30)]
        public string PackingListNumber { get; set; } = string.Empty;

        [Required]
        [EnsureNotEmpty]
        public List<ReceiveItemDto> Items { get; init; } = [];
    }
}
