
using CustomerIdentityWebApi.Commands;
using MediatR;

namespace CustomerIdentityWebApi.Handlers
{
    public class AddCustomerHandler : IRequestHandler<AddCustomerCommand, int>
    {
        private readonly ICustomerDAL _customerDAL;

        public AddCustomerHandler(ICustomerDAL customerDAL)
        {
            this._customerDAL = customerDAL;
        }

        public async Task<int> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            return await this._customerDAL.AddCustomer(request.Customer);

        }

    }
}
