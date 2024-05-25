using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTiendita.DTO.Requests
{
  public class DeleteAdminRequestDTO
  {
    public string SuperAdminPassword { get; set; }
    public int AdminId { get; set; }
  }
}
