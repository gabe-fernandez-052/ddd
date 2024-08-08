using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("BranchNumber", "EntityName")]
[Table("NextNumber")]
public partial class NextNumber
{
    [Key]
    public int BranchNumber { get; set; }

    [Key]
    [StringLength(30)]
    public string EntityName { get; set; } = null!;

    public int LastNumber { get; set; }

    public int MaxNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [ForeignKey("BranchNumber")]
    [InverseProperty("NextNumbers")]
    public virtual Cdilocation BranchNumberNavigation { get; set; } = null!;
}
