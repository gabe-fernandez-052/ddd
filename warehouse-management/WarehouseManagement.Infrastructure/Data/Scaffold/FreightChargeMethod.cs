using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("FreightChargeMethod")]
public partial class FreightChargeMethod
{
    [Key]
    public int FreightChargeType { get; set; }

    [StringLength(30)]
    public string FreightChargeDescription { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    public bool FreightChargeAccount { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public bool BillFreight { get; set; }

    public bool BillFromOrder { get; set; }

    public bool BillAsPendingFreight { get; set; }

    [InverseProperty("FreightChargeTypeNavigation")]
    public virtual ICollection<CarrierFreightChargeMethod> CarrierFreightChargeMethods { get; set; } = new List<CarrierFreightChargeMethod>();

    [InverseProperty("FreightChargeTypeNavigation")]
    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    [InverseProperty("FreightChargeTypeNavigation")]
    public virtual ICollection<SupplierOrderItem> SupplierOrderItems { get; set; } = new List<SupplierOrderItem>();
}
