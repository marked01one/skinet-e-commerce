using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Entities.OrderAggregate;

namespace API.Helpers
{
  public class MappingProfiles : Profile
  {
    public MappingProfiles()
    {
      CreateMap<Product, ProductToReturnDto>()
        .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
        .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
        .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

      CreateMap<Core.Entities.Identity.Address, AddressDto>().ReverseMap();
      CreateMap<CustomerBasketDto, CustomerBasket>();
      CreateMap<BasketItemDto, BasketItem>();
      CreateMap<AddressDto, Core.Entities.OrderAggregate.Address>();
      CreateMap<Order, OrderToReturnDto>()
        .ForMember(
          destination => destination.DeliveryMethod, 
          options => options.MapFrom(source => source.DeliveryMethod.ShortName)
        )
        .ForMember(
          destination => destination.ShippingPrice, 
          options => options.MapFrom(source => source.DeliveryMethod.Price)
        );
      CreateMap<OrderItem, OrderItemDto>()
        .ForMember(
          destination => destination.ProductId, 
          options => options.MapFrom(source => source.ItemOrdered.Id)
        )
        .ForMember(
          destination => destination.ProductName, 
          options => options.MapFrom(source => source.ItemOrdered.ProductName)
        )
        .ForMember(
          destination => destination.PictureUrl, 
          options => options.MapFrom(source => source.ItemOrdered.PictureUrl)
        )
        .ForMember(
          destination => destination.PictureUrl, 
          options => options.MapFrom<OrderItemUrlResolver>()
        );
    }
  }
}