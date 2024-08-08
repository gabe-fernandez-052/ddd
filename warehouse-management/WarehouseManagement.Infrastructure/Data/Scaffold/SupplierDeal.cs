using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("SupplierNumber", "SupplierDealNumber")]
[Table("SupplierDeal")]
[Index("DealNumber", Name = "IX_SupplierDeal_DealNumber")]
public partial class SupplierDeal
{
    [Key]
    public int SupplierNumber { get; set; }

    [Key]
    public int SupplierDealNumber { get; set; }

    public short DealBasis { get; set; }

    public short DealPaymentType { get; set; }

    public double? DealPaymentPercentage { get; set; }

    [StringLength(200)]
    public string? DealCriteria { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [StringLength(50)]
    public string? DealReference { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DealStartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DealEndDate { get; set; }

    public int DealProcessingMethod { get; set; }

    public bool DealShowSupplierSource { get; set; }

    public int DealNumber { get; set; }

    public int? TeamMemberNumber { get; set; }

    [StringLength(2)]
    public string DocumentLanguage { get; set; } = null!;

    public int? EndCustomerNumber { get; set; }

    public int? EndLocationNumber { get; set; }

    [ForeignKey("EndCustomerNumber, EndLocationNumber")]
    [InverseProperty("SupplierDeals")]
    public virtual InternalLocation? InternalLocation { get; set; }

    [ForeignKey("SupplierNumber")]
    [InverseProperty("SupplierDeals")]
    public virtual Supplier SupplierNumberNavigation { get; set; } = null!;
}
