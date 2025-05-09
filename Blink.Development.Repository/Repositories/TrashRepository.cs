﻿using Blink.Development.Entities.Entities;
using Blink.Development.Repository.Data;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Blink.Development.Repository.Repositories;

public class TrashRepository : GenericRepository<Trash>, ITrashRepository
{
    public TrashRepository(ILogger logger, AppDbContext context) : base(logger, context) { }

    public override async Task<IEnumerable<Trash>> GetAll()
    {
        try
        {
            return await _dbSet
                .Where(x => x.IsDeleted == false)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.ReturnDate)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Get All Function Erorr", typeof(TrashRepository));
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
            _logger.LogError(ex, $"Delete Function Erorr", typeof(TrashRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Trash trash)
    {
        try
        {
            var trashToUpdate = await _dbSet
                .FirstOrDefaultAsync(x => x.Id == trash.Id);
            if (trashToUpdate == null)
                return false;

            trashToUpdate.Name = trash.Name ?? trashToUpdate.Name;


            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating store");
            throw;
        }
    }
}
