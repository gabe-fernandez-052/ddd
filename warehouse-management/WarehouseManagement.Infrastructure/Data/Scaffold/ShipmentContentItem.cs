using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("ShipmentContentItem")]
[Index("Rowguid", Name = "MSmerge_index_1523371672", IsUnique = true)]
public partial class ShipmentContentItem
{
    [Key]
    [Column("LabelID")]
    public int LabelId { get; set; }

    public int ShipmentNumber { get; set; }

    public int ProductNumber { get; set; }

    public int Quantity { get; set; }

    public int LabelCount { get; set; }

    [StringLength(500)]
    public string? DateCode { get; set; }

    [StringLength(500)]
    public string? LotCode { get; set; }

    public string? AdditionalIdentifiers { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    [StringLength(10)]
    public string? CountryCode { get; set; }

    [ForeignKey("CountryCode")]
    [InverseProperty("ShipmentContentItems")]
    public virtual Country? CountryCodeNavigation { get; set; }

    [ForeignKey("ProductNumber")]
    [InverseProperty("ShipmentContentItems")]
    public virtual Product ProductNumberNavigation { get; set; } = null!;
}
