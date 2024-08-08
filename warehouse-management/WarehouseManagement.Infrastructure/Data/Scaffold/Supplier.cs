using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("Supplier")]
public partial class Supplier
{
    [Key]
    public int SupplierNumber { get; set; }

    public short PaymentTermsType { get; set; }

    [StringLength(50)]
    public string SupplierName { get; set; } = null!;

    [StringLength(60)]
    public string? SupplierAddress { get; set; }

    [StringLength(60)]
    public string? SupplierAddress2 { get; set; }

    [StringLength(30)]
    public string? SupplierCity { get; set; }

    [StringLength(20)]
    public string? SupplierState { get; set; }

    [StringLength(30)]
    public string? SupplierCountry { get; set; }

    [StringLength(20)]
    public string? SupplierPhone { get; set; }

    [StringLength(20)]
    public string? SupplierFax { get; set; }

    [StringLength(50)]
    public string? SupplierEmail { get; set; }

    [StringLength(20)]
    public string? SupplierPostalCode { get; set; }

    [Column(TypeName = "money")]
    public decimal? SupplierMinimumOrderAmount { get; set; }

    public bool SupplierRotate { get; set; }

    public bool SupplierReturnStock { get; set; }

    public bool SupplierCancel { get; set; }

    public double? SupplierRestockingCharge { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    [StringLength(250)]
    public string? SupplierWebAddress { get; set; }

    public short SupplierTrustLevel { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SupplierEntryDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SupplierPriceListDate { get; set; }

    public short SupplierStatus { get; set; }

    public short SupplierDefaultWarehouse { get; set; }

    public short? SupplierCheckRunDays { get; set; }

    public int? BranchLastUpdated { get; set; }

    [StringLength(30)]
    public string? SupplierAccountReference { get; set; }

    [StringLength(10)]
    public string? CountryCode { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? SupplierAveragePayDays { get; set; }

    public bool SupplierShowEndCustomer { get; set; }

    public bool SupplierAllowDrop { get; set; }

    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    public short SupplierType { get; set; }

    [StringLength(2)]
    public string? AccountingDivision { get; set; }

    public int? BaseSupplierNumber { get; set; }

    public int? OrderChangeCancelWindow { get; set; }

    public int? QuoteExpirationDays { get; set; }

    public bool ProcessBillBack { get; set; }

    public bool ShowSupplierPartNumber { get; set; }

    [StringLength(50)]
    public string? Incoterms { get; set; }

    public bool ShowSupplierPartToCustomer { get; set; }

    [StringLength(2)]
    public string DocumentLanguage { get; set; } = null!;

    [InverseProperty("SupplierNumberNavigation")]
    public virtual ICollection<Apinvoice> Apinvoices { get; set; } = new List<Apinvoice>();

    [ForeignKey("CdicompanyNumber")]
    [InverseProperty("Suppliers")]
    public virtual Cdicompany CdicompanyNumberNavigation { get; set; } = null!;

    [ForeignKey("CountryCode")]
    [InverseProperty("Suppliers")]
    public virtual Country? CountryCodeNavigation { get; set; }

    [ForeignKey("PaymentTermsType")]
    [InverseProperty("Suppliers")]
    public virtual PaymentTerm PaymentTermsTypeNavigation { get; set; } = null!;

    [InverseProperty("SupplierNumberNavigation")]
    public virtual ICollection<SupplierDeal> SupplierDeals { get; set; } = new List<SupplierDeal>();

    [InverseProperty("SupplierNumberNavigation")]
    public virtual ICollection<SupplierInventoryItem> SupplierInventoryItems { get; set; } = new List<SupplierInventoryItem>();

    [InverseProperty("SupplierNumberNavigation")]
    public virtual ICollection<SupplierManufacturer> SupplierManufacturers { get; set; } = new List<SupplierManufacturer>();

    [InverseProperty("SupplierNumberNavigation")]
    public virtual ICollection<SupplierOrder> SupplierOrders { get; set; } = new List<SupplierOrder>();
}
