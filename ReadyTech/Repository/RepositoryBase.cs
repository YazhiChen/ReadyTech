using Microsoft.EntityFrameworkCore;
using ReadyTech.Models;
using System.Linq.Expressions;

namespace ReadyTech.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ReadyTechDbContext dbContext { get; set; }

        public RepositoryBase(ReadyTechDbContext context)
        {
            dbContext = context;
        }

        public T Get(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }
        public T Find(Expression<Func<T, bool>> match)
        {
            return dbContext.Set<T>().SingleOrDefault(match);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await dbContext.Set<T>().SingleOrDefaultAsync(match);
        }
        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = dbContext.Set<T>();
            return query;
        }
        public IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = dbContext.Set<T>().Where(predicate);
            return query;
        }

        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }

        public void AddRange(List<T> entityList)
        {
            dbContext.Set<T>().AddRange(entityList);
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public void DeleteRange(List<T> entityList)
        {
            dbContext.Set<T>().RemoveRange(entityList);
        }

        public void Edit(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }
        public void EditRange(List<T> entityList)
        {
            dbContext.Set<T>().UpdateRange(entityList);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
