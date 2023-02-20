using AutoMapper;
using EventBus.Events;
using Shipping.CQRS.Commands.OrderShipment;
using Shipping.CQRS.Commands.UpdateShipment;
using Shipping.CQRS.Queries.GetShipmentList;
using Shipping.Entities;

namespace Shipping.Mapper
{
    public class ShippingProfile : Profile
    {
        public ShippingProfile()
        {
            CreateMap<Shipment, Shipment>().ReverseMap();
            CreateMap<Entities.Shipment, ShipmentInsert>().ReverseMap();
            CreateMap<Entities.Shipment, OrderShipmentCommand>()
            //    .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
            //    .ForMember(dest => dest.TrackingNumber, opt => opt.MapFrom(src => src.TrackingNumber))
            //    .ForMember(dest => dest.TrackingUrl, opt => opt.MapFrom(src => src.TrackingUrl))
            //    .ForMember(dest => dest.DeliveryDateUtc, opt => opt.MapFrom(src => src.DeliveryDateUtc))
            //    .ForMember(dest => dest.ShippedDateUtc, opt => opt.MapFrom(src => src.ShippedDateUtc))
            //    .ForMember(dest => dest.CreatedOnUtc, opt => opt.MapFrom(src => src.CreatedOnUtc))
                .ReverseMap();
            CreateMap<Entities.Shipment, UpdateShipmentCommand>()
                .ReverseMap();

            CreateMap<OrderShipmentCommand, OrderShipmentEvent>().ReverseMap();
        }
    }
}
