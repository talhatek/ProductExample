using Ornek.Dal.Abstract;
using Ornek.Dal.Concrete.EF.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ornek.Dal.Concrete.EF.Repo
{
    public  class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly OrnekContext ornekContext = new OrnekContext();

        
        public T Add(T entity)
        {
            ornekContext.Set<T>().Add(entity);
            ornekContext.SaveChanges();
            return entity;
        }

        public bool DeleteById(int id)
        {
            var entity = ornekContext.Set<T>().Find(id);
            ornekContext.Set<T>().Remove(entity);
           return ornekContext.SaveChanges()>0;
            
        }

        

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                ornekContext.Dispose();
            }
        }

        public IQueryable<T> GetAll()
        {
            return ornekContext.Set<T>().AsNoTracking().AsQueryable();
        }

        public IQueryable<T> GetAllByQuery(Expression<Func<T, bool>> expression)
        {
            return ornekContext.Set<T>().AsNoTracking().Where(expression).AsQueryable();
        }

        public T GetById(int id)
        {
            var entity = ornekContext.Set<T>().Find(id);
            return entity;
        }

        public bool Update(T  entity)
        {
          //  var entity = ornekContext.Set<T>().Find(id);
         
            ornekContext.Set<T>().AddOrUpdate(entity);
            return ornekContext.SaveChanges() > 0;
        }
    }
}
