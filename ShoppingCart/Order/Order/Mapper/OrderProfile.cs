using AutoMapper;
using Order.Models;

namespace Order.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile() 
        {
            CreateMap<Models.Order, OrderQueryModel>().ReverseMap();
        }
    }
}
