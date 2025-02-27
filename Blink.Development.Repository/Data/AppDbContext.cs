using Blink.Development.Entities;
using Blink.Development.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blink.Development.Repository.Data;

public class AppDbContext : IdentityDbContext<User>
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    // store delivery(check the last one) city order branch Trash and cutomers are done
    // DbSet properties using proper PascalCase naming
    public DbSet<Order> Orders { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<User> StoresAndDeliveries { get; set; }
    public DbSet<Trash> Trashes { get; set; }
    public DbSet<MoneyTransaction> MoneyTransactions { get; set; }
    public DbSet<Mission> Missions { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Inventory> Inventory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Order>()
            .HasOne(o => o.UserStore)
            .WithMany(s => s.StoreOrders)
            .HasForeignKey(o => o.UserStoreId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.DeliveryUser)
            .WithMany(d => d.DeliveryOrders)
            .HasForeignKey(o => o.DeliveryUserId)
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
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Trash)
            .WithOne(o => o.Order)
            .HasForeignKey<Trash>(o => o.OrderId)
            .OnDelete(DeleteBehavior.NoAction);

        // user store
        modelBuilder.Entity<User>()
            .HasOne(s => s.StoreBranch)
            .WithMany(b => b.UserStores)
            .HasForeignKey(s => s.StoreBranchId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>()
            .HasOne(s => s.StoreMoneyTransaction)
            .WithOne(mt => mt.UserStore)
            .HasForeignKey<MoneyTransaction>(mt => mt.UserStoreId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>()
            .HasMany(s => s.StoreOrders)
            .WithOne(o => o.UserStore)
            .HasForeignKey(o => o.UserStoreId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>()
            .HasMany(s => s.Inventory)
            .WithOne(i => i.UserStore)
            .HasForeignKey(i => i.UserStoreId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasMany(s => s.Mission)
            .WithOne(m => m.UserStore)
            .HasForeignKey(m => m.UserStoreId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Inventory>()
            .HasOne(i => i.UserStore)
            .WithMany(s => s.Inventory)
            .HasForeignKey(i => i.UserStoreId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>()
            .HasOne(Delivery => Delivery.DeliveryBranch)
            .WithMany(Branch => Branch.DeliveryUsers)
            .HasForeignKey(Delivery => Delivery.DeliveryBranchId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>()
            .HasOne(m => m.DeliveryMoneyTransaction)
            .WithOne(d => d.DeliveryUser)
            .HasConstraintName("FK_Delivery_MoneyTransaction")
            .HasForeignKey<MoneyTransaction>(d => d.DeliveryUserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>()
            .HasMany(Delivery => Delivery.DeliveryOrders)
            .WithOne(Order => Order.DeliveryUser)
            .HasForeignKey(Order => Order.DeliveryUserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<City>()
            .HasMany(c => c.Orders)
            .WithOne(c => c.City)
            .HasForeignKey(c => c.CityId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<City>()
            .HasMany(c => c.Streets)
            .WithOne(c => c.City)
            .HasForeignKey(c => c.CityId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Branch>()
            .HasMany(b => b.UserStores)
            .WithOne(s => s.StoreBranch)
            .HasForeignKey(s => s.StoreBranchId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Branch>()
            .HasMany(b => b.DeliveryUsers)
            .WithOne(s => s.DeliveryBranch)
            .HasForeignKey(s => s.DeliveryBranchId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Branch>()
            .HasMany(b => b.Orders)
            .WithOne(s => s.Branch)
            .HasForeignKey(s => s.BranchId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<MoneyTransaction>()
            .HasOne(mt => mt.UserStore)
            .WithOne(s => s.StoreMoneyTransaction)
            .HasForeignKey<MoneyTransaction>(mt => mt.UserStoreId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<MoneyTransaction>()
            .HasOne(mt => mt.DeliveryUser)
            .WithOne(s => s.DeliveryMoneyTransaction)
            .HasForeignKey<MoneyTransaction>(s => s.DeliveryUserId)
            .OnDelete(DeleteBehavior.NoAction);

    }

}
