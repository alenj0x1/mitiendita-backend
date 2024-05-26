using MiTienditaBackend.DTO.Requests.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienditaBackend.BLL.Services.Contract
{
    public interface IAppService
  {
    int CheckSuperAdmin();
    string? Login(LoginRequestDTO req);
  }
}
