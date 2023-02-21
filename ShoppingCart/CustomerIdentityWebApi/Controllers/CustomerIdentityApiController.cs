using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using DAL;
//using Microsoft.EntityFrameworkCore;
using CustomerIdentityWebApi.CQRS.Queries.Interfaces;
using CustomerIdentityWebApi.CQRS.Commands.Interfaces;
using CustomerIdentityWebApi.Models;


namespace CustomerIdentityWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerIdentityApiController : ControllerBase
    {
        #region CQRS
        private readonly ICustomerCommand _customerCommand;
        private readonly ICustomerQuery _customerQuery;

        public CustomerIdentityApiController(ICustomerCommand customerCommand, ICustomerQuery customerQuery)
        {
            _customerCommand = customerCommand;
            _customerQuery = customerQuery;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerQueryModel>> GetCustomers()
        {
            return await _customerQuery.GetCustomersAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomers(CustomerCommandModel model)
        {
            try
            {
                var product = await _customerCommand.AddCustomersAsync(model);
                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomers(int id,CustomerCommandModel model)
        {
            try
            {
                var customer = await _customerCommand.UpdateCustomersAsync(id,model);
                if(customer != null)
                {
                    return StatusCode(StatusCodes.Status200OK, customer);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
               
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomers(int id)
        {
            try
            {
                var statusId = await _customerCommand.DeleteCustomersAsync(id);
                if(statusId==1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
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
