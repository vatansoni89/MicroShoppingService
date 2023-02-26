using Catalog.Command;
using Catalog.Database;
using MediatR;

namespace Catalog.Handler
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand,int>
    {
        private readonly ICatalogDAL catalogDAL;

        public DeleteProductHandler(ICatalogDAL catalogDAL)
        {
            this.catalogDAL = catalogDAL;
        }

        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await this.catalogDAL.Delete(request.ProductId);
        }
    }
}
