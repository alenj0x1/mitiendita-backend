using System;
using System.Collections.Generic;

namespace MiTiendita.Entity;

public partial class SellProduct
{
    public int SellId { get; set; }

    public int? ProductId { get; set; }

    public int? Amount { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Sell Sell { get; set; } = null!;
}
