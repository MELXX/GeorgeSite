using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GeorgeSite.Models.Data
{
    public class IdentityRepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        IdentityDbContext IdentityDbContext;

        public IdentityRepositoryBase(IdentityDbContext identityDbContext)
        {
            IdentityDbContext = identityDbContext;
        }

        public void Create(T entity)
        {
            IdentityDbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            IdentityDbContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindAll()
        {
            return IdentityDbContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return IdentityDbContext.Set<T>().Where(expression);
        }

        public T GetById(int id)
        {
            return IdentityDbContext.Set<T>().Find(id);
        }

        public void Save()
        {
            IdentityDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            IdentityDbContext.Set<T>().Update(entity);
        }
    }
}
