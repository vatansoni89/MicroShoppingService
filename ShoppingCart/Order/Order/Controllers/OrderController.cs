using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Order.Commands.Interfaces;
using Order.Models;
using Order.Queries.Interfaces;

namespace Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderCommand _orderCommand;
        private readonly IOrderQuery _orderQuery;

        public OrderController(IOrderCommand orderCommand, IOrderQuery orderQuery)
        {
            _orderCommand = orderCommand;
            _orderQuery = orderQuery;
        }

        [HttpGet("~/api/GetAllOrder")]
        public async Task<IActionResult> GetAllOrder([FromQuery] OrderQueryModel orderQueryModel)
        {
            var result = await _orderQuery.GetAllOrder(orderQueryModel);
            return Ok(result);
        }

        [HttpGet("~/api/GetOrderById")]
        public async Task<IActionResult> GetOrderById([FromQuery] OrderQueryModel orderQueryModel)
        {
            var result = await _orderQuery.GetOrderById(orderQueryModel);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(OrderCommandModel orderCommand)
        {
            try
            {
                var order = await _orderCommand.AddOrderAsync(orderCommand);
                return StatusCode(StatusCodes.Status200OK, order);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(OrderCommandModel orderCommand)
        {
            try
            {
                var isUpdated = await _orderCommand.UpdateOrderAsync(orderCommand);
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

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            try
            {
                var isDeleted = await _orderCommand.DeleteOrderAsync(orderId);
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
        public async Task<IActionResult> ConfirmOrder(OrderCommandModel orderCommand)
        {
            try
            {
                var isShipped = await _orderCommand.ConfirmOrderAsync(orderCommand);
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
    }
}