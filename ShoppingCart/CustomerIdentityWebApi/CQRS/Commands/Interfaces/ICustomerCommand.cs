using CustomerIdentityWebApi.Models;

namespace CustomerIdentityWebApi.CQRS.Commands.Interfaces
{
    public interface ICustomerCommand
    {
        Task<CustomerCommandModel> AddCustomersAsync(CustomerCommandModel model);
        Task<CustomerCommandModel> UpdateCustomersAsync(int id , CustomerCommandModel model);
        Task<int> DeleteCustomersAsync(int id);

    }
}
