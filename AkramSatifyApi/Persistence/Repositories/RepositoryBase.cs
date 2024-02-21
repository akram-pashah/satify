using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryDbContext RepositoryDbContext { get; set; }
        protected RepositoryBase(RepositoryDbContext repositoryContext)
        {
            this.RepositoryDbContext = repositoryContext;
        }

        public IQueryable<T> FindAll() => this.RepositoryDbContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            RepositoryDbContext.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity) => this.RepositoryDbContext.Set<T>().Add(entity);
        
        public void Update(T entity) => this.RepositoryDbContext.Set<T>().Update(entity);

        public void Delete(T entity) => this.RepositoryDbContext.Set<T>().Remove(entity);

        public async Task SaveChanges() => await this.RepositoryDbContext.SaveChangesAsync();
    }
}
