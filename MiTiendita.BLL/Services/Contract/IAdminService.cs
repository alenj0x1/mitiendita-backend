using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiTiendita.DTO;
using MiTiendita.DTO.Requests;
using MiTiendita.Entity;

namespace MiTiendita.BLL.Services.Contract
{
  public interface IAdminService
  {
    User? GetAdmin(int adminId);
    Task<AdminDTO> CreateAdmin(CreateAdminRequesrtDTO model);
    Task<AdminDTO> UpdateAdmin(UpdateAdminRequestDTO model);
    Task<bool> DeleteAdmin(int adminId);
  }
}
