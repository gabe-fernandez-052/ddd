using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("CdicompanyNumber", "CustomerNumber")]
[Table("CDICompanyAccount")]
public partial class CdicompanyAccount
{
    [Key]
    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    [Key]
    public int CustomerNumber { get; set; }

    public bool CustomerProcessCredit { get; set; }

    [Column(TypeName = "money")]
    public decimal CustomerCreditLine { get; set; }

    public short CustomerCreditStatus { get; set; }

    public short CustomerStatus { get; set; }

    public int? CustomerSubStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CustomerStatusDate { get; set; }

    public int CustomerDaysFactor { get; set; }

    public float CustomerAveragePayDays { get; set; }

    [Column(TypeName = "money")]
    public decimal CustomerAccountBalance { get; set; }

    [Column(TypeName = "money")]
    public decimal CustomerOver30 { get; set; }

    [Column(TypeName = "money")]
    public decimal CustomerOver60 { get; set; }

    [Column(TypeName = "money")]
    public decimal CustomerOver90 { get; set; }

    [Column(TypeName = "money")]
    public decimal CustomerOver120 { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public short PaymentTermsType { get; set; }

    public short InvoiceMethod { get; set; }

    public bool AllowCancel { get; set; }

    public bool AllowReturn { get; set; }

    [StringLength(50)]
    public string? InvoiceReference { get; set; }

    [Column(TypeName = "money")]
    public decimal? PriorYearSales { get; set; }

    [Column("YTDSales", TypeName = "money")]
    public decimal? Ytdsales { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastStatementDate { get; set; }

    public int? MaxInvoiceDaysLate { get; set; }

    [StringLength(20)]
    public string? InvoiceFax { get; set; }

    public short? SalesStatus { get; set; }

    [StringLength(4000)]
    public string? InvoiceEmail { get; set; }

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [StringLength(2)]
    public string DocumentLanguage { get; set; } = null!;

    [ForeignKey("CdicompanyNumber")]
    [InverseProperty("CdicompanyAccounts")]
    public virtual Cdicompany CdicompanyNumberNavigation { get; set; } = null!;

    [ForeignKey("CustomerNumber")]
    [InverseProperty("CdicompanyAccounts")]
    public virtual Customer CustomerNumberNavigation { get; set; } = null!;

    [ForeignKey("PaymentTermsType")]
    [InverseProperty("CdicompanyAccounts")]
    public virtual PaymentTerm PaymentTermsTypeNavigation { get; set; } = null!;
}
