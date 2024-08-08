using Microsoft.EntityFrameworkCore;

namespace WarehouseManagement.Infrastructure.Data.Scaffold
{
    public partial class WarehouseManagementContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDbFunction(typeof(WarehouseManagementContext).GetMethod(nameof(GetExchangeRateByType), [typeof(string), typeof(string), typeof(DateTime), typeof(int)])!)
                .HasName("fnGetExchangeRateByType");

            modelBuilder
                .HasDbFunction(typeof(WarehouseManagementContext).GetMethod(nameof(GetShipDebitSupplierSource), [typeof(int), typeof(int)])!)
                .HasName("fnGetShipDebitSupplierSource");
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Add(_ => new TriggerAddingConvention());
        }

        /// <summary>
        /// Dummy Method to allow calling a SQL Function.
        /// </summary>
        /// <remarks>
        /// See https://learn.microsoft.com/en-us/ef/core/querying/user-defined-function-mapping#mapping-a-method-to-a-sql-function for more information.
        /// </remarks>
        /// <param name="fromCurrency"></param>
        /// <param name="toCurrency"></param>
        /// <param name="rateDate"></param>
        /// <param name="rateType"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public decimal GetExchangeRateByType(string fromCurrency, string toCurrency, DateTime rateDate, int rateType)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Dummy Method to allow calling a SQL Function.
        /// </summary>
        /// <remarks>
        /// See https://learn.microsoft.com/en-us/ef/core/querying/user-defined-function-mapping#mapping-a-method-to-a-sql-function for more information.
        /// </remarks>
        /// <param name="invoiceNumber"></param>
        /// <param name="itemNumber"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public string GetShipDebitSupplierSource(int invoiceNumber, int itemNumber)
        {
            throw new NotSupportedException();
        }
    }
}
