namespace WarehouseManagement.Domain.ValueObjects
{
    public class ReceiveItem(string partNumber, int quantity, string lotCode, string dateCode, string locationInfo, string thirdPartyReference, DateTime dateReceived) : ValueObject
    {
        public string PartNumber { get; } = partNumber;

        public int Quantity { get; } = quantity;

        public string LotCode { get; } = lotCode;

        public string DateCode { get; } = dateCode;

        public string LocationInfo { get; } = locationInfo;

        public string ThirdPartyReference { get; } = thirdPartyReference;

        public DateTime DateReceived { get; } = dateReceived;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PartNumber;
            yield return Quantity;
            yield return LotCode;
            yield return DateCode;
            yield return LocationInfo;
            yield return ThirdPartyReference;
            yield return DateReceived;
        }
    }
}
