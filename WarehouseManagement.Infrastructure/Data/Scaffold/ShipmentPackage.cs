using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("ShipmentNumber", "PackageNumber")]
[Table("ShipmentPackage")]
public partial class ShipmentPackage
{
    [Key]
    public int ShipmentNumber { get; set; }

    [Key]
    public int PackageNumber { get; set; }

    public double PackageWeight { get; set; }

    [StringLength(30)]
    public string? PackageTrackingNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column("PackLogixLPN")]
    public int? PackLogixLpn { get; set; }

    [ForeignKey("ShipmentNumber")]
    [InverseProperty("ShipmentPackages")]
    public virtual Shipment ShipmentNumberNavigation { get; set; } = null!;
}
