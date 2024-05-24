using System;
using System.Collections.Generic;

namespace MiTiendita.Entity;

public partial class Cash
{
    public int CashId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int StoreId { get; set; }

    public virtual ICollection<Cashier> Cashiers { get; set; } = new List<Cashier>();

    public virtual Store Store { get; set; } = null!;
}
