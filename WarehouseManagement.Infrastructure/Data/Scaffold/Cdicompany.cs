using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("CDICompany")]
public partial class Cdicompany
{
    [Key]
    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    [Column("CDICompanyDomain")]
    [StringLength(30)]
    public string CdicompanyDomain { get; set; } = null!;

    [Column("CDICompanyName")]
    [StringLength(50)]
    public string CdicompanyName { get; set; } = null!;

    [Column("CDICompanyTaxID")]
    [StringLength(30)]
    public string CdicompanyTaxId { get; set; } = null!;

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column("CDICompanyShortName")]
    [StringLength(30)]
    public string CdicompanyShortName { get; set; } = null!;

    public short? PaymentTermsType { get; set; }

    [Column(TypeName = "money")]
    public decimal CustomerCreditLine { get; set; }

    public bool EnforceCreditLimit { get; set; }

    public int? HoldDays { get; set; }

    [Column("DUNS")]
    [StringLength(30)]
    public string? Duns { get; set; }

    [Column("ARAddress")]
    [StringLength(60)]
    public string? Araddress { get; set; }

    [Column("ARAddress2")]
    [StringLength(60)]
    public string? Araddress2 { get; set; }

    [Column("ARCity")]
    [StringLength(30)]
    public string? Arcity { get; set; }

    [Column("ARState")]
    [StringLength(20)]
    public string? Arstate { get; set; }

    [Column("ARPostalCode")]
    [StringLength(20)]
    public string? ArpostalCode { get; set; }

    [Column("ARPhone")]
    [StringLength(20)]
    public string? Arphone { get; set; }

    [Column("ARFax")]
    [StringLength(20)]
    public string? Arfax { get; set; }

    [Column("AREmail")]
    [StringLength(350)]
    public string? Aremail { get; set; }

    [Column("APAddress")]
    [StringLength(60)]
    public string? Apaddress { get; set; }

    [Column("APAddress2")]
    [StringLength(60)]
    public string? Apaddress2 { get; set; }

    [Column("APCity")]
    [StringLength(30)]
    public string? Apcity { get; set; }

    [Column("APState")]
    [StringLength(20)]
    public string? Apstate { get; set; }

    [Column("APPostalCode")]
    [StringLength(20)]
    public string? AppostalCode { get; set; }

    [Column("APPhone")]
    [StringLength(20)]
    public string? Apphone { get; set; }

    [Column("APFax")]
    [StringLength(20)]
    public string? Apfax { get; set; }

    [Column("APEmail")]
    [StringLength(350)]
    public string? Apemail { get; set; }

    [Column("INCOTERMS")]
    [StringLength(50)]
    public string? Incoterms { get; set; }

    [Column("ARCountryCode")]
    [StringLength(10)]
    public string? ArcountryCode { get; set; }

    [Column("APCountryCode")]
    [StringLength(10)]
    public string? ApcountryCode { get; set; }

    [Column("MASIntegration")]
    public bool Masintegration { get; set; }

    public int? DefaultWarehouse { get; set; }

    public int? DefaultContact { get; set; }

    public int? DefaultBranch { get; set; }

    [StringLength(350)]
    public string? SalesEmail { get; set; }

    [StringLength(30)]
    public string? AccountingReference { get; set; }

    [StringLength(3)]
    public string? BaseCurrency { get; set; }

    public short ExchangeRateType { get; set; }

    public bool IsOpportunityRequiredForSample { get; set; }

    public short? DefaultReportingCalendar { get; set; }

    [StringLength(100)]
    public string? LegalName { get; set; }

    [StringLength(2)]
    public string DocumentLanguage { get; set; } = null!;

    [InverseProperty("CdicompanyNumberNavigation")]
    public virtual ICollection<Allocation> Allocations { get; set; } = new List<Allocation>();

    [ForeignKey("ApcountryCode")]
    [InverseProperty("CdicompanyApcountryCodeNavigations")]
    public virtual Country? ApcountryCodeNavigation { get; set; }

    [InverseProperty("CdicompanyNumberNavigation")]
    public virtual ICollection<Apinvoice> Apinvoices { get; set; } = new List<Apinvoice>();

    [ForeignKey("ArcountryCode")]
    [InverseProperty("CdicompanyArcountryCodeNavigations")]
    public virtual Country? ArcountryCodeNavigation { get; set; }

    [InverseProperty("CdicompanyNumberNavigation")]
    public virtual ICollection<Arinvoice> Arinvoices { get; set; } = new List<Arinvoice>();

    [InverseProperty("CdicompanyNumberNavigation")]
    public virtual ICollection<CdicompanyAccount> CdicompanyAccounts { get; set; } = new List<CdicompanyAccount>();

    [InverseProperty("CdicompanyNumberNavigation")]
    public virtual ICollection<CdicompanyCommission> CdicompanyCommissionCdicompanyNumberNavigations { get; set; } = new List<CdicompanyCommission>();

    [InverseProperty("ToCdicompanyNumberNavigation")]
    public virtual ICollection<CdicompanyCommission> CdicompanyCommissionToCdicompanyNumberNavigations { get; set; } = new List<CdicompanyCommission>();

    [InverseProperty("CdicompanyNumberNavigation")]
    public virtual ICollection<CdicompanyGroup> CdicompanyGroupCdicompanyNumberNavigations { get; set; } = new List<CdicompanyGroup>();

    [InverseProperty("RelatedCdicompanyNumberNavigation")]
    public virtual ICollection<CdicompanyGroup> CdicompanyGroupRelatedCdicompanyNumberNavigations { get; set; } = new List<CdicompanyGroup>();

    [InverseProperty("CdicompanyNumberNavigation")]
    public virtual ICollection<CdicompanyVat> CdicompanyVats { get; set; } = new List<CdicompanyVat>();

    [InverseProperty("CdicompanyNumberNavigation")]
    public virtual ICollection<CditerritoryBranch> CditerritoryBranches { get; set; } = new List<CditerritoryBranch>();

    [InverseProperty("CdicompanyNumberNavigation")]
    public virtual ICollection<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();

    [ForeignKey("DefaultWarehouse")]
    [InverseProperty("Cdicompanies")]
    public virtual Warehouse? DefaultWarehouseNavigation { get; set; }

    [InverseProperty("CdicompanyNumberNavigation")]
    public virtual ICollection<InventoryBin> InventoryBins { get; set; } = new List<InventoryBin>();

    [InverseProperty("CdicompanyNumberNavigation")]
    public virtual ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();

    [ForeignKey("PaymentTermsType")]
    [InverseProperty("Cdicompanies")]
    public virtual PaymentTerm? PaymentTermsTypeNavigation { get; set; }

    [InverseProperty("CdicompanyNumberNavigation")]
    public virtual ICollection<Receiver> Receivers { get; set; } = new List<Receiver>();

    [InverseProperty("CdicompanyNumberNavigation")]
    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    [InverseProperty("CdicompanyNumberNavigation")]
    public virtual ICollection<SupplierManufacturer> SupplierManufacturers { get; set; } = new List<SupplierManufacturer>();

    [InverseProperty("CdicompanyNumberNavigation")]
    public virtual ICollection<SupplierOrder> SupplierOrders { get; set; } = new List<SupplierOrder>();

    [InverseProperty("CdicompanyNumberNavigation")]
    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
