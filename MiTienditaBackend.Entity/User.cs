using System;
using System.Collections.Generic;

namespace MiTienditaBackend.Entity;

public partial class User
{
    public int UserId { get; set; }

    public string Mail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PasswordHint { get; set; } = null!;

    public int? UserRole { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CashId { get; set; }

    public int? StoreId { get; set; }

    public virtual Cash? Cash { get; set; }

    public virtual ICollection<Sell> Sells { get; set; } = new List<Sell>();

    public virtual Store? Store { get; set; }

    public virtual AppRole? UserRoleNavigation { get; set; }
}
