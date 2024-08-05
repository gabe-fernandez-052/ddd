namespace WarehouseManagement.Domain.ValueObjects
{
    public class Address(string? address1, string? address2, string? city, string? state, string? postalCode, string? countryCode) : ValueObject
    {
        public string? Address1 { get; } = address1;

        public string? Address2 { get; } = address2;

        public string? City { get; } = city;

        public string? State { get; } = state;

        public string? PostalCode { get; } = postalCode;

        public string? CountryCode { get; } = countryCode;

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Address1;
            yield return Address2;
            yield return City;
            yield return State;
            yield return PostalCode;
            yield return CountryCode;
        }
    }
}
