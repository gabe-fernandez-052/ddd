namespace WarehouseManagement.Domain.Entities
{
    public class CustomerOrder(int id) : Entity<int>(id)
    {
        public int EntityNumber { get; init; }
        public string? LocationName { get; init; }
        public int CustomerLocationNumber { get; init; }
        public int BranchNumber { get; init; }
        public int ContactNumber { get; init; }
        public string EntityReference { get; init; } = string.Empty;
        public int TeamMemberNumber { get; init; }
        public string CurrencyCode { get; init; } = string.Empty;
        public short PaymentTermsType { get; init; }
        public double? OrderCreditCardFreightCharge { get; init; }
        public int CompanyNumber { get; init; }
        public int? EndCustomerNumber { get; init; }
        public int? EndLocationNumber { get; init; }
        public string? EntityName { get; init; }
        public decimal? FreightAmount { get; init; }
        public string DocumentLanguage { get; init; } = string.Empty;
        public int OrderType { get; init; }
        public List<CustomerOrderItem> Items { get; set; } = [];
        public bool? ApplyCurrencyBillingAdjustment { get; init; }
        public string? BillingAdjustmentCurrency { get; init; }
        public decimal? BillingAdjustmentRate { get; init; }
    }
}
