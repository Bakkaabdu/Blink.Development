using Blink.Development.Entities;
using Blink.Development.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blink.Development.Repository.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // DbSet properties using proper PascalCase naming
    public DbSet<Order> Orders { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<Trash> Trashes { get; set; }
    public DbSet<MoneyTransaction> MoneyTransactions { get; set; }
    public DbSet<Mission> Missions { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Inventory> Inventory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Store)
            .WithMany(s => s.Orders)
            .HasForeignKey(o => o.StoreId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Delivery)
            .WithMany(d => d.Orders)
            .HasForeignKey(o => o.DeliveryId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Status)
            .WithMany(s => s.Orders)
            .HasForeignKey(o => o.StatusId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.City)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CityId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Street)
            .WithMany(s => s.Orders)
            .HasForeignKey(o => o.StreetId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Branch)
            .WithMany(b => b.Orders)
            .HasForeignKey(o => o.BranchId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Store>()
            .HasOne(s => s.Branch)
            .WithMany(b => b.Stores)
            .HasForeignKey(s => s.BranchId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Store>()
            .HasOne(s => s.MoneyTransaction)
            .WithOne(mt => mt.Store)
            .HasForeignKey<MoneyTransaction>(mt => mt.StoreId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Store>()
            .HasMany(s => s.Orders)
            .WithOne(o => o.Store)
            .HasForeignKey(o => o.StoreId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Store>()
            .HasMany(s => s.Inventory)
            .WithOne(i => i.Store)
            .HasForeignKey(i => i.StoreId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Store>()
            .HasMany(s => s.Mission)
            .WithOne(m => m.Store)
            .HasForeignKey(m => m.StoreId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Delivery>()
            .HasOne(Delivery => Delivery.Branch)
            .WithMany(Branch => Branch.Deliveries)
            .HasForeignKey(Delivery => Delivery.BranchId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Delivery>()
            .HasOne(m => m.MoneyTransaction)
            .WithOne(d => d.Delivery)
            .HasConstraintName("FK_Delivery_MoneyTransaction")
            .HasForeignKey<MoneyTransaction>(d => d.DeliveryId)
            .OnDelete(DeleteBehavior.NoAction);


    }

}
