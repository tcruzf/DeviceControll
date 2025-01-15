using AutoMapper;
using ControllRR.Application.DTOs;
using ControllRR.Domain.Entities;

public class SectorMappingProfile : Profile
{
    public SectorMappingProfile()
    {
        CreateMap<Sector, SectorDto>().ReverseMap();
    }
}