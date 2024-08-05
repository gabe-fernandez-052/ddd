using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("AllocationNumber", "BinNumber")]
[Table("AllocationInventoryBin")]
public partial class AllocationInventoryBin
{
    [Key]
    public int AllocationNumber { get; set; }

    [Key]
    public int BinNumber { get; set; }

    public int Quantity { get; set; }

    public bool IsAllocationPostPick { get; set; }

    [ForeignKey("AllocationNumber")]
    [InverseProperty("AllocationInventoryBins")]
    public virtual Allocation AllocationNumberNavigation { get; set; } = null!;

    [ForeignKey("BinNumber")]
    [InverseProperty("AllocationInventoryBins")]
    public virtual InventoryBin BinNumberNavigation { get; set; } = null!;
}
