using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[PrimaryKey("PackLogixLpn", "ProductNumber", "Quantity", "DateCode", "LotOrSerial")]
[Table("ShipmentPackageDetail")]
[Index("Rowguid", Name = "index_rowguid", IsUnique = true)]
public partial class ShipmentPackageDetail
{
    [Key]
    [Column("PackLogixLPN")]
    public int PackLogixLpn { get; set; }

    [Key]
    public int ProductNumber { get; set; }

    [Key]
    public int Quantity { get; set; }

    [Key]
    [StringLength(50)]
    public string DateCode { get; set; } = null!;

    [Key]
    [StringLength(50)]
    public string LotOrSerial { get; set; } = null!;

    [Column("COO")]
    [StringLength(10)]
    public string? Coo { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }
}
