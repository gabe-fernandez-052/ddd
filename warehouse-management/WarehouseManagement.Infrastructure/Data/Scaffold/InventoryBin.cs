using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("InventoryBin")]
public partial class InventoryBin
{
    [Key]
    public int BinNumber { get; set; }

    public int? ReceiverNumber { get; set; }

    public int? ReceiverItemNumber { get; set; }

    public int WarehouseNumber { get; set; }

    public int ProductNumber { get; set; }

    public int FormatNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime BinDateReceived { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? BinDateCode { get; set; }

    public int BinQuantityRemaining { get; set; }

    public int BinQuantityOriginal { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal BinUnitCost { get; set; }

    public int BinStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [StringLength(20)]
    public string? LotCode { get; set; }

    [StringLength(20)]
    public string? ManufacturerDateCode { get; set; }

    [StringLength(100)]
    public string? LocationInfo { get; set; }

    [StringLength(30)]
    public string? ThirdPartyReference { get; set; }

    [InverseProperty("BinNumberNavigation")]
    public virtual ICollection<AllocationInventoryBin> AllocationInventoryBins { get; set; } = new List<AllocationInventoryBin>();

    [ForeignKey("CdicompanyNumber")]
    [InverseProperty("InventoryBins")]
    public virtual Cdicompany CdicompanyNumberNavigation { get; set; } = null!;

    [ForeignKey("ReceiverNumber, ReceiverItemNumber")]
    [InverseProperty("InventoryBins")]
    public virtual ReceiverItem? ReceiverItem { get; set; }

    [InverseProperty("BinNumberNavigation")]
    public virtual ICollection<ShipmentItemBin> ShipmentItemBins { get; set; } = new List<ShipmentItemBin>();

    [ForeignKey("ProductNumber, FormatNumber, WarehouseNumber")]
    [InverseProperty("InventoryBins")]
    public virtual WarehouseInventory WarehouseInventory { get; set; } = null!;
}
