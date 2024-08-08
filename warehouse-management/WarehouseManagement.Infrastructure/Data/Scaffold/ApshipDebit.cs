using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("APShipDebit")]
[Index("DealNumber", Name = "IX_APShipDebit_DealNumber")]
public partial class ApshipDebit
{
    [Key]
    [Column("APInvoiceNumber")]
    public int ApinvoiceNumber { get; set; }

    public int SupplierNumber { get; set; }

    public int SupplierDealNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public int DealNumber { get; set; }

    [ForeignKey("ApinvoiceNumber")]
    [InverseProperty("ApshipDebit")]
    public virtual Apinvoice ApinvoiceNumberNavigation { get; set; } = null!;
}
