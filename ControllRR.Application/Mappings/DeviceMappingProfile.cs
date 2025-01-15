using AutoMapper;
using ControllRR.Application.DTOs;
using ControllRR.Domain.Entities;


public class DeviceMappingProfile : Profile
{
    public DeviceMappingProfile()
    {
        CreateMap<Device, DeviceDto>().ReverseMap();
    }
}