using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("SupplierNumber", "ProductNumber", "FormatNumber")]
[Table("SupplierInventoryItem")]
public partial class SupplierInventoryItem
{
    [Key]
    public int SupplierNumber { get; set; }

    [Key]
    public int ProductNumber { get; set; }

    [Key]
    public int FormatNumber { get; set; }

    public short? SupplierItemLeadTime { get; set; }

    public bool SupplierItemRotate { get; set; }

    public bool SupplierItemReturnStock { get; set; }

    public bool SupplierItemCancel { get; set; }

    public int? SupplierItemMinimumQuantity { get; set; }

    [StringLength(50)]
    public string? SupplierItemPartNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FactoryStockDate { get; set; }

    public int? FactoryStock { get; set; }

    public int SafetyStockQuantity { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal SafetyStockPercentage { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? QuoteExpirationDate { get; set; }

    [ForeignKey("SupplierNumber")]
    [InverseProperty("SupplierInventoryItems")]
    public virtual Supplier SupplierNumberNavigation { get; set; } = null!;
}
