using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("ShipmentCustomerOrder")]
public partial class ShipmentCustomerOrder
{
    [Key]
    public int ShipmentNumber { get; set; }

    public int? InvoiceNumber { get; set; }

    public int OrderNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid? Rowguid { get; set; }

    [ForeignKey("InvoiceNumber")]
    [InverseProperty("ShipmentCustomerOrders")]
    public virtual ArshipmentInvoice? InvoiceNumberNavigation { get; set; }

    [ForeignKey("OrderNumber")]
    [InverseProperty("ShipmentCustomerOrders")]
    public virtual CustomerOrder OrderNumberNavigation { get; set; } = null!;

    [ForeignKey("ShipmentNumber")]
    [InverseProperty("ShipmentCustomerOrder")]
    public virtual Shipment ShipmentNumberNavigation { get; set; } = null!;
}
