using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("SupplierOrderNumber", "SupplierOrderItemNumber")]
[Table("SupplierOrderItem")]
public partial class SupplierOrderItem
{
    [Key]
    public int SupplierOrderNumber { get; set; }

    [Key]
    public int SupplierOrderItemNumber { get; set; }

    public int FreightChargeType { get; set; }

    public int CarrierNumber { get; set; }

    [StringLength(8)]
    public string CarrierServiceCode { get; set; } = null!;

    public int ProductNumber { get; set; }

    public int FormatNumber { get; set; }

    public int WarehouseNumber { get; set; }

    public int SupplierOrderItemQuantity { get; set; }

    public int SupplierOrderItemReceived { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal SupplierOrderItemUnitCost { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SupplierOrderItemPromiseDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime SupplierOrderItemReceiveDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SupplierOrderItemShipDate { get; set; }

    public bool SupplierOrderItemInsure { get; set; }

    [Column("SupplierOrderItemShipASAP")]
    public bool SupplierOrderItemShipAsap { get; set; }

    public bool SupplierOrderItemPartial { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SupplierOrderItemConfirmDate { get; set; }

    public short SupplierOrderItemStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime SupplierOrderItemDate { get; set; }

    public short? SupplierOrderItemSubStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    public int? SupplierOrderItemAllocated { get; set; }

    public bool SupplierOrderItemReturn { get; set; }

    public bool SupplierOrderItemCancel { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [StringLength(30)]
    public string? SupplierReference { get; set; }

    public int? LineId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RequestDate { get; set; }

    [StringLength(500)]
    public string? Comment { get; set; }

    [ForeignKey("CarrierNumber, CarrierServiceCode")]
    [InverseProperty("SupplierOrderItems")]
    public virtual CarrierService CarrierService { get; set; } = null!;

    [ForeignKey("FreightChargeType")]
    [InverseProperty("SupplierOrderItems")]
    public virtual FreightChargeMethod FreightChargeTypeNavigation { get; set; } = null!;

    [ForeignKey("ProductNumber")]
    [InverseProperty("SupplierOrderItems")]
    public virtual Product ProductNumberNavigation { get; set; } = null!;

    [InverseProperty("SupplierOrderItem")]
    public virtual ICollection<ReceiverOrderItem> ReceiverOrderItems { get; set; } = new List<ReceiverOrderItem>();

    [ForeignKey("SupplierOrderNumber")]
    [InverseProperty("SupplierOrderItems")]
    public virtual SupplierOrder SupplierOrderNumberNavigation { get; set; } = null!;

    [ForeignKey("WarehouseNumber")]
    [InverseProperty("SupplierOrderItems")]
    public virtual Warehouse WarehouseNumberNavigation { get; set; } = null!;
}
