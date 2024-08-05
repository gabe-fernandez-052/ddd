using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("ApinvoiceNumber", "ApinvoiceItemNumber")]
[Table("APShipDebitItem")]
[Index("InvoiceNumber", Name = "IX_APShipDebitItem_InvoiceNumber")]
public partial class ApshipDebitItem
{
    [Key]
    [Column("APInvoiceNumber")]
    public int ApinvoiceNumber { get; set; }

    [Key]
    [Column("APInvoiceItemNumber")]
    public int ApinvoiceItemNumber { get; set; }

    public int InvoiceNumber { get; set; }

    public int InvoiceItemNumber { get; set; }

    [StringLength(50)]
    public string? ShipDebitSupplierSource { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [ForeignKey("ApinvoiceNumber, ApinvoiceItemNumber")]
    [InverseProperty("ApshipDebitItem")]
    public virtual ApinvoiceItemCommon ApinvoiceItemCommon { get; set; } = null!;

    [ForeignKey("InvoiceNumber, InvoiceItemNumber")]
    [InverseProperty("ApshipDebitItems")]
    public virtual ArinvoiceItemCommon ArinvoiceItemCommon { get; set; } = null!;
}
