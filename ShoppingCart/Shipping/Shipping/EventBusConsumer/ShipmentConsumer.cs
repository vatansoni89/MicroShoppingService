using AutoMapper;
using EventBus.Events;
using MassTransit;
using MediatR;
using Shipping.Features.Shipments.Commands.OrderShipment;

namespace Shipping.EventBusConsumer
{
    public class ShipmentConsumer : IConsumer<OrderShipmentEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<ShipmentConsumer> _logger;

        public ShipmentConsumer(IMediator mediator, IMapper mapper, ILogger<ShipmentConsumer> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<OrderShipmentEvent> context)
        {
            var command = _mapper.Map<OrderShipmentCommand>(context.Message);            
            var result = await _mediator.Send(command);

            _logger.LogInformation("OrderShipmentEvent consumed successfully. Created Order Id : {newOrderId}", result);
        }
    }
}
