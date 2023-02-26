using Catalog.Database;
using Catalog.Query;
using MediatR;

namespace Catalog.Handler
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery,List<Product>>
    {

        private readonly ICatalogDAL _catalogDAL;

        public GetAllProductsHandler(ICatalogDAL catalogDAL)
        {
            _catalogDAL = catalogDAL;
        }

        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _catalogDAL.GetAllProducts();
            
           
        }
     
    }
}
