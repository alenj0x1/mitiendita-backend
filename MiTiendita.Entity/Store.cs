using System;
using System.Collections.Generic;

namespace MiTiendita.Entity;

public partial class Store
{
    public int StoreId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public decimal? Cash { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Cash> Cashes { get; set; } = new List<Cash>();

    public virtual ICollection<Cashier> Cashiers { get; set; } = new List<Cashier>();

    public virtual ICollection<Manager> Managers { get; set; } = new List<Manager>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Sell> Sells { get; set; } = new List<Sell>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
