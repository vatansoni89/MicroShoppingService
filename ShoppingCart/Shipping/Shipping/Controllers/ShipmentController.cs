using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shipping.Entities;
using Shipping.Features.Shipments.Commands.OrderShipment;
using Shipping.Repositories.Interfaces;
using System.Net;

namespace Shipping.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ShipmentController> _logger;

        public ShipmentController(IShipmentRepository repository, IMapper mapper, ILogger<ShipmentController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Shipment>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Shipment>>> GetShipments()
        {
            var Shipments = await _repository.GetShipments();
            return Ok(Shipments);
        }

        [HttpGet("{id}", Name = "GetShipment")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Shipment), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Shipment>> GetShipmentById(string id)
        {
            var Shipment = await _repository.GetShipment(id);

            if (Shipment == null)
            {
                _logger.LogError($"Shipment with id: {id}, not found.");
                return NotFound();
            }

            return Ok(Shipment);
        }

        [Route("[action]/{orderId}", Name = "GetShipmentByOrderId")]
        [HttpGet]
        [ProducesResponseType(typeof(Shipment), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Shipment>> GetShipmentByOrderId(string orderId)
        {
            var Shipments = await _repository.GetShipmentByOrderId(orderId);
            return Ok(Shipments);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Shipment), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Shipment>> CreateShipment([FromBody] ShipmentInsert shipment)
        {
            var shipmentEntity = _mapper.Map<Shipment>(shipment);
            shipmentEntity.Id = Guid.NewGuid().ToString();
            await _repository.CreateShipment(shipmentEntity);
            return CreatedAtRoute("GetShipment", new { id = shipmentEntity.Id }, shipmentEntity);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Shipment), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateShipment([FromBody] Shipment Shipment)
        {
            return Ok(await _repository.UpdateShipment(Shipment));
        }

        [HttpDelete("{id}", Name = "DeleteShipment")]
        [ProducesResponseType(typeof(Shipment), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteShipmentById(string id)
        {
            return Ok(await _repository.DeleteShipment(id));
        }
    }
}
