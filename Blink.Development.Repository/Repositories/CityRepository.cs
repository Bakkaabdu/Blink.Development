using Blink.Development.Entities.Entities;
using Blink.Development.Repository.Data;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Blink.Development.Repository.Repositories;

public class CityRepository : GenericRepository<City>, ICityRepository
{
    public CityRepository(ILogger logger, AppDbContext context) : base(logger, context) { }

    public override async Task<IEnumerable<City>> GetAll()
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
            _logger.LogError(ex, $"Get All Function Erorr", typeof(CityRepository));
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
            _logger.LogError(ex, $"Delete Function Erorr", typeof(CityRepository));
            throw;
        }
    }

    public override async Task<bool> Update(City city)
    {
        try
        {
            var cityToUpdate = await _dbSet
                .FirstOrDefaultAsync(x => x.Id == city.Id);
            if (cityToUpdate == null)
                return false;

            cityToUpdate.Name = city.Name ?? cityToUpdate.Name;


            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating city");
            throw;
        }
    }


}

