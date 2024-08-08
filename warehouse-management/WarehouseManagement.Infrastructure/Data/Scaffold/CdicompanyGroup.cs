using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("CdicompanyNumber", "RelatedCdicompanyNumber")]
[Table("CDICompanyGroup")]
public partial class CdicompanyGroup
{
    [Key]
    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    [Key]
    [Column("RelatedCDICompanyNumber")]
    public int RelatedCdicompanyNumber { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public bool SharedSales { get; set; }

    public bool RollupReporting { get; set; }

    [ForeignKey("CdicompanyNumber")]
    [InverseProperty("CdicompanyGroupCdicompanyNumberNavigations")]
    public virtual Cdicompany CdicompanyNumberNavigation { get; set; } = null!;

    [ForeignKey("RelatedCdicompanyNumber")]
    [InverseProperty("CdicompanyGroupRelatedCdicompanyNumberNavigations")]
    public virtual Cdicompany RelatedCdicompanyNumberNavigation { get; set; } = null!;
}
