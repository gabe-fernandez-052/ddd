using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

[Table("Country")]
public partial class Country
{
    [Key]
    [StringLength(10)]
    public string CountryCode { get; set; } = null!;

    [StringLength(30)]
    public string CountryName { get; set; } = null!;

    [Column("ISOCode")]
    [StringLength(3)]
    public string Isocode { get; set; } = null!;

    [StringLength(3)]
    public string CountryCodeI { get; set; } = null!;

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    public int? PhoneCode { get; set; }

    public bool IsEuropeanUnion { get; set; }

    public bool IsStateProvinceRequired { get; set; }

    public bool IsHidden { get; set; }

    [InverseProperty("ApcountryCodeNavigation")]
    public virtual ICollection<Cdicompany> CdicompanyApcountryCodeNavigations { get; set; } = new List<Cdicompany>();

    [InverseProperty("ArcountryCodeNavigation")]
    public virtual ICollection<Cdicompany> CdicompanyArcountryCodeNavigations { get; set; } = new List<Cdicompany>();

    [InverseProperty("CountryCodeNavigation")]
    public virtual ICollection<CdicompanyVat> CdicompanyVats { get; set; } = new List<CdicompanyVat>();

    [InverseProperty("CountryCodeNavigation")]
    public virtual ICollection<CditerritoryCountry> CditerritoryCountries { get; set; } = new List<CditerritoryCountry>();

    [InverseProperty("CountryCodeNavigation")]
    public virtual ICollection<CditerritoryPostalCode> CditerritoryPostalCodes { get; set; } = new List<CditerritoryPostalCode>();

    [InverseProperty("CountryCodeNavigation")]
    public virtual ICollection<CditerritoryState> CditerritoryStates { get; set; } = new List<CditerritoryState>();

    [InverseProperty("DefaultCountryOfOriginNavigation")]
    public virtual ICollection<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    [InverseProperty("CountryCodeNavigation")]
    public virtual ICollection<OrderCreditCardAuthorization> OrderCreditCardAuthorizations { get; set; } = new List<OrderCreditCardAuthorization>();

    [InverseProperty("ProductOriginCountryNavigation")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    [InverseProperty("CountryOfOriginNavigation")]
    public virtual ICollection<ReceiverItem> ReceiverItems { get; set; } = new List<ReceiverItem>();

    [InverseProperty("CountryCodeNavigation")]
    public virtual ICollection<ShipmentContentItem> ShipmentContentItems { get; set; } = new List<ShipmentContentItem>();

    [InverseProperty("CountryCodeNavigation")]
    public virtual ICollection<ShipmentItem> ShipmentItems { get; set; } = new List<ShipmentItem>();

    [InverseProperty("CountryCodeNavigation")]
    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    [InverseProperty("CountryCodeNavigation")]
    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();

    [InverseProperty("CountryOfOriginNavigation")]
    public virtual ICollection<TransactionItemTariff> TransactionItemTariffs { get; set; } = new List<TransactionItemTariff>();

    [InverseProperty("CountryCodeNavigation")]
    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
