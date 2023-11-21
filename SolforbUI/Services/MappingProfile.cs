using AutoMapper;
using BuisnessLogicLayer.DTO;
using DAL.Entities;
using SolforbUI.Models;

namespace SolforbUI.Services
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<Provider, ProviderDTO>();

            CreateMap<ProviderDTO, ProviderViewModel>();
            CreateMap<OrderDTO, OrderViewModel>();
            CreateMap<OrderItemDTO, OrderItemViewModel>();

            CreateMap<OrderViewModel, OrderDTO>();
            CreateMap<ProviderViewModel, ProviderDTO>();
            CreateMap<OrderItemViewModel, OrderItemDTO>();

            CreateMap<OrderItemDTO, OrderItem>();
            CreateMap<OrderDTO, Order>();
            CreateMap<ProviderDTO, Provider>();

            CreateMap<UniqueElementsDTO, UniqueElementsViewModel>();
            CreateMap<UniqueElementsViewModel, UniqueElementsDTO>();
            CreateMap<DataToFilterViewModel, DataToFilterDTO>();
        }
    }
}
