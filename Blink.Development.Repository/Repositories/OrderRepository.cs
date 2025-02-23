using Blink.Development.Entities.Entities;
using Blink.Development.Repository.Data;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Blink.Development.Repository.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(ILogger logger, AppDbContext context) : base(logger, context) { }

    public override async Task<IEnumerable<Order>> GetAll()
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
            _logger.LogError(ex, $"Get All Function Erorr", typeof(OrderRepository));
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
            _logger.LogError(ex, $"Delete Function Erorr", typeof(OrderRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Order order)
    {
        try
        {
            var orderToUpdate = await _dbSet
                .FirstOrDefaultAsync(x => x.Id == order.Id);
            if (orderToUpdate == null)
                return false;

            orderToUpdate.Name = order.Name ?? orderToUpdate.Name;

            orderToUpdate.Quantity = order.Quantity;
            orderToUpdate.Price = order.Price;
            orderToUpdate.Note = order.Note ?? orderToUpdate.Note;
            orderToUpdate.Description = order.Description ?? orderToUpdate.Description;
            orderToUpdate.IsPaid = order.IsPaid;
            orderToUpdate.CanOpen = order.CanOpen;
            orderToUpdate.Packaging = order.Packaging;
            orderToUpdate.CanTry = order.CanTry;
            orderToUpdate.CanPay50 = order.CanPay50;
            orderToUpdate.bigShipmentsPrice = order.bigShipmentsPrice;

            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating order");
            throw;
        }
    }


}
