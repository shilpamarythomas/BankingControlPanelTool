using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _RepositoryContext { get; set; }
        protected DbSet<T> _dbSet;
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _RepositoryContext = repositoryContext;
            _dbSet= _RepositoryContext.Set<T>();
        }
        public IQueryable<T> FindAll() => _dbSet.AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            _dbSet.Where(expression).AsNoTracking();
        public void Create(T entity) => _dbSet.Add(entity);
             
        public void Update(T entity) => _dbSet.Update(entity);
        public void Delete(T entity) => _dbSet.Remove(entity);
        public void SaveChange() => _RepositoryContext.SaveChanges();
        public void SaveChangesAsync() => _RepositoryContext.SaveChangesAsync();
    }
}
