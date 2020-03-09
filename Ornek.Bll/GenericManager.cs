using Ornek.Dal.Abstract;

using Ornek.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ornek.Bll
{
    
    public  class GenericManager<T> : IGenericService1<T> where T:class
    {
       private readonly IGenericRepo<T> genericRepo;

        public GenericManager(IGenericRepo<T> genericRepo)
        {
            this.genericRepo = genericRepo;
        }

        
        
        public T Add(T entity)
        {
            return genericRepo.Add(entity);
        }

        public bool DeleteById(int id)
        {
            return genericRepo.DeleteById(id);
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
                genericRepo.Dispose();
            }   
        }

        public IQueryable<T> GetAll()
        {
            return genericRepo.GetAll();
        }

        public IQueryable<T> GetAllByQuery(Expression<Func<T, bool>> expression)
        {
            return GetAllByQuery(expression);
        }

        public T GetById(int id)
        {
            return genericRepo.GetById(id);
        }

        public bool Update(T entity)
        {
            return genericRepo.Update(entity);
        }
    }
}
