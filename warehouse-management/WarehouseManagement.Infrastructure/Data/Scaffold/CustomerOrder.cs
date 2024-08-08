using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("CustomerOrder")]
public partial class CustomerOrder
{
    [Key]
    public int OrderNumber { get; set; }

    public int ContactNumber { get; set; }

    public int TeamMemberNumber { get; set; }

    public int BranchNumber { get; set; }

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    public int CustomerNumber { get; set; }

    public int LocationNumber { get; set; }

    [Column("OrderCustomerPO")]
    [StringLength(30)]
    public string OrderCustomerPo { get; set; } = null!;

    public short PaymentTermsType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime OrderDate { get; set; }

    public short OrderStatus { get; set; }

    public bool OrderShipComplete { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    public int? NoteNumber { get; set; }

    [StringLength(50)]
    public string? OrderEndCustomer { get; set; }

    public int? OrderPhase { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    public int? OpportunityNumber { get; set; }

    public int? EndCustomerNumber { get; set; }

    public int? EndLocationNumber { get; set; }

    [StringLength(60)]
    public string? ShippingAttention { get; set; }

    [StringLength(50)]
    public string? OrderCustomerApplication { get; set; }

    [StringLength(50)]
    public string? OrderCustomerProject { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal? TaxAmount { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal? FreightAmount { get; set; }

    [StringLength(50)]
    public string? Incoterms { get; set; }

    [StringLength(50)]
    public string? SingleUseResaleNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TaxRateVerificationDate { get; set; }

    public int? DestinationCustomerNumber { get; set; }

    public int? DestinationLocationNumber { get; set; }

    [StringLength(2)]
    public string DocumentLanguage { get; set; } = null!;

    public bool? ApplyCurrencyBillingAdjustment { get; set; }

    [StringLength(3)]
    public string? BillingAdjustmentCurrency { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal? BillingAdjustmentRate { get; set; }

    [ForeignKey("BranchNumber")]
    [InverseProperty("CustomerOrders")]
    public virtual Branch BranchNumberNavigation { get; set; } = null!;

    [ForeignKey("CdicompanyNumber")]
    [InverseProperty("CustomerOrders")]
    public virtual Cdicompany CdicompanyNumberNavigation { get; set; } = null!;

    [ForeignKey("CustomerNumber, LocationNumber")]
    [InverseProperty("CustomerOrders")]
    public virtual CustomerLocation CustomerLocation { get; set; } = null!;

    [ForeignKey("CustomerNumber")]
    [InverseProperty("CustomerOrders")]
    public virtual Customer CustomerNumberNavigation { get; set; } = null!;

    [ForeignKey("EndCustomerNumber, EndLocationNumber")]
    [InverseProperty("CustomerOrders")]
    public virtual InternalLocation? InternalLocation { get; set; }

    [ForeignKey("OpportunityNumber")]
    [InverseProperty("CustomerOrders")]
    public virtual Opportunity? OpportunityNumberNavigation { get; set; }

    [InverseProperty("OrderNumberNavigation")]
    public virtual OrderCreditCardAuthorization? OrderCreditCardAuthorization { get; set; }

    [InverseProperty("OrderNumberNavigation")]
    public virtual ICollection<OrderLineItem> OrderLineItems { get; set; } = new List<OrderLineItem>();

    [ForeignKey("PaymentTermsType")]
    [InverseProperty("CustomerOrders")]
    public virtual PaymentTerm PaymentTermsTypeNavigation { get; set; } = null!;

    [InverseProperty("OrderNumberNavigation")]
    public virtual ICollection<ShipmentCustomerOrder> ShipmentCustomerOrders { get; set; } = new List<ShipmentCustomerOrder>();
}
