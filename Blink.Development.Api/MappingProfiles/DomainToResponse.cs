using AutoMapper;
using Blink.Development.Entities.Dtos.Response.Branch;
using Blink.Development.Entities.Dtos.Response.Delivery;
using Blink.Development.Entities.Dtos.Response.Store;
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

        // Store 
        CreateMap<Store, CreateStoreResponseDto>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.PhoneNumber,
                opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.BranchId,
                opt => opt.MapFrom(src => src.BranchId));

        // delivery
        CreateMap<Delivery, CreateDeliveryResponseDto>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.PhoneNumber,
                opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.BranchId,
                opt => opt.MapFrom(src => src.BranchId));
    }
}
