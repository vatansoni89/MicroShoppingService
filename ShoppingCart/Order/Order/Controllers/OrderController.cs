using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Order.Commands.AddOrder;
using Order.Commands.ConfirmOrder;
using Order.Commands.DeleteOrder;
using Order.Commands.UpdateOrder;
using Order.Models;
using Order.Queries.GetAllOrder;
using Order.Queries.GetOrderById;

namespace Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(AddOrderCommand orderCommand)
        {
            try
            {
                var order = await _mediator.Send(orderCommand);
                return StatusCode(StatusCodes.Status200OK, order);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand updateOrderCommand)
        {
            try
            {
                var isUpdated = await _mediator.Send(updateOrderCommand);
                if (isUpdated)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                return StatusCode(StatusCodes.Status304NotModified);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(DeleteOrderCommand deleteOrderCommand)
        {
            try
            {
                var isDeleted = await _mediator.Send(deleteOrderCommand);
                if (isDeleted)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                return StatusCode(StatusCodes.Status304NotModified);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("~/api/ConfirmOrder")]
        public async Task<IActionResult> ConfirmOrder(ConfirmOrderCommand confirmOrderCommand)
        {
            try
            {
                var isShipped = await _mediator.Send(confirmOrderCommand);
                if (isShipped)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                return StatusCode(StatusCodes.Status304NotModified);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("~/api/GetAllOrder")]
        public async Task<IActionResult> GetAllOrder([FromQuery] GetAllOrderQuery getAllOrderQuery)
        {
            var result = await _mediator.Send(getAllOrderQuery);
            return Ok(result);
        }

        [HttpGet("~/api/GetOrderById")]
        public async Task<IActionResult> GetOrderById([FromQuery] GetOrderByIdQuery getOrderByIdQuery)
        {
            var result = await _mediator.Send(getOrderByIdQuery);
            return Ok(result);
        }
    }
}