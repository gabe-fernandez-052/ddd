using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("CustomerNumber", "LocationNumber")]
[Table("InternalLocation")]
public partial class InternalLocation
{
    [Key]
    public int CustomerNumber { get; set; }

    [Key]
    public int LocationNumber { get; set; }

    [StringLength(75)]
    public string? LocationName { get; set; }

    [StringLength(60)]
    public string? LocationAddress { get; set; }

    [StringLength(60)]
    public string? LocationAddress2 { get; set; }

    [StringLength(30)]
    public string? LocationCity { get; set; }

    [StringLength(20)]
    public string? LocationState { get; set; }

    [StringLength(20)]
    public string? LocationPostalCode { get; set; }

    [StringLength(20)]
    public string? LocationPhone { get; set; }

    [StringLength(20)]
    public string? LocationFax { get; set; }

    [StringLength(20)]
    public string? LocationResaleNumber { get; set; }

    public bool LocationResaleForm { get; set; }

    public double? LocationTaxRate { get; set; }

    [StringLength(50)]
    public string? LocationEmail { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    public bool LocationTaxable { get; set; }

    public bool LocationOriginCertificate { get; set; }

    public bool LocationResidential { get; set; }

    [StringLength(10)]
    public string? CountryCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LocationResaleExpiration { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [StringLength(50)]
    public string? LocationInnerLabelFormat { get; set; }

    [StringLength(50)]
    public string? LocationOuterLabelFormat { get; set; }

    [Column("CDITerritoryNumber")]
    public int? CditerritoryNumber { get; set; }

    [StringLength(4000)]
    public string? LocationFreightInstructions { get; set; }

    [StringLength(20)]
    public string? CustomsRegistrationCode { get; set; }

    public bool IsFreightForwarder { get; set; }

    [StringLength(50)]
    public string? IncoTerms { get; set; }

    [ForeignKey("CustomerNumber, LocationNumber")]
    [InverseProperty("InternalLocation")]
    public virtual CustomerLocation CustomerLocation { get; set; } = null!;

    [InverseProperty("InternalLocation")]
    public virtual ICollection<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();

    [InverseProperty("InternalLocation")]
    public virtual ICollection<CustomerTeamMember> CustomerTeamMembers { get; set; } = new List<CustomerTeamMember>();

    [InverseProperty("InternalLocation")]
    public virtual ICollection<SupplierDeal> SupplierDeals { get; set; } = new List<SupplierDeal>();
}
