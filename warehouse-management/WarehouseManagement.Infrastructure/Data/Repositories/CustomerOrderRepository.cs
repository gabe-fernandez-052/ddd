using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.Enums;
using WarehouseManagement.Domain.Exceptions;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Infrastructure.Data.Scaffold;
using CustomerOrder = WarehouseManagement.Domain.Entities.CustomerOrder;
using CustomerOrderItem = WarehouseManagement.Domain.Entities.CustomerOrderItem;

namespace WarehouseManagement.Infrastructure.Data.Repositories
{
    public class CustomerOrderRepository(WarehouseManagementContext dbContext) : ICustomerOrderRepository
    {
        private const int ORDER_TRANSACTION_TYPE = 1;

        public CustomerOrder GetCustomerOrder(int orderNumber)
        {
            var order = dbContext.CustomerOrders
               .Include(co => co.CustomerNumberNavigation)
               .Join(dbContext.InternalLocations, co => new { co.CustomerNumber, co.LocationNumber }, il => new { il.CustomerNumber, il.LocationNumber },
                   (co, il) => new { co, il })
               .GroupJoin(dbContext.OrderCreditCardAuthorizations, x => x.co.OrderNumber, cca => cca.OrderNumber, (x, cca) => new { x.co, x.il, cca })
               .SelectMany(x => x.cca.DefaultIfEmpty(), (x, cca) => new { x.co, x.il, cca })
               .Where(x => x.co.OrderNumber == orderNumber)
               .Select(x => new CustomerOrder(orderNumber)
               {
                   EntityNumber = x.il.CustomerNumber,
                   LocationName = x.il.LocationName,
                   CustomerLocationNumber = x.co.LocationNumber,
                   BranchNumber = x.co.BranchNumber,
                   ContactNumber = x.co.ContactNumber,
                   EntityReference = x.co.OrderCustomerPo,
                   TeamMemberNumber = x.co.TeamMemberNumber,
                   CurrencyCode = x.co.CurrencyCode,
                   PaymentTermsType = x.co.PaymentTermsType,
                   OrderCreditCardFreightCharge = x.cca != null ? x.cca.OrderCreditCardFreightCharge : 0.0,
                   CompanyNumber = x.co.CdicompanyNumber,
                   EndCustomerNumber = x.co.EndCustomerNumber,
                   EndLocationNumber = x.co.EndLocationNumber,
                   EntityName = x.co.CustomerNumberNavigation.CustomerName,
                   FreightAmount = x.co.FreightAmount,
                   DocumentLanguage = x.co.DocumentLanguage,
                   OrderType = (int)OrderType.CustomerOrder,
                   ApplyCurrencyBillingAdjustment = x.co.ApplyCurrencyBillingAdjustment,
                   BillingAdjustmentCurrency = x.co.BillingAdjustmentCurrency,
                   BillingAdjustmentRate = x.co.BillingAdjustmentRate,
               }).SingleOrDefault() ?? throw new Exception("Customer Order not found.");

            order.Items = dbContext.CustomerOrders
                .Join(dbContext.OrderLineItems, o => o.OrderNumber, i => i.OrderNumber, (o, i) => new { o, i })
                .Join(dbContext.Products, x => x.i.ProductNumber, p => p.ProductNumber, (x, p) => new { x.o, x.i, p })
                .Join(dbContext.Manufacturers, x => x.p.ManufacturerNumber, m => m.ManufacturerNumber, (x, m) => new { x.o, x.i, x.p, m })
                .Join(dbContext.Warehouses, x => x.i.WarehouseNumber, w => w.WarehouseNumber, (x, w) => new { x.o, x.i, x.p, x.m, w })
                .GroupJoin(dbContext.SupplierManufacturers, x => new { x.m.ManufacturerNumber, x.o.CdicompanyNumber },
                    sm => new { sm.ManufacturerNumber, sm.CdicompanyNumber }, (x, sm) => new { x.o, x.i, x.p, x.m, x.w, sm })
                .SelectMany(x => x.sm.DefaultIfEmpty(), (x, sm) => new { x.o, x.i, x.p, x.m, x.w, sm })
                .GroupJoin(dbContext.SupplierInventoryItems, x => new { x.sm.SupplierNumber, x.i.ProductNumber, x.i.FormatNumber },
                    sii => new { sii.SupplierNumber, sii.ProductNumber, sii.FormatNumber }, (x, sii) => new { x.o, x.i, x.p, x.m, x.w, x.sm, sii })
                .SelectMany(x => x.sii.DefaultIfEmpty(), (x, sii) => new { x.o, x.i, x.p, x.m, x.w, x.sm, sii })
                .GroupJoin(dbContext.OrderItemCarrierAccounts, x => new { x.i.OrderNumber, x.i.OrderItemNumber },
                    oica => new { oica.OrderNumber, oica.OrderItemNumber }, (x, oica) => new { x.o, x.i, x.p, x.m, x.w, x.sm, x.sii, oica })
                .SelectMany(x => x.oica.DefaultIfEmpty(), (x, oica) => new { x.o, x.i, x.p, x.m, x.w, x.sm, x.sii, oica })
                .Where(x => x.i.OrderNumber == orderNumber && x.i.OrderItemStatus != (int)OrderOutStatus.Shipped)
                .Select(x => new CustomerOrderItem(x.i.OrderItemNumber)
                {
                    TransactionNumber = x.i.OrderNumber,
                    ProductNumber = x.i.ProductNumber,
                    FormatNumber = x.i.FormatNumber,
                    CarrierNumber = x.i.CarrierNumber,
                    CarrierServiceCode = x.i.CarrierServiceCode,
                    Quantity = x.i.OrderItemQuantity,
                    TargetShipDate = x.i.OrderItemTargetShipDate,
                    Status = x.i.OrderItemStatus,
                    SubStatus = x.i.OrderItemSubStatus,
                    Resale = x.i.OrderItemResale,
                    QuantityShipped = x.i.OrderItemQuantityShipped,
                    WarehouseNumber = x.i.WarehouseNumber,
                    FreightChargeType = x.i.FreightChargeType,
                    ShipAsap = x.i.OrderItemShipAsap,
                    PartialShipment = x.i.OrderItemPartialShipment,
                    Taxable = x.i.OrderItemTaxable,
                    InsureShipment = x.i.OrderItemInsureShipment,
                    ProductPartNumber = x.p.ProductPartNumber,
                    ProductOriginCountry = x.p.ProductOriginCountry,
                    ManufacturerNumber = x.p.ManufacturerNumber,
                    CarrierAccount = x.oica != null ? x.oica.OrderItemCarrierAccount1 : null,
                    CostCurrencyCode = x.i.CostCurrencyCode,
                    TaxType = x.i.OrderItemTaxable ? (x.i.TaxType == null ? 1 : x.i.TaxType) : x.i.TaxType,
                    SourceCost = x.i.OrderItemCost,
                    ManufacturerPartNumber = x.sii != null ? x.sii.SupplierItemPartNumber : null,
                    TransactionTypeNumber = ORDER_TRANSACTION_TYPE,
                    TransactionSubTypeNumber = (int)OrderType.CustomerOrder,
                    Hold = x.i.OrderItemHold,
                    ExportPhase = x.i.ExportPhase,
                    DockDate = x.i.OrderItemOnDockDate,
                    RequestDate = x.i.RequestDate,
                    BranchNumber = x.i.BranchNumber,
                }).ToList();

            return order;
        }

        public List<OrderAllocation> GetItemAllocations(int orderType, int orderNumber, int itemNumber)
        {
            return dbContext.Allocations
                .Where(a => a.OrderOutType == orderType && a.OrderOutNumber == orderNumber && a.OrderOutItemNumber == itemNumber)
                .Select(a => new OrderAllocation(a.AllocationNumber)
                {
                    Quantity = a.AllocationQuantity,
                    SourceType = a.SourceType,
                    OrderOutNumber = a.OrderOutNumber,
                    OrderOutItemNumber = a.OrderOutItemNumber,
                    BinNumber = a.BinNumber,
                    OrderInConfirmDate = a.OrderInConfirmDate,
                })
                .ToList();
        }
    }
}
