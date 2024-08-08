using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("Product")]
[Index("ManufacturerNumber", Name = "IX_Product_ManufacturerNumber_Include")]
[Index("ProductTypeNumber", Name = "IX_Product_ProductTypeNumber")]
[Index("ManufacturerNumber", "ProductTypeNumber", Name = "product_manufacturer_producttype_ix")]
[Index("ManufacturerNumber", "ProductCategoryNumber", "ProductStatus", Name = "productsearch_ix")]
public partial class Product
{
    [Key]
    public int ProductNumber { get; set; }

    public int StandardFormat { get; set; }

    public int ManufacturerNumber { get; set; }

    [StringLength(50)]
    public string ProductPartNumber { get; set; } = null!;

    public double? ProductWeight { get; set; }

    [StringLength(30)]
    public string? ProductPackingRestrictions { get; set; }

    public short? ProductShelfLife { get; set; }

    public short? ProductRating { get; set; }

    public short ProductStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ProductLastBuyDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    public int ProductCategoryNumber { get; set; }

    public int? ProductLeadTime { get; set; }

    public double? ProductRunRate { get; set; }

    public int ProductTypeNumber { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [StringLength(200)]
    public string? ProductDatasheetReference { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ProductEntryDate { get; set; }

    [StringLength(100)]
    public string? ProductMessage { get; set; }

    [Column("IsROHSCompliant")]
    public bool IsRohscompliant { get; set; }

    public bool IsRegisterable { get; set; }

    [StringLength(200)]
    public string? ProductDescription { get; set; }

    public bool? IsExportRestricted { get; set; }

    [Column("HTSCode")]
    [StringLength(20)]
    public string? Htscode { get; set; }

    [Column("ECCN")]
    [StringLength(20)]
    public string? Eccn { get; set; }

    [StringLength(10)]
    public string? ProductOriginCountry { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LeadTimeEntryDate { get; set; }

    public bool IsHoldRequired { get; set; }

    public int? MoistureSensitivityLevel { get; set; }

    public int AccountClass { get; set; }

    [Column("IsCAProposition65Regulated")]
    public bool IsCaproposition65Regulated { get; set; }

    public bool IsIdentifierRequired { get; set; }

    [ForeignKey("ManufacturerNumber")]
    [InverseProperty("Products")]
    public virtual Manufacturer ManufacturerNumberNavigation { get; set; } = null!;

    [ForeignKey("ManufacturerNumber, ProductCategoryNumber")]
    [InverseProperty("Products")]
    public virtual ManufacturerProductCategory ManufacturerProductCategory { get; set; } = null!;

    [ForeignKey("ProductOriginCountry")]
    [InverseProperty("Products")]
    public virtual Country? ProductOriginCountryNavigation { get; set; }

    [InverseProperty("ProductNumberNavigation")]
    public virtual ICollection<ShipmentContentItem> ShipmentContentItems { get; set; } = new List<ShipmentContentItem>();

    [InverseProperty("ProductNumberNavigation")]
    public virtual ICollection<SupplierDealProduct> SupplierDealProducts { get; set; } = new List<SupplierDealProduct>();

    [InverseProperty("ProductNumberNavigation")]
    public virtual ICollection<SupplierOrderItem> SupplierOrderItems { get; set; } = new List<SupplierOrderItem>();
}
