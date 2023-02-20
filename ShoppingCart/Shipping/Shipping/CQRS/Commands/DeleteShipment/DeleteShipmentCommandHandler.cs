using AutoMapper;
using MediatR;
using Shipping.Entities;
using Shipping.Exceptions;
using Shipping.Repositories.Interfaces;

namespace Shipping.CQRS.Commands.DeleteShipment
{
    public class DeleteShipmentCommandHandler : IRequestHandler<DeleteShipmentCommand, string>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteShipmentCommandHandler> _logger;

        public DeleteShipmentCommandHandler(IShipmentRepository shipmentRepository, IMapper mapper, ILogger<DeleteShipmentCommandHandler> logger)
        {
            _shipmentRepository = shipmentRepository ?? throw new ArgumentNullException(nameof(shipmentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> Handle(DeleteShipmentCommand request, CancellationToken cancellationToken)
        {
            var shipmentToDelete = await _shipmentRepository.GetShipment(request.Id);
            if (shipmentToDelete == null)
            {
                throw new NotFoundException(nameof(Shipment), request.Id);
            }

            await _shipmentRepository.DeleteShipment(request.Id);

            _logger.LogInformation($"Shipment {shipmentToDelete.Id} is successfully deleted.");

            return request.Id;
        }
    }
}
