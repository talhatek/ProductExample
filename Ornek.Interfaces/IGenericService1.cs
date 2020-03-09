using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ornek.Interfaces
{
    public interface IGenericService1<T>:IDisposable
    {
        T Add(T entity);
        T GetById(int id);
        IQueryable<T> GetAll();

        IQueryable<T> GetAllByQuery(Expression<Func<T, bool>> expression);
        bool DeleteById(int id);
        bool Update(T entity);


    }
}
