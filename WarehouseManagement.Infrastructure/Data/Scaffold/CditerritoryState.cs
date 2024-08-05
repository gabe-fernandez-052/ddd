using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("CditerritoryNumber", "StateProvince")]
[Table("CDITerritoryState")]
public partial class CditerritoryState
{
    [Key]
    [Column("CDITerritoryNumber")]
    public int CditerritoryNumber { get; set; }

    [Key]
    [StringLength(20)]
    public string StateProvince { get; set; } = null!;

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [StringLength(10)]
    public string CountryCode { get; set; } = null!;

    [ForeignKey("CountryCode")]
    [InverseProperty("CditerritoryStates")]
    public virtual Country CountryCodeNavigation { get; set; } = null!;
}
