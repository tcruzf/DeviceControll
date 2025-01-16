using AutoMapper;
using ControllRR.Application.DTOs;
using ControllRR.Domain.Entities;

public class MaintenanceMappingProfile : Profile
{
    public MaintenanceMappingProfile()
    {
        // Mapeamento de Maintenance para MaintenanceDto
        CreateMap<Maintenance, MaintenanceDto>()

            .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.Name)) // 
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.Device.Type)) // 
            .ForMember(dest => dest.SectorName, opt => opt.MapFrom(src => src.Device.Sector.Name)) //
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)) // 
         
            .ReverseMap(); // Permitir mapeamento reverso

       
    }
}