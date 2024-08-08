using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("CdicompanyNumber", "ToCdicompanyNumber", "ManufacturerNumber", "SalesCategoryNumber", "StartDate")]
[Table("CDICompanyCommission")]
public partial class CdicompanyCommission
{
    [Key]
    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    [Key]
    [Column("ToCDICompanyNumber")]
    public int ToCdicompanyNumber { get; set; }

    [Key]
    public int ManufacturerNumber { get; set; }

    [Key]
    public int SalesCategoryNumber { get; set; }

    public short CommissionType { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal CommissionRate { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    public int? CustomerNumber { get; set; }

    [ForeignKey("CdicompanyNumber")]
    [InverseProperty("CdicompanyCommissionCdicompanyNumberNavigations")]
    public virtual Cdicompany CdicompanyNumberNavigation { get; set; } = null!;

    [ForeignKey("CustomerNumber")]
    [InverseProperty("CdicompanyCommissions")]
    public virtual Customer? CustomerNumberNavigation { get; set; }

    [ForeignKey("ToCdicompanyNumber")]
    [InverseProperty("CdicompanyCommissionToCdicompanyNumberNavigations")]
    public virtual Cdicompany ToCdicompanyNumberNavigation { get; set; } = null!;
}
