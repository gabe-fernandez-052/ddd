using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("ApinvoiceNumber", "ApinvoiceItemNumber")]
[Table("APInvoiceItemCommon")]
public partial class ApinvoiceItemCommon
{
    [Key]
    [Column("APInvoiceNumber")]
    public int ApinvoiceNumber { get; set; }

    [Key]
    [Column("APInvoiceItemNumber")]
    public int ApinvoiceItemNumber { get; set; }

    public int ProductNumber { get; set; }

    public int FormatNumber { get; set; }

    [Column("APInvoiceType")]
    public short ApinvoiceType { get; set; }

    [Column("APInvoiceItemDate", TypeName = "datetime")]
    public DateTime ApinvoiceItemDate { get; set; }

    [Column("APInvoiceItemCost", TypeName = "decimal(18, 5)")]
    public decimal ApinvoiceItemCost { get; set; }

    [Column("APInvoiceItemQuantity")]
    public int ApinvoiceItemQuantity { get; set; }

    public int? WhoLastUpdated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    public int? BranchNumber { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column("APInvoiceItemAdjustment")]
    public bool ApinvoiceItemAdjustment { get; set; }

    [Column("APInvoiceAdjustmentNumber")]
    public int? ApinvoiceAdjustmentNumber { get; set; }

    [ForeignKey("ApinvoiceNumber")]
    [InverseProperty("ApinvoiceItemCommons")]
    public virtual Apinvoice ApinvoiceNumberNavigation { get; set; } = null!;

    [InverseProperty("ApinvoiceItemCommon")]
    public virtual ApshipDebitItem? ApshipDebitItem { get; set; }
}
