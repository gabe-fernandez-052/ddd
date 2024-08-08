using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("Customer")]
public partial class Customer
{
    [Key]
    public int CustomerNumber { get; set; }

    [StringLength(75)]
    public string? CustomerName { get; set; }

    [StringLength(60)]
    public string? CustomerAddress { get; set; }

    [StringLength(60)]
    public string? CustomerAddress2 { get; set; }

    [StringLength(30)]
    public string? CustomerCity { get; set; }

    [StringLength(20)]
    public string? CustomerState { get; set; }

    [StringLength(20)]
    public string? CustomerPostalCode { get; set; }

    [StringLength(20)]
    public string? CustomerPhone { get; set; }

    [StringLength(20)]
    public string? CustomerFax { get; set; }

    [StringLength(350)]
    public string? CustomerEmail { get; set; }

    public short CustomerPrimaryFunction { get; set; }

    public int? CustomerDefaultLocation { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CustomerEntryDate { get; set; }

    public int? SalesTipNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [StringLength(50)]
    public string? CustomerWebAddress { get; set; }

    [StringLength(10)]
    public string? CountryCode { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column("CustomerDUNS")]
    [StringLength(30)]
    public string? CustomerDuns { get; set; }

    [Column("CustomerEIN")]
    [StringLength(30)]
    public string? CustomerEin { get; set; }

    [Column("ParentID")]
    public int? ParentId { get; set; }

    public int ExportStatus { get; set; }

    [InverseProperty("CustomerNumberNavigation")]
    public virtual ICollection<Arinvoice> Arinvoices { get; set; } = new List<Arinvoice>();

    [InverseProperty("CustomerNumberNavigation")]
    public virtual ICollection<CdicompanyAccount> CdicompanyAccounts { get; set; } = new List<CdicompanyAccount>();

    [InverseProperty("CustomerNumberNavigation")]
    public virtual ICollection<CdicompanyCommission> CdicompanyCommissions { get; set; } = new List<CdicompanyCommission>();

    [InverseProperty("CustomerNumberNavigation")]
    public virtual ICollection<CustomerExpedite> CustomerExpedites { get; set; } = new List<CustomerExpedite>();

    [InverseProperty("CustomerNumberNavigation")]
    public virtual ICollection<CustomerLocation> CustomerLocations { get; set; } = new List<CustomerLocation>();

    [InverseProperty("CustomerNumberNavigation")]
    public virtual ICollection<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();

    [InverseProperty("CustomerNumberNavigation")]
    public virtual ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
}
