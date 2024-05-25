using AutoMapper;
using MiTiendaBackend.DAL.Repository.Contract;
using MiTiendita.BLL.Services.Contract;
using MiTiendita.DTO;
using MiTiendita.DTO.Requests;
using MiTiendita.Entity;
using MiTiendita.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTiendita.BLL.Services
{
  public class AdminService : IAdminService
  {
    private readonly IGenericRepository<User> _userRep;
    private readonly IMapper _mapper;
    private readonly PasswordHasher _passwordHasher = new();

    public AdminService(IGenericRepository<User> userRep, IMapper mapper)
    {
      _userRep = userRep;
      _mapper = mapper;
    }

    private bool CheckSuperAdmin(string? superAdminPassword)
    {
      // Without admins
      if (_userRep.Count() == 0)
        return true;

      // Admind needed
      if (_userRep.Count() > 0 && superAdminPassword == null)
        return false;

      User? SuperAdmin = _userRep.Get(admin => admin.UserRole == 1);
      bool CheckPasswordSuperAdmin = _passwordHasher.Verify(SuperAdmin.Password, superAdminPassword);

      // Invalid password admin
      if (!CheckPasswordSuperAdmin)
        return false;

      return true;
    }

    public User? GetAdmin(int adminId)
    {
      try
      {
        User? FindAdmin = _userRep.Get(admin => admin.UserId == adminId && admin.UserRole == 2);

        return FindAdmin;
      }
      catch (Exception)
      {

        throw;
      }
    }

    public AdminDTO CreateAdmin(CreateAdminRequesrtDTO model)
    {
      try
      {
        bool SuperAdminCheck =  CheckSuperAdmin(model.SuperAdminPassword);

        if (!SuperAdminCheck)
        {
          throw new TaskCanceledException("admin_superadmin_password_required_or_incorrect");
        }

        User? FindAdmin = _userRep.Get(admin => admin.Mail == model.Mail);
      
        if (FindAdmin != null)
        {
          throw new TaskCanceledException("admin_mail_taked");
        }

        User NewAdmin = new User();

        NewAdmin.Mail = model.Mail;
        NewAdmin.Password = _passwordHasher.Hash(model.Password);
        NewAdmin.PasswordHint = model.PasswordHint;

        if (SuperAdminCheck && _userRep.Count() == 0)
        {
          NewAdmin.UserRole = 1;
        }
        else
        {
          NewAdmin.UserRole = 2;
        }

        User CreatedAdmin = _userRep.Create(_mapper.Map<User>(NewAdmin));
       
        return _mapper.Map<AdminDTO>(CreatedAdmin);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public AdminDTO UpdateAdmin(UpdateAdminRequestDTO model)
    {
      try
      {
        bool SuperAdminCheck = CheckSuperAdmin(model.SuperAdminPassword);

        if (!SuperAdminCheck)
        {
          throw new TaskCanceledException("admin_superadmin_incorrect_credentials");
        }

        User? FindAdmin = _userRep.Get(admin => admin.UserId == model.AdminId);

        if (FindAdmin == null)
        {
          throw new TaskCanceledException("admin_incorrect_id");
        }

        model.Mail = model.Mail != null ? model.Mail : FindAdmin.Mail;
        model.Password = model.Password != null ? _passwordHasher.Hash(model.Password) : FindAdmin.Password;
        model.PasswordHint = model.PasswordHint != null ? model.PasswordHint : FindAdmin.PasswordHint;

        _userRep.Update(_mapper.Map<User>(model));

        User? UpdatedAdmin = GetAdmin(model.AdminId);

        return _mapper.Map<AdminDTO>(UpdatedAdmin);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public bool DeleteAdmin(DeleteAdminRequestDTO model)
    {
      try
      {
        bool SuperAdminCheck = CheckSuperAdmin(model.SuperAdminPassword);

        if (!SuperAdminCheck)
        {
          throw new TaskCanceledException("admin_superadmin_incorrect_credentials");
        }

        User? FindAdmin = GetAdmin(model.AdminId);

        if (FindAdmin == null)
        {
          throw new TaskCanceledException("admin_incorrect_id");
        }

        return _userRep.Delete(FindAdmin);
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
