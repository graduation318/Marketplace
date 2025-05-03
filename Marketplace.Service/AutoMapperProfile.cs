using AutoMapper;
using Marketplace.Data;
using Marketplace.Data.Models;
using Marketplace.Service.ModelsRequest;

namespace Marketplace.Service;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserRequest, User>().ReverseMap();
        CreateMap<ProductRequest, Product>().ReverseMap();
        CreateMap<CategoryRequest, Category>().ReverseMap();
        CreateMap<CharacteristicRequest, Characteristic>().ReverseMap();
        CreateMap<OrderRequest, Order>().ReverseMap();
        CreateMap<PaymentRequest, Payment>().ReverseMap();
        CreateMap<ShipmentRequest, Shipment>().ReverseMap();
        CreateMap<ProductCharacteristicRequest, ProductCharacteristic>().ReverseMap();
    }
}