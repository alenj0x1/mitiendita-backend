using Microsoft.Extensions.Configuration;
using MiTienditaBackend.DAL.Repository.Contract;
using MiTienditaBackend.DTO.Requests.App;
using MiTienditaBackend.BLL.Services.Contract;
using MiTienditaBackend.Entity;
using MiTienditaBackend.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienditaBackend.BLL.Services
{
    public class AppService : IAppService
  {
    private readonly IGenericRepository<User> _userRep;
    private readonly IGenericRepository<AppRole> _appRole;
    private readonly IConfiguration _configuration;
    private readonly PasswordHasher _passwordHasher = new();
    private readonly ManageToken _manageToken = new();

    public AppService(IGenericRepository<User> userRep, IGenericRepository<AppRole> appRole, IConfiguration configuration)
    {
      _userRep = userRep;
      _appRole = appRole;
      _configuration = configuration;
    }

    public int CheckSuperAdmin()
    {
      try
      {
        User? SuperAdmin = _userRep.Get(u => u.UserRole == 1);

        if (SuperAdmin == null)
          return 0;

        return SuperAdmin.UserId;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public string? Login(LoginRequestDTO req)
    {
      User? FindUser = _userRep.Get(u => u.Mail == req.Mail);

      if (FindUser == null)
        throw new TaskCanceledException("login_incorrect_credentials");

      bool PasswordVerify = _passwordHasher.Verify(FindUser.Password, req.Password);

      if (!PasswordVerify)
        throw new TaskCanceledException("login_incorrect_credentials");

      string UserToken = _manageToken.CreateToken(_configuration, _appRole, FindUser);

      return UserToken;
    }
  }
}
