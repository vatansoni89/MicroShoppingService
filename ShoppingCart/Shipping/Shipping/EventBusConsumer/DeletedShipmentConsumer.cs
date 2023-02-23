using AutoMapper;
using EventBus.Events.Shipment;
using MassTransit;
using MediatR;
using Shipping.CQRS.Commands.OrderShipment;
using Shipping.CQRS.Queries.EventHandlers.Deleted;

namespace Shipping.EventBusConsumer
{
    public class DeletedShipmentConsumer : IConsumer<DeletedShipmentEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<DeletedShipmentConsumer> _logger;

        public DeletedShipmentConsumer(IMediator mediator, IMapper mapper, ILogger<DeletedShipmentConsumer> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<DeletedShipmentEvent> context)
        {
            var command = _mapper.Map<DeletedShipment>(context.Message);
            await _mediator.Send(command);

            _logger.LogInformation("DeletedShipmentEvent consumed successfully");
        }
    }
}
