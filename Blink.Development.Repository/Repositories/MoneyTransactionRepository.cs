using Blink.Development.Entities.Entities;
using Blink.Development.Repository.Data;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Blink.Development.Repository.Repositories;

public class MoneyTransactionRepository : GenericRepository<MoneyTransaction>, IMoneyTransactionRepository
{
    private readonly UserManager<User> _userManager;

    public MoneyTransactionRepository(ILogger logger, AppDbContext context, UserManager<User> userManager) : base(logger, context)
    {
        _userManager = userManager;
    }

    public override async Task<IEnumerable<MoneyTransaction>> GetAll()
    {
        try
        {
            return await _dbSet
                .Where(x => x.IsDeleted == false)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.TransactionDate)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Get All Function Erorr", typeof(MoneyTransactionRepository));
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return false;

            entity.IsDeleted = true;
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Delete Function Erorr", typeof(MoneyTransactionRepository));
            throw;
        }
    }


    public async Task HandelDeliveryTransaction(MoneyTransaction transaction)
    {
        if (transaction == null)
            throw new ArgumentNullException(nameof(transaction));

        if (string.IsNullOrEmpty(transaction.DeliveryUserId))
            throw new ArgumentException("Delivery user ID is required.", nameof(transaction.DeliveryUserId));

        var deliveryUser = await _userManager.FindByIdAsync(transaction.DeliveryUserId);

        if (deliveryUser == null)
            throw new InvalidOperationException("Delivery user not found.");

        if (deliveryUser.TypeOfUser != UserType.Delivery)
            throw new InvalidOperationException("Specified user is not a Delivery user.");

        if (deliveryUser.Balance < transaction.Amount) // Ensure sufficient balance
            throw new InvalidOperationException("Insufficient balance for the transaction.");

        if (transaction.Id == Guid.Empty)
            transaction.Id = Guid.NewGuid();

        using var dbTransaction = await _context.Database.BeginTransactionAsync();
        try
        {
            // Deduct the transaction amount from the delivery user's balance
            deliveryUser.Balance -= transaction.Amount; // ✅ Correct logic

            // Link the transaction to the delivery user
            deliveryUser.DeliveryMoneyTransactionId = transaction.Id;
            transaction.TransactionDate = DateTime.UtcNow;

            // If transferring to a store, link the store user here
            // transaction.UserStoreId = "store_user_id_here";

            await _userManager.UpdateAsync(deliveryUser);
            await _context.MoneyTransactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            await dbTransaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await dbTransaction.RollbackAsync();
            throw; // Add logging here
        }
    }

    public async Task HandelStoreTransaction(MoneyTransaction transaction)
    {
        if (transaction == null)
            throw new ArgumentNullException(nameof(transaction));

        if (string.IsNullOrEmpty(transaction.UserStoreId))
            throw new ArgumentException("Store user ID is required.", nameof(transaction.UserStoreId));

        var storeUser = await _userManager.FindByIdAsync(transaction.UserStoreId);

        if (storeUser == null)
            throw new InvalidOperationException("Store user not found.");

        if (storeUser.TypeOfUser != UserType.Store)
            throw new InvalidOperationException("Specified user is not a Store user.");

        if (storeUser.Balance < transaction.Amount) // Ensure sufficient balance
            throw new InvalidOperationException("Insufficient balance for the transaction.");

        if (transaction.Id == Guid.Empty)
            transaction.Id = Guid.NewGuid();

        using var dbTransaction = await _context.Database.BeginTransactionAsync();
        try
        {
            // Deduct the transaction amount from the delivery user's balance
            storeUser.Balance += transaction.Amount; // ✅ Correct logic

            // Link the transaction to the delivery user
            storeUser.StoreMoneyTransactionId = transaction.Id;
            transaction.TransactionDate = DateTime.UtcNow;

            // If transferring to a store, link the store user here
            // transaction.UserStoreId = "store_user_id_here";

            await _userManager.UpdateAsync(storeUser);
            await _context.MoneyTransactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            await dbTransaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await dbTransaction.RollbackAsync();
            throw; // Add logging here
        }
    }


}















