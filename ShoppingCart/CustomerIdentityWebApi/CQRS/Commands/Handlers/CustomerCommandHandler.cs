using CustomerIdentityWebApi.CQRS.Commands.Interfaces;
using CustomerIdentityWebApi.Database;
using CustomerIdentityWebApi.Models;

namespace CustomerIdentityWebApi.CQRS.Commands.Handlers
{
    public class CustomerCommandHandler:ICustomerCommand
    {
        AppDbContext _appDbContext;
        public CustomerCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<CustomerCommandModel> AddCustomersAsync(CustomerCommandModel model)
        {
            var customer = new Customer
            {
                CustomerName = model.CustomerName,
                CustomerEmail = model.CustomerEmail,
                CustomerPhoneNumber = model.CustomerPhoneNumber
            };
            _appDbContext.Customers.Add(customer);
            await _appDbContext.SaveChangesAsync();

            model.CustomerId = customer.CustomerId;
            return model;
        }

        public async Task<CustomerCommandModel> UpdateCustomersAsync(int id, CustomerCommandModel model)
        {
                if (id != model.CustomerId)
                {
                CustomerCommandModel emptyModel = new CustomerCommandModel();
                    return emptyModel;
                }
                var customer = new Customer
                {
                    CustomerId=model.CustomerId,
                    CustomerName = model.CustomerName,
                    CustomerEmail = model.CustomerEmail,
                    CustomerPhoneNumber = model.CustomerPhoneNumber
                };
                _appDbContext.Customers.Update(customer);
                await _appDbContext.SaveChangesAsync();
                return  model;

        }

        public async Task<int> DeleteCustomersAsync(int id)
        {
            var data = _appDbContext.Customers.Find(id);
            if (data != null)
            {
                _appDbContext.Customers.Remove(data);
                await _appDbContext.SaveChangesAsync();
                return 1;
            }
            else
            {
               return 0;
            }
        }
    }
}
