using Blink.Development.Entities.Entities;
using Blink.Development.Repository.Data;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Blink.Development.Repository.Repositories;

public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
{
    public InventoryRepository(ILogger logger, AppDbContext context) : base(logger, context) { }

    public override async Task<IEnumerable<Inventory>> GetAll()
    {
        try
        {
            return await _dbSet
                .Where(x => x.IsDeleted == false)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.CreatedAt)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Get All Function Erorr", typeof(InventoryRepository));
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
            _logger.LogError(ex, $"Delete Function Erorr", typeof(InventoryRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Inventory inventory)
    {
        try
        {
            var inventoryToUpdate = await _dbSet
                .FirstOrDefaultAsync(x => x.Id == inventory.Id);
            if (inventoryToUpdate == null)
                return false;

            inventoryToUpdate.Name = inventory.Name ?? inventoryToUpdate.Name;
            inventoryToUpdate.ProductName = inventory.ProductName;
            inventoryToUpdate.Quantity = inventory.Quantity;

            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating Inventory");
            throw;
        }
    }


}
