using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("CditerritoryNumber", "CountryCode")]
[Table("CDITerritoryCountry")]
public partial class CditerritoryCountry
{
    [Key]
    [Column("CDITerritoryNumber")]
    public int CditerritoryNumber { get; set; }

    [Key]
    [StringLength(10)]
    public string CountryCode { get; set; } = null!;

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [ForeignKey("CountryCode")]
    [InverseProperty("CditerritoryCountries")]
    public virtual Country CountryCodeNavigation { get; set; } = null!;
}
