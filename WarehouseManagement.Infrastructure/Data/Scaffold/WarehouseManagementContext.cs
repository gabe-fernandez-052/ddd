using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold;

public partial class WarehouseManagementContext : DbContext
{
    public WarehouseManagementContext()
    {
    }

    public WarehouseManagementContext(DbContextOptions<WarehouseManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Allocation> Allocations { get; set; }

    public virtual DbSet<AllocationInventoryBin> AllocationInventoryBins { get; set; }

    public virtual DbSet<Apinvoice> Apinvoices { get; set; }

    public virtual DbSet<ApinvoiceItemCommon> ApinvoiceItemCommons { get; set; }

    public virtual DbSet<ApshipDebit> ApshipDebits { get; set; }

    public virtual DbSet<ApshipDebitItem> ApshipDebitItems { get; set; }

    public virtual DbSet<Arinvoice> Arinvoices { get; set; }

    public virtual DbSet<ArinvoiceItem> ArinvoiceItems { get; set; }

    public virtual DbSet<ArinvoiceItemCommission> ArinvoiceItemCommissions { get; set; }

    public virtual DbSet<ArinvoiceItemCommon> ArinvoiceItemCommons { get; set; }

    public virtual DbSet<ArinvoiceTotal> ArinvoiceTotals { get; set; }

    public virtual DbSet<ArshipmentInvoice> ArshipmentInvoices { get; set; }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<BranchTeamMember> BranchTeamMembers { get; set; }

    public virtual DbSet<CarrierFreightChargeMethod> CarrierFreightChargeMethods { get; set; }

    public virtual DbSet<CarrierService> CarrierServices { get; set; }

    public virtual DbSet<Cdicompany> Cdicompanies { get; set; }

    public virtual DbSet<CdicompanyAccount> CdicompanyAccounts { get; set; }

    public virtual DbSet<CdicompanyCommission> CdicompanyCommissions { get; set; }

    public virtual DbSet<CdicompanyGroup> CdicompanyGroups { get; set; }

    public virtual DbSet<CdicompanyVat> CdicompanyVats { get; set; }

    public virtual DbSet<CdilistValue> CdilistValues { get; set; }

    public virtual DbSet<Cdilocation> Cdilocations { get; set; }

    public virtual DbSet<CditerritoryBranch> CditerritoryBranches { get; set; }

    public virtual DbSet<CditerritoryCountry> CditerritoryCountries { get; set; }

    public virtual DbSet<CditerritoryPostalCode> CditerritoryPostalCodes { get; set; }

    public virtual DbSet<CditerritoryState> CditerritoryStates { get; set; }

    public virtual DbSet<CompanyConfiguration> CompanyConfigurations { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerExpedite> CustomerExpedites { get; set; }

    public virtual DbSet<CustomerExpediteItem> CustomerExpediteItems { get; set; }

    public virtual DbSet<CustomerLocation> CustomerLocations { get; set; }

    public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }

    public virtual DbSet<CustomerTeamMember> CustomerTeamMembers { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventNote> EventNotes { get; set; }

    public virtual DbSet<FreightChargeMethod> FreightChargeMethods { get; set; }

    public virtual DbSet<InternalLocation> InternalLocations { get; set; }

    public virtual DbSet<InventoryBin> InventoryBins { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<ManufacturerConfiguration> ManufacturerConfigurations { get; set; }

    public virtual DbSet<ManufacturerProductCategory> ManufacturerProductCategories { get; set; }

    public virtual DbSet<Opportunity> Opportunities { get; set; }

    public virtual DbSet<OrderCreditCardAuthorization> OrderCreditCardAuthorizations { get; set; }

    public virtual DbSet<OrderItemCarrierAccount> OrderItemCarrierAccounts { get; set; }

    public virtual DbSet<OrderItemChange> OrderItemChanges { get; set; }

    public virtual DbSet<OrderItemCommission> OrderItemCommissions { get; set; }

    public virtual DbSet<OrderItemToShip> OrderItemToShips { get; set; }

    public virtual DbSet<OrderLineItem> OrderLineItems { get; set; }

    public virtual DbSet<OrderToShip> OrderToShips { get; set; }

    public virtual DbSet<PaymentTerm> PaymentTerms { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Receiver> Receivers { get; set; }

    public virtual DbSet<ReceiverItem> ReceiverItems { get; set; }

    public virtual DbSet<ReceiverOrderItem> ReceiverOrderItems { get; set; }

    public virtual DbSet<ReceiverSupplierOrder> ReceiverSupplierOrders { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<ShipmentContentItem> ShipmentContentItems { get; set; }

    public virtual DbSet<ShipmentCustomerOrder> ShipmentCustomerOrders { get; set; }

    public virtual DbSet<ShipmentItem> ShipmentItems { get; set; }

    public virtual DbSet<ShipmentItemBin> ShipmentItemBins { get; set; }

    public virtual DbSet<ShipmentOrderItem> ShipmentOrderItems { get; set; }

    public virtual DbSet<ShipmentPackage> ShipmentPackages { get; set; }

    public virtual DbSet<ShipmentPackageDetail> ShipmentPackageDetails { get; set; }

    public virtual DbSet<Spssshipment> Spssshipments { get; set; }

    public virtual DbSet<SpssshipmentPart> SpssshipmentParts { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplierDeal> SupplierDeals { get; set; }

    public virtual DbSet<SupplierDealProduct> SupplierDealProducts { get; set; }

    public virtual DbSet<SupplierInventoryItem> SupplierInventoryItems { get; set; }

    public virtual DbSet<SupplierManufacturer> SupplierManufacturers { get; set; }

    public virtual DbSet<SupplierOrder> SupplierOrders { get; set; }

    public virtual DbSet<SupplierOrderItem> SupplierOrderItems { get; set; }

    public virtual DbSet<TransactionItemLink> TransactionItemLinks { get; set; }

    public virtual DbSet<TransactionItemTariff> TransactionItemTariffs { get; set; }

    public virtual DbSet<TransactionLog> TransactionLogs { get; set; }

    public virtual DbSet<VSupplierManufacturer> VSupplierManufacturers { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WarehouseInventory> WarehouseInventories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allocation>(entity =>
        {
            entity.HasKey(e => e.AllocationNumber).HasName("aaaaaAllocation1_PK");

            entity.HasIndex(e => new { e.ProductNumber, e.FormatNumber }, "InventoryItemAllocation").HasFillFactor(80);

            entity.HasIndex(e => new { e.OrderInType, e.OrderInNumber, e.OrderInItemNumber }, "OrderIn").HasFillFactor(80);

            entity.HasIndex(e => new { e.OrderOutType, e.OrderOutNumber, e.OrderOutItemNumber }, "OrderOut").HasFillFactor(80);

            entity.HasIndex(e => e.WarehouseNumber, "WarehouseAllocation").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.AllocationNumber).ValueGeneratedNever();
            entity.Property(e => e.OrderInType).HasDefaultValue(2);
            entity.Property(e => e.OrderOutType).HasDefaultValue(1);
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.TransactionTypeIn).HasDefaultValue(1);
            entity.Property(e => e.TransactionTypeOut).HasDefaultValue(1);

            entity.HasOne(d => d.CdicompanyNumberNavigation).WithMany(p => p.Allocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Allocation_CDICompany");

            entity.HasOne(d => d.WarehouseNumberNavigation).WithMany(p => p.Allocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Allocation_Warehouse");
        });

        modelBuilder.Entity<AllocationInventoryBin>(entity =>
        {
            entity.Property(e => e.IsAllocationPostPick).HasDefaultValue(true);

            entity.HasOne(d => d.AllocationNumberNavigation).WithMany(p => p.AllocationInventoryBins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AllocationInventoryBin_Allocation");

            entity.HasOne(d => d.BinNumberNavigation).WithMany(p => p.AllocationInventoryBins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AllocationInventoryBin_InventoryBin");
        });

        modelBuilder.Entity<Apinvoice>(entity =>
        {
            entity.HasKey(e => e.ApinvoiceNumber).HasName("aaaaaAPInvoice_PK");

            entity.HasIndex(e => e.SupplierNumber, "IX_APInvoice_SupplierNumber").HasFillFactor(80);

            entity.HasIndex(e => new { e.SupplierNumber, e.SupplierInvoiceNumber }, "SupplierInvoiceNumber")
                .IsUnique()
                .HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.ApinvoiceNumber).ValueGeneratedNever();
            entity.Property(e => e.CurrencyCode).IsFixedLength();
            entity.Property(e => e.DocumentLanguage).HasDefaultValue("en");
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.CdicompanyNumberNavigation).WithMany(p => p.Apinvoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_APInvoice_CDICompany");

            entity.HasOne(d => d.SupplierNumberNavigation).WithMany(p => p.Apinvoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_APInvoice_Supplier");
        });

        modelBuilder.Entity<ApinvoiceItemCommon>(entity =>
        {
            entity.HasKey(e => new { e.ApinvoiceNumber, e.ApinvoiceItemNumber }).HasName("aaaaaAPInvoiceItemCommon_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.ApinvoiceNumberNavigation).WithMany(p => p.ApinvoiceItemCommons).HasConstraintName("FK_APInvoiceItemCommon_APInvoice");
        });

        modelBuilder.Entity<ApshipDebit>(entity =>
        {
            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.ApinvoiceNumber).ValueGeneratedNever();
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.ApinvoiceNumberNavigation).WithOne(p => p.ApshipDebit).HasConstraintName("FK_APShipDebit_APInvoice");
        });

        modelBuilder.Entity<ApshipDebitItem>(entity =>
        {
            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.ApinvoiceItemCommon).WithOne(p => p.ApshipDebitItem).HasConstraintName("FK_APShipDebitItem_APInvoiceItemCommon");

            entity.HasOne(d => d.ArinvoiceItemCommon).WithMany(p => p.ApshipDebitItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_APShipDebitItem_ARInvoiceItemCommon");
        });

        modelBuilder.Entity<Arinvoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceNumber).HasName("aaaaaARInvoice_PK");

            entity.HasIndex(e => e.CustomerNumber, "IX_CustomerNumber").HasFillFactor(80);

            entity.HasIndex(e => e.InvoiceStatus, "InvoiceStatus").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.InvoiceNumber).ValueGeneratedNever();
            entity.Property(e => e.BillingAdjustmentCurrency).IsFixedLength();
            entity.Property(e => e.CurrencyCode)
                .HasDefaultValue("USD")
                .IsFixedLength();
            entity.Property(e => e.DocumentLanguage).HasDefaultValue("en");
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.TaxExchangeRate).HasDefaultValue(1.0m);

            entity.HasOne(d => d.CdicompanyNumberNavigation).WithMany(p => p.Arinvoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ARInvoice_CDICompany");

            entity.HasOne(d => d.CustomerNumberNavigation).WithMany(p => p.Arinvoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ARInvoice_Customer");
        });

        modelBuilder.Entity<ArinvoiceItem>(entity =>
        {
            entity.HasKey(e => new { e.InvoiceNumber, e.InvoiceItemNumber }).HasName("aaaaaARInvoiceItem_PK");

            entity.HasIndex(e => new { e.ShipmentNumber, e.ShipmentItemNumber }, "IX_ARInvoiceItem_ShipmentItem").HasFillFactor(80);

            entity.HasIndex(e => e.InvoiceItemNumber, "JDinvoiceItemNumber").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.ArinvoiceItemCommon).WithOne(p => p.ArinvoiceItem).HasConstraintName("FK_ARInvoiceItem_ARInvoiceItemCommon");

            entity.HasOne(d => d.ShipmentItem).WithMany(p => p.ArinvoiceItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ARInvoiceItem_ShipmentItem");
        });

        modelBuilder.Entity<ArinvoiceItemCommission>(entity =>
        {
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.ArinvoiceItemCommon).WithMany(p => p.ArinvoiceItemCommissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ARInvoiceItemCommission_ARInvoiceItemCommon");
        });

        modelBuilder.Entity<ArinvoiceItemCommon>(entity =>
        {
            entity.HasKey(e => new { e.InvoiceNumber, e.InvoiceItemNumber }).HasName("aaaaaARInvoiceItemCommon_PK");

            entity.HasIndex(e => new { e.ProductNumber, e.FormatNumber, e.InvoiceType, e.InvoiceItemDate }, "IX_ARInvoiceItemCommon").HasFillFactor(80);

            entity.HasIndex(e => e.InvoiceItemDate, "InvoiceItemDate").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.CostCurrencyCode)
                .HasDefaultValue("USD")
                .IsFixedLength();
            entity.Property(e => e.CostExchangeRate).HasDefaultValue(1.0m);
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.BranchNumberNavigation).WithMany(p => p.ArinvoiceItemCommons).HasConstraintName("FK_ARInvoiceItemCommon_Branch");

            entity.HasOne(d => d.InvoiceNumberNavigation).WithMany(p => p.ArinvoiceItemCommons).HasConstraintName("FK_ARInvoiceItemCommon_ARInvoice");

            entity.HasOne(d => d.WarehouseNumberNavigation).WithMany(p => p.ArinvoiceItemCommons).HasConstraintName("FK_ARInvoiceItemCommon_Warehouse");
        });

        modelBuilder.Entity<ArinvoiceTotal>(entity =>
        {
            entity.Property(e => e.InvoiceNumber).ValueGeneratedNever();
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.TotalCurrencyCode).IsFixedLength();

            entity.HasOne(d => d.InvoiceNumberNavigation).WithOne(p => p.ArinvoiceTotal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ARInvoiceTotal_ARInvoice");
        });

        modelBuilder.Entity<ArshipmentInvoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceNumber).HasName("aaaaaARShipmentInvoice_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.InvoiceNumber).ValueGeneratedNever();
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.InvoiceNumberNavigation).WithOne(p => p.ArshipmentInvoice).HasConstraintName("FK_ARShipmentInvoice_ARInvoice");

            entity.HasOne(d => d.PaymentTermsTypeNavigation).WithMany(p => p.ArshipmentInvoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ARShipmentInvoice_PaymentTermsType");
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.BranchNumber).HasName("aaaaaBranch_PK");

            entity.HasIndex(e => e.BranchName, "BranchName").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.BranchNumber).ValueGeneratedNever();
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.BranchNumberNavigation).WithOne(p => p.Branch)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Branch_CDILocation");

            entity.HasOne(d => d.SupportBranchNavigation).WithMany(p => p.InverseSupportBranchNavigation).HasConstraintName("FK_Branch_Branch");
        });

        modelBuilder.Entity<BranchTeamMember>(entity =>
        {
            entity.HasKey(e => new { e.ContactNumber, e.BranchNumber }).HasName("aaaaaBranchTeamMember_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.BranchNumberNavigation).WithMany(p => p.BranchTeamMembers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BranchTeamMember_Branch");
        });

        modelBuilder.Entity<CarrierFreightChargeMethod>(entity =>
        {
            entity.HasKey(e => new { e.CarrierNumber, e.FreightChargeType }).HasName("aaaaaCarrierFreightChargeMethod_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.FreightChargeTypeNavigation).WithMany(p => p.CarrierFreightChargeMethods)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarrierFreightCharge_FreightCharge");
        });

        modelBuilder.Entity<CarrierService>(entity =>
        {
            entity.HasKey(e => new { e.CarrierNumber, e.CarrierServiceCode }).HasName("aaaaaCarrierService_PK");

            entity.HasIndex(e => e.CarrierServiceNumber, "IX_CarrierService")
                .IsUnique()
                .HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<Cdicompany>(entity =>
        {
            entity.HasKey(e => e.CdicompanyNumber).HasName("PKCDICompany");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.CdicompanyNumber).ValueGeneratedNever();
            entity.Property(e => e.BaseCurrency).IsFixedLength();
            entity.Property(e => e.CdicompanyShortName).HasDefaultValue("CDI");
            entity.Property(e => e.DocumentLanguage).HasDefaultValue("en");
            entity.Property(e => e.ExchangeRateType).HasDefaultValue((short)1);
            entity.Property(e => e.HoldDays).HasDefaultValue(15);
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.ApcountryCodeNavigation).WithMany(p => p.CdicompanyApcountryCodeNavigations).HasConstraintName("FK_CDICompany_APCountry");

            entity.HasOne(d => d.ArcountryCodeNavigation).WithMany(p => p.CdicompanyArcountryCodeNavigations).HasConstraintName("FK_CDICompany_ARCountry");

            entity.HasOne(d => d.DefaultWarehouseNavigation).WithMany(p => p.Cdicompanies).HasConstraintName("FK_CDICompany_Warehouse");

            entity.HasOne(d => d.PaymentTermsTypeNavigation).WithMany(p => p.Cdicompanies).HasConstraintName("FK_CDICompany_PaymentTerms");
        });

        modelBuilder.Entity<CdicompanyAccount>(entity =>
        {
            entity.HasKey(e => new { e.CdicompanyNumber, e.CustomerNumber }).HasName("PKCDICompanyAccount");

            entity.HasIndex(e => e.CustomerNumber, "IX_CDICompanyAccount").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_2058149377")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.AllowCancel).HasDefaultValue(true);
            entity.Property(e => e.AllowReturn).HasDefaultValue(true);
            entity.Property(e => e.CurrencyCode)
                .HasDefaultValue("USD")
                .IsFixedLength();
            entity.Property(e => e.CustomerProcessCredit).HasDefaultValue(true);
            entity.Property(e => e.DocumentLanguage).HasDefaultValue("en");
            entity.Property(e => e.MaxInvoiceDaysLate).HasDefaultValue(0);
            entity.Property(e => e.PriorYearSales).HasDefaultValue(0m);
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.SalesStatus).HasDefaultValue((short)0);
            entity.Property(e => e.Ytdsales).HasDefaultValue(0m);

            entity.HasOne(d => d.CdicompanyNumberNavigation).WithMany(p => p.CdicompanyAccounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CDICompanyAccount_CDICompany");

            entity.HasOne(d => d.CustomerNumberNavigation).WithMany(p => p.CdicompanyAccounts).HasConstraintName("FK_CDICompanyAccount_Customer");

            entity.HasOne(d => d.PaymentTermsTypeNavigation).WithMany(p => p.CdicompanyAccounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CDICompanyAccount_PaymentTermsType");
        });

        modelBuilder.Entity<CdicompanyCommission>(entity =>
        {
            entity.HasKey(e => new { e.CdicompanyNumber, e.ToCdicompanyNumber, e.ManufacturerNumber, e.SalesCategoryNumber, e.StartDate }).HasName("PKCDICompanyCommission");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.StartDate).HasDefaultValue(new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            entity.Property(e => e.EndDate).HasDefaultValue(new DateTime(9999, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.CdicompanyNumberNavigation).WithMany(p => p.CdicompanyCommissionCdicompanyNumberNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CDICompanyCommission_CDICompany");

            entity.HasOne(d => d.CustomerNumberNavigation).WithMany(p => p.CdicompanyCommissions).HasConstraintName("FK_CDICompanyCommission_Customer");

            entity.HasOne(d => d.ToCdicompanyNumberNavigation).WithMany(p => p.CdicompanyCommissionToCdicompanyNumberNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CDICompanyCommission_CDICompanyTo");
        });

        modelBuilder.Entity<CdicompanyGroup>(entity =>
        {
            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.CdicompanyNumberNavigation).WithMany(p => p.CdicompanyGroupCdicompanyNumberNavigations).HasConstraintName("FK_CDICompanyGroup_CDICompany");

            entity.HasOne(d => d.RelatedCdicompanyNumberNavigation).WithMany(p => p.CdicompanyGroupRelatedCdicompanyNumberNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CDICompanyGroup_CDICompany1");
        });

        modelBuilder.Entity<CdicompanyVat>(entity =>
        {
            entity.Property(e => e.InvoiceCurrencyCode).IsFixedLength();
            entity.Property(e => e.ReportingCurrencyCode)
                .HasDefaultValue("GBP")
                .IsFixedLength();
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.CdicompanyNumberNavigation).WithMany(p => p.CdicompanyVats)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CDICompanyVAT_CDICompany");

            entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.CdicompanyVats)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CDICompanyVAT_Country");
        });

        modelBuilder.Entity<CdilistValue>(entity =>
        {
            entity.HasKey(e => new { e.ListNumber, e.ListValue }).HasName("aaaaaCDIListValue_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<Cdilocation>(entity =>
        {
            entity.HasKey(e => e.CdilocationNumber).HasName("aaaaaCDILocation_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.CdilocationNumber).ValueGeneratedNever();
            entity.Property(e => e.LocationActive).HasDefaultValue(true);
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<CditerritoryBranch>(entity =>
        {
            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.BranchNumberNavigation).WithMany(p => p.CditerritoryBranches).HasConstraintName("FK_CDITerritoryBranch_Branch");

            entity.HasOne(d => d.CdicompanyNumberNavigation).WithMany(p => p.CditerritoryBranches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CDITerritoryBranch_CDICompany");
        });

        modelBuilder.Entity<CditerritoryCountry>(entity =>
        {
            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.CditerritoryCountries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CDITerritoryCountry_Country");
        });

        modelBuilder.Entity<CditerritoryPostalCode>(entity =>
        {
            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.CditerritoryPostalCodes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CDITerritoryPostalCode_Country");
        });

        modelBuilder.Entity<CditerritoryState>(entity =>
        {
            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.CditerritoryStates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CDITerritoryState_Country");
        });

        modelBuilder.Entity<CompanyConfiguration>(entity =>
        {
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryCode).HasName("aaaaaCountry_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerNumber).HasName("aaaaaCustomer_PK");

            entity.HasIndex(e => e.CustomerName, "CustomerName").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.CustomerNumber).ValueGeneratedNever();
            entity.Property(e => e.ExportStatus).HasDefaultValue(1);
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<CustomerExpedite>(entity =>
        {
            entity.HasKey(e => e.ExpediteNumber).HasName("PKCustomerExpedite");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.ExpediteNumber).ValueGeneratedNever();
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.BranchNumberNavigation).WithMany(p => p.CustomerExpedites)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerExpedite_Branch");

            entity.HasOne(d => d.CustomerNumberNavigation).WithMany(p => p.CustomerExpedites)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerExpedite_Customer");
        });

        modelBuilder.Entity<CustomerExpediteItem>(entity =>
        {
            entity.HasKey(e => new { e.ExpediteNumber, e.ExpediteItemNumber }).HasName("PKCustomerExpediteItem");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.OrderOutType).HasDefaultValue(1);
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.ExpediteNumberNavigation).WithMany(p => p.CustomerExpediteItems).HasConstraintName("FK_CustomerExpediteItem_CustomerExpedite");
        });

        modelBuilder.Entity<CustomerLocation>(entity =>
        {
            entity.HasKey(e => new { e.CustomerNumber, e.LocationNumber }).HasName("aaaaaCustomerLocation_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.CustomerNumberNavigation).WithMany(p => p.CustomerLocations).HasConstraintName("FK_CustomerLocation_Customer");
        });

        modelBuilder.Entity<CustomerOrder>(entity =>
        {
            entity.HasKey(e => e.OrderNumber).HasName("aaaaaCustomerOrder_PK");

            entity.HasIndex(e => new { e.CustomerNumber, e.OrderCustomerPo }, "CustomerPO")
                .IsUnique()
                .HasFillFactor(80);

            entity.HasIndex(e => e.CustomerNumber, "IX_CustomerOrder_Customer").HasFillFactor(80);

            entity.HasIndex(e => e.EndCustomerNumber, "IX_CustomerOrder_EndCustomer").HasFillFactor(80);

            entity.HasIndex(e => e.TeamMemberNumber, "IX_CustomerOrder_TeamMember").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.OrderNumber).ValueGeneratedNever();
            entity.Property(e => e.ApplyCurrencyBillingAdjustment).HasDefaultValue(false);
            entity.Property(e => e.BillingAdjustmentCurrency)
                .HasDefaultValueSql("(NULL)")
                .IsFixedLength();
            entity.Property(e => e.BillingAdjustmentRate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.CurrencyCode).IsFixedLength();
            entity.Property(e => e.DocumentLanguage).HasDefaultValue("en");
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.BranchNumberNavigation).WithMany(p => p.CustomerOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerOrder_Branch");

            entity.HasOne(d => d.CdicompanyNumberNavigation).WithMany(p => p.CustomerOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerOrder_CDICompany");

            entity.HasOne(d => d.CustomerNumberNavigation).WithMany(p => p.CustomerOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerOrder_Customer");

            entity.HasOne(d => d.OpportunityNumberNavigation).WithMany(p => p.CustomerOrders).HasConstraintName("FK_CustomerOrder_Opportunity");

            entity.HasOne(d => d.PaymentTermsTypeNavigation).WithMany(p => p.CustomerOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerOrder_PaymentTermsType");

            entity.HasOne(d => d.CustomerLocation).WithMany(p => p.CustomerOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerOrder_CustomerLocation");

            entity.HasOne(d => d.InternalLocation).WithMany(p => p.CustomerOrders).HasConstraintName("FK__CustomerOrder__564BC36F");
        });

        modelBuilder.Entity<CustomerTeamMember>(entity =>
        {
            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.InternalLocation).WithMany(p => p.CustomerTeamMembers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerTeamMember_InternalLocation");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("aaaaaEvent_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.EventId).ValueGeneratedNever();
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<EventNote>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("aaaaaEventNote_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.EventId).ValueGeneratedNever();
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.Event).WithOne(p => p.EventNote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventNote_Event");
        });

        modelBuilder.Entity<FreightChargeMethod>(entity =>
        {
            entity.HasKey(e => e.FreightChargeType).HasName("aaaaaFreightChargeMethod_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.FreightChargeType).ValueGeneratedNever();
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<InternalLocation>(entity =>
        {
            entity.HasKey(e => new { e.CustomerNumber, e.LocationNumber }).HasName("aaaaaInternalLocation_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.CustomerLocation).WithOne(p => p.InternalLocation).HasConstraintName("FK_InternalLocation_CustomerLocation");
        });

        modelBuilder.Entity<InventoryBin>(entity =>
        {
            entity.HasKey(e => e.BinNumber).HasName("aaaaaInventoryBin_PK");

            entity.HasIndex(e => new { e.ProductNumber, e.FormatNumber, e.WarehouseNumber }, "IX_Product_Format_Warehouse").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.BinNumber).ValueGeneratedNever();
            entity.Property(e => e.CurrencyCode)
                .HasDefaultValue("USD")
                .IsFixedLength();
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.CdicompanyNumberNavigation).WithMany(p => p.InventoryBins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryBin_CDICompany");

            entity.HasOne(d => d.ReceiverItem).WithMany(p => p.InventoryBins).HasConstraintName("FK_InventoryBin_ReceiverItem");

            entity.HasOne(d => d.WarehouseInventory).WithMany(p => p.InventoryBins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryBin_WarehouseInventory");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerNumber).HasName("aaaaaManufacturer_PK");

            entity.HasIndex(e => e.ManufacturerName, "ManufacturerName").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.ManufacturerNumber).ValueGeneratedNever();
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.DefaultCountryOfOriginNavigation).WithMany(p => p.Manufacturers).HasConstraintName("FK_Manufacturer_Country");
        });

        modelBuilder.Entity<ManufacturerConfiguration>(entity =>
        {
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.ManufacturerNumberNavigation).WithMany(p => p.ManufacturerConfigurations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ManufacturerConfiguration_ManufacturerNumber");
        });

        modelBuilder.Entity<ManufacturerProductCategory>(entity =>
        {
            entity.HasKey(e => new { e.ManufacturerNumber, e.ProductCategoryNumber }).HasName("aaaaaManufacturerProductCategory_PK");

            entity.HasIndex(e => e.Rowguid, "rowguid_index")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.DefaultPriceBreak).HasDefaultValue((short)1);
            entity.Property(e => e.PriceBreaks).HasDefaultValue((short)1);
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.SalesCategoryNumber).HasDefaultValue(1);

            entity.HasOne(d => d.ManufacturerNumberNavigation).WithMany(p => p.ManufacturerProductCategories).HasConstraintName("FK_ManufacturerProductCategory_Manufacturer");
        });

        modelBuilder.Entity<Opportunity>(entity =>
        {
            entity.HasIndex(e => e.CustomerNumber, "IX_Opportunity_Customer").HasFillFactor(80);

            entity.HasIndex(e => e.TeamMemberNumber, "IX_Opportunity_TeamMember").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.OpportunityNumber).ValueGeneratedNever();
            entity.Property(e => e.CategoryId).HasDefaultValue(1);
            entity.Property(e => e.CurrencyCode)
                .HasDefaultValue("USD")
                .IsFixedLength();
            entity.Property(e => e.DocumentLanguage).HasDefaultValue("en");
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.BranchNumberNavigation).WithMany(p => p.Opportunities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Opportunity_Branch");

            entity.HasOne(d => d.CdicompanyNumberNavigation).WithMany(p => p.Opportunities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Opportunity_CDICompany");

            entity.HasOne(d => d.CustomerNumberNavigation).WithMany(p => p.Opportunities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Opportunity_Customer");
        });

        modelBuilder.Entity<OrderCreditCardAuthorization>(entity =>
        {
            entity.HasKey(e => e.OrderNumber).HasName("aaaaaOrderCreditCardAuthorization_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.OrderNumber).ValueGeneratedNever();
            entity.Property(e => e.OrderCreditCardCode).IsFixedLength();
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.OrderCreditCardAuthorizations).HasConstraintName("FK_OrderCreditCardAuthorizat_Country");

            entity.HasOne(d => d.OrderNumberNavigation).WithOne(p => p.OrderCreditCardAuthorization).HasConstraintName("FK_OrderCreditCardAuthorizat_CustomerOrder");
        });

        modelBuilder.Entity<OrderItemCarrierAccount>(entity =>
        {
            entity.HasKey(e => new { e.OrderNumber, e.OrderItemNumber }).HasName("aaaaaOrderItemCarrierAccount_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.OrderLineItem).WithOne(p => p.OrderItemCarrierAccount).HasConstraintName("FK_OrderItemCarrierAccount_ORderLineItem");
        });

        modelBuilder.Entity<OrderItemChange>(entity =>
        {
            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<OrderItemCommission>(entity =>
        {
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.OrderLineItem).WithMany(p => p.OrderItemCommissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItemCommission_OrderLineItem");
        });

        modelBuilder.Entity<OrderItemToShip>(entity =>
        {
            entity.HasKey(e => new { e.ShipmentNumber, e.OrderItemShipNumber }).HasName("aaaaaOrderItemToShip_PK");

            entity.HasIndex(e => e.ItemCarrierServiceCode, "ItemCarrierServiceCode").HasFillFactor(80);

            entity.HasIndex(e => e.OrderShipType, "OrderItemToShipOrderShipType").HasFillFactor(80);

            entity.HasIndex(e => new { e.OrderShipType, e.OrderShipNumber, e.OrderItemShipNumber }, "OrderToShipOrderItemToShip")
                .IsUnique()
                .HasFillFactor(90);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.CarrierServiceNumber).HasDefaultValue(1);
            entity.Property(e => e.ExportPhase).HasDefaultValue(1);
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.ShipmentNumberNavigation).WithMany(p => p.OrderItemToShips)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItemToShip_OrderToShip");

            entity.HasOne(d => d.WarehouseNumberNavigation).WithMany(p => p.OrderItemToShips)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItemToShip_WarehouseNumber");
        });

        modelBuilder.Entity<OrderLineItem>(entity =>
        {
            entity.HasKey(e => new { e.OrderNumber, e.OrderItemNumber }).HasName("aaaaaOrderLineItem_PK");

            entity.HasIndex(e => e.ProductNumber, "IX_ProductNumber").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.CostCurrencyCode)
                .HasDefaultValue("USD")
                .IsFixedLength();
            entity.Property(e => e.CostExchangeRate).HasDefaultValue(1.0m);
            entity.Property(e => e.ExportPhase).HasDefaultValue(1);
            entity.Property(e => e.LineId).HasDefaultValue(1);
            entity.Property(e => e.OrderItemCancel).HasDefaultValue(true);
            entity.Property(e => e.OrderItemReturnStock).HasDefaultValue(true);
            entity.Property(e => e.RequestDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.OrderNumberNavigation).WithMany(p => p.OrderLineItems).HasConstraintName("FK_OrderLineItem_CustomerOrder");

            entity.HasOne(d => d.WarehouseNumberNavigation).WithMany(p => p.OrderLineItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderLineItem_Warehouse");

            entity.HasOne(d => d.CarrierService).WithMany(p => p.OrderLineItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderLineItem_CarrierService");
        });

        modelBuilder.Entity<OrderToShip>(entity =>
        {
            entity.HasKey(e => e.ShipmentNumber).HasName("aaaaaOrderToShip_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.ExportStatus).HasDefaultValue(1);
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<PaymentTerm>(entity =>
        {
            entity.HasKey(e => e.PaymentTermsType).HasName("aaaaaPaymentTerms_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.PaymentTermsType).ValueGeneratedNever();
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductNumber).HasName("aaaaaProduct_PK");

            entity.HasIndex(e => e.ManufacturerNumber, "IX_Product_ManufacturerNumber").HasFillFactor(80);

            entity.HasIndex(e => new { e.ManufacturerNumber, e.ProductPartNumber }, "Manufacturer_ProductPart")
                .IsUnique()
                .HasFillFactor(80);

            entity.HasIndex(e => e.ProductPartNumber, "_ProductPartNumber_").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.ProductNumber).ValueGeneratedNever();
            entity.Property(e => e.IsExportRestricted).HasDefaultValue(false);
            entity.Property(e => e.MoistureSensitivityLevel).HasDefaultValue(1);
            entity.Property(e => e.ProductCategoryNumber).HasDefaultValue(1);
            entity.Property(e => e.ProductEntryDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ProductLeadTime).HasDefaultValue(0);
            entity.Property(e => e.ProductRunRate).HasDefaultValue(0.0);
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.ManufacturerNumberNavigation).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Manufacturer");

            entity.HasOne(d => d.ProductOriginCountryNavigation).WithMany(p => p.Products).HasConstraintName("FK_Product_Country");

            entity.HasOne(d => d.ManufacturerProductCategory).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ManufacturerProductCategory");
        });

        modelBuilder.Entity<Receiver>(entity =>
        {
            entity.HasKey(e => e.ReceiverNumber).HasName("aaaaaReceiver_PK");

            entity.HasIndex(e => e.WarehouseNumber, "IX_Receiver_Warehouse").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.ReceiverNumber).ValueGeneratedNever();
            entity.Property(e => e.DocumentLanguage).HasDefaultValue("en");
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.CdicompanyNumberNavigation).WithMany(p => p.Receivers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receiver_CDICompany");

            entity.HasOne(d => d.WarehouseNumberNavigation).WithMany(p => p.Receivers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receiver_Warehouse");

            entity.HasOne(d => d.CarrierService).WithMany(p => p.Receivers).HasConstraintName("FK_Receiver_CarrierService");
        });

        modelBuilder.Entity<ReceiverItem>(entity =>
        {
            entity.HasKey(e => new { e.ReceiverNumber, e.ReceiverItemNumber }).HasName("aaaaaReceiverItem_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.CostCurrencyCode)
                .HasDefaultValue("USD")
                .IsFixedLength();
            entity.Property(e => e.CostExchangeRate).HasDefaultValue(1.0m);
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.CountryOfOriginNavigation).WithMany(p => p.ReceiverItems).HasConstraintName("FK_ReceiverItem_Country");

            entity.HasOne(d => d.ReceiverNumberNavigation).WithMany(p => p.ReceiverItems).HasConstraintName("FK_ReceiverItem_Receiver");
        });

        modelBuilder.Entity<ReceiverOrderItem>(entity =>
        {
            entity.HasKey(e => new { e.ReceiverNumber, e.ReceiverItemNumber }).HasName("aaaaaReceiverOrderItem_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.ReceiverItem).WithOne(p => p.ReceiverOrderItem).HasConstraintName("FK_ReceiverOrderItem_ReceiverItem");

            entity.HasOne(d => d.SupplierOrderItem).WithMany(p => p.ReceiverOrderItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceiverOrderItem_SupplierOrderItem");
        });

        modelBuilder.Entity<ReceiverSupplierOrder>(entity =>
        {
            entity.HasIndex(e => e.ApinvoiceNumber, "IX_ReceiverSupplierOrder_APInvoiceNumber").HasFillFactor(80);

            entity.HasIndex(e => e.SupplierOrderNumber, "IX_ReceiversupplierOrder_SupplierOrderNumber").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.ReceiverNumber).ValueGeneratedNever();
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.ReceiverNumberNavigation).WithOne(p => p.ReceiverSupplierOrder).HasConstraintName("FK_ReceiverSupplierOrder_Receiver");

            entity.HasOne(d => d.SupplierOrderNumberNavigation).WithMany(p => p.ReceiverSupplierOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceiverSupplierOrder_SupplierOrder");
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.HasKey(e => e.ShipmentNumber).HasName("aaaaaShipment_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.ShipmentNumber).ValueGeneratedNever();
            entity.Property(e => e.DocumentLanguage).HasDefaultValue("en");
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.CdicompanyNumberNavigation).WithMany(p => p.Shipments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipment_CDICompany");

            entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.Shipments).HasConstraintName("FK_Shipment_CountryCode");

            entity.HasOne(d => d.FreightChargeTypeNavigation).WithMany(p => p.Shipments).HasConstraintName("FK_Shipment_FreightChargeMethod");

            entity.HasOne(d => d.WarehouseNumberNavigation).WithMany(p => p.Shipments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipment_Warehouse");

            entity.HasOne(d => d.CarrierService).WithMany(p => p.Shipments).HasConstraintName("FK_Shipment_CarrierService");
        });

        modelBuilder.Entity<ShipmentContentItem>(entity =>
        {
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.ShipmentContentItems).HasConstraintName("FK_ShipmentContentItem_Country");

            entity.HasOne(d => d.ProductNumberNavigation).WithMany(p => p.ShipmentContentItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShipmentContentItem_Product");
        });

        modelBuilder.Entity<ShipmentCustomerOrder>(entity =>
        {
            entity.HasKey(e => e.ShipmentNumber).HasName("aaaaaShipmentCustomerOrder_PK");

            entity.HasIndex(e => e.InvoiceNumber, "IX_ShipmentCustomerOrder_InvoiceNumber").HasFillFactor(80);

            entity.HasIndex(e => e.OrderNumber, "IX_ShipmentCustomerOrder_OrderNumber").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_1395536055")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.ShipmentNumber).ValueGeneratedNever();
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.InvoiceNumberNavigation).WithMany(p => p.ShipmentCustomerOrders).HasConstraintName("FK_ShipmentCustomerOrder_ARShipmentInvoice");

            entity.HasOne(d => d.OrderNumberNavigation).WithMany(p => p.ShipmentCustomerOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShipmentCustomerOrder_CustomerOrder");

            entity.HasOne(d => d.ShipmentNumberNavigation).WithOne(p => p.ShipmentCustomerOrder).HasConstraintName("FK_ShipmentCustomerOrder_Shipment");
        });

        modelBuilder.Entity<ShipmentItem>(entity =>
        {
            entity.HasKey(e => new { e.ShipmentNumber, e.ShipmentItemNumber }).HasName("aaaaaShipmentItem_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.HasIndex(e => new { e.ProductNumber, e.FormatNumber }, "productnumberFormatNumber").HasFillFactor(80);

            entity.Property(e => e.CostCurrencyCode)
                .HasDefaultValue("USD")
                .IsFixedLength();
            entity.Property(e => e.CostExchangeRate).HasDefaultValue(1.0m);
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.ShipmentItems).HasConstraintName("FK_ShipmentItem_Country");

            entity.HasOne(d => d.ShipmentNumberNavigation).WithMany(p => p.ShipmentItems).HasConstraintName("FK_ShipmentItem_Shipment");

            entity.HasOne(d => d.WarehouseNumberNavigation).WithMany(p => p.ShipmentItems).HasConstraintName("FK_ShipmentItem_Warehouse");
        });

        modelBuilder.Entity<ShipmentItemBin>(entity =>
        {
            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.BinNumberNavigation).WithMany(p => p.ShipmentItemBins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShipmentItemBin_InventoryBin");

            entity.HasOne(d => d.ShipmentItem).WithMany(p => p.ShipmentItemBins).HasConstraintName("FK_ShipmentItemBin_ShipmentItem");
        });

        modelBuilder.Entity<ShipmentOrderItem>(entity =>
        {
            entity.HasKey(e => new { e.ShipmentNumber, e.ShipmentItemNumber }).HasName("aaaaaShipmentOrderItem_PK");

            entity.HasIndex(e => new { e.OrderNumber, e.OrderItemNumber }, "IX_ShipmentOrderItem").HasFillFactor(80);

            entity.HasIndex(e => e.OrderNumber, "IX_shipmentorderitem_OrderNumber").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.OrderLineItem).WithMany(p => p.ShipmentOrderItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShipmentOrderItem_OrderLineItem");

            entity.HasOne(d => d.ShipmentItem).WithOne(p => p.ShipmentOrderItem).HasConstraintName("FK_ShipmentOrderItem_ShipmentItem");
        });

        modelBuilder.Entity<ShipmentPackage>(entity =>
        {
            entity.HasKey(e => new { e.ShipmentNumber, e.PackageNumber }).HasName("aaaaaShipmentPackage_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.ShipmentNumberNavigation).WithMany(p => p.ShipmentPackages).HasConstraintName("FK_ShipmentPackage_Shipment");
        });

        modelBuilder.Entity<ShipmentPackageDetail>(entity =>
        {
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<Spssshipment>(entity =>
        {
            entity.Property(e => e.CarrierServiceNumber).HasDefaultValue(1);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierNumber).HasName("aaaaaSupplier_PK");

            entity.HasIndex(e => e.SupplierName, "SupplierName").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_1651536967")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.SupplierNumber).ValueGeneratedNever();
            entity.Property(e => e.AccountingDivision).IsFixedLength();
            entity.Property(e => e.CurrencyCode)
                .HasDefaultValue("USD")
                .IsFixedLength();
            entity.Property(e => e.DocumentLanguage).HasDefaultValue("en");
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.SupplierAllowDrop).HasDefaultValue(true);

            entity.HasOne(d => d.CdicompanyNumberNavigation).WithMany(p => p.Suppliers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Supplier_CDICompany");

            entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.Suppliers).HasConstraintName("FK_Supplier_Country");

            entity.HasOne(d => d.PaymentTermsTypeNavigation).WithMany(p => p.Suppliers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Supplier_PaymentTerms");
        });

        modelBuilder.Entity<SupplierDeal>(entity =>
        {
            entity.HasKey(e => new { e.SupplierNumber, e.SupplierDealNumber }).HasName("aaaaaSupplierDeal_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.DocumentLanguage).HasDefaultValue("en");
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.SupplierNumberNavigation).WithMany(p => p.SupplierDeals).HasConstraintName("FK_SupplierDeal_Supplier");

            entity.HasOne(d => d.InternalLocation).WithMany(p => p.SupplierDeals).HasConstraintName("FK_SupplierDeal_EndCustomerNumberEndLocationNumber");
        });

        modelBuilder.Entity<SupplierDealProduct>(entity =>
        {
            entity.HasKey(e => new { e.SupplierNumber, e.SupplierDealNumber, e.ProductNumber }).HasName("aaaaaSupplierDealProduct_PK");

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.ItemNumber).HasDefaultValue(1);
            entity.Property(e => e.ItemStatus).HasDefaultValue((short)0);
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.ProductNumberNavigation).WithMany(p => p.SupplierDealProducts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplierDealProduct_Product");
        });

        modelBuilder.Entity<SupplierInventoryItem>(entity =>
        {
            entity.HasKey(e => new { e.SupplierNumber, e.ProductNumber, e.FormatNumber }).HasName("aaaaaSupplierInventoryItem_PK");

            entity.HasIndex(e => e.ProductNumber, "ProductNumber").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.SupplierNumberNavigation).WithMany(p => p.SupplierInventoryItems).HasConstraintName("FK_SupplierInventoryItem_Supplier");
        });

        modelBuilder.Entity<SupplierManufacturer>(entity =>
        {
            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.CdicompanyNumberNavigation).WithMany(p => p.SupplierManufacturers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplierManufacturer_CDICompany");

            entity.HasOne(d => d.ManufacturerNumberNavigation).WithMany(p => p.SupplierManufacturers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplierManufacturer_Manufacturer");

            entity.HasOne(d => d.SupplierNumberNavigation).WithMany(p => p.SupplierManufacturers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplierManufacturer_Supplier");
        });

        modelBuilder.Entity<SupplierOrder>(entity =>
        {
            entity.HasKey(e => e.SupplierOrderNumber).HasName("aaaaaSupplierOrder_PK");

            entity.HasIndex(e => e.ContactNumber, "IX_SupplierOrder_ContactNubmer").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.SupplierOrderNumber).ValueGeneratedNever();
            entity.Property(e => e.CurrencyCode).IsFixedLength();
            entity.Property(e => e.DocumentLanguage).HasDefaultValue("en");
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.BranchNumberNavigation).WithMany(p => p.SupplierOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplierOrder_Branch");

            entity.HasOne(d => d.CdicompanyNumberNavigation).WithMany(p => p.SupplierOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplierOrder_CDICompany");

            entity.HasOne(d => d.PaymentTermsTypeNavigation).WithMany(p => p.SupplierOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplierOrder_PaymentTerms");

            entity.HasOne(d => d.SupplierNumberNavigation).WithMany(p => p.SupplierOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplierOrder_Supplier");
        });

        modelBuilder.Entity<SupplierOrderItem>(entity =>
        {
            entity.HasKey(e => new { e.SupplierOrderNumber, e.SupplierOrderItemNumber }).HasName("aaaaaSupplierOrderItem_PK");

            entity.HasIndex(e => e.ProductNumber, "IX_SupplierOrderItem_ProductNumber").HasFillFactor(80);

            entity.HasIndex(e => e.SupplierOrderItemStatus, "IX_SupplierOrderItem_Supplierorderitemstatus").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.LineId).HasDefaultValue(1);
            entity.Property(e => e.RequestDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.SupplierOrderItemAllocated).HasDefaultValue(0);
            entity.Property(e => e.SupplierOrderItemCancel).HasDefaultValue(true);
            entity.Property(e => e.SupplierOrderItemReturn).HasDefaultValue(true);

            entity.HasOne(d => d.FreightChargeTypeNavigation).WithMany(p => p.SupplierOrderItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplierOrderItem_FreightChargeMethod");

            entity.HasOne(d => d.ProductNumberNavigation).WithMany(p => p.SupplierOrderItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplierOrderItem_Product");

            entity.HasOne(d => d.SupplierOrderNumberNavigation).WithMany(p => p.SupplierOrderItems).HasConstraintName("FK_SupplierOrderItem_SupplierOrder");

            entity.HasOne(d => d.WarehouseNumberNavigation).WithMany(p => p.SupplierOrderItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplierOrderItem_Warehouse");

            entity.HasOne(d => d.CarrierService).WithMany(p => p.SupplierOrderItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplierOrderItem_CarrierService");
        });

        modelBuilder.Entity<TransactionItemLink>(entity =>
        {
            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<TransactionItemTariff>(entity =>
        {
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.CountryOfOriginNavigation).WithMany(p => p.TransactionItemTariffs).HasConstraintName("FK_TransactionItemTariff_Country");
        });

        modelBuilder.Entity<TransactionLog>(entity =>
        {
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<VSupplierManufacturer>(entity =>
        {
            entity.ToView("vSupplierManufacturer");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.WarehouseNumber).HasName("aaaaaWarehouse_PK");

            entity.HasIndex(e => e.Rowguid, "index_824390006")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.WarehouseNumber).ValueGeneratedNever();
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.Warehouses).HasConstraintName("FK_Warehouse_Country");

            entity.HasOne(d => d.WarehouseNumberNavigation).WithOne(p => p.Warehouse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_CDILocation");
        });

        modelBuilder.Entity<WarehouseInventory>(entity =>
        {
            entity.HasKey(e => new { e.ProductNumber, e.FormatNumber, e.WarehouseNumber }).HasName("aaaaaWarehouseInventory_PK");

            entity.HasIndex(e => new { e.ProductNumber, e.FormatNumber }, "InventoryItemWarehouseInventory").HasFillFactor(80);

            entity.HasIndex(e => e.Rowguid, "index_rowguid")
                .IsUnique()
                .HasFillFactor(80);

            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");

            entity.HasOne(d => d.WarehouseNumberNavigation).WithMany(p => p.WarehouseInventories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WarehouseInventory_Warehouse");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
