using ReadyTech.Models;

namespace ReadyTech.Repository
{
    public class EntityWrapper : IEntityWrapper
    {
        private readonly ReadyTechDbContext context;

        private IRepositoryBase<CoffeeOrder> coffeeOrder;

        public EntityWrapper(ReadyTechDbContext dbContext)
        {
            context = dbContext;
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public IRepositoryBase<CoffeeOrder> CoffeeOrder => coffeeOrder ??= new RepositoryBase<CoffeeOrder>(context);
    }
}
