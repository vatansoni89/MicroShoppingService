using CustomerIdentityWebApi.Models;

namespace CustomerIdentityWebApi.CQRS.Queries.Interfaces
{
    public interface ICustomerQuery
    {
        Task<IEnumerable<CustomerQueryModel>> GetCustomersAsync();
    }
}
