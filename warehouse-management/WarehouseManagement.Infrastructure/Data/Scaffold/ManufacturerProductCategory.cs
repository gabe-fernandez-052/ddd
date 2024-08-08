using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("ManufacturerNumber", "ProductCategoryNumber")]
[Table("ManufacturerProductCategory")]
public partial class ManufacturerProductCategory
{
    [Key]
    public int ManufacturerNumber { get; set; }

    [Key]
    public int ProductCategoryNumber { get; set; }

    [StringLength(30)]
    public string ManufacturerCategoryDescription { get; set; } = null!;

    public int? ManufacturerCategoryLeadTime { get; set; }

    [StringLength(30)]
    public string? ManufacturerCategoryExportCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [StringLength(50)]
    public string? ManufacturerCategoryReference { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public int SalesCategoryNumber { get; set; }

    public short PriceBreaks { get; set; }

    public short DefaultPriceBreak { get; set; }

    public bool IsGroupId { get; set; }

    [ForeignKey("ManufacturerNumber")]
    [InverseProperty("ManufacturerProductCategories")]
    public virtual Manufacturer ManufacturerNumberNavigation { get; set; } = null!;

    [InverseProperty("ManufacturerProductCategory")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
