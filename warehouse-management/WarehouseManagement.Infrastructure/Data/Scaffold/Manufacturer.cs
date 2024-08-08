using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("Manufacturer")]
public partial class Manufacturer
{
    [Key]
    public int ManufacturerNumber { get; set; }

    [StringLength(50)]
    public string ManufacturerName { get; set; } = null!;

    [StringLength(20)]
    public string? ManufacturerPhone { get; set; }

    [StringLength(20)]
    public string? ManufacturerFax { get; set; }

    [StringLength(50)]
    public string? ManufacturerEmail { get; set; }

    [StringLength(250)]
    public string? ManufacturerWebAddress { get; set; }

    [StringLength(50)]
    public string? ManufacturerDatasheetAddress { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public short ManufacturerTrustLevel { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ManufacturerEntryDate { get; set; }

    public int? BranchLastUpdated { get; set; }

    public bool ManufacturerLimitProductEntry { get; set; }

    public bool ManufacturerCentrallyPurchase { get; set; }

    [StringLength(10)]
    public string? CountryCode { get; set; }

    public int ManufacturerPurchasingWindow { get; set; }

    public bool ManufacturerRequireDesignInfo { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [StringLength(10)]
    public string? DefaultCountryOfOrigin { get; set; }

    [Column("ManufacturerDUNs")]
    [StringLength(30)]
    public string? ManufacturerDuns { get; set; }

    public bool DefaultIsHoldRequired { get; set; }

    [StringLength(50)]
    public string? ManufacturerDisplayName { get; set; }

    [ForeignKey("DefaultCountryOfOrigin")]
    [InverseProperty("Manufacturers")]
    public virtual Country? DefaultCountryOfOriginNavigation { get; set; }

    [InverseProperty("ManufacturerNumberNavigation")]
    public virtual ICollection<ManufacturerConfiguration> ManufacturerConfigurations { get; set; } = new List<ManufacturerConfiguration>();

    [InverseProperty("ManufacturerNumberNavigation")]
    public virtual ICollection<ManufacturerProductCategory> ManufacturerProductCategories { get; set; } = new List<ManufacturerProductCategory>();

    [InverseProperty("ManufacturerNumberNavigation")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    [InverseProperty("ManufacturerNumberNavigation")]
    public virtual ICollection<SupplierManufacturer> SupplierManufacturers { get; set; } = new List<SupplierManufacturer>();
}
