using Blink.Development.Repository.Data;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Blink.Development.Repository.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _context;

    public IBranchRepository Branchs { get; }

    public ICityRepository Cities { get; }

    public ICustomerRepository Customers { get; }

    public IInventoryRepository Inventories { get; }

    public IMissionRepository Missions { get; }

    public IMoneyTransactionRepository MoneyTransactions { get; }

    public IOrderRepository Orders { get; }

    public IStatusRepository Status => throw new NotImplementedException();

    public IStreetRepository Streets { get; }

    public ITrashRepository Trashes { get; }

    public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        var logger = loggerFactory.CreateLogger("log");
        Branchs = new BranchRepository(logger, _context);
        Cities = new CityRepository(logger, _context);
        Customers = new CustomerRepository(logger, _context);
        Inventories = new InventoryRepository(logger, _context);
        Missions = new MissionRepository(logger, _context);
        MoneyTransactions = new MoneyTransactionRepository(logger, _context);
        Orders = new OrderRepository(logger, _context);
        // Status
        Streets = new StreetRepository(logger, _context);
        Trashes = new TrashRepository(logger, _context);
    }
    public async Task<bool> CompleteAsync()
    {
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
