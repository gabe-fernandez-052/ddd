using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("ReceiverNumber", "ReceiverItemNumber")]
[Table("ReceiverItem")]
public partial class ReceiverItem
{
    [Key]
    public int ReceiverNumber { get; set; }

    [Key]
    public int ReceiverItemNumber { get; set; }

    public int ProductNumber { get; set; }

    public int FormatNumber { get; set; }

    public short ReceiverType { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal ReceiverItemCost { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ReceiverItemDate { get; set; }

    public int ReceiverItemQuantity { get; set; }

    public int ReceiverItemStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal? ReceiverItemMatchCost { get; set; }

    [StringLength(3)]
    public string CostCurrencyCode { get; set; } = null!;

    [StringLength(10)]
    public string? CountryOfOrigin { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal CostExchangeRate { get; set; }

    [ForeignKey("CountryOfOrigin")]
    [InverseProperty("ReceiverItems")]
    public virtual Country? CountryOfOriginNavigation { get; set; }

    [InverseProperty("ReceiverItem")]
    public virtual ICollection<InventoryBin> InventoryBins { get; set; } = new List<InventoryBin>();

    [ForeignKey("ReceiverNumber")]
    [InverseProperty("ReceiverItems")]
    public virtual Receiver ReceiverNumberNavigation { get; set; } = null!;

    [InverseProperty("ReceiverItem")]
    public virtual ReceiverOrderItem? ReceiverOrderItem { get; set; }
}
