using AutoMapper;
using EventBus.Events.Shipment;
using MassTransit;
using MediatR;
using Shipping.CQRS.Commands.OrderShipment;
using Shipping.CQRS.Queries.EventHandlers.Created;

namespace Shipping.EventBusConsumer
{
    public class CreatedShipmentConsumer : IConsumer<CreatedShipmentEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatedShipmentConsumer> _logger;

        public CreatedShipmentConsumer(IMediator mediator, IMapper mapper, ILogger<CreatedShipmentConsumer> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<CreatedShipmentEvent> context)
        {
            var command = _mapper.Map<CreatedShipment>(context.Message);
            await _mediator.Send(command);

            _logger.LogInformation("CreatedShipmentEvent consumed successfully");
        }
    }
}
