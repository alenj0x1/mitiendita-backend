using System;
using System.Collections.Generic;

namespace MiTiendita.Entity;

public partial class AppRole
{
    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
