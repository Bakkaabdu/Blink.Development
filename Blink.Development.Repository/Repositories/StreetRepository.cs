using Blink.Development.Entities.Entities;
using Blink.Development.Repository.Data;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Blink.Development.Repository.Repositories;

public class StreetRepository : GenericRepository<Street>, IStreetRepository
{
    public StreetRepository(ILogger logger, AppDbContext context) : base(logger, context) { }

    public override async Task<IEnumerable<Street>> GetAll()
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
            _logger.LogError(ex, $"Get All Function Erorr", typeof(StreetRepository));
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
            _logger.LogError(ex, $"Delete Function Erorr", typeof(StreetRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Street street)
    {
        try
        {
            var streetToUpdate = await _dbSet
                .FirstOrDefaultAsync(x => x.Id == street.Id);
            if (streetToUpdate == null)
                return false;

            streetToUpdate.Name = street.Name ?? streetToUpdate.Name;


            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating street");
            throw;
        }
    }


}
