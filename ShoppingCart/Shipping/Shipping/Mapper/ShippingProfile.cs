using AutoMapper;
using EventBus.Events.Shipment;
using Shipping.CQRS.Commands.DeleteShipment;
using Shipping.CQRS.Commands.OrderShipment;
using Shipping.CQRS.Commands.UpdateShipment;
using Shipping.CQRS.Queries.EventHandlers.Created;
using Shipping.CQRS.Queries.EventHandlers.Deleted;
using Shipping.CQRS.Queries.EventHandlers.Updated;
using Shipping.Entities;

namespace Shipping.Mapper
{
    public class ShippingProfile : Profile
    {
        public ShippingProfile()
        {
            CreateMap<Shipment, CreateShipmentCommand>().ReverseMap();
            CreateMap<Shipment, UpdateShipmentCommand>().ReverseMap();
            CreateMap<CreateShipmentCommand, CreateShipmentEvent>().ReverseMap();
            CreateMap<Shipment, CreatedShipment>().ReverseMap();
            CreateMap<Shipment, UpdatedShipment>().ReverseMap();
            CreateMap<Shipment, DeletedShipment>().ReverseMap();
            CreateMap<CreatedShipment, CreatedShipmentEvent>().ReverseMap();
            CreateMap<Shipment, CreatedShipmentEvent>().ReverseMap();
            CreateMap<UpdatedShipment, UpdatedShipmentEvent>().ReverseMap();
            CreateMap<Shipment, UpdatedShipmentEvent>().ReverseMap();
            CreateMap<DeletedShipment, DeletedShipmentEvent>().ReverseMap();
            CreateMap<Shipment, DeletedShipmentEvent>().ReverseMap();
            CreateMap<DeleteShipmentCommand, DeletedShipmentEvent>().ReverseMap();
            CreateMap<UpdateShipmentCommand, UpdatedShipmentEvent>().ReverseMap();
        }
    }
}
