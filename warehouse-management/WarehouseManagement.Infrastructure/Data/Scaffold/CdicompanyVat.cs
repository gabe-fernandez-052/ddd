using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("CdicompanyNumber", "CountryCode")]
[Table("CDICompanyVAT")]
[Index("Rowguid", Name = "MSmerge_index_623393234", IsUnique = true)]
public partial class CdicompanyVat
{
    [Key]
    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    [Key]
    [StringLength(10)]
    public string CountryCode { get; set; } = null!;

    [Column(TypeName = "decimal(18, 5)")]
    public decimal Rate { get; set; }

    [StringLength(4)]
    public string Division { get; set; } = null!;

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [StringLength(3)]
    public string ReportingCurrencyCode { get; set; } = null!;

    [StringLength(30)]
    public string? AccountingReference { get; set; }

    [StringLength(3)]
    public string? InvoiceCurrencyCode { get; set; }

    public bool IsLocalDeliveryOnly { get; set; }

    public short? ExchangeRateType { get; set; }

    [Column("SuppressforVATID")]
    public bool SuppressforVatid { get; set; }

    [ForeignKey("CdicompanyNumber")]
    [InverseProperty("CdicompanyVats")]
    public virtual Cdicompany CdicompanyNumberNavigation { get; set; } = null!;

    [ForeignKey("CountryCode")]
    [InverseProperty("CdicompanyVats")]
    public virtual Country CountryCodeNavigation { get; set; } = null!;
}
