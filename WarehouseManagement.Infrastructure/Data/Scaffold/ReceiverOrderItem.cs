using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("ReceiverNumber", "ReceiverItemNumber")]
[Table("ReceiverOrderItem")]
public partial class ReceiverOrderItem
{
    [Key]
    public int ReceiverNumber { get; set; }

    [Key]
    public int ReceiverItemNumber { get; set; }

    public int SupplierOrderNumber { get; set; }

    public int SupplierOrderItemNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [ForeignKey("ReceiverNumber, ReceiverItemNumber")]
    [InverseProperty("ReceiverOrderItem")]
    public virtual ReceiverItem ReceiverItem { get; set; } = null!;

    [ForeignKey("SupplierOrderNumber, SupplierOrderItemNumber")]
    [InverseProperty("ReceiverOrderItems")]
    public virtual SupplierOrderItem SupplierOrderItem { get; set; } = null!;
}
