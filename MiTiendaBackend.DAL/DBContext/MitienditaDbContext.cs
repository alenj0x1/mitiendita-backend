using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using MiTiendita.Entity;

namespace MiTiendita.DAL.DBContext;

public partial class MitienditaDbContext : DbContext
{
    public MitienditaDbContext()
    {
    }

    public MitienditaDbContext(DbContextOptions<MitienditaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cash> Cashes { get; set; }

    public virtual DbSet<Cashier> Cashiers { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sell> Sells { get; set; }

    public virtual DbSet<SellProduct> SellProducts { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cash>(entity =>
        {
            entity.HasKey(e => e.CashId).HasName("PK__Cash__961C70C55AB5D3F9");

            entity.ToTable("Cash");

            entity.Property(e => e.CashId).HasColumnName("cashId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.StoreId).HasColumnName("storeId");

            entity.HasOne(d => d.Store).WithMany(p => p.Cashes)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cash__storeId__403A8C7D");
        });

        modelBuilder.Entity<Cashier>(entity =>
        {
            entity.HasKey(e => e.CashierId).HasName("PK__Cashier__9723F4C480F56648");

            entity.ToTable("Cashier");

            entity.Property(e => e.CashierId).HasColumnName("cashierId");
            entity.Property(e => e.Cash).HasColumnName("cash");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Mail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PasswordHint)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password_hint");
            entity.Property(e => e.StoreId).HasColumnName("storeId");

            entity.HasOne(d => d.CashNavigation).WithMany(p => p.Cashiers)
                .HasForeignKey(d => d.Cash)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cashier__cash__5535A963");

            entity.HasOne(d => d.Store).WithMany(p => p.Cashiers)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cashier__storeId__571DF1D5");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("PK__Manager__47E0141FB6ACAF37");

            entity.ToTable("Manager");

            entity.Property(e => e.ManagerId).HasColumnName("managerId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Mail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PasswordHint)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password_hint");
            entity.Property(e => e.StoreId).HasColumnName("storeId");

            entity.HasOne(d => d.Store).WithMany(p => p.Managers)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Manager__storeId__3C69FB99");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__2D10D16A8C3A74F2");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("brand");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Stock)
                .HasDefaultValue(0)
                .HasColumnName("stock");
            entity.Property(e => e.StoreId).HasColumnName("storeId");

            entity.HasOne(d => d.Store).WithMany(p => p.Products)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__storeId__44FF419A");
        });

        modelBuilder.Entity<Sell>(entity =>
        {
            entity.HasKey(e => e.SellId).HasName("PK__Sell__2D21FF24F6B93B06");

            entity.ToTable("Sell");

            entity.Property(e => e.SellId).HasColumnName("sellId");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.StoreId).HasColumnName("storeId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Store).WithMany(p => p.Sells)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sell__storeId__4D94879B");

            entity.HasOne(d => d.User).WithMany(p => p.Sells)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Sell__userId__4CA06362");
        });

        modelBuilder.Entity<SellProduct>(entity =>
        {
            entity.HasKey(e => e.SellId).HasName("PK__SellProd__2D21FF248785B50B");

            entity.ToTable("SellProduct");

            entity.Property(e => e.SellId)
                .ValueGeneratedNever()
                .HasColumnName("sellId");
            entity.Property(e => e.Amount)
                .HasDefaultValue(1)
                .HasColumnName("amount");
            entity.Property(e => e.ProductId).HasColumnName("productId");

            entity.HasOne(d => d.Product).WithMany(p => p.SellProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__SellProdu__produ__5165187F");

            entity.HasOne(d => d.Sell).WithOne(p => p.SellProduct)
                .HasForeignKey<SellProduct>(d => d.SellId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SellProdu__sellI__5070F446");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__Store__1EA71613FE140ED4");

            entity.ToTable("Store");

            entity.Property(e => e.StoreId).HasColumnName("storeId");
            entity.Property(e => e.Cash)
                .HasDefaultValue(0m)
                .HasColumnType("money")
                .HasColumnName("cash");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("imageUrl");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__CB9A1CFF82563DE2");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Mail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.PasswordHint)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password_Hint");
            entity.Property(e => e.Paswword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("paswword");
            entity.Property(e => e.StoreId).HasColumnName("storeId");

            entity.HasOne(d => d.Store).WithMany(p => p.Users)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__storeId__48CFD27E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
