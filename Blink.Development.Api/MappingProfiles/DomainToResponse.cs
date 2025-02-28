using AutoMapper;
using Blink.Development.Entities;
using Blink.Development.Entities.Dtos.Response.Branch;
using Blink.Development.Entities.Dtos.Response.City;
using Blink.Development.Entities.Dtos.Response.Customer;
using Blink.Development.Entities.Dtos.Response.Inventory;
using Blink.Development.Entities.Dtos.Response.Mission;
using Blink.Development.Entities.Dtos.Response.Street;
using Blink.Development.Entities.Dtos.Response.Trash;
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

        #region Inventory
        CreateMap<Inventory, CreateInventoryResponseDto>()
            .ForMember(dest => dest.UserStoreId,
            opt => opt.MapFrom(src => src.UserStoreId))
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ProductName,
            opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.Quantity,
            opt => opt.MapFrom(src => src.Quantity));
        #endregion

        #region Mission
        CreateMap<Mission, CreateMissionResponseDto>()
            .ForMember(dest => dest.Id,
            opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserStoreId,
            opt => opt.MapFrom(src => src.UserStoreId))
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.IsTrashed,
            opt => opt.MapFrom(src => src.IsTrashed))
            .ForMember(dest => dest.TakeItBy,
            opt => opt.MapFrom(src => src.TakeItBy))
            .ForMember(dest => dest.AmountRequested,
            opt => opt.MapFrom(src => src.AmountRequested))
            .ForMember(dest => dest.IsCompleted,
            opt => opt.MapFrom(src => src.IsCompleted));
        #endregion

        #region Street
        CreateMap<Street, CreateStreetResponseDto>()
            .ForMember(dest => dest.Id,
            opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.CityId,
            opt => opt.MapFrom(src => src.CityId))
            .ForMember(dest => dest.DeliveryPrice,
            opt => opt.MapFrom(src => src.DeliveryPrice))
            .ForMember(dest => dest.BlinkProfit,
            opt => opt.MapFrom(src => src.BlinkProfit));
        #endregion

        #region Trash
        CreateMap<Trash, CreateTrashResponseDto>()
            .ForMember(dest => dest.Id,
            opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.OrderId,
            opt => opt.MapFrom(src => src.OrderId));
        #endregion
    }
}
