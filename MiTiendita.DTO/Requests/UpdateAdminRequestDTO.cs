using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTiendita.DTO.Requests
{
  public class UpdateAdminRequestDTO
  {
    public string SuperAdminPassword { get; set; }
    public int AdminId { get; set; }
    public string? Mail { get; set; }

    public string? Password { get; set; }

    public string? PasswordHint { get; set; }
  }
}
