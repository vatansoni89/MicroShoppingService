using CustomerIdentityWebApi.Database;
using MediatR;

namespace CustomerIdentityWebApi.Queries
{
    public class GetCustomerListQuery:IRequest<List<Customer>>
    {
    }
}
