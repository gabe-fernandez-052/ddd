using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("TransactionLog")]
[Index("Rowguid", Name = "MSmerge_index_2020947835", IsUnique = true)]
public partial class TransactionLog
{
    [Key]
    [Column("TransactionID")]
    public int TransactionId { get; set; }

    public int TransactionType { get; set; }

    public int TransactionSubType { get; set; }

    public int TransactionNumber { get; set; }

    public int ItemNumber { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }
}
