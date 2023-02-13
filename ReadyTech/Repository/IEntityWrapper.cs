using ReadyTech.Models;

namespace ReadyTech.Repository
{
    public interface IEntityWrapper
    {
        void SaveChanges();
        IRepositoryBase<CoffeeOrder> CoffeeOrder { get; }
    }
}
