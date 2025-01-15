using AutoMapper;
using ControllRR.Application.DTOs;
using ControllRR.Application.Interfaces;
using ControllRR.Domain.Entities;
using ControllRR.Domain.Interfaces;

namespace ControllRR.Application.Services;

public class SectorService : ISectorService
{
    private readonly ISectorRepository _sectorRepository;
    private readonly IMapper _mapper;
    public SectorService(ISectorRepository sectorRepository, IMapper mapper)
    {
        _sectorRepository = sectorRepository;
        _mapper = mapper;
    }

    public async Task<SectorDto>  GetByIdAsync(int id)
    {
        var sector = await _sectorRepository.GetByIdAsync(id);
        return  _mapper.Map<SectorDto>(sector);

    }
    public async Task<IEnumerable<SectorDto>> GetAllAsync()
    {
        var sectors = await _sectorRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<SectorDto>>(sectors);
    }

    public async Task AddAsync(SectorDto sectorDto)
    {
        var sectors = _mapper.Map<Sector>(sectorDto);
        await _sectorRepository.AddAsync(sectors);
    }

    public async Task UpdateAsync(SectorDto sectorDto)
    {
        var sector = _mapper.Map<Sector>(sectorDto);
        await _sectorRepository.UpdateAsync(sector);

    }

    public async Task DeleteAsync(int id)
    {
        await _sectorRepository.DeleteAsync(id);
    }
}