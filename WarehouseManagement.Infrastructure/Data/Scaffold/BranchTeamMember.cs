using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("ContactNumber", "BranchNumber")]
[Table("BranchTeamMember")]
public partial class BranchTeamMember
{
    [Key]
    public int ContactNumber { get; set; }

    [Key]
    public int BranchNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateEntered { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [ForeignKey("BranchNumber")]
    [InverseProperty("BranchTeamMembers")]
    public virtual Branch BranchNumberNavigation { get; set; } = null!;
}
