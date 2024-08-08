using Microsoft.EntityFrameworkCore;
using static WarehouseManagement.Infrastructure.Data.Scaffold.WarehouseManagementContext;

namespace WarehouseManagement.Infrastructure.Data.Scaffold
{
    public partial class NextNumbersContext(string connectionString) : DbContext
    {
        private readonly string _connectionString = connectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        public virtual DbSet<NextNumber> NextNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NextNumber>(entity =>
            {
                entity.HasKey(e => new { e.BranchNumber, e.EntityName }).HasName("aaaaaNextNumber_PK");

                entity.HasIndex(e => e.Rowguid, "index_rowguid")
                    .IsUnique()
                    .HasFillFactor(80);

                entity.Property(e => e.BranchLastUpdated).HasDefaultValue(0);
                entity.Property(e => e.Rowguid).HasDefaultValueSql("(newsequentialid())");
                entity.Property(e => e.WhoLastUpdated).HasDefaultValue(0);

                entity.HasOne(d => d.BranchNumberNavigation).WithMany(p => p.NextNumbers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NextNumber_CDILocation");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
