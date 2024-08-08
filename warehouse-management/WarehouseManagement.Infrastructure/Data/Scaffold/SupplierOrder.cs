using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("SupplierOrder")]
public partial class SupplierOrder
{
    [Key]
    public int SupplierOrderNumber { get; set; }

    public int TeamMemberNumber { get; set; }

    public int? NoteNumber { get; set; }

    public int ContactNumber { get; set; }

    [StringLength(3)]
    public string? CurrencyCode { get; set; }

    public int BranchNumber { get; set; }

    public short PaymentTermsType { get; set; }

    public int SupplierNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime SupplierOrderDate { get; set; }

    public short SupplierOrderStatus { get; set; }

    [StringLength(30)]
    public string? SupplierOrderReference { get; set; }

    public bool SupplierOrderShipComplete { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    [StringLength(50)]
    public string? Incoterms { get; set; }

    [StringLength(2)]
    public string DocumentLanguage { get; set; } = null!;

    [ForeignKey("BranchNumber")]
    [InverseProperty("SupplierOrders")]
    public virtual Branch BranchNumberNavigation { get; set; } = null!;

    [ForeignKey("CdicompanyNumber")]
    [InverseProperty("SupplierOrders")]
    public virtual Cdicompany CdicompanyNumberNavigation { get; set; } = null!;

    [ForeignKey("PaymentTermsType")]
    [InverseProperty("SupplierOrders")]
    public virtual PaymentTerm PaymentTermsTypeNavigation { get; set; } = null!;

    [InverseProperty("SupplierOrderNumberNavigation")]
    public virtual ICollection<ReceiverSupplierOrder> ReceiverSupplierOrders { get; set; } = new List<ReceiverSupplierOrder>();

    [ForeignKey("SupplierNumber")]
    [InverseProperty("SupplierOrders")]
    public virtual Supplier SupplierNumberNavigation { get; set; } = null!;

    [InverseProperty("SupplierOrderNumberNavigation")]
    public virtual ICollection<SupplierOrderItem> SupplierOrderItems { get; set; } = new List<SupplierOrderItem>();
}
