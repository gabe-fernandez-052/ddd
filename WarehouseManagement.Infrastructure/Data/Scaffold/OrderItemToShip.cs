using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("ShipmentNumber", "OrderItemShipNumber")]
[Table("OrderItemToShip")]
public partial class OrderItemToShip
{
    public short OrderShipType { get; set; }

    public int OrderShipNumber { get; set; }

    [Key]
    public int OrderItemShipNumber { get; set; }

    public int ProductNumber { get; set; }

    public int FormatNumber { get; set; }

    public int WarehouseNumber { get; set; }

    public int ItemQuantityOrdered { get; set; }

    public int ItemQuantityShipped { get; set; }

    public int ItemQuantityAllocated { get; set; }

    public int ItemQuantityOnHand { get; set; }

    public bool ItemShipOnReceipt { get; set; }

    public bool ItemPartialShipment { get; set; }

    public bool ItemSelected { get; set; }

    public short ItemShipStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ItemInputDate { get; set; }

    [StringLength(50)]
    public string ItemManufacturerName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ItemDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ItemShipDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ItemDockDate { get; set; }

    [StringLength(30)]
    public string? ItemCarrierAccount { get; set; }

    [StringLength(8)]
    public string? ItemCarrierServiceCode { get; set; }

    [StringLength(30)]
    public string? ItemFreightChargeMethod { get; set; }

    public double? ItemResale { get; set; }

    public double? ItemCost { get; set; }

    [StringLength(50)]
    public string ItemCarrier { get; set; } = null!;

    [StringLength(50)]
    public string ItemBranch { get; set; } = null!;

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ItemPrintDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ItemPickDate { get; set; }

    public bool ItemNonStandard { get; set; }

    public bool ItemReceivedToday { get; set; }

    public int CarrierServiceNumber { get; set; }

    [StringLength(500)]
    public string? ItemNote { get; set; }

    public int? WhoLastUpdated { get; set; }

    [StringLength(4000)]
    public string? ItemSpecialFreight { get; set; }

    [StringLength(50)]
    public string? CustomerPartNumber { get; set; }

    [StringLength(50)]
    public string? PrimaryStockingZone { get; set; }

    [Key]
    public int ShipmentNumber { get; set; }

    public int ExportPhase { get; set; }

    [ForeignKey("ShipmentNumber")]
    [InverseProperty("OrderItemToShips")]
    public virtual OrderToShip ShipmentNumberNavigation { get; set; } = null!;

    [ForeignKey("WarehouseNumber")]
    [InverseProperty("OrderItemToShips")]
    public virtual Warehouse WarehouseNumberNavigation { get; set; } = null!;
}
