using AutoMapper;
using EventBus.Events.Shipment;
using MassTransit;
using MassTransit.Transports;
using MediatR;
using Shipping.Entities;
using Shipping.Exceptions;
using Shipping.Repositories;
using Shipping.Repositories.Interfaces;

namespace Shipping.CQRS.Commands.UpdateShipment
{
    public class UpdateShipmentCommandHandler : IRequestHandler<UpdateShipmentCommand, int>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IShipmentReadRepository _shipmentReadRepository;
        private readonly IShipmentWriteRepository _shipmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateShipmentCommandHandler> _logger;

        public UpdateShipmentCommandHandler(IPublishEndpoint publishEndpoint, IShipmentReadRepository shipmentReadRepository, IShipmentWriteRepository shipmentRepository, IMapper mapper, ILogger<UpdateShipmentCommandHandler> logger)
        {
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _shipmentReadRepository = shipmentReadRepository ?? throw new ArgumentNullException(nameof(shipmentReadRepository));
            _shipmentRepository = shipmentRepository ?? throw new ArgumentNullException(nameof(shipmentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(UpdateShipmentCommand request, CancellationToken cancellationToken)
        {
            var shipmentToUpdate = await _shipmentReadRepository.GetShipment(request.Id);
            if (shipmentToUpdate == null)
            {
                throw new NotFoundException(nameof(Shipment), request.Id);
            }
            shipmentToUpdate.LastModifiedOnUtc = DateTime.UtcNow;
            _mapper.Map(request, shipmentToUpdate, typeof(UpdateShipmentCommand), typeof(Shipment));

            await _shipmentRepository.UpdateAsync(shipmentToUpdate);
            _logger.LogInformation($"Shipment {shipmentToUpdate.Id} is successfully updated.");
            var eventMessage = _mapper.Map<UpdatedShipmentEvent>(shipmentToUpdate);
            await _publishEndpoint.Publish(eventMessage, cancellationToken);
            return shipmentToUpdate.Id;
        }
    }
}
