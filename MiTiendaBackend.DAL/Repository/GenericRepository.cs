using Microsoft.EntityFrameworkCore;
using MiTiendaBackend.DAL.DBContext;
using MiTiendaBackend.DAL.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiTiendaBackend.DAL.Repository
{
  public class GenericRepository<T> : IGenericRepository<T> where T : class
  {
    private readonly MitienditaDbContext _dbContext;

    public GenericRepository(MitienditaDbContext dbContext)
    {
      this._dbContext = dbContext;
    }

    public async Task<T> Create(T model)
    {
      try
      {
        _dbContext.Set<T>().Add(model);
        await _dbContext.SaveChangesAsync();

        return model;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> Delete(T model)
    {
      try
      {
        _dbContext.Set<T>().Remove(model);
        await _dbContext.SaveChangesAsync();

        return true;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public T? Get(Expression<Func<T, bool>> filter)
    {
      T? Result = _dbContext.Set<T>().Where(filter).FirstOrDefault();

      return Result;
    }

    public IQueryable<T> Query(Expression<Func<T, bool>> filter)
    {
      try
      {
        IQueryable<T> query = filter != null ? _dbContext.Set<T>().Where(filter) : _dbContext.Set<T>();

        return query;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<bool> Update(T model)
    {
      try
      {
        _dbContext.Set<T>().Update(model);
        await _dbContext.SaveChangesAsync();

        return true;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<int> Count()
    {
      try
      {
        return await _dbContext.Set<T>().CountAsync();
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
