using Blink.Development.Entities.Entities;

namespace Blink.Development.Repository.Repositories.Interfaces
{
    public interface IMoneyTransactionRepository : IGenericRepository<MoneyTransaction>
    {
        Task HandelDeliveryTransaction(MoneyTransaction transaction);
        Task HandelStoreTransaction(MoneyTransaction transaction);

    }
}
