using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("TransactionType", "TransactionSubType", "TransactionNumber", "ItemNumber")]
[Table("TransactionItemTariff")]
[Index("Rowguid", Name = "IX_TransactionItemTariff_rowguid", IsUnique = true)]
public partial class TransactionItemTariff
{
    [Key]
    public int TransactionType { get; set; }

    [Key]
    public int TransactionSubType { get; set; }

    [Key]
    public int TransactionNumber { get; set; }

    [Key]
    public short ItemNumber { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal TariffRate { get; set; }

    public short RateMethod { get; set; }

    public short BillingMethod { get; set; }

    [StringLength(1024)]
    public string? Description { get; set; }

    public int? WhoLastUpdated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [StringLength(10)]
    public string? CountryOfOrigin { get; set; }

    [ForeignKey("CountryOfOrigin")]
    [InverseProperty("TransactionItemTariffs")]
    public virtual Country? CountryOfOriginNavigation { get; set; }
}
