using System;
using System.Collections.Generic;

namespace MiTienditaBackend.Entity;

public partial class Sell
{
    public int SellId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? UserId { get; set; }

    public int StoreId { get; set; }

    public virtual SellProduct? SellProduct { get; set; }

    public virtual Store Store { get; set; } = null!;

    public virtual User? User { get; set; }
}
