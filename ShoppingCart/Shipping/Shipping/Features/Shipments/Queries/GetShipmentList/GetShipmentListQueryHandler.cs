using AutoMapper;
using MediatR;
using Shipping.Entities;
using Shipping.Repositories.Interfaces;

namespace Shipping.Features.Shipments.Queries.GetShipmentList
{
    public class GetShipmentListQueryHandler : IRequestHandler<GetShipmentListQuery, List<ShipmentsVM>>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public GetShipmentListQueryHandler(IShipmentRepository shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository ?? throw new ArgumentNullException(nameof(shipmentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<ShipmentsVM>> Handle(GetShipmentListQuery request, CancellationToken cancellationToken)
        {
            var shipmentList = await _shipmentRepository.GetShipmentByOrderId(request.OrderId);
            return _mapper.Map<List<ShipmentsVM>>(shipmentList);
        }
    }
}
