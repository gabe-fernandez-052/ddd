using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

public partial class PaymentTerm
{
    [Key]
    public short PaymentTermsType { get; set; }

    [StringLength(30)]
    public string PaymentTermsDescription { get; set; } = null!;

    public short PaymentTermsStandardDays { get; set; }

    public double? PaymentTermsDiscount { get; set; }

    public short? PaymentTermsDiscountDays { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public short? MonthsToAdd { get; set; }

    public short? DayOfMonth { get; set; }

    public bool RequiresPrepayment { get; set; }

    public bool RequiresCreditCardAuthorization { get; set; }

    [StringLength(250)]
    public string? CustomerDocumentMessage { get; set; }

    [InverseProperty("PaymentTermsTypeNavigation")]
    public virtual ICollection<ArshipmentInvoice> ArshipmentInvoices { get; set; } = new List<ArshipmentInvoice>();

    [InverseProperty("PaymentTermsTypeNavigation")]
    public virtual ICollection<Cdicompany> Cdicompanies { get; set; } = new List<Cdicompany>();

    [InverseProperty("PaymentTermsTypeNavigation")]
    public virtual ICollection<CdicompanyAccount> CdicompanyAccounts { get; set; } = new List<CdicompanyAccount>();

    [InverseProperty("PaymentTermsTypeNavigation")]
    public virtual ICollection<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();

    [InverseProperty("PaymentTermsTypeNavigation")]
    public virtual ICollection<SupplierOrder> SupplierOrders { get; set; } = new List<SupplierOrder>();

    [InverseProperty("PaymentTermsTypeNavigation")]
    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
