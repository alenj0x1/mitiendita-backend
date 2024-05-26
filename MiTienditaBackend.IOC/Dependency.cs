using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiTienditaBackend.DAL.DBContext;
using MiTienditaBackend.DAL.Repository;
using MiTienditaBackend.DAL.Repository.Contract;
using MiTienditaBackend.BLL.Services;
using MiTienditaBackend.BLL.Services.Contract;
using MiTienditaBackend.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienditaBackend.IOC
{
  public static class Dependency
  {
    public static void DependencyInjection(this IServiceCollection services, IConfiguration config)
    {
      services.AddDbContext<MitienditaDbContext>(opt =>
      {
        opt.UseSqlServer(config.GetConnectionString("sqlString"));
      });

      services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

      services.AddAutoMapper(typeof(AutoMapperProfile));

      services.AddScoped<IAppService, AppService>();
      services.AddScoped<IAdminService, AdminService>();
      services.AddScoped<IStoreService, StoreService>();
    }
  }
}
