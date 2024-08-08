using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("ARInvoiceItemCommission")]
[Index("Rowguid", Name = "MSmerge_index_1042027136", IsUnique = true)]
public partial class ArinvoiceItemCommission
{
    [Key]
    public int ItemCommissionId { get; set; }

    public int InvoiceNumber { get; set; }

    public int ItemNumber { get; set; }

    public int SplitType { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal SplitPercentage { get; set; }

    public int TeamMemberNumber { get; set; }

    public int SalesRole { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public int? WhoLastUpdated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    [ForeignKey("InvoiceNumber, ItemNumber")]
    [InverseProperty("ArinvoiceItemCommissions")]
    public virtual ArinvoiceItemCommon ArinvoiceItemCommon { get; set; } = null!;
}
