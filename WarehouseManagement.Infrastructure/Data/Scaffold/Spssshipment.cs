using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("OrderType", "OrderNumber", "PackageNumber", "CarrierServiceNumber")]
[Table("SPSSShipment")]
public partial class Spssshipment
{
    [Key]
    public int OrderType { get; set; }

    [Key]
    public int OrderNumber { get; set; }

    [Key]
    public int PackageNumber { get; set; }

    public double Weight { get; set; }

    public double Freight { get; set; }

    [StringLength(30)]
    public string TrackingNumber { get; set; } = null!;

    public int? InvoiceNumber { get; set; }

    public int? ShipmentNumber { get; set; }

    [StringLength(10)]
    public string Method { get; set; } = null!;

    [StringLength(20)]
    public string? Account { get; set; }

    [Column("UniqueID")]
    [StringLength(50)]
    public string UniqueId { get; set; } = null!;

    [StringLength(1000)]
    public string? Message { get; set; }

    [Key]
    public int CarrierServiceNumber { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? RateWeight { get; set; }

    [StringLength(500)]
    public string? ManufacturedDate { get; set; }

    [StringLength(500)]
    public string? ProductLotNumber { get; set; }

    public bool IsPackLogixInfo { get; set; }

    [Column("PickerID")]
    [StringLength(50)]
    public string? PickerId { get; set; }

    [Column("PackerID")]
    [StringLength(50)]
    public string? PackerId { get; set; }

    [Column("LPN")]
    public int? Lpn { get; set; }
}
