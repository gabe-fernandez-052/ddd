using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("ReceiverSupplierOrder")]
public partial class ReceiverSupplierOrder
{
    [Key]
    public int ReceiverNumber { get; set; }

    [Column("APInvoiceNumber")]
    public int? ApinvoiceNumber { get; set; }

    public int SupplierOrderNumber { get; set; }

    [StringLength(30)]
    public string? ReceiverInvoiceNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [ForeignKey("ReceiverNumber")]
    [InverseProperty("ReceiverSupplierOrder")]
    public virtual Receiver ReceiverNumberNavigation { get; set; } = null!;

    [ForeignKey("SupplierOrderNumber")]
    [InverseProperty("ReceiverSupplierOrders")]
    public virtual SupplierOrder SupplierOrderNumberNavigation { get; set; } = null!;
}
