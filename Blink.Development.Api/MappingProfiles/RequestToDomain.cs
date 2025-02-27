using AutoMapper;
using Blink.Development.Entities.Dtos.Request.Branch;
using Blink.Development.Entities.Entities;

namespace Blink.Development.Api.MappingProfiles;

public class RequestToDomain : Profile
{
    public RequestToDomain()
    {
        // Branch Create
        CreateMap<CreateBranchRequestDto, Branch>()
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name));
        // Branch Update
        CreateMap<UpdateBranchRequestDto, Branch>()
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name));



    }
}
