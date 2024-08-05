using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("ListNumber", "ListValue")]
[Table("CDIListValue")]
public partial class CdilistValue
{
    [Key]
    public int ListNumber { get; set; }

    [Key]
    public short ListValue { get; set; }

    [StringLength(30)]
    public string ListDisplay { get; set; } = null!;

    public bool ListDefault { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public short ListSort { get; set; }
}
