using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Keyless]
public partial class VSupplierManufacturer
{
    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    public int ManufacturerNumber { get; set; }

    public int SupplierNumber { get; set; }

    public int ManufacturerStatus { get; set; }
}
