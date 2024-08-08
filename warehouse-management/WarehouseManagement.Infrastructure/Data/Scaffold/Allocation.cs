using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("Allocation")]
public partial class Allocation
{
    [Key]
    public int AllocationNumber { get; set; }

    public int OrderOutType { get; set; }

    public int OrderOutNumber { get; set; }

    public int OrderOutItemNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime OrderOutItemDate { get; set; }

    [StringLength(75)]
    public string? OrderOutEntityName { get; set; }

    [StringLength(30)]
    public string? OrderOutEntityReference { get; set; }

    public int OrderOutEntityNumber { get; set; }

    public int? OrderOutEntitySubNumber { get; set; }

    public int OrderOutTeamMemberNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime OrderOutTargetShipDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime OrderOutOnDockdate { get; set; }

    [Column("OrderOutSOR")]
    public bool OrderOutSor { get; set; }

    public int SourceType { get; set; }

    public int? BinNumber { get; set; }

    public int WarehouseNumber { get; set; }

    public int AllocationQuantity { get; set; }

    public int ProductNumber { get; set; }

    public int FormatNumber { get; set; }

    public int? OrderInType { get; set; }

    public int? OrderInNumber { get; set; }

    public int? OrderInItemNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderInReceiveDate { get; set; }

    [StringLength(75)]
    public string? OrderInEntityName { get; set; }

    public int? OrderInEntityNumber { get; set; }

    public int? OrderInEntitySubNumber { get; set; }

    public int? OrderInTeamMemberNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderInConfirmDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public int TransactionTypeOut { get; set; }

    public int TransactionTypeIn { get; set; }

    public int AllocationHoldStatus { get; set; }

    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    [InverseProperty("AllocationNumberNavigation")]
    public virtual ICollection<AllocationInventoryBin> AllocationInventoryBins { get; set; } = new List<AllocationInventoryBin>();

    [ForeignKey("CdicompanyNumber")]
    [InverseProperty("Allocations")]
    public virtual Cdicompany CdicompanyNumberNavigation { get; set; } = null!;

    [ForeignKey("WarehouseNumber")]
    [InverseProperty("Allocations")]
    public virtual Warehouse WarehouseNumberNavigation { get; set; } = null!;
}
