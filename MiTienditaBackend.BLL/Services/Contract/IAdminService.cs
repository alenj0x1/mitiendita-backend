using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiTienditaBackend.DTO.Requests.Admin;
using MiTienditaBackend.DTO;
using MiTienditaBackend.Entity;

namespace MiTienditaBackend.BLL.Services.Contract
{
    public interface IAdminService
  {
    User? GetAdmin(int adminId);
    Task<AdminDTO> CreateAdmin(CreateAdminRequesrtDTO model);
    Task<AdminDTO> UpdateAdmin(UpdateAdminRequestDTO model);
    Task<bool> DeleteAdmin(int adminId);
  }
}
