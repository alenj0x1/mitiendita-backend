using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTiendita.DTO.Requests
{
  public class CreateAdminRequesrtDTO
  {
    public string? SuperAdminPassword { get; set; }
    public string Mail { get; set; }

    public string Password { get; set; }

    public string PasswordHint { get; set; }
  }
}
