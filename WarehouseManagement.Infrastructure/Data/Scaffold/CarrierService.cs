using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("CarrierNumber", "CarrierServiceCode")]
[Table("CarrierService")]
public partial class CarrierService
{
    [Key]
    public int CarrierNumber { get; set; }

    [Key]
    [StringLength(8)]
    public string CarrierServiceCode { get; set; } = null!;

    public short CarrierServiceDays { get; set; }

    [StringLength(30)]
    public string CarrierServiceDescription { get; set; } = null!;

    public int CarrierServiceNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [StringLength(50)]
    public string? CarrierReferenceCode { get; set; }

    public int? MinimumTransitDays { get; set; }

    public int? MaximumTransitDays { get; set; }

    [InverseProperty("CarrierService")]
    public virtual ICollection<OrderLineItem> OrderLineItems { get; set; } = new List<OrderLineItem>();

    [InverseProperty("CarrierService")]
    public virtual ICollection<Receiver> Receivers { get; set; } = new List<Receiver>();

    [InverseProperty("CarrierService")]
    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    [InverseProperty("CarrierService")]
    public virtual ICollection<SupplierOrderItem> SupplierOrderItems { get; set; } = new List<SupplierOrderItem>();
}
