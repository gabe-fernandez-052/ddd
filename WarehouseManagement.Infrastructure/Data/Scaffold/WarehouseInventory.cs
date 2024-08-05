using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("ProductNumber", "FormatNumber", "WarehouseNumber")]
[Table("WarehouseInventory")]
public partial class WarehouseInventory
{
    [Key]
    public int ProductNumber { get; set; }

    [Key]
    public int FormatNumber { get; set; }

    [Key]
    public int WarehouseNumber { get; set; }

    public int? WarehouseQuantityOnHand { get; set; }

    public int? WarehouseQuantityOnOrder { get; set; }

    public int? WarehouseQuantityAllocated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WarehouseLastShipmentDate { get; set; }

    [StringLength(100)]
    public string? WarehouseLocationInfo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid? Rowguid { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastCycleCount { get; set; }

    [InverseProperty("WarehouseInventory")]
    public virtual ICollection<InventoryBin> InventoryBins { get; set; } = new List<InventoryBin>();

    [ForeignKey("WarehouseNumber")]
    [InverseProperty("WarehouseInventories")]
    public virtual Warehouse WarehouseNumberNavigation { get; set; } = null!;
}
