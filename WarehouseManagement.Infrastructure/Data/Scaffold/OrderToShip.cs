using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("OrderToShip")]
public partial class OrderToShip
{
    public short OrderShipType { get; set; }

    public int OrderShipNumber { get; set; }

    public short? PaymentTermsType { get; set; }

    public int? ContactNumber { get; set; }

    public int? WarehouseNumber { get; set; }

    public int? SupplierNumber { get; set; }

    public short? SupplierWarehouseNumber { get; set; }

    public int? CustomerNumber { get; set; }

    public short? LocationNumber { get; set; }

    [Column("OrderShipPO")]
    [StringLength(30)]
    public string? OrderShipPo { get; set; }

    public bool OrderShipComplete { get; set; }

    public short? OrderShipCardType { get; set; }

    [StringLength(50)]
    public string? OrderShipCardName { get; set; }

    [StringLength(30)]
    public string? OrderShipCardNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderShipCardExpiration { get; set; }

    [StringLength(50)]
    public string OrderShipDestinationName { get; set; } = null!;

    public int? TeamMemberNumber { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    [StringLength(60)]
    public string? ShippingAttention { get; set; }

    [Key]
    public int ShipmentNumber { get; set; }

    public int InvoiceNumber { get; set; }

    public int ExportStatus { get; set; }

    [InverseProperty("ShipmentNumberNavigation")]
    public virtual ICollection<OrderItemToShip> OrderItemToShips { get; set; } = new List<OrderItemToShip>();
}
