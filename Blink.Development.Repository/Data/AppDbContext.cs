using Blink.Development.Entities;
using Blink.Development.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blink.Development.Repository.Data;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Order> orders { get; set; }
    public DbSet<City> cities { get; set; }
    public DbSet<Street> streets { get; set; }
    public DbSet<Customer> customers { get; set; }
    public DbSet<Status> statuses { get; set; }
    public DbSet<Store> stores { get; set; }
    public DbSet<Delivery> deliveries { get; set; }
    public DbSet<Profit> profits { get; set; }
    public DbSet<Trash> trashes { get; set; }
    public DbSet<MoneyTransaction> moneyTransactions { get; set; }
    public DbSet<Mission> missions { get; set; }
    public DbSet<Blinki> blinks { get; set; }
    public DbSet<Branch> branches { get; set; }
    public DbSet<Inventory> inventory { get; set; }

}
