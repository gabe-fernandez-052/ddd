using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("Warehouse")]
public partial class Warehouse
{
    [Key]
    public int WarehouseNumber { get; set; }

    [StringLength(50)]
    public string WarehouseName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [StringLength(50)]
    public string? WarehouseEmail { get; set; }

    public bool WarehouseHub { get; set; }

    [StringLength(4)]
    public string? WarehouseDivision { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public int WarehouseType { get; set; }

    public int? BranchNumber { get; set; }

    [StringLength(30)]
    public string? AccountingReference { get; set; }

    [StringLength(10)]
    public string? CountryCode { get; set; }

    [StringLength(50)]
    public string? ShippingPoint { get; set; }

    public bool IsGlobalWebInventory { get; set; }

    public bool AllowBrokenPackage { get; set; }

    public bool SuppressSupplierReporting { get; set; }

    [InverseProperty("WarehouseNumberNavigation")]
    public virtual ICollection<Allocation> Allocations { get; set; } = new List<Allocation>();

    [InverseProperty("WarehouseNumberNavigation")]
    public virtual ICollection<ArinvoiceItemCommon> ArinvoiceItemCommons { get; set; } = new List<ArinvoiceItemCommon>();

    [InverseProperty("DefaultWarehouseNavigation")]
    public virtual ICollection<Cdicompany> Cdicompanies { get; set; } = new List<Cdicompany>();

    [ForeignKey("CountryCode")]
    [InverseProperty("Warehouses")]
    public virtual Country? CountryCodeNavigation { get; set; }

    [InverseProperty("WarehouseNumberNavigation")]
    public virtual ICollection<OrderItemToShip> OrderItemToShips { get; set; } = new List<OrderItemToShip>();

    [InverseProperty("WarehouseNumberNavigation")]
    public virtual ICollection<OrderLineItem> OrderLineItems { get; set; } = new List<OrderLineItem>();

    [InverseProperty("WarehouseNumberNavigation")]
    public virtual ICollection<Receiver> Receivers { get; set; } = new List<Receiver>();

    [InverseProperty("WarehouseNumberNavigation")]
    public virtual ICollection<ShipmentItem> ShipmentItems { get; set; } = new List<ShipmentItem>();

    [InverseProperty("WarehouseNumberNavigation")]
    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    [InverseProperty("WarehouseNumberNavigation")]
    public virtual ICollection<SupplierOrderItem> SupplierOrderItems { get; set; } = new List<SupplierOrderItem>();

    [InverseProperty("WarehouseNumberNavigation")]
    public virtual ICollection<WarehouseInventory> WarehouseInventories { get; set; } = new List<WarehouseInventory>();

    [ForeignKey("WarehouseNumber")]
    [InverseProperty("Warehouse")]
    public virtual Cdilocation WarehouseNumberNavigation { get; set; } = null!;
}
