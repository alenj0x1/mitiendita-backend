using System;
using System.Collections.Generic;

namespace MiTienditaBackend.Entity;

public partial class Store
{
    public int StoreId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public decimal? Balance { get; set; }

    public string MoneyType { get; set; } = null!;

    public int Iva { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Cash> Cashes { get; set; } = new List<Cash>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Sell> Sells { get; set; } = new List<Sell>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
