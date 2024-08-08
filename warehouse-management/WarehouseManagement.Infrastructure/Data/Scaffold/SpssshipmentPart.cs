using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("OrderType", "OrderNumber", "CarrierServiceNumber", "PartNumber")]
[Table("SPSSShipmentPart")]
public partial class SpssshipmentPart
{
    [Key]
    public int OrderType { get; set; }

    [Key]
    public int OrderNumber { get; set; }

    [Key]
    public int CarrierServiceNumber { get; set; }

    [Key]
    [StringLength(50)]
    public string PartNumber { get; set; } = null!;

    [Column("COO")]
    [StringLength(10)]
    public string? Coo { get; set; }

    public int? ShipmentNumber { get; set; }
}
