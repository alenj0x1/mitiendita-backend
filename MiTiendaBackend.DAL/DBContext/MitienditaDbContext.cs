using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MiTiendita.Entity;

namespace MiTiendaBackend.DAL.DBContext;

public partial class MitienditaDbContext : DbContext
{
    public MitienditaDbContext()
    {
    }

    public MitienditaDbContext(DbContextOptions<MitienditaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppRole> AppRoles { get; set; }

    public virtual DbSet<Cash> Cashes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sell> Sells { get; set; }

    public virtual DbSet<SellProduct> SellProducts { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__AppRoles__CD98462A40516D75");

            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Cash>(entity =>
        {
            entity.HasKey(e => e.CashId).HasName("PK__Cash__961C70C5D97EB917");

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
                .HasConstraintName("FK__Cash__storeId__3F466844");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__2D10D16AE188018B");

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
                .HasConstraintName("FK__Product__storeId__4AB81AF0");
        });

        modelBuilder.Entity<Sell>(entity =>
        {
            entity.HasKey(e => e.SellId).HasName("PK__Sell__2D21FF24C1F36074");

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
                .HasConstraintName("FK__Sell__storeId__4F7CD00D");

            entity.HasOne(d => d.User).WithMany(p => p.Sells)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Sell__userId__4E88ABD4");
        });

        modelBuilder.Entity<SellProduct>(entity =>
        {
            entity.HasKey(e => e.SellId).HasName("PK__SellProd__2D21FF24BB925161");

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
                .HasConstraintName("FK__SellProdu__produ__534D60F1");

            entity.HasOne(d => d.Sell).WithOne(p => p.SellProduct)
                .HasForeignKey<SellProduct>(d => d.SellId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SellProdu__sellI__52593CB8");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__Store__1EA71613DA9BFF7B");

            entity.ToTable("Store");

            entity.Property(e => e.StoreId).HasColumnName("storeId");
            entity.Property(e => e.Balance)
                .HasDefaultValue(0m)
                .HasColumnType("money")
                .HasColumnName("balance");
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
            entity.Property(e => e.Iva).HasColumnName("iva");
            entity.Property(e => e.MoneyType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("moneyType");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__CB9A1CFF54ED2271");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.CashId).HasColumnName("cashId");
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
                .HasColumnName("passwordHint");
            entity.Property(e => e.StoreId).HasColumnName("storeId");
            entity.Property(e => e.UserRole)
                .HasDefaultValue(5)
                .HasColumnName("userRole");

            entity.HasOne(d => d.Cash).WithMany(p => p.Users)
                .HasForeignKey(d => d.CashId)
                .HasConstraintName("FK__User__cashId__44FF419A");

            entity.HasOne(d => d.Store).WithMany(p => p.Users)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK__User__storeId__45F365D3");

            entity.HasOne(d => d.UserRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRole)
                .HasConstraintName("FK__User__userRole__4316F928");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
