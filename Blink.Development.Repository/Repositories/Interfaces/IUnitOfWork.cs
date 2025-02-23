namespace Blink.Development.Repository.Repositories.Interfaces;

public interface IUnitOfWork
{
    IBranchRepository Branchs { get; }
    ICityRepository Cities { get; }
    ICustomerRepository Customers { get; }
    IDeliveryRepository Deliveries { get; }
    IInventoryRepository Inventories { get; }
    IMissionRepository Missions { get; }
    IMoneyTransactionRepository MoneyTransactions { get; }
    IOrderRepository Orders { get; }
    IStatusRepository Status { get; }
    IStoreRepository Stores { get; }
    IStreetRepository Streets { get; }
    ITrashRepository Trashes { get; }

    Task<bool> CompleteAsync();
}
