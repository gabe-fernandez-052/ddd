using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("Event")]
public partial class Event
{
    [Key]
    public int EventId { get; set; }

    public int EventType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public int? BranchLastUpdated { get; set; }

    [StringLength(256)]
    public string EventKey { get; set; } = null!;

    [InverseProperty("Event")]
    public virtual EventNote? EventNote { get; set; }
}
