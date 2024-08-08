using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("ARInvoiceTotal")]
[Index("Rowguid", Name = "MSmerge_index_1709091802", IsUnique = true)]
public partial class ArinvoiceTotal
{
    [Key]
    public int InvoiceNumber { get; set; }

    [StringLength(3)]
    public string TotalCurrencyCode { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal TotalInvoice { get; set; }

    [Column(TypeName = "money")]
    public decimal TotalTax { get; set; }

    [Column(TypeName = "money")]
    public decimal TotalDiscount { get; set; }

    [Column(TypeName = "money")]
    public decimal TotalProduct { get; set; }

    [Column(TypeName = "money")]
    public decimal TotalFreight { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal ExchangeRate { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column(TypeName = "money")]
    public decimal BalanceDue { get; set; }

    [ForeignKey("InvoiceNumber")]
    [InverseProperty("ArinvoiceTotal")]
    public virtual Arinvoice InvoiceNumberNavigation { get; set; } = null!;
}
