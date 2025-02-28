using Blink.Development.Entities;
using Blink.Development.Repository.Data;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Blink.Development.Repository.Repositories;

public class MissionRepository : GenericRepository<Mission>, IMissionRepository
{
    public MissionRepository(ILogger logger, AppDbContext context) : base(logger, context) { }

    public override async Task<IEnumerable<Mission>> GetAll()
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
            _logger.LogError(ex, $"Get All Function Erorr", typeof(MissionRepository));
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
            _logger.LogError(ex, $"Delete Function Erorr", typeof(MissionRepository));
            throw;
        }
    }



}
