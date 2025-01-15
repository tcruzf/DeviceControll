using ControllRR.Application.DTOs;

namespace ControllRR.Application.Interfaces;

public interface IDeviceService
{
    Task<DeviceDto> GetByIdAsync(int id);
    Task<IEnumerable<DeviceDto>> GetAllAsync();
    Task AddAsync(DeviceDto device);
    Task DeleteAsync(int id);
    Task UpdateAsync(DeviceDto device);

}