using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTiendita.DTO
{
  public class AdminDTO
  {
    public int AdminId { get; set; }

    public string Mail { get; set; } = null!;

    public string Password { get; set; }

    public string PasswordHint { get; set; }

    public DateTime? CreatedAt { get; set; }
  }
}
