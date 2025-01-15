using ControllRR.Domain.Entities;

namespace ControllRR.Domain.Interfaces;

public interface ISectorRepository
{
    Task<IEnumerable<Sector>> GetAllAsync();
    Task<Sector> GetByIdAsync(int id);
    Task AddAsync(Sector sector);
    Task UpdateAsync(Sector sector);
    Task DeleteAsync(int id);
}