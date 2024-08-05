using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.ValueObjects;

namespace WarehouseManagement.Domain.Interfaces
{
    public interface IWarehouseManagementRepository
    {
        int? GetCompany(Guid clientId);

        int GetBranchNumber(int warehouseNumber);

        int? GetWhoLastUpdatedIdentity(int companyNumber);

        Address GetCustomerLocation(int customerNumber, int locationNumber);

        int GetWarehouseType(int warehouseNumber);

        decimal GetExchangeRate(int companyNumber, string fromCurrency, string toCurrency);
    }
}
