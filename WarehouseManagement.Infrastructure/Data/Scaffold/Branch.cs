using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("Branch")]
public partial class Branch
{
    [Key]
    public int BranchNumber { get; set; }

    public int? SupportBranch { get; set; }

    [StringLength(60)]
    public string BranchAddress { get; set; } = null!;

    [StringLength(60)]
    public string? BranchAddress2 { get; set; }

    [StringLength(30)]
    public string BranchCity { get; set; } = null!;

    [StringLength(30)]
    public string BranchCountry { get; set; } = null!;

    [StringLength(350)]
    public string? BranchEmail { get; set; }

    [StringLength(20)]
    public string? BranchFax { get; set; }

    [StringLength(50)]
    public string BranchName { get; set; } = null!;

    [StringLength(20)]
    public string BranchPhone { get; set; } = null!;

    [StringLength(20)]
    public string? BranchPhoneTollFree { get; set; }

    [StringLength(20)]
    public string BranchPostalCode { get; set; } = null!;

    [StringLength(20)]
    public string BranchState { get; set; } = null!;

    public short BranchType { get; set; }

    public float? BranchWeight { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [StringLength(4)]
    public string? BranchSalesDivision { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column("BranchSalesTaxID")]
    [StringLength(30)]
    public string? BranchSalesTaxId { get; set; }

    [Column("BranchDUNS")]
    [StringLength(30)]
    public string? BranchDuns { get; set; }

    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    [StringLength(10)]
    public string? CountryCode { get; set; }

    [StringLength(30)]
    public string? AccountingReference { get; set; }

    [InverseProperty("BranchNumberNavigation")]
    public virtual ICollection<ArinvoiceItemCommon> ArinvoiceItemCommons { get; set; } = new List<ArinvoiceItemCommon>();

    [ForeignKey("BranchNumber")]
    [InverseProperty("Branch")]
    public virtual Cdilocation BranchNumberNavigation { get; set; } = null!;

    [InverseProperty("BranchNumberNavigation")]
    public virtual ICollection<BranchTeamMember> BranchTeamMembers { get; set; } = new List<BranchTeamMember>();

    [InverseProperty("BranchNumberNavigation")]
    public virtual ICollection<CditerritoryBranch> CditerritoryBranches { get; set; } = new List<CditerritoryBranch>();

    [InverseProperty("BranchNumberNavigation")]
    public virtual ICollection<CustomerExpedite> CustomerExpedites { get; set; } = new List<CustomerExpedite>();

    [InverseProperty("BranchNumberNavigation")]
    public virtual ICollection<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();

    [InverseProperty("SupportBranchNavigation")]
    public virtual ICollection<Branch> InverseSupportBranchNavigation { get; set; } = new List<Branch>();

    [InverseProperty("BranchNumberNavigation")]
    public virtual ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();

    [InverseProperty("BranchNumberNavigation")]
    public virtual ICollection<SupplierOrder> SupplierOrders { get; set; } = new List<SupplierOrder>();

    [ForeignKey("SupportBranch")]
    [InverseProperty("InverseSupportBranchNavigation")]
    public virtual Branch? SupportBranchNavigation { get; set; }
}
