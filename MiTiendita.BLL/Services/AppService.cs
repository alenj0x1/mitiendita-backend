using Microsoft.Extensions.Configuration;
using MiTiendaBackend.DAL.Repository.Contract;
using MiTiendaBackend.DTO.Requests;
using MiTiendita.BLL.Services.Contract;
using MiTiendita.Entity;
using MiTiendita.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTiendita.BLL.Services
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

    public async Task<bool> CheckAdmin()
    {
      try
      {
        int AdminCount = await _userRep.Count();

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
