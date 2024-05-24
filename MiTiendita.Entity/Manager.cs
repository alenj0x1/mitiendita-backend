using System;
using System.Collections.Generic;

namespace MiTiendita.Entity;

public partial class Manager
{
    public int ManagerId { get; set; }

    public string Mail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PasswordHint { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public int StoreId { get; set; }

    public virtual Store Store { get; set; } = null!;
}
