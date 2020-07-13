using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SuLnu.DataAccess.Interfaces.Base;
using SuLnu.DataAccess.Interfaces;

namespace SuLnu.DataAccess.Repositories.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected SuLnuDBContext _suLnuDBContext { get; set; }

        public RepositoryBase(SuLnuDBContext suLnuDBContext)
        {
            _suLnuDBContext = suLnuDBContext;
        }

        public IQueryable<T> FindAll()
        {
            return _suLnuDBContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _suLnuDBContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            _suLnuDBContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _suLnuDBContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _suLnuDBContext.Set<T>().Remove(entity);
        }
    }
}
