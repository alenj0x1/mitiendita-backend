using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiTiendaBackend.DAL.Repository;
using MiTiendaBackend.DAL.Repository.Contract;
using MiTiendita.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTiendita.IOC
{
  public static class Dependency
  {
    public static void DependencyInjection(this IServiceCollection services, IConfiguration config)
    {
      services.AddDbContext<MitienditaDbContext>(opt =>
      {
        opt.UseSqlServer(config.GetConnectionString("sqlString"));
      });

      services.AddTransient(typeof(GenericRepository<>));
    }
  }
}
