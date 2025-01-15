using ControllRR.Domain.Entities;
using ControllRR.Infrastructure.Data;
using ControllRR.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControllRR.Infrastructure.Repositories;

public class DeviceRepository : IDeviceRepository
{
    private readonly ControllRRContext _controllRRContext;
    public DeviceRepository(ControllRRContext controllRRContext)
    {
        _controllRRContext = controllRRContext;
    }

    public async Task<IEnumerable<Device>> GetAllAsync()
    {
        return await _controllRRContext.Devices.ToListAsync();
    }
    
    public async Task<Device?> GetByIdAsync(int id) => await _controllRRContext.Devices.FindAsync(id);

    public async Task AddAsync(Device device)
    {
        await _controllRRContext.Devices.AddAsync(device);
        await _controllRRContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Device device)
    {
        _controllRRContext.Update(device);
        await _controllRRContext.SaveChangesAsync();

    }

    public async Task DeleteAsync(int id)
    {
        var device = await GetByIdAsync(id);
        if( device != null)
        {
            _controllRRContext.Devices.Remove(device);
            await _controllRRContext.SaveChangesAsync();
            
        }
    }
}