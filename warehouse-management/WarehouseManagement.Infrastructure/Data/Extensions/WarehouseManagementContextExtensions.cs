using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Infrastructure.Data.Scaffold;

namespace WarehouseManagement.Infrastructure.Data.Extensions
{
    public static class WarehouseManagementContextExtensions
    {
        public static TEntity? SingleOrDefaultLocalOrDb<TEntity>(this WarehouseManagementContext context, Func<TEntity, bool> predicate) where TEntity : class
        {
            var deletedEntities = context.ChangeTracker.Entries()
                                                       .Where(e => e.State == EntityState.Deleted)
                                                       .Select(e => e.Entity)
                                                       .ToList();

            var localEntity = context.Set<TEntity>().Local.SingleOrDefault(predicate);

            if (localEntity != null)
            {
                if (deletedEntities.Contains(localEntity))
                {
                    return null;
                }

                return localEntity;
            }

            var dbEntity = context.Set<TEntity>().SingleOrDefault(predicate);

            if (dbEntity != null)
            {
                if (deletedEntities.Contains(dbEntity))
                {
                    return null;
                }

                return dbEntity;
            }

            return null;
        }

        public static IEnumerable<TEntity> WhereLocalOrDb<TEntity>(this WarehouseManagementContext context, Func<TEntity, bool> predicate) where TEntity : class
        {
            var deletedEntities = context.ChangeTracker.Entries<TEntity>()
                                                       .Where(e => e.State == EntityState.Deleted)
                                                       .Select(e => e.Entity)
                                                       .ToList();

            var localEntity = context.Set<TEntity>().Local.Where(predicate);

            if (localEntity.Any())
            {
                return localEntity.Except(deletedEntities).ToList();
            }

            var dbEntity = context.Set<TEntity>().Where(predicate);

            if (dbEntity.Any())
            {
                return dbEntity.Except(deletedEntities).ToList();
            }

            return Enumerable.Empty<TEntity>();
        }
    }
}
