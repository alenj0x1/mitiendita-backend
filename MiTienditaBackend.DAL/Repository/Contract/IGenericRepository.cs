using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiTienditaBackend.DAL.Repository.Contract
{
  public interface IGenericRepository<T> where T : class
  {
    T? Get(Expression<Func<T, bool>> filter);
    Task<T> Create(T model);
    Task<bool> Update(T model);
    Task<bool> Delete(T model);
    IQueryable<T> Query(Expression<Func<T, bool>> filter);
    Task<int> Count();
  }
}
