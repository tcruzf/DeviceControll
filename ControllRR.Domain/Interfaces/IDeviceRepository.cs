using ControllRR.Domain.Entities;

namespace ControllRR.Domain.Interfaces;

public interface IDeviceRepository
{
    Task<Device?> GetByIdAsync(int id);
    Task<IEnumerable<Device>> GetAllAsync();
    Task AddAsync(Device device);
    Task DeleteAsync(int id);
    Task UpdateAsync(Device device);

}