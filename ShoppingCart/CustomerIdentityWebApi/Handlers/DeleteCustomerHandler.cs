using CustomerIdentityWebApi.Commands;
using MediatR;
using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, int>
{
    private readonly ICustomerDAL _customerDAL;
    public DeleteCustomerHandler(ICustomerDAL customerDAL)
	{
        _customerDAL = customerDAL;
    }
    public async Task<int> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        return await this._customerDAL.DeleteCustomer(request.Id);
    }
}
