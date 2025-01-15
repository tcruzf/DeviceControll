using ControllRR.Domain.Entities;
using ControllRR.Domain.Interfaces;
using ControllRR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControllRR.Infrastructure.Repositories;

public class MaintenanceRepository : IMaintenanceRepository
{
    private readonly ControllRRContext _controllRRContext;

    public MaintenanceRepository(ControllRRContext controllRRContext)
    {
        _controllRRContext = controllRRContext;
    }

    public async Task<IEnumerable<Maintenance>> GetAllAsync()
    {
        return await _controllRRContext.Maintenances
        .Include(x => x.User)
        .ToListAsync();
    }

    public async Task<Maintenance?> GetByIdAsync(int id)
    {
      return  await _controllRRContext.Maintenances
      .Include(x => x.User)
      .Include(x => x.Device)
      .Include(x => x.Device.Sector)
      .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task AddAsync(Maintenance maintenance)
    {
        await _controllRRContext.Maintenances.AddAsync(maintenance);
        await _controllRRContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Maintenance maintenance)
    {
        _controllRRContext.Maintenances.Update(maintenance);
        await _controllRRContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var maintenance = await GetByIdAsync(id);
        _controllRRContext.Maintenances.Remove(maintenance);
        await _controllRRContext.SaveChangesAsync();

    }




}