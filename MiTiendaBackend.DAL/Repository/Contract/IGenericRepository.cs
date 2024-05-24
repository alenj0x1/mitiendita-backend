using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiTiendaBackend.DAL.Repository.Contract
{
  public interface IGenericRepository<T> where T : class
  {
    T? Get(Expression<Func<T, bool>> filter);
    T Create(T model);
    bool Update(T model);
    bool Delete(T model);
    IQueryable<T> Query(Expression<Func<T, bool>> filter);
  }
}
