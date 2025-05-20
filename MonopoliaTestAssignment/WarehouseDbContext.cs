using Microsoft.EntityFrameworkCore;
using MonopoliaTestAssignment.Models;

namespace MonopoliaTestAssignment
{
    internal class WarehouseDbContext : DbContext
    {
        public DbSet<Pallet> Pallets { get; set; } = null!;
        public DbSet<Box> Boxes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var projectDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent;
            string dbPath = projectDir.FullName + "/Database/warehouse.db";
            optionsBuilder.UseSqlite("Data Source=" + dbPath);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
