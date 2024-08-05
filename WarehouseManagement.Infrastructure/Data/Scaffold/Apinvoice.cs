using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("APInvoice")]
[Index("CdicompanyNumber", "ApinvoiceInputDate", Name = "IX_APInvoice_InputDate")]
public partial class Apinvoice
{
    [Key]
    [Column("APInvoiceNumber")]
    public int ApinvoiceNumber { get; set; }

    public int SupplierNumber { get; set; }

    [StringLength(30)]
    public string SupplierInvoiceNumber { get; set; } = null!;

    [Column("APInvoiceType")]
    public short ApinvoiceType { get; set; }

    [Column("APInvoiceDate", TypeName = "datetime")]
    public DateTime ApinvoiceDate { get; set; }

    [Column("APInvoiceFreightAmount", TypeName = "money")]
    public decimal ApinvoiceFreightAmount { get; set; }

    [Column("APInvoiceTaxAmount", TypeName = "money")]
    public decimal ApinvoiceTaxAmount { get; set; }

    [Column("APInvoiceProductAmount", TypeName = "money")]
    public decimal ApinvoiceProductAmount { get; set; }

    [Column("APInvoiceStatus")]
    public short ApinvoiceStatus { get; set; }

    public int? WhoLastUpdated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("APInvoiceInputDate", TypeName = "datetime")]
    public DateTime ApinvoiceInputDate { get; set; }

    [Column("APInvoiceBalanceDue", TypeName = "money")]
    public decimal ApinvoiceBalanceDue { get; set; }

    public int? NoteNumber { get; set; }

    [Column("APInvoiceDueDate", TypeName = "datetime")]
    public DateTime ApinvoiceDueDate { get; set; }

    [Column("APInvoiceDaysToPay")]
    public int ApinvoiceDaysToPay { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column("APInvoiceLastPayment", TypeName = "datetime")]
    public DateTime? ApinvoiceLastPayment { get; set; }

    [Column("APInvoiceLastCheck")]
    [StringLength(20)]
    public string? ApinvoiceLastCheck { get; set; }

    [Column("APInvoiceLastPaymentAmount", TypeName = "money")]
    public decimal? ApinvoiceLastPaymentAmount { get; set; }

    [Column("APInvoiceMatchTotal", TypeName = "money")]
    public decimal? ApinvoiceMatchTotal { get; set; }

    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    public int? TeamMemberNumber { get; set; }

    [StringLength(3)]
    public string? CurrencyCode { get; set; }

    [StringLength(2)]
    public string DocumentLanguage { get; set; } = null!;

    [InverseProperty("ApinvoiceNumberNavigation")]
    public virtual ICollection<ApinvoiceItemCommon> ApinvoiceItemCommons { get; set; } = new List<ApinvoiceItemCommon>();

    [InverseProperty("ApinvoiceNumberNavigation")]
    public virtual ApshipDebit? ApshipDebit { get; set; }

    [ForeignKey("CdicompanyNumber")]
    [InverseProperty("Apinvoices")]
    public virtual Cdicompany CdicompanyNumberNavigation { get; set; } = null!;

    [ForeignKey("SupplierNumber")]
    [InverseProperty("Apinvoices")]
    public virtual Supplier SupplierNumberNavigation { get; set; } = null!;
}
