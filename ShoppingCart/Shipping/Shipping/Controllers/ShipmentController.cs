using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shipping.CQRS.Commands.DeleteShipment;
using Shipping.CQRS.Commands.OrderShipment;
using Shipping.CQRS.Commands.UpdateShipment;
using Shipping.CQRS.Queries.GetShipment;
using Shipping.CQRS.Queries.GetShipmentList;
using Shipping.Entities;
using System.Net;

namespace Shipping.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ShipmentController> _logger;

        public ShipmentController(IMediator mediator, ILogger<ShipmentController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(_mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Shipment>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Shipment>>> GetShipments()
        {
            var query = new GetShipmentListQuery();
            var shipments = await _mediator.Send(query);
            return Ok(shipments);
        }

        [HttpGet("{id}", Name = "GetShipment")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Shipment), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Shipment>> GetShipmentById(string id)
        {
            var query = new GetShipmentQuery(id);
            var shipment = await _mediator.Send(query);
            if (shipment == null)
            {
                _logger.LogError($"Shipment with id: {id}, not found.");
                return NotFound();
            }

            return Ok(shipment);
        }

        [Route("[action]/{orderId}", Name = "GetShipmentByOrderId")]
        [HttpGet]
        [ProducesResponseType(typeof(Shipment), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Shipment>> GetShipmentByOrderId(string orderId)
        {
            var query = new GetShipmentListQuery(orderId);
            var shipments = await _mediator.Send(query);
            return Ok(shipments);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Shipment), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Shipment>> CreateShipment([FromBody] OrderShipmentCommand shipment)
        {
            var result = await _mediator.Send(shipment);
            return CreatedAtRoute("GetShipment", new { id = result }, shipment);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Shipment), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateShipment([FromBody] UpdateShipmentCommand shipment)
        {
            var result = await _mediator.Send(shipment);
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteShipment")]
        [ProducesResponseType(typeof(Shipment), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteShipmentById(string id)
        {
            var command = new DeleteShipmentCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
