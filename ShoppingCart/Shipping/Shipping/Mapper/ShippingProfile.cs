using AutoMapper;
using EventBus.Events;
using Shipping.Entities;
using Shipping.Features.Shipments.Commands.OrderShipment;
using Shipping.Features.Shipments.Commands.UpdateShipment;
using Shipping.Features.Shipments.Queries.GetShipmentList;

namespace Shipping.Mapper
{
    public class ShippingProfile : Profile
    {
        public ShippingProfile()
        {
            CreateMap<Shipment, ShipmentsVM>().ReverseMap();
            CreateMap<Shipment, ShipmentInsert>().ReverseMap();
            CreateMap<Shipment, OrderShipmentCommand>()
            //    .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
            //    .ForMember(dest => dest.TrackingNumber, opt => opt.MapFrom(src => src.TrackingNumber))
            //    .ForMember(dest => dest.TrackingUrl, opt => opt.MapFrom(src => src.TrackingUrl))
            //    .ForMember(dest => dest.DeliveryDateUtc, opt => opt.MapFrom(src => src.DeliveryDateUtc))
            //    .ForMember(dest => dest.ShippedDateUtc, opt => opt.MapFrom(src => src.ShippedDateUtc))
            //    .ForMember(dest => dest.CreatedOnUtc, opt => opt.MapFrom(src => src.CreatedOnUtc))
                .ReverseMap();
            CreateMap<Shipment, UpdateShipmentCommand>()
                .ReverseMap();

            CreateMap<OrderShipmentCommand, OrderShipmentEvent>().ReverseMap();
        }
    }
}
