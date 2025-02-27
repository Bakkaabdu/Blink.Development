using AutoMapper;
using Blink.Development.Entities.Dtos.Response.Branch;
using Blink.Development.Entities.Entities;

namespace Blink.Development.Api.MappingProfiles;

public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        // Branch
        CreateMap<Branch, CreateBranchResponseDto>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name));
    }
}
