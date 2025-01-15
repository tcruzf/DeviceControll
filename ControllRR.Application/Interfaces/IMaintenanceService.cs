using ControllRR.Application.DTOs;

namespace ControllRR.Application.Interfaces;

public interface IMaintenanceService
{
    Task<MaintenanceDto> GetByIdAsync(int id);
    Task<IEnumerable<MaintenanceDto>> GetAllAsync();
    Task AddAsync(MaintenanceDto maintenance);
    Task UpdateAsync(MaintenanceDto maintenanceDto);
    Task DeleteAsync(int id);

}