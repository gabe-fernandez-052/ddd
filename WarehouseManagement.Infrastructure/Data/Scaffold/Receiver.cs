using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("Receiver")]
public partial class Receiver
{
    [Key]
    public int ReceiverNumber { get; set; }

    public int? CarrierNumber { get; set; }

    [StringLength(8)]
    public string? CarrierServiceCode { get; set; }

    public int WarehouseNumber { get; set; }

    [StringLength(30)]
    public string? ReceiverPackingList { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ReceiverDate { get; set; }

    public int ReceiverType { get; set; }

    public int ReceiverStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateLastUpdated { get; set; }

    public int? WhoLastUpdated { get; set; }

    public int? BranchLastUpdated { get; set; }

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    [Column("CDICompanyNumber")]
    public int CdicompanyNumber { get; set; }

    [StringLength(50)]
    public string? TrackingNumber { get; set; }

    [StringLength(50)]
    public string? ImportEntryReference { get; set; }

    [StringLength(2)]
    public string DocumentLanguage { get; set; } = null!;

    [ForeignKey("CarrierNumber, CarrierServiceCode")]
    [InverseProperty("Receivers")]
    public virtual CarrierService? CarrierService { get; set; }

    [ForeignKey("CdicompanyNumber")]
    [InverseProperty("Receivers")]
    public virtual Cdicompany CdicompanyNumberNavigation { get; set; } = null!;

    [InverseProperty("ReceiverNumberNavigation")]
    public virtual ICollection<ReceiverItem> ReceiverItems { get; set; } = new List<ReceiverItem>();

    [InverseProperty("ReceiverNumberNavigation")]
    public virtual ReceiverSupplierOrder? ReceiverSupplierOrder { get; set; }

    [ForeignKey("WarehouseNumber")]
    [InverseProperty("Receivers")]
    public virtual Warehouse WarehouseNumberNavigation { get; set; } = null!;
}
