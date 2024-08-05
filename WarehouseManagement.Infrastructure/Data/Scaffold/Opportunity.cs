using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("Opportunity")]
public partial class Opportunity
{
    [Key]
    public int OpportunityNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EntryDate { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(50)]
    public string? Application { get; set; }

    [StringLength(50)]
    public string? EndProduct { get; set; }

    public int Phase { get; set; }

    [StringLength(50)]
    public string OpportunityName { get; set; } = null!;

    public int CustomerNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PrototypeDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ProductionDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CloseDate { get; set; }

    public int BranchNumber { get; set; }

    public int TeamMemberNumber { get; set; }

    public short OpportunityRating { get; set; }

    public short OpportunityReferralCode { get; set; }

    public int? OpportunityReferralReference { get; set; }

    public int Status { get; set; }

    public int? LostReason { get; set; }

    [StringLength(255)]
    public string? LostReasonNote { get; set; }

    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public int BuildModel { get; set; }

    public int EstimatedAnnualUsage { get; set; }

    public int? WhoEntered { get; set; }

    public int? LocationNumber { get; set; }

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    public int CategoryId { get; set; }

    [StringLength(2)]
    public string DocumentLanguage { get; set; } = null!;

    [ForeignKey("BranchNumber")]
    [InverseProperty("Opportunities")]
    public virtual Branch BranchNumberNavigation { get; set; } = null!;

    [ForeignKey("CdicompanyNumber")]
    [InverseProperty("Opportunities")]
    public virtual Cdicompany CdicompanyNumberNavigation { get; set; } = null!;

    [ForeignKey("CustomerNumber")]
    [InverseProperty("Opportunities")]
    public virtual Customer CustomerNumberNavigation { get; set; } = null!;

    [InverseProperty("OpportunityNumberNavigation")]
    public virtual ICollection<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();
}
