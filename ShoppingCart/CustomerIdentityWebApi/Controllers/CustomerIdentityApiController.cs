using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using DAL;
//using Microsoft.EntityFrameworkCore;
using CustomerIdentityWebApi.CQRS.Queries.Interfaces;
using CustomerIdentityWebApi.CQRS.Commands.Interfaces;
using CustomerIdentityWebApi.Models;
using MediatR;
using CustomerIdentityWebApi.Database;
using CustomerIdentityWebApi.Queries;
using Azure;
using CustomerIdentityWebApi.Commands;

namespace CustomerIdentityWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerIdentityApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerIdentityApiController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(_mediator));
        }

        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            return await _mediator.Send(new GetCustomerListQuery());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddCustomer(Customer customer)
        {
            var result = await _mediator.Send(new AddCustomerCommand(customer));
            return StatusCode(result);
        }

        [HttpPut("{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateCustomer(int Id, Customer customer)
        {
            var result = await _mediator.Send(new UpdateCustomerCommand(Id, customer));
            return StatusCode(result);
        }

        [HttpDelete("{customerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCustomer(int Id)
        {
            var result = await _mediator.Send(new DeleteCustomerCommand(Id));
            return StatusCode(result);

        }
        #region CQRS
        //private readonly ICustomerCommand _customerCommand;
        //private readonly ICustomerQuery _customerQuery;



        //public CustomerIdentityApiController(ICustomerCommand customerCommand, ICustomerQuery customerQuery)
        //{
        //    _customerCommand = customerCommand;
        //    _customerQuery = customerQuery;
        //}

        //[HttpGet]
        //public async Task<IEnumerable<CustomerQueryModel>> GetCustomers()
        //{
        //   // var response = _mediator.Send();
        //    return await _customerQuery.GetCustomersAsync();
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddCustomers(CustomerCommandModel model)
        //{
        //    try
        //    {
        //        var response = await _customerCommand.AddCustomersAsync(model);
        //        return StatusCode(StatusCodes.Status201Created, response);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //}

        //[HttpPut]
        //public async Task<IActionResult> UpdateCustomers(int id,CustomerCommandModel model)
        //{
        //    try
        //    {
        //        var customer = await _customerCommand.UpdateCustomersAsync(id,model);
        //        if(customer != null)
        //        {
        //            return StatusCode(StatusCodes.Status200OK, customer);
        //        }
        //        else
        //        {
        //            return StatusCode(StatusCodes.Status500InternalServerError);
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCustomers(int id)
        //{
        //    try
        //    {
        //        var statusId = await _customerCommand.DeleteCustomersAsync(id);
        //        if(statusId==1)
        //        {
        //            return StatusCode(StatusCodes.Status200OK);
        //        }
        //        else
        //        {
        //            return StatusCode(StatusCodes.Status500InternalServerError);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> AuthenticateUser(LoginModel model)
        //{
        //    var data = await _authService.AuthenticateUser(model);
        //    if (data != null)
        //        return Ok(data);
        //    else
        //        return NotFound("User Not Found!");
        //}
        #endregion CQRS

        #region API Methods without CQRS
        //private DatabaseContext _db;
        //public CustomerIdentityApiController(DatabaseContext db)
        //{
        //    _db = db;
        //}
        //[HttpPost]
        //public IActionResult Add(CustomerDetails model)
        //{
        //    try
        //    {
        //        _db.CustomerDetails.Add(model);
        //        _db.SaveChanges();
        //        // return Ok(data);
        //        return StatusCode(StatusCodes.Status201Created, model);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }

        //}

        //[Produces("application/json")]
        //[HttpGet]
        //public async Task<IEnumerable<CustomerDetails>> GetAll()
        //{
        //    return await _db.CustomerDetails.ToListAsync();
        //}

        //[HttpPut]
        //public IActionResult Update(int id, CustomerDetails model)
        //{
        //    try
        //    {
        //        if (id != model.Id)
        //        {
        //            return BadRequest();
        //        }
        //        _db.CustomerDetails.Update(model);
        //        _db.SaveChanges();
        //        return StatusCode(StatusCodes.Status200OK, model);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }

        //}
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var data = _db.CustomerDetails.Find(id);
        //    if (data != null)
        //    {
        //        _db.CustomerDetails.Remove(data);
        //        _db.SaveChanges();
        //        return StatusCode(StatusCodes.Status200OK);
        //    }
        //    else
        //    {
        //        return StatusCode(StatusCodes.Status204NoContent);
        //    }
        //}

        #endregion API Methods without CQRS
    }
}
