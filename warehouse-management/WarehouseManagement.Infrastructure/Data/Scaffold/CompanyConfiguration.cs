using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("CompanyId", "OptionId")]
[Table("CompanyConfiguration")]
[Index("Rowguid", Name = "MSmerge_index_1907373040", IsUnique = true)]
public partial class CompanyConfiguration
{
    [Key]
    [Column("CompanyID")]
    public int CompanyId { get; set; }

    [Key]
    [Column("OptionID")]
    public int OptionId { get; set; }

    public bool? BooleanValue { get; set; }

    [StringLength(500)]
    public string? TextValue { get; set; }

    [Column(TypeName = "numeric(18, 5)")]
    public decimal? NumericValue { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }
}
