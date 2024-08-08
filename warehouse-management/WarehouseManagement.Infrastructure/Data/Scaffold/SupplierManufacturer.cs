using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("SupplierNumber", "ManufacturerNumber", "CdicompanyNumber")]
[Table("SupplierManufacturer")]
[Index("CdicompanyNumber", "ManufacturerNumber", Name = "IX_SupplierManufacturer", IsUnique = true)]
public partial class SupplierManufacturer
{
    [Key]
    public int SupplierNumber { get; set; }

    [Key]
    public int ManufacturerNumber { get; set; }

    [Key]
    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    public int ManufacturerStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [ForeignKey("CdicompanyNumber")]
    [InverseProperty("SupplierManufacturers")]
    public virtual Cdicompany CdicompanyNumberNavigation { get; set; } = null!;

    [ForeignKey("ManufacturerNumber")]
    [InverseProperty("SupplierManufacturers")]
    public virtual Manufacturer ManufacturerNumberNavigation { get; set; } = null!;

    [ForeignKey("SupplierNumber")]
    [InverseProperty("SupplierManufacturers")]
    public virtual Supplier SupplierNumberNavigation { get; set; } = null!;
}
