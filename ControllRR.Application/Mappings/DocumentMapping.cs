using AutoMapper;
using ControllRR.Application.DTOs;
using ControllRR.Domain.Entities;

public class DocumentMappingProfile : Profile
{
    public DocumentMappingProfile()
    {
        // Mapeamento de Document para DocumentDto
        CreateMap<Document, DocumentDto>()

            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.DocumentName, opt => opt.MapFrom(src => src.DocumentName))
            .ForMember(dest => dest.UploadedAt, opt => opt.MapFrom(src => src.UploadedAt))
            .ReverseMap();
    }
}