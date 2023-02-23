using AutoMapper;
using EventBus.Events.Shipment;
using MassTransit;
using MediatR;
using Shipping.CQRS.Commands.OrderShipment;
using Shipping.CQRS.Queries.EventHandlers.Updated;

namespace Shipping.EventBusConsumer
{
    public class UpdatedShipmentConsumer : IConsumer<UpdatedShipmentEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatedShipmentConsumer> _logger;

        public UpdatedShipmentConsumer(IMediator mediator, IMapper mapper, ILogger<UpdatedShipmentConsumer> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<UpdatedShipmentEvent> context)
        {
            var command = _mapper.Map<UpdatedShipment>(context.Message);
            await _mediator.Send(command);

            _logger.LogInformation("UpdatedShipmentEvent consumed successfully");
        }
    }
}
