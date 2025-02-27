using AutoMapper;
using Blink.Development.Entities.Dtos.Request.Branch;
using Blink.Development.Entities.Dtos.Request.City;
using Blink.Development.Entities.Dtos.Request.Customer;
using Blink.Development.Entities.Dtos.Request.Order;
using Blink.Development.Entities.Entities;

namespace Blink.Development.Api.MappingProfiles;

public class RequestToDomain : Profile
{
    public RequestToDomain()
    {
        #region Branch
        // Branch Create
        CreateMap<CreateBranchRequestDto, Branch>()
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name));
        // Branch Update
        CreateMap<UpdateBranchRequestDto, Branch>()
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name));
        #endregion

        #region Order
        // Order Create Mapping
        CreateMap<CreateOrderRequestDto, Order>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.IsPaid, opt => opt.MapFrom(src => src.IsPaid))
            .ForMember(dest => dest.CanOpen, opt => opt.MapFrom(src => src.CanOpen))
            .ForMember(dest => dest.Packaging, opt => opt.MapFrom(src => src.Packaging))
            .ForMember(dest => dest.CanTry, opt => opt.MapFrom(src => src.CanTry))
            .ForMember(dest => dest.CanPay50, opt => opt.MapFrom(src => src.CanPay50))
            .ForMember(dest => dest.bigShipmentsPrice, opt => opt.MapFrom(src => src.BigShipmentsPrice))
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
            .ForMember(dest => dest.StreetId, opt => opt.MapFrom(src => src.StreetId))
            .ForMember(dest => dest.BranchId, opt => opt.MapFrom(src => src.BranchId))
            .ForMember(dest => dest.TrashId, opt => opt.MapFrom(src => src.TrashId))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.UserStoreId, opt => opt.MapFrom(src => src.UserStoreId))
            .ForMember(dest => dest.DeliveryUserId, opt => opt.MapFrom(src => src.DeliveryUserId))
            // Ignore navigation properties that shouldn't be set from DTO
            .ForMember(dest => dest.Customer, opt => opt.Ignore())
            .ForMember(dest => dest.City, opt => opt.Ignore())
            .ForMember(dest => dest.Street, opt => opt.Ignore())
            .ForMember(dest => dest.Branch, opt => opt.Ignore())
            .ForMember(dest => dest.Trash, opt => opt.Ignore())
            .ForMember(dest => dest.UserStore, opt => opt.Ignore())
            .ForMember(dest => dest.DeliveryUser, opt => opt.Ignore());

        // update
        CreateMap<UpdateOrderRequestDto, Order>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
           .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
           .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note))
           .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
           .ForMember(dest => dest.IsPaid, opt => opt.MapFrom(src => src.IsPaid))
           .ForMember(dest => dest.CanOpen, opt => opt.MapFrom(src => src.CanOpen))
           .ForMember(dest => dest.Packaging, opt => opt.MapFrom(src => src.Packaging))
           .ForMember(dest => dest.CanTry, opt => opt.MapFrom(src => src.CanTry))
           .ForMember(dest => dest.CanPay50, opt => opt.MapFrom(src => src.CanPay50))
           .ForMember(dest => dest.bigShipmentsPrice, opt => opt.MapFrom(src => src.BigShipmentsPrice))
           .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
           .ForMember(dest => dest.StreetId, opt => opt.MapFrom(src => src.StreetId))
           .ForMember(dest => dest.BranchId, opt => opt.MapFrom(src => src.BranchId))
           .ForMember(dest => dest.TrashId, opt => opt.MapFrom(src => src.TrashId))
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

        #endregion

        #region City
        CreateMap<CreateCityRequestDto, City>()
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name));
        CreateMap<UpdateCityRequestDto, City>()
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name));
        #endregion

        #region Customer 
        // Branch Create
        CreateMap<CreateCustomerRequestDto, Customer>()
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Phone,
            opt => opt.MapFrom(src => src.Phone))
            .ForMember(dest => dest.Phone2,
            opt => opt.MapFrom(src => src.Phone2));
        // Branch Update
        CreateMap<UpdateCustomerRequestDto, Customer>()
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Phone,
            opt => opt.MapFrom(src => src.Phone))
            .ForMember(dest => dest.Phone2,
            opt => opt.MapFrom(src => src.Phone2));
        #endregion
    }
}
