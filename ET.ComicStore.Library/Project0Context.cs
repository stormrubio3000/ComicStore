using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ET.ComicStore.Library
{
    public partial class Project0Context : DbContext
    {
        public Project0Context()
        {
        }

        public Project0Context(DbContextOptions<Project0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ComicStore> ComicStore { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersProduct> OrdersProduct { get; set; }
        public virtual DbSet<StoreProduct> StoreProduct { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<ComicStore>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK__ComicSto__3B82F0E1BF0A16AC");

                entity.ToTable("ComicStore", "Comic");

                entity.HasIndex(e => e.Location)
                    .HasName("UQ__ComicSto__E55D3B106C0C8350")
                    .IsUnique();

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "Comic");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Fk_Customer_To_Location");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory", "Comic");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Fk_Inventory_To_ComicStore");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("Orders", "Comic");

                entity.Property(e => e.OrdersId).HasColumnName("OrdersID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("Fk_Orders_To_Customer");
            });

            modelBuilder.Entity<OrdersProduct>(entity =>
            {
                entity.ToTable("OrdersProduct", "Comic");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OrdersId).HasColumnName("OrdersID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.OrdersProduct)
                    .HasForeignKey(d => d.OrdersId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Fk_OrderProduct_To_OrdersInventory");
            });

            modelBuilder.Entity<StoreProduct>(entity =>
            {
                entity.ToTable("StoreProduct", "Comic");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.SetId).HasColumnName("SetID");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.StoreProduct)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Fk_StoreProduct_To_Inventory");

                entity.HasOne(d => d.Set)
                    .WithMany(p => p.InverseSet)
                    .HasForeignKey(d => d.SetId)
                    .HasConstraintName("Fk_StoreSet_To_StoreProduct");
            });
        }
    }
}
