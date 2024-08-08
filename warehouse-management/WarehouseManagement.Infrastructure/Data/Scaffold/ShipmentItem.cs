using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("ShipmentNumber", "ShipmentItemNumber")]
[Table("ShipmentItem")]
public partial class ShipmentItem
{
    [Key]
    public int ShipmentNumber { get; set; }

    [Key]
    public int ShipmentItemNumber { get; set; }

    public int ProductNumber { get; set; }

    public int FormatNumber { get; set; }

    public int ShipmentItemQuantity { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal ShipmentItemCost { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal ShipmentItemResale { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ShipmentItemDate { get; set; }

    public bool ShipmentItemAllowReturn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    public short ShipmentType { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [StringLength(10)]
    public string? CountryCode { get; set; }

    [StringLength(3)]
    public string CostCurrencyCode { get; set; } = null!;

    public int? WarehouseNumber { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal CostExchangeRate { get; set; }

    [StringLength(50)]
    public string? ManufacturerPartNumber { get; set; }

    [InverseProperty("ShipmentItem")]
    public virtual ICollection<ArinvoiceItem> ArinvoiceItems { get; set; } = new List<ArinvoiceItem>();

    [ForeignKey("CountryCode")]
    [InverseProperty("ShipmentItems")]
    public virtual Country? CountryCodeNavigation { get; set; }

    [InverseProperty("ShipmentItem")]
    public virtual ICollection<ShipmentItemBin> ShipmentItemBins { get; set; } = new List<ShipmentItemBin>();

    [ForeignKey("ShipmentNumber")]
    [InverseProperty("ShipmentItems")]
    public virtual Shipment ShipmentNumberNavigation { get; set; } = null!;

    [InverseProperty("ShipmentItem")]
    public virtual ShipmentOrderItem? ShipmentOrderItem { get; set; }

    [ForeignKey("WarehouseNumber")]
    [InverseProperty("ShipmentItems")]
    public virtual Warehouse? WarehouseNumberNavigation { get; set; }
}
