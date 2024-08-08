using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("CustomerNumber", "LocationNumber", "ContactNumber")]
[Table("CustomerTeamMember")]
public partial class CustomerTeamMember
{
    [Key]
    public int CustomerNumber { get; set; }

    [Key]
    public int LocationNumber { get; set; }

    [Key]
    public int ContactNumber { get; set; }

    public int? WhoLastUpdated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public bool SuppressBranchAssignment { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Ship12MonthResale { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Ship12MonthCost { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Book90DayResale { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Book90DayCost { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Ship90DayResale { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Ship90DayCost { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Backlog30DayResale { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Backlog30DayCost { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Backlog60DayResale { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Backlog60DayCost { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Backlog90DayResale { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Backlog90DayCost { get; set; }

    [ForeignKey("CustomerNumber, LocationNumber")]
    [InverseProperty("CustomerTeamMembers")]
    public virtual InternalLocation InternalLocation { get; set; } = null!;
}
