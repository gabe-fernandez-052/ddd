using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("InvoiceNumber", "InvoiceItemNumber")]
[Table("ARInvoiceItemCommon")]
public partial class ArinvoiceItemCommon
{
    [Key]
    public int InvoiceNumber { get; set; }

    [Key]
    public int InvoiceItemNumber { get; set; }

    public int ProductNumber { get; set; }

    public int FormatNumber { get; set; }

    public short InvoiceType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime InvoiceItemDate { get; set; }

    public int InvoiceItemQuantity { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal InvoiceItemCost { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal InvoiceItemResale { get; set; }

    public bool InvoiceItemTaxable { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    public int? WarehouseNumber { get; set; }

    public int? BranchNumber { get; set; }

    [Column("InvoiceItemCustomerPO")]
    [StringLength(30)]
    public string? InvoiceItemCustomerPo { get; set; }

    public int? InvoiceItemOrderNumber { get; set; }

    public int? ContactNumber { get; set; }

    public int? RepresentativeNumber { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public bool InvoiceItemAdjustment { get; set; }

    public int? InvoiceAdjustmentNumber { get; set; }

    [StringLength(3)]
    public string CostCurrencyCode { get; set; } = null!;

    [Column(TypeName = "decimal(18, 5)")]
    public decimal? CostConverted { get; set; }

    public int? TaxType { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal CostExchangeRate { get; set; }

    [InverseProperty("ArinvoiceItemCommon")]
    public virtual ICollection<ApshipDebitItem> ApshipDebitItems { get; set; } = new List<ApshipDebitItem>();

    [InverseProperty("ArinvoiceItemCommon")]
    public virtual ArinvoiceItem? ArinvoiceItem { get; set; }

    [InverseProperty("ArinvoiceItemCommon")]
    public virtual ICollection<ArinvoiceItemCommission> ArinvoiceItemCommissions { get; set; } = new List<ArinvoiceItemCommission>();

    [ForeignKey("BranchNumber")]
    [InverseProperty("ArinvoiceItemCommons")]
    public virtual Branch? BranchNumberNavigation { get; set; }

    [ForeignKey("InvoiceNumber")]
    [InverseProperty("ArinvoiceItemCommons")]
    public virtual Arinvoice InvoiceNumberNavigation { get; set; } = null!;

    [ForeignKey("WarehouseNumber")]
    [InverseProperty("ArinvoiceItemCommons")]
    public virtual Warehouse? WarehouseNumberNavigation { get; set; }
}
