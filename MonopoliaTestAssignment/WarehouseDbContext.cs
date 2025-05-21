using Microsoft.EntityFrameworkCore;
using MonopoliaTestAssignment.Models;

namespace MonopoliaTestAssignment
{
    internal class WarehouseDbContext(string dataSource) : DbContext
    {
        public DbSet<Pallet> Pallets { get; set; } = null!;
        public DbSet<Box> Boxes { get; set; } = null!;

        private readonly string dataSource = dataSource;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + dataSource);
            base.OnConfiguring(optionsBuilder);
        }

        //Сгруппировать все паллеты по сроку годности, отсортировать по возрастанию срока годности, в каждой группе отсортировать паллеты по весу.
        public IEnumerable<Pallet> FirstQuery()
        {
            var pallets = Pallets.Include(p => p.Boxes).ToList();
            
            return pallets.Where(p => p.ExpirationDate != null)
                          .GroupBy(p => p.ExpirationDate)
                          .OrderBy(g => g.Key)
                          .SelectMany(g => g.OrderBy(p => p.Weight));
        }

        //3 паллеты, которые содержат коробки с наибольшим сроком годности, отсортированные по возрастанию объема.
        public IEnumerable<Pallet> SecondQuery()
        {
            var pallets = Pallets.Include(p => p.Boxes).ToList();

            return pallets.OrderByDescending(p => p.ExpirationDate)
                          .Take(3)
                          .OrderBy(p => p.Volume);
        }
    }
}
