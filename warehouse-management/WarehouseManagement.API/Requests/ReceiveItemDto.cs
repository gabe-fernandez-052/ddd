using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.Requests
{
    public record ReceiveItemDto
    {
        [Required(AllowEmptyStrings = false)]
        public string PartNumber { get; init; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int Quantity { get; init; }

        [StringLength(20)]
        public string LotCode { get; init; } = string.Empty;

        [StringLength(20)]
        public string DateCode { get; init; } = string.Empty;

        [StringLength(100)]
        public string LocationInfo { get; init; } = string.Empty;

        [StringLength(30)]
        [Required(AllowEmptyStrings = false)]
        public string ThirdPartyReference { get; init; } = string.Empty;

        [Required]
        public DateTime DateReceived { get; init; }
    }
}
