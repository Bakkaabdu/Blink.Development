using AutoMapper;
using Blink.Development.Entities.Dtos.Response.Branch;
using Blink.Development.Entities.Dtos.Response.City;
using Blink.Development.Entities.Dtos.Response.Customer;
using Blink.Development.Entities.Entities;

namespace Blink.Development.Api.MappingProfiles;

public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        #region Branch
        // Branch
        CreateMap<Branch, CreateBranchResponseDto>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name));
        #endregion

        #region City
        CreateMap<City, CreateCityResponseDto>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name));
        #endregion

        #region Customer
        CreateMap<Customer, CreateCustomerResponseDto>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Phone,
            opt => opt.MapFrom(src => src.Phone))
            .ForMember(dest => dest.Phone2,
            opt => opt.MapFrom(src => src.Phone2));
        #endregion
    }
}
