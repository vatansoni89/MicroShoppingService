using Catalog.Database;
using MediatR;

namespace Catalog.Query
{
    public record GetProductQuery(int Id) : IRequest<Product?>;
    public record GetAllProductsQuery : IRequest<List<Product>>;
}
