using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("CarrierNumber", "FreightChargeType")]
[Table("CarrierFreightChargeMethod")]
public partial class CarrierFreightChargeMethod
{
    [Key]
    public int CarrierNumber { get; set; }

    [Key]
    public int FreightChargeType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [ForeignKey("FreightChargeType")]
    [InverseProperty("CarrierFreightChargeMethods")]
    public virtual FreightChargeMethod FreightChargeTypeNavigation { get; set; } = null!;
}
