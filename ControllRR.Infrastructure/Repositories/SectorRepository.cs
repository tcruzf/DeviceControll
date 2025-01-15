using ControllRR.Domain.Entities;
using ControllRR.Domain.Interfaces;
using ControllRR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControllRR.Infrastructure.Repositories;

public class SectorRepository : ISectorRepository
{
    private readonly ControllRRContext _controllRRContext;

    public SectorRepository(ControllRRContext controllRRContext)
    {
        _controllRRContext = controllRRContext;
    }

    public async Task<IEnumerable<Sector>> GetAllAsync()
    {
        return await _controllRRContext.Sectors.ToListAsync();
    }

    public async Task<Sector?> GetByIdAsync(int id) => await _controllRRContext.Sectors.FindAsync(id);

    public async Task AddAsync(Sector sector)
    {
        await _controllRRContext.Sectors.AddAsync(sector);
        await _controllRRContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Sector sector)
    {
        _controllRRContext.Update(sector);
        await _controllRRContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var sector = await GetByIdAsync(id);
        if (id != null)
        {
            _controllRRContext.Sectors.Remove(sector);
            await _controllRRContext.SaveChangesAsync();
        }
   }


}