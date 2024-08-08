using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("SupplierNumber", "SupplierDealNumber", "ProductNumber")]
[Table("SupplierDealProduct")]
[Index("DealNumber", Name = "IX_SupplierDealProduct_DealNumber")]
public partial class SupplierDealProduct
{
    [Key]
    public int SupplierNumber { get; set; }

    [Key]
    public int SupplierDealNumber { get; set; }

    [Key]
    public int ProductNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal? DealProductCost { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal? DealProductResale { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public int? QuantityLimit { get; set; }

    public int DealNumber { get; set; }

    public short? ItemStatus { get; set; }

    public int? ItemNumber { get; set; }

    public int? FormatNumber { get; set; }

    [ForeignKey("ProductNumber")]
    [InverseProperty("SupplierDealProducts")]
    public virtual Product ProductNumberNavigation { get; set; } = null!;
}
