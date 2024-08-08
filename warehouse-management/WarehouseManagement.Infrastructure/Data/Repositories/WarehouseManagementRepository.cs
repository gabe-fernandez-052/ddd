using WarehouseManagement.Domain.Exceptions;
using WarehouseManagement.Domain.Interfaces;
using WarehouseManagement.Domain.ValueObjects;
using WarehouseManagement.Infrastructure.Data.Scaffold;

namespace WarehouseManagement.Infrastructure.Data.Repositories
{
    public class WarehouseManagementRepository(WarehouseManagementContext dbContext) : IWarehouseManagementRepository
    {
        public int? GetCompany(Guid clientId)
        {
            return dbContext.Cdicompanies.SingleOrDefault(c => c.Rowguid == clientId)?.CdicompanyNumber;
        }

        public int GetBranchNumber(int warehouseNumber)
        {
            var warehouse = dbContext.Warehouses.SingleOrDefault(w => w.WarehouseNumber == warehouseNumber);

            return warehouse?.BranchNumber ?? warehouseNumber;
        }

        public int? GetWhoLastUpdatedIdentity(int companyNumber)
        {
            var apiIdentityCompanyConfig = 57;

            var companyConfiguration = dbContext.CompanyConfigurations.SingleOrDefault(cc => cc.CompanyId == companyNumber &&
                                                                                                 cc.OptionId == apiIdentityCompanyConfig &&
                                                                                                 cc.NumericValue != null);

            return (int?)companyConfiguration?.NumericValue;
        }

        public Address GetCustomerLocation(int customerNumber, int locationNumber)
        {
            return dbContext.CustomerLocations
                .Join(dbContext.InternalLocations, cl => new { cl.CustomerNumber, cl.LocationNumber }, il => new { il.CustomerNumber, il.LocationNumber },
                    (cl, il) => new { cl, il })
                .Where(x => x.cl.CustomerNumber == customerNumber && x.cl.LocationNumber == locationNumber)
                .Select(x => new Address(
                    x.il.LocationAddress,
                    x.il.LocationAddress2,
                    x.il.LocationCity,
                    x.il.LocationState,
                    x.il.LocationPostalCode,
                    x.il.CountryCode)
                )
                .SingleOrDefault() ?? throw new Exception("Customer location not found.");
        }

        public int GetWarehouseType(int warehouseNumber)
        {
            return dbContext.Warehouses
                .Where(w => w.WarehouseNumber == warehouseNumber)
                .Select(w => w.WarehouseType)
                .Single();
        }

        public decimal GetExchangeRate(int companyNumber, string fromCurrency, string toCurrency)
        {
            return dbContext.Cdicompanies.Where(c => c.CdicompanyNumber == companyNumber)
                .Select(c => dbContext.GetExchangeRateByType(fromCurrency, toCurrency, DateTime.Now, c.ExchangeRateType))
                .Single();
        }
    }
}
