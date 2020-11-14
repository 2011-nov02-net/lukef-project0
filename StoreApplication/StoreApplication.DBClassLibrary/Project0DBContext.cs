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
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StoreInventory> StoreInventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "StoreApp");

                entity.Property(e => e.CustomerId).HasMaxLength(30);

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

                entity.HasIndex(e => e.Name, "UQ__Location__737584F61F3517F1")
                    .IsUnique();

                entity.Property(e => e.LocationId).HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders", "StoreApp");

                entity.Property(e => e.OrderId).HasMaxLength(30);

                entity.Property(e => e.CustomerId)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LocationId)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__656C112C");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Orders__Location__6477ECF3");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetails", "StoreApp");

                entity.Property(e => e.Id).HasMaxLength(30);

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.OrderTime).HasColumnType("date");

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderDeta__Order__68487DD7");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderDeta__Produ__693CA210");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "StoreApp");

                entity.HasIndex(e => e.Name, "UQ__Product__737584F658549A29")
                    .IsUnique();

                entity.Property(e => e.ProductId).HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<StoreInventory>(entity =>
            {
                entity.ToTable("StoreInventory", "StoreApp");

                entity.Property(e => e.StoreInventoryId).HasMaxLength(30);

                entity.Property(e => e.LocationId)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.StoreInventories)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__StoreInve__Locat__6D0D32F4");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StoreInventories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__StoreInve__Produ__6E01572D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
