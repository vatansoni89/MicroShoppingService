using AutoMapper;
using MediatR;
using Shipping.Data.Interfaces;
using Shipping.Entities;
using Shipping.Exceptions;
using Shipping.Repositories.Interfaces;

namespace Shipping.CQRS.Queries.EventHandlers.Created
{
    public class CreatedShipmentEventHandler : IRequestHandler<CreatedShipment, int>
    {
        private readonly IShippingReadContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatedShipmentEventHandler> _logger;

        public CreatedShipmentEventHandler(IShippingReadContext context, IMapper mapper, ILogger<CreatedShipmentEventHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CreatedShipment request, CancellationToken cancellationToken)
        {
            var shipment = _mapper.Map<Shipment>(request);
            await _context.Shipments.InsertOneAsync(shipment, cancellationToken: cancellationToken);
            _logger.LogInformation($"Shipment for order {shipment.OrderId} is successfully created.");
            return shipment.Id;
        }
    }
}
