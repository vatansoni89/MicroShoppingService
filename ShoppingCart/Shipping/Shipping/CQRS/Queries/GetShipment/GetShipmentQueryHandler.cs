using AutoMapper;
using MediatR;
using Shipping.CQRS.Queries.GetShipmentList;
using Shipping.Entities;
using Shipping.Repositories.Interfaces;

namespace Shipping.CQRS.Queries.GetShipment
{
    public class GetShipmentQueryHandler : IRequestHandler<GetShipmentQuery, Shipment>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public GetShipmentQueryHandler(IShipmentRepository shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository ?? throw new ArgumentNullException(nameof(shipmentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Shipment> Handle(GetShipmentQuery request, CancellationToken cancellationToken)
        {
            var shipment = await _shipmentRepository.GetShipment(request.ShipmentId);
            return shipment;
        }
    }
}
