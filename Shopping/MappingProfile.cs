using Shopping.BL;
using Shopping.Data.Entities;
using Shopping.ViewModels;
using Shopping.Views.Entities;
using System.Collections.Generic;

namespace Shopping
{
    internal class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductPL, ProductBL>().ReverseMap();
            CreateMap<OrderPL, OrderBL>().ReverseMap();
            CreateMap<OrderItemPL, OrderItemBL>().ReverseMap();
            CreateMap<CustomerPL, CustomerBL>().ReverseMap();
            CreateMap<OrderItemDL, OrderItemBL>().ReverseMap();
            CreateMap<OrderDL, OrderBL>().ReverseMap();
            CreateMap<ProductDL, ProductBL>().ReverseMap();
            CreateMap<CustomerDL, CustomerBL>().ReverseMap();
            CreateMap<OrdersViewModel, OrderBL>().ReverseMap();
            CreateMap<OrderViewModel, OrderBL>().ReverseMap();
            CreateMap<OrdersViewModel, OrderDL>().ReverseMap();
            CreateMap<OrderItemsViewModel, OrderItemBL>().ReverseMap();
        }
    }
}