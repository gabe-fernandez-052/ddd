using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("Shipment")]
public partial class Shipment
{
    [Key]
    public int ShipmentNumber { get; set; }

    public int? FreightChargeType { get; set; }

    public int WarehouseNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ShipmentDate { get; set; }

    public int? CarrierNumber { get; set; }

    [StringLength(8)]
    public string? CarrierServiceCode { get; set; }

    public bool ShipmentInsured { get; set; }

    [StringLength(30)]
    public string? ShipmentCarrierAccount { get; set; }

    public short? ShipmentContainerType { get; set; }

    [StringLength(500)]
    public string? ShipmentMessage { get; set; }

    public double? ShipmentFreight { get; set; }

    [StringLength(75)]
    public string? ShipmentName { get; set; }

    [StringLength(60)]
    public string? ShipmentAddress { get; set; }

    [StringLength(60)]
    public string? ShipmentAddress2 { get; set; }

    [StringLength(30)]
    public string? ShipmentCity { get; set; }

    [StringLength(20)]
    public string? ShipmentState { get; set; }

    [StringLength(20)]
    public string? ShipmentPostalCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    public short ShipmentType { get; set; }

    public bool ShipmentResidential { get; set; }

    [StringLength(10)]
    public string? CountryCode { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    [StringLength(500)]
    public string? ManufacturedDate { get; set; }

    [StringLength(500)]
    public string? ProductLotNumber { get; set; }

    [Column("PickerID")]
    [StringLength(50)]
    public string? PickerId { get; set; }

    [Column("PackerID")]
    [StringLength(50)]
    public string? PackerId { get; set; }

    [StringLength(2)]
    public string DocumentLanguage { get; set; } = null!;

    [ForeignKey("CarrierNumber, CarrierServiceCode")]
    [InverseProperty("Shipments")]
    public virtual CarrierService? CarrierService { get; set; }

    [ForeignKey("CdicompanyNumber")]
    [InverseProperty("Shipments")]
    public virtual Cdicompany CdicompanyNumberNavigation { get; set; } = null!;

    [ForeignKey("CountryCode")]
    [InverseProperty("Shipments")]
    public virtual Country? CountryCodeNavigation { get; set; }

    [ForeignKey("FreightChargeType")]
    [InverseProperty("Shipments")]
    public virtual FreightChargeMethod? FreightChargeTypeNavigation { get; set; }

    [InverseProperty("ShipmentNumberNavigation")]
    public virtual ShipmentCustomerOrder? ShipmentCustomerOrder { get; set; }

    [InverseProperty("ShipmentNumberNavigation")]
    public virtual ICollection<ShipmentItem> ShipmentItems { get; set; } = new List<ShipmentItem>();

    [InverseProperty("ShipmentNumberNavigation")]
    public virtual ICollection<ShipmentPackage> ShipmentPackages { get; set; } = new List<ShipmentPackage>();

    [ForeignKey("WarehouseNumber")]
    [InverseProperty("Shipments")]
    public virtual Warehouse WarehouseNumberNavigation { get; set; } = null!;
}
