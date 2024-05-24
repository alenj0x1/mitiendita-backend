using System;
using System.Collections.Generic;

namespace MiTiendita.Entity;

public partial class User
{
    public int UserId { get; set; }

    public string Mail { get; set; } = null!;

    public string Paswword { get; set; } = null!;

    public string PasswordHint { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public int StoreId { get; set; }

    public virtual ICollection<Sell> Sells { get; set; } = new List<Sell>();

    public virtual Store Store { get; set; } = null!;
}
