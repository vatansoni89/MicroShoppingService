using AutoMapper;
using EventBus.Events.Shipment;
using MassTransit;
using MediatR;
using Shipping.Entities;
using Shipping.Repositories.Interfaces;

namespace Shipping.CQRS.Commands.OrderShipment
{
    public class CreateShipmentCommandHandler : IRequestHandler<CreateShipmentCommand, int>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IShipmentWriteRepository _shipmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateShipmentCommandHandler> _logger;

        public CreateShipmentCommandHandler(IPublishEndpoint publishEndpoint, IShipmentWriteRepository shipmentRepository, IMapper mapper, ILogger<CreateShipmentCommandHandler> logger)
        {
            _shipmentRepository = shipmentRepository ?? throw new ArgumentNullException(nameof(shipmentRepository));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
        {
            var shipmentEntity = _mapper.Map<Shipment>(request);
            await _shipmentRepository.AddAsync(shipmentEntity);
            _logger.LogInformation($"Shipment for order {shipmentEntity.OrderId} is successfully created.");
            var eventMessage = _mapper.Map<CreatedShipmentEvent>(shipmentEntity);
            await _publishEndpoint.Publish(eventMessage, cancellationToken);
            return shipmentEntity.Id;
        }
    }
}
