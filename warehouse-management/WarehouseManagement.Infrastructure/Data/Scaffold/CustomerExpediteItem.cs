using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("ExpediteNumber", "ExpediteItemNumber")]
[Table("CustomerExpediteItem")]
public partial class CustomerExpediteItem
{
    [Key]
    public int ExpediteNumber { get; set; }

    [Key]
    public int ExpediteItemNumber { get; set; }

    public int OrderNumber { get; set; }

    public int OrderItemNumber { get; set; }

    public int ExpediteItemStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ExpediteItemNeedDate { get; set; }

    [Column("ExpediteItemCDIDate", TypeName = "datetime")]
    public DateTime? ExpediteItemCdidate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public int? ItemSubStatus { get; set; }

    public int OrderOutType { get; set; }

    [StringLength(255)]
    public string? ExpediteResponse { get; set; }

    [ForeignKey("ExpediteNumber")]
    [InverseProperty("CustomerExpediteItems")]
    public virtual CustomerExpedite ExpediteNumberNavigation { get; set; } = null!;
}
