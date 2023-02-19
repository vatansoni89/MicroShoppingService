using AutoMapper;
using MassTransit.Transports;
using MediatR;
using Shipping.Entities;
using Shipping.Exceptions;
using Shipping.Repositories.Interfaces;

namespace Shipping.Features.Shipments.Commands.UpdateShipment
{
    public class UpdateShipmentCommandHandler : IRequestHandler<UpdateShipmentCommand, string>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateShipmentCommandHandler> _logger;

        public UpdateShipmentCommandHandler(IShipmentRepository shipmentRepository, IMapper mapper, ILogger<UpdateShipmentCommandHandler> logger)
        {
            _shipmentRepository = shipmentRepository ?? throw new ArgumentNullException(nameof(shipmentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> Handle(UpdateShipmentCommand request, CancellationToken cancellationToken)
        {
            var shipmentToUpdate = await _shipmentRepository.GetShipment(request.Id);
            if (shipmentToUpdate == null)
            {
                throw new NotFoundException(nameof(Shipment), request.Id);
            }
            _mapper.Map(request, shipmentToUpdate, typeof(UpdateShipmentCommand), typeof(Shipment));

            await _shipmentRepository.UpdateShipment(shipmentToUpdate);
            _logger.LogInformation($"Shipment {shipmentToUpdate.Id} is successfully updated.");

            return shipmentToUpdate.Id;
        }
    }
}
