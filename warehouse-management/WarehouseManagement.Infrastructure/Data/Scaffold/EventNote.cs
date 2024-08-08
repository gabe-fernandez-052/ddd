using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("EventNote")]
public partial class EventNote
{
    [Key]
    public int EventId { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [StringLength(256)]
    public string? Note { get; set; }

    [ForeignKey("EventId")]
    [InverseProperty("EventNote")]
    public virtual Event Event { get; set; } = null!;
}
