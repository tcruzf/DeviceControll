using AutoMapper;
using ControllRR.Application.DTOs;
using ControllRR.Domain.Entities;

public class MaintenanceMappingProfile : Profile
{
    public MaintenanceMappingProfile()
    {
        // Mapeamento de Maintenance para MaintenanceDto
        CreateMap<Maintenance, MaintenanceDto>()

            .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.Name)) // Mapear o nome do usuário
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.Device.Type)) // Mapear o nome do dispositivo
            .ForMember(dest => dest.SectorName, opt => opt.MapFrom(src => src.Device.Sector.Name)) // Mapear o nome do setor
            .ReverseMap(); // Permitir mapeamento reverso

        // Caso precise de mapeamento para DTOs adicionais, adicione aqui
    }
}