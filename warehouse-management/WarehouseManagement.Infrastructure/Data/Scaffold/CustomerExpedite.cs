using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("CustomerExpedite")]
public partial class CustomerExpedite
{
    [Key]
    public int ExpediteNumber { get; set; }

    public int TeamMemberNumber { get; set; }

    public int CustomerNumber { get; set; }

    public int BranchNumber { get; set; }

    public int ExpediteType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ExpediteDate { get; set; }

    public int ContactNumber { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [StringLength(500)]
    public string? ExpediteNote { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EscalationDate { get; set; }

    [ForeignKey("BranchNumber")]
    [InverseProperty("CustomerExpedites")]
    public virtual Branch BranchNumberNavigation { get; set; } = null!;

    [InverseProperty("ExpediteNumberNavigation")]
    public virtual ICollection<CustomerExpediteItem> CustomerExpediteItems { get; set; } = new List<CustomerExpediteItem>();

    [ForeignKey("CustomerNumber")]
    [InverseProperty("CustomerExpedites")]
    public virtual Customer CustomerNumberNavigation { get; set; } = null!;
}
