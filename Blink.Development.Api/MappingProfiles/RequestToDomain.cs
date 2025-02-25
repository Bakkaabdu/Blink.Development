using AutoMapper;
using Blink.Development.Entities.Dtos.Request.Branch;
using Blink.Development.Entities.Dtos.Request.Delivery;
using Blink.Development.Entities.Dtos.Request.Strore;
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

        // Store
        CreateMap<CreateStoreRequestDto, Store>()
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address,
            opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.PhoneNumber,
            opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.BranchId,
            opt => opt.MapFrom(src => src.BranchId));

        // Delievry
        CreateMap<CreateDeliveryRequestDto, Delivery>()
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address,
            opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Photo,
            opt => opt.MapFrom(src => src.Photo))
            .ForMember(dest => dest.Description,
            opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.IsActive,
            opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.PhoneNumber,
            opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.BranchId,
            opt => opt.MapFrom(src => src.BranchId))
            .ForMember(dest => dest.Balance,
            opt => opt.MapFrom(src => src.Balance));
    }
}
