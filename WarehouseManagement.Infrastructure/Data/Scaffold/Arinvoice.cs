using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("ARInvoice")]
[Index("CdicompanyNumber", "InvoiceBalanceDue", Name = "IX_ARINVOICE_CDICOMPANYNUMBER")]
[Index("CustomerNumber", Name = "IX_ARInvoice_CustomerNumber")]
public partial class Arinvoice
{
    [Key]
    public int InvoiceNumber { get; set; }

    public int CustomerNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime InvoiceDate { get; set; }

    [Column(TypeName = "money")]
    public decimal InvoiceFreightAmount { get; set; }

    [Column(TypeName = "money")]
    public decimal InvoiceTaxAmount { get; set; }

    [Column(TypeName = "money")]
    public decimal InvoiceProductCost { get; set; }

    [Column(TypeName = "money")]
    public decimal InvoiceProductAmount { get; set; }

    public short InvoiceType { get; set; }

    public short InvoiceStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column(TypeName = "money")]
    public decimal InvoiceBalanceDue { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InvoiceLastPayment { get; set; }

    [StringLength(20)]
    public string? InvoiceLastCheck { get; set; }

    [Column(TypeName = "money")]
    public decimal? InvoiceLastPaymentAmount { get; set; }

    [Column(TypeName = "money")]
    public decimal? InvoiceMatchTotal { get; set; }

    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal InvoiceTaxRate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TaxRateVerificationDate { get; set; }

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [StringLength(50)]
    public string? InvoiceSequence { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal TaxExchangeRate { get; set; }

    [StringLength(2)]
    public string DocumentLanguage { get; set; } = null!;

    public bool ApplyCurrencyBillingAdjustment { get; set; }

    [StringLength(3)]
    public string? BillingAdjustmentCurrency { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal? BillingAdjustmentRate { get; set; }

    [StringLength(20)]
    public string? AllocationNumber { get; set; }

    [InverseProperty("InvoiceNumberNavigation")]
    public virtual ICollection<ArinvoiceItemCommon> ArinvoiceItemCommons { get; set; } = new List<ArinvoiceItemCommon>();

    [InverseProperty("InvoiceNumberNavigation")]
    public virtual ArinvoiceTotal? ArinvoiceTotal { get; set; }

    [InverseProperty("InvoiceNumberNavigation")]
    public virtual ArshipmentInvoice? ArshipmentInvoice { get; set; }

    [ForeignKey("CdicompanyNumber")]
    [InverseProperty("Arinvoices")]
    public virtual Cdicompany CdicompanyNumberNavigation { get; set; } = null!;

    [ForeignKey("CustomerNumber")]
    [InverseProperty("Arinvoices")]
    public virtual Customer CustomerNumberNavigation { get; set; } = null!;
}
