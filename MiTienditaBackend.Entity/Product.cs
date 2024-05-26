using System;
using System.Collections.Generic;

namespace MiTienditaBackend.Entity;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public decimal Price { get; set; }

    public int? Stock { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int StoreId { get; set; }

    public virtual ICollection<SellProduct> SellProducts { get; set; } = new List<SellProduct>();

    public virtual Store Store { get; set; } = null!;
}
