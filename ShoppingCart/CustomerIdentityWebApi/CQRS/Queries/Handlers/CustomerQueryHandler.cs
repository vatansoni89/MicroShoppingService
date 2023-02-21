
using Microsoft.EntityFrameworkCore;
using CustomerIdentityWebApi.CQRS.Queries.Interfaces;
using CustomerIdentityWebApi.Database;
using CustomerIdentityWebApi.Models;

namespace CustomerIdentityWebApi.CQRS.Queries.Handlers
{
    public class CustomerQueryHandler:ICustomerQuery
    {
        AppDbContext _appDbContext;
        public CustomerQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<CustomerQueryModel>> GetCustomersAsync()
        {
            return await _appDbContext.Customers.Select(p => new CustomerQueryModel
            {
                CustomerId = p.CustomerId,
                CustomerName = p.CustomerName,
                CustomerEmail = p.CustomerEmail,
                CustomerPhoneNumber = p.CustomerPhoneNumber
            }).ToListAsync();
        }
    }
}
