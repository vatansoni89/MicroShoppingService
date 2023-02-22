using Catalog.Database;
using Catalog.Query;
using MediatR;

namespace Catalog.Handler
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, Product?>
    {
        private readonly ICatalogDAL _catalogDAL;

        public GetProductHandler(ICatalogDAL catalogDAL)
        {
            _catalogDAL = catalogDAL;
        }

        public async Task<Product?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _catalogDAL.GetProduct(request.Id);
            return product;

        }
    }
}
