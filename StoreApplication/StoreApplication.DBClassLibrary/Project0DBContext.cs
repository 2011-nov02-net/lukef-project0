using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StoreApplication.DBClassLibrary
{
    public partial class Project0DBContext : DbContext
    {
        public Project0DBContext()
        {
        }

        public Project0DBContext(DbContextOptions<Project0DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StoreInventory> StoreInventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "StoreApp");

                entity.HasIndex(e => e.Email, "UQ__Customer__A9D105344AF340D6")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "StoreApp");

                entity.HasIndex(e => e.Name, "UQ__Location__737584F699B7C172")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders", "StoreApp");

                entity.Property(e => e.OrderTime)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__14E61A24");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Orders__Location__13F1F5EB");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Orders__ProductI__15DA3E5D");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "StoreApp");

                entity.HasIndex(e => e.Name, "UQ__Product__737584F619450E3A")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<StoreInventory>(entity =>
            {
                entity.ToTable("StoreInventory", "StoreApp");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.StoreInventories)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__StoreInve__Locat__1A9EF37A");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StoreInventories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__StoreInve__Produ__1B9317B3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
