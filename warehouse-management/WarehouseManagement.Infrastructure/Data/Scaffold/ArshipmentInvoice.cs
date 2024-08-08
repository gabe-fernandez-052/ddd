using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("ARShipmentInvoice")]
public partial class ArshipmentInvoice
{
    [Key]
    public int InvoiceNumber { get; set; }

    public short PaymentTermsType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime InvoiceDueDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime InvoiceDiscountDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    public int InvoiceDaysToPay { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [ForeignKey("InvoiceNumber")]
    [InverseProperty("ArshipmentInvoice")]
    public virtual Arinvoice InvoiceNumberNavigation { get; set; } = null!;

    [ForeignKey("PaymentTermsType")]
    [InverseProperty("ArshipmentInvoices")]
    public virtual PaymentTerm PaymentTermsTypeNavigation { get; set; } = null!;

    [InverseProperty("InvoiceNumberNavigation")]
    public virtual ICollection<ShipmentCustomerOrder> ShipmentCustomerOrders { get; set; } = new List<ShipmentCustomerOrder>();
}
