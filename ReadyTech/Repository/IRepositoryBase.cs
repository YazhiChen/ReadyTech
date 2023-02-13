using System.Linq.Expressions;

namespace ReadyTech.Repository
{
    public interface IRepositoryBase<T>
    {
        T Get(int id);
        Task<T> GetAsync(int id);
        T Find(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        IQueryable<T> GetAll();
        IQueryable<T> GetBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(List<T> entityList);
        void Delete(T entity);
        void DeleteRange(List<T> entityList);
        void Edit(T entity);
        void EditRange(List<T> entityList);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
