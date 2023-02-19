using AutoMapper;
using MediatR;
using Shipping.Entities;
using Shipping.Repositories.Interfaces;

namespace Shipping.Features.Shipments.Commands.OrderShipment
{
    public class OrderShipmentCommandHandler : IRequestHandler<OrderShipmentCommand, string>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderShipmentCommandHandler> _logger;

        public OrderShipmentCommandHandler(IShipmentRepository shipmentRepository, IMapper mapper, ILogger<OrderShipmentCommandHandler> logger)
        {
            _shipmentRepository = shipmentRepository ?? throw new ArgumentNullException(nameof(shipmentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> Handle(OrderShipmentCommand request, CancellationToken cancellationToken)
        {
            var shipmentEntity = _mapper.Map<Shipment>(request);
            shipmentEntity.Id = Guid.NewGuid().ToString();
            await _shipmentRepository.CreateShipment(shipmentEntity);
            _logger.LogInformation($"Shipment for order {shipmentEntity.OrderId} is successfully created.");

            return shipmentEntity.Id;
        }
    }
}
