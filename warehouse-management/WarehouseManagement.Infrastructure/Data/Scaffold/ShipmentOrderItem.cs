using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("ShipmentNumber", "ShipmentItemNumber")]
[Table("ShipmentOrderItem")]
public partial class ShipmentOrderItem
{
    [Key]
    public int ShipmentNumber { get; set; }

    [Key]
    public int ShipmentItemNumber { get; set; }

    public int OrderNumber { get; set; }

    public int OrderItemNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [ForeignKey("OrderNumber, OrderItemNumber")]
    [InverseProperty("ShipmentOrderItems")]
    public virtual OrderLineItem OrderLineItem { get; set; } = null!;

    [ForeignKey("ShipmentNumber, ShipmentItemNumber")]
    [InverseProperty("ShipmentOrderItem")]
    public virtual ShipmentItem ShipmentItem { get; set; } = null!;
}
