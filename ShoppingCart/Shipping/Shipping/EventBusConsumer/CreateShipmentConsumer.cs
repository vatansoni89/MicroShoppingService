using AutoMapper;
using EventBus.Events.Shipment;
using MassTransit;
using MediatR;
using Shipping.CQRS.Commands.OrderShipment;

namespace Shipping.EventBusConsumer
{
    public class CreateShipmentConsumer : IConsumer<CreateShipmentEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateShipmentConsumer> _logger;

        public CreateShipmentConsumer(IMediator mediator, IMapper mapper, ILogger<CreateShipmentConsumer> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<CreateShipmentEvent> context)
        {
            var command = _mapper.Map<CreateShipmentCommand>(context.Message);            
            var result = await _mediator.Send(command);

            _logger.LogInformation("CreateShipmentEvent consumed successfully. Created Order Id : {newOrderId}", result);
        }
    }
}
