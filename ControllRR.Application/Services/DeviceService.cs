using AutoMapper;
using ControllRR.Application.DTOs;
using ControllRR.Application.Interfaces;
using ControllRR.Domain.Entities;
using ControllRR.Domain.Interfaces;

namespace ControllRR.Application.Services;

public class DeviceService : IDeviceService
{
    private readonly IDeviceRepository _deviceRepository;
    private readonly IMapper _mapper;

    public DeviceService(IDeviceRepository deviceRepository, IMapper mapper)
    {
        _deviceRepository = deviceRepository;
        _mapper = mapper;    
    
    }
    public async Task<DeviceDto> GetByIdAsync(int id)
    {
       var device = await _deviceRepository.GetByIdAsync(id);
       return _mapper.Map<DeviceDto>(device);

    }

    public async Task<IEnumerable<DeviceDto>> GetAllAsync()
    {
        var devices = await _deviceRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<DeviceDto>>(devices);

    }

    public async Task AddAsync(DeviceDto deviceDto)
    {
        var device = _mapper.Map<Device>(deviceDto);
        await _deviceRepository.AddAsync(device);
    }

    public async Task UpdateAsync(DeviceDto deviceDto)
    {
        var device = _mapper.Map<Device>(deviceDto);
       await _deviceRepository.UpdateAsync(device);

    }

    public async Task DeleteAsync(int id)
    {
        await _deviceRepository.DeleteAsync(id);
        
    }



}