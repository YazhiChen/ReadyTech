using Microsoft.EntityFrameworkCore;

namespace ReadyTech.Models
{
    public class ReadyTechDbContext: DbContext
    {
        public ReadyTechDbContext(DbContextOptions<ReadyTechDbContext> options)
        : base(options)
        {
        }

        public DbSet<CoffeeOrder> CoffeeOrder { get; set; }
    }
}
