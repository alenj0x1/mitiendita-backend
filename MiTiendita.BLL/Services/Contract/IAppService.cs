using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTiendita.BLL.Services.Contract
{
  public interface IAppService
  {
    Task<bool> CheckAdmin();
  }
}
