using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("OrderCreditCardAuthorization")]
public partial class OrderCreditCardAuthorization
{
    [Key]
    public int OrderNumber { get; set; }

    public short OrderCreditCardType { get; set; }

    [StringLength(50)]
    public string OrderCreditCardHolderName { get; set; } = null!;

    public double OrderCreditCardProductCharge { get; set; }

    public double OrderCreditCardFreightCharge { get; set; }

    public double OrderCreditCardTaxCharge { get; set; }

    public double OrderCreditCardOtherCharge { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime OrderCreditCardExpiration { get; set; }

    [Column("OrderCreditCardAuthorization")]
    [StringLength(30)]
    public string? OrderCreditCardAuthorization1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [StringLength(60)]
    public string? OrderCreditCardAddress { get; set; }

    [StringLength(60)]
    public string? OrderCreditCardAddress2 { get; set; }

    [StringLength(30)]
    public string? OrderCreditCardCity { get; set; }

    [StringLength(20)]
    public string? OrderCreditCardState { get; set; }

    [StringLength(30)]
    public string? OrderCreditCardCountry { get; set; }

    [StringLength(20)]
    public string? OrderCreditCardPostalCode { get; set; }

    [StringLength(10)]
    public string? CountryCode { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [StringLength(4)]
    public string? OrderCreditCardCode { get; set; }

    [StringLength(32)]
    public string? OrderCreditCardNumber { get; set; }

    [Column("TransID")]
    [StringLength(20)]
    public string? TransId { get; set; }

    [ForeignKey("CountryCode")]
    [InverseProperty("OrderCreditCardAuthorizations")]
    public virtual Country? CountryCodeNavigation { get; set; }

    [ForeignKey("OrderNumber")]
    [InverseProperty("OrderCreditCardAuthorization")]
    public virtual CustomerOrder OrderNumberNavigation { get; set; } = null!;
}
