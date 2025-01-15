using ControllRR.Domain.Entities;

namespace ControllRR.Domain.Interfaces;

public interface IMaintenanceRepository
{
    Task<Maintenance> GetByIdAsync(int id);
    Task<IEnumerable<Maintenance>> GetAllAsync();

    Task AddAsync(Maintenance maintenance);
    Task UpdateAsync(Maintenance maintenance);
    Task DeleteAsync(int id);


}