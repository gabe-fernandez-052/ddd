using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("InvoiceNumber", "InvoiceItemNumber")]
[Table("ARInvoiceItem")]
public partial class ArinvoiceItem
{
    [Key]
    public int InvoiceNumber { get; set; }

    [Key]
    public int InvoiceItemNumber { get; set; }

    public int ShipmentNumber { get; set; }

    public int ShipmentItemNumber { get; set; }

    public bool InvoiceItemTaxable { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [ForeignKey("InvoiceNumber, InvoiceItemNumber")]
    [InverseProperty("ArinvoiceItem")]
    public virtual ArinvoiceItemCommon ArinvoiceItemCommon { get; set; } = null!;

    [ForeignKey("ShipmentNumber, ShipmentItemNumber")]
    [InverseProperty("ArinvoiceItems")]
    public virtual ShipmentItem ShipmentItem { get; set; } = null!;
}
