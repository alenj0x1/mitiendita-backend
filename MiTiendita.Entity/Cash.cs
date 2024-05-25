using System;
using System.Collections.Generic;

namespace MiTiendita.Entity;

public partial class Cash
{
    public int CashId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int StoreId { get; set; }

    public virtual Store Store { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
