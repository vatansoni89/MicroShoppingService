using CustomerIdentityWebApi.Database;
using MediatR;

namespace CustomerIdentityWebApi.Commands
{

    public record AddCustomerCommand(Customer Customer) : IRequest<int>;
    public record UpdateCustomerCommand(int Id, Customer Customer) : IRequest<int>;
    public record DeleteCustomerCommand(int Id) : IRequest<int>;

}
