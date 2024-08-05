using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("ShipmentNumber", "ShipmentItemNumber", "BinNumber")]
[Table("ShipmentItemBin")]
public partial class ShipmentItemBin
{
    [Key]
    public int ShipmentNumber { get; set; }

    [Key]
    public int ShipmentItemNumber { get; set; }

    [Key]
    public int BinNumber { get; set; }

    public int ShipmentBinQuantity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [ForeignKey("BinNumber")]
    [InverseProperty("ShipmentItemBins")]
    public virtual InventoryBin BinNumberNavigation { get; set; } = null!;

    [ForeignKey("ShipmentNumber, ShipmentItemNumber")]
    [InverseProperty("ShipmentItemBins")]
    public virtual ShipmentItem ShipmentItem { get; set; } = null!;
}
