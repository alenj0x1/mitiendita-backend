using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienditaBackend.DTO
{
  public class StoreDTO
  {
    public int StoreId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public decimal? Cash { get; set; }

    public DateTime? CreatedAt { get; set; }
  }
}
