using MiTiendaBackend.DAL.Repository.Contract;
using MiTiendita.BLL.Services.Contract;
using MiTiendita.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTiendita.BLL.Services
{
  public class AppService : IAppService
  {
    private readonly IGenericRepository<User> _adminRep;

    public AppService(IGenericRepository<User> adminRep)
    {
      _adminRep = adminRep;
    }

    public async Task<bool> CheckAdmin()
    {
      try
      {
        int AdminCount = await _adminRep.Count();

        if (AdminCount == 0)
        {
          return false;
        }

        return true;
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
