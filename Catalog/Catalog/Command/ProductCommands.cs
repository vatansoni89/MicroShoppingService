using Catalog.Database;
using MediatR;

namespace Catalog.Command
{
    public record AddProductCommand(Product Product) : IRequest<int>;
    public record UpdatProductCommand(int Id, Product Product) : IRequest<int>;
    public record DeleteProductCommand(int ProductId) : IRequest<int>;
}
