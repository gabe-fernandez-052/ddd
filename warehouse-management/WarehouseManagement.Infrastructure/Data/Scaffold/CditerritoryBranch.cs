using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("CditerritoryNumber", "CdicompanyNumber")]
[Table("CDITerritoryBranch")]
public partial class CditerritoryBranch
{
    [Key]
    [Column("CDITerritoryNumber")]
    public int CditerritoryNumber { get; set; }

    public int BranchNumber { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public int? TeamMemberNumber { get; set; }

    [Key]
    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    public int? FieldSalesPerson { get; set; }

    public int? InsideSalesPerson { get; set; }

    [ForeignKey("BranchNumber")]
    [InverseProperty("CditerritoryBranches")]
    public virtual Branch BranchNumberNavigation { get; set; } = null!;

    [ForeignKey("CdicompanyNumber")]
    [InverseProperty("CditerritoryBranches")]
    public virtual Cdicompany CdicompanyNumberNavigation { get; set; } = null!;
}
