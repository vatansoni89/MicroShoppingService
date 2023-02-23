using AutoMapper;
using MediatR;
using Shipping.Entities;
using Shipping.Repositories.Interfaces;
using System.Collections.Generic;

namespace Shipping.CQRS.Queries.GetShipmentList
{
    public class GetShipmentListQueryHandler : IRequestHandler<GetShipmentListQuery, List<Shipment>>
    {
        private readonly IShipmentReadRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public GetShipmentListQueryHandler(IShipmentReadRepository shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository ?? throw new ArgumentNullException(nameof(shipmentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<Shipment>> Handle(GetShipmentListQuery request, CancellationToken cancellationToken)
        {
            List<Shipment> shipmentList;
            if (!string.IsNullOrEmpty(request.OrderId))
                shipmentList = await _shipmentRepository.GetShipmentsByOrderId(request.OrderId);
            else
                shipmentList = await _shipmentRepository.GetShipments();
            return _mapper.Map<List<Shipment>>(shipmentList);
        }
    }
}
