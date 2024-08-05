using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("TransactionSubType", "TransactionNumber", "ItemNumber", "RevisionId")]
[Table("OrderItemChange")]
public partial class OrderItemChange
{
    [Key]
    public int TransactionSubType { get; set; }

    [Key]
    public int TransactionNumber { get; set; }

    [Key]
    public int ItemNumber { get; set; }

    [Key]
    [Column("RevisionID")]
    public int RevisionId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RequestDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ScheduledDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ConfirmedDate { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal Cost { get; set; }

    public int ContactNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ChangeDate { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public int? ProductNumber { get; set; }

    public int? FormatNumber { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal? Resale { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ShipDate { get; set; }

    [StringLength(256)]
    public string? ChangeNote { get; set; }

    public int? Status { get; set; }

    public int? SubStatus { get; set; }

    public bool? ItemHold { get; set; }

    public int? Warehouse { get; set; }

    public int? ExportPhase { get; set; }
}
