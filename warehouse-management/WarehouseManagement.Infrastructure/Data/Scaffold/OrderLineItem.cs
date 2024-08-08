using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("OrderNumber", "OrderItemNumber")]
[Table("OrderLineItem")]
public partial class OrderLineItem
{
    [Key]
    public int OrderNumber { get; set; }

    [Key]
    public int OrderItemNumber { get; set; }

    public int FreightChargeType { get; set; }

    public int WarehouseNumber { get; set; }

    public int CarrierNumber { get; set; }

    [StringLength(8)]
    public string CarrierServiceCode { get; set; } = null!;

    public int ProductNumber { get; set; }

    public int FormatNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime OrderItemDate { get; set; }

    public int OrderItemQuantity { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal OrderItemResale { get; set; }

    public bool OrderItemTaxable { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime OrderItemOnDockDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime OrderItemTargetShipDate { get; set; }

    public bool OrderItemInsureShipment { get; set; }

    public int OrderItemQuantityShipped { get; set; }

    public bool OrderItemPartialShipment { get; set; }

    public short OrderItemStatus { get; set; }

    public short? OrderItemSubStatus { get; set; }

    public short? OrderItemEndUse { get; set; }

    public bool OrderItemSendLiterature { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal OrderItemCost { get; set; }

    [Column("OrderItemShipASAP")]
    public bool OrderItemShipAsap { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    public bool OrderItemReturnStock { get; set; }

    public bool OrderItemCancel { get; set; }

    public int BranchNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderItemPromiseDate { get; set; }

    public bool OrderItemHold { get; set; }

    public int? RepresentativeNumber { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [StringLength(30)]
    public string? SupplierReference { get; set; }

    public short DeliveryAlert { get; set; }

    public int? TeamMemberNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RequestDate { get; set; }

    [StringLength(50)]
    public string? CustomerPartNumber { get; set; }

    public int LineId { get; set; }

    [StringLength(500)]
    public string? Comment { get; set; }

    [StringLength(3)]
    public string CostCurrencyCode { get; set; } = null!;

    [Column(TypeName = "decimal(18, 5)")]
    public decimal? CostConverted { get; set; }

    public int? TaxType { get; set; }

    public int ExportPhase { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal CostExchangeRate { get; set; }

    [ForeignKey("CarrierNumber, CarrierServiceCode")]
    [InverseProperty("OrderLineItems")]
    public virtual CarrierService CarrierService { get; set; } = null!;

    [InverseProperty("OrderLineItem")]
    public virtual OrderItemCarrierAccount? OrderItemCarrierAccount { get; set; }

    [InverseProperty("OrderLineItem")]
    public virtual ICollection<OrderItemCommission> OrderItemCommissions { get; set; } = new List<OrderItemCommission>();

    [ForeignKey("OrderNumber")]
    [InverseProperty("OrderLineItems")]
    public virtual CustomerOrder OrderNumberNavigation { get; set; } = null!;

    [InverseProperty("OrderLineItem")]
    public virtual ICollection<ShipmentOrderItem> ShipmentOrderItems { get; set; } = new List<ShipmentOrderItem>();

    [ForeignKey("WarehouseNumber")]
    [InverseProperty("OrderLineItems")]
    public virtual Warehouse WarehouseNumberNavigation { get; set; } = null!;
}
