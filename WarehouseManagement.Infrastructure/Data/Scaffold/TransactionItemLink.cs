using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("FromType", "FromSubType", "FromTransactionNumber", "FromItemNumber", "ToType", "ToSubType", "ToTransactionNumber", "ToItemNumber")]
[Table("TransactionItemLink")]
[Index("FromTransactionNumber", Name = "IX_TransactionItemLink_FromTransactionNumber")]
[Index("FromType", "ToType", Name = "TransactionItemLink_FromType")]
public partial class TransactionItemLink
{
    [Key]
    public int FromType { get; set; }

    [Key]
    public int FromSubType { get; set; }

    [Key]
    public int FromTransactionNumber { get; set; }

    [Key]
    public int FromItemNumber { get; set; }

    [Key]
    public int ToType { get; set; }

    [Key]
    public int ToSubType { get; set; }

    [Key]
    public int ToTransactionNumber { get; set; }

    [Key]
    public int ToItemNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ToItemDate { get; set; }
}
