using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("OrderNumber", "OrderItemNumber")]
[Table("OrderItemCarrierAccount")]
public partial class OrderItemCarrierAccount
{
    [Key]
    public int OrderNumber { get; set; }

    [Key]
    public int OrderItemNumber { get; set; }

    [Column("OrderItemCarrierAccount")]
    [StringLength(30)]
    public string OrderItemCarrierAccount1 { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [ForeignKey("OrderNumber, OrderItemNumber")]
    [InverseProperty("OrderItemCarrierAccount")]
    public virtual OrderLineItem OrderLineItem { get; set; } = null!;
}
