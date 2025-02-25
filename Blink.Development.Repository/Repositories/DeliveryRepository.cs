using Blink.Development.Entities.Entities;
using Blink.Development.Repository.Data;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Blink.Development.Repository.Repositories;

public class DeliveryRepository : GenericRepository<Delivery>, IDeliveryRepository
{
    public DeliveryRepository(ILogger logger, AppDbContext context) : base(logger, context) { }

    public override async Task<IEnumerable<Delivery>> GetAll()
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
            _logger.LogError(ex, $"Get All Function Erorr", typeof(DeliveryRepository));
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
            _logger.LogError(ex, $"Delete Function Erorr", typeof(DeliveryRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Delivery delivery)
    {
        try
        {
            var deliveryToUpdate = await _dbSet
                .FirstOrDefaultAsync(x => x.Id == delivery.Id);
            if (deliveryToUpdate == null)
                return false;

            deliveryToUpdate.Name = delivery.Name ?? deliveryToUpdate.Name;
            deliveryToUpdate.PhoneNumber = delivery.PhoneNumber;
            deliveryToUpdate.Address = delivery.Address;
            deliveryToUpdate.Photo = delivery.Photo ?? deliveryToUpdate.Photo;
            deliveryToUpdate.Description = delivery.Description ?? deliveryToUpdate.Description;
            deliveryToUpdate.IsActive = delivery.IsActive;
            deliveryToUpdate.IdentityCardPhoto = delivery.IdentityCardPhoto ?? deliveryToUpdate.IdentityCardPhoto;
            deliveryToUpdate.BranchId = delivery.BranchId;
            deliveryToUpdate.Balance = delivery.Balance;
            deliveryToUpdate.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating delivery");
            throw;
        }



    }
}
