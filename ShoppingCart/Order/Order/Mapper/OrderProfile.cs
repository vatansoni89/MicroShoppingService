using AutoMapper;
using Order.Models;
using Order.Queries.GetAllOrder;

namespace Order.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile() 
        {
            CreateMap<Models.Order, OrderQueryModel>().ReverseMap();
            CreateMap<GetOrderQueryResponse, Order.Models.Order>().ReverseMap();
        }
    }
}
