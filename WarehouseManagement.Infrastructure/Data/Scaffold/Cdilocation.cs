using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("CDILocation")]
public partial class Cdilocation
{
    [Key]
    [Column("CDILocationNumber")]
    public int CdilocationNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public bool LocationActive { get; set; }

    [InverseProperty("BranchNumberNavigation")]
    public virtual Branch? Branch { get; set; }

    [InverseProperty("BranchNumberNavigation")]
    public virtual ICollection<NextNumber> NextNumbers { get; set; } = new List<NextNumber>();

    [InverseProperty("WarehouseNumberNavigation")]
    public virtual Warehouse? Warehouse { get; set; }
}
