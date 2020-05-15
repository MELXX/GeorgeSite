using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GeorgeSite.Models.Data
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T:class
    {
        private AppDbContext AppDbContext;

        public RepositoryBase(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public void Create(T entity)
        {
            AppDbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            AppDbContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindAll()
        {
            return AppDbContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return AppDbContext.Set<T>().Where(expression);
        }

        public T GetById(int id)
        {
           return  AppDbContext.Set<T>().Find(id);
        }

        public void Save()
        {
            AppDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            AppDbContext.Set<T>().Update(entity);
        }
    }
}
