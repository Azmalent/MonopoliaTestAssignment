using Microsoft.EntityFrameworkCore;
using MonopoliaTestAssignment.Models;

namespace MonopoliaTestAssignment
{
    internal class WarehouseDbContext : DbContext
    {
        public DbSet<Pallet> Pallets { get; set; } = null!;
        public DbSet<Box> Boxes { get; set; } = null!;

        private readonly string dataSource;

        public WarehouseDbContext(string dataSource)
        {
            this.dataSource = dataSource;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + dataSource);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
