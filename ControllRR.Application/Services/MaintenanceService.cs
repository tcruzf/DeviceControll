using AutoMapper;
using ControllRR.Application.DTOs;
using ControllRR.Application.Interfaces;
using ControllRR.Domain.Entities;
using ControllRR.Domain.Interfaces;

namespace ControllRR.Application.Services;

public class MaintenanceService : IMaintenanceService
{
    private readonly IMaintenanceRepository _maintenanceRepository;
    private readonly IMapper _mapper;
    public MaintenanceService(IMaintenanceRepository maintenanceRepository, IMapper mapper)
    {
        _maintenanceRepository = maintenanceRepository;
        _mapper = mapper;
    }

    public async Task<MaintenanceDto> GetByIdAsync(int id)
    {
       var maintenance = await _maintenanceRepository.GetByIdAsync(id);
       return _mapper.Map<MaintenanceDto>(maintenance);
    }

       public async Task<IEnumerable<MaintenanceDto>> GetAllAsync()
    {
        var maintenances = await _maintenanceRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<MaintenanceDto>>(maintenances);

    }
    public async Task AddAsync(MaintenanceDto maintenanceDto)
    {
        var maintenance = _mapper.Map<Maintenance>(maintenanceDto);
        await _maintenanceRepository.AddAsync(maintenance);

    }

    public async Task UpdateAsync(MaintenanceDto maintenanceDto)
    {
        var maintenance = _mapper.Map<Maintenance>(maintenanceDto);
        await _maintenanceRepository.UpdateAsync(maintenance);

    }
     public async Task DeleteAsync(int id)
    {
        await _maintenanceRepository.DeleteAsync(id);
    }
 
}