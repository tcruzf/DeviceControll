using ControllRR.Application.DTOs;

namespace ControllRR.Application.Interfaces;

public interface ISectorService
{
    Task<SectorDto> GetByIdAsync(int id);
    Task<IEnumerable<SectorDto>> GetAllAsync();
    Task AddAsync (SectorDto sector);
    Task UpdateAsync(SectorDto sector);
    Task DeleteAsync (int id);
}