using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("CditerritoryNumber", "PostalCodeStart")]
[Table("CDITerritoryPostalCode")]
public partial class CditerritoryPostalCode
{
    [Key]
    [Column("CDITerritoryNumber")]
    public int CditerritoryNumber { get; set; }

    [Key]
    [StringLength(20)]
    public string PostalCodeStart { get; set; } = null!;

    [StringLength(20)]
    public string PostalCodeEnd { get; set; } = null!;

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [StringLength(10)]
    public string CountryCode { get; set; } = null!;

    [ForeignKey("CountryCode")]
    [InverseProperty("CditerritoryPostalCodes")]
    public virtual Country CountryCodeNavigation { get; set; } = null!;
}
