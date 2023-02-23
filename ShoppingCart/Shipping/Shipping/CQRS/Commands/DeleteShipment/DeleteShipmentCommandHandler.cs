using AutoMapper;
using EventBus.Events.Shipment;
using MassTransit;
using MediatR;
using Shipping.Entities;
using Shipping.Exceptions;
using Shipping.Repositories.Interfaces;

namespace Shipping.CQRS.Commands.DeleteShipment
{
    public class DeleteShipmentCommandHandler : IRequestHandler<DeleteShipmentCommand, int>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IShipmentReadRepository _shipmentReadRepository;
        private readonly IShipmentWriteRepository _shipmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteShipmentCommandHandler> _logger;

        public DeleteShipmentCommandHandler(IPublishEndpoint publishEndpoint, IShipmentReadRepository shipmentReadRepository, IShipmentWriteRepository shipmentRepository, IMapper mapper, ILogger<DeleteShipmentCommandHandler> logger)
        {
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _shipmentReadRepository = shipmentReadRepository ?? throw new ArgumentNullException(nameof(shipmentReadRepository));
            _shipmentRepository = shipmentRepository ?? throw new ArgumentNullException(nameof(shipmentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(DeleteShipmentCommand request, CancellationToken cancellationToken)
        {
            var shipmentToDelete = await _shipmentReadRepository.GetShipment(request.Id);
            if (shipmentToDelete == null)
            {
                throw new NotFoundException(nameof(Shipment), request.Id);
            }

            await _shipmentRepository.DeleteAsync(shipmentToDelete);

            _logger.LogInformation($"Shipment {shipmentToDelete.Id} is successfully deleted.");
            var eventMessage = _mapper.Map<DeletedShipmentEvent>(request);
            await _publishEndpoint.Publish(eventMessage, cancellationToken);
            return request.Id;
        }
    }
}
