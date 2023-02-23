using CustomerIdentityWebApi.Commands;
using MediatR;
using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class UpdateCustomerHandler: IRequestHandler<UpdateCustomerCommand, int>
{
  
    private readonly ICustomerDAL _customerDAL;

    public UpdateCustomerHandler(ICustomerDAL customerDAL)
    {
        _customerDAL = customerDAL;
    }

    public async Task<int> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        return await this._customerDAL.UpdateCustomer(request.Id, request.Customer);
    }

}


