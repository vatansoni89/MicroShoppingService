using Catalog.Command;
using Catalog.Database;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Handler
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly ICatalogDAL catalogDAL;

        public AddProductHandler(ICatalogDAL catalogDAL)
        {
            this.catalogDAL = catalogDAL;
        }

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {           
           return  await this.catalogDAL.AddProduct(request.Product);         
            
        }
    }
}
