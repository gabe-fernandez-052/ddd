using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("CustomerNumber", "LocationNumber")]
[Table("CustomerLocation")]
public partial class CustomerLocation
{
    [Key]
    public int CustomerNumber { get; set; }

    [Key]
    public int LocationNumber { get; set; }

    public int LocationType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public int? CarrierNumber { get; set; }

    [ForeignKey("CustomerNumber")]
    [InverseProperty("CustomerLocations")]
    public virtual Customer CustomerNumberNavigation { get; set; } = null!;

    [InverseProperty("CustomerLocation")]
    public virtual ICollection<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();

    [InverseProperty("CustomerLocation")]
    public virtual InternalLocation? InternalLocation { get; set; }
}
