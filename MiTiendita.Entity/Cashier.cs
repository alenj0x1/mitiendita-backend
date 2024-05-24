using System;
using System.Collections.Generic;

namespace MiTiendita.Entity;

public partial class Cashier
{
    public int CashierId { get; set; }

    public string Mail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PasswordHint { get; set; } = null!;

    public int Cash { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int StoreId { get; set; }

    public virtual Cash CashNavigation { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
