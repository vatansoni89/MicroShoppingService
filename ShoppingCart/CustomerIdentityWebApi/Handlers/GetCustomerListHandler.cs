using CustomerIdentityWebApi.Database;
using MediatR;
using CustomerIdentityWebApi.Queries;
using CustomerIdentityWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerIdentityWebApi.Handlers
{
    public class GetCustomerListHandler:IRequestHandler<GetCustomerListQuery, List<Customer>>
    {
        private readonly ICustomerDAL _customerDAL;

        public GetCustomerListHandler(ICustomerDAL customerDAL)
        {
            _customerDAL = customerDAL;
        }

        public async Task<List<Customer>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            return await _customerDAL.GetAllCustomers();


        }
    }
}
