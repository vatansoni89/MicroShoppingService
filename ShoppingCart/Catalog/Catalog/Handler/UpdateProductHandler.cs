using Catalog.Command;
using Catalog.Database;
using MediatR;

namespace Catalog.Handler
{
    public class UpdateProductHandler : IRequestHandler<UpdatProductCommand, int>
    {
        private readonly ICatalogDAL catalogDAL;

        public UpdateProductHandler(ICatalogDAL catalogDAL)
        {
            this.catalogDAL = catalogDAL;
        }

        public async Task<int> Handle(UpdatProductCommand request, CancellationToken cancellationToken)
        {
            return await this.catalogDAL.UpdateProduct(request.Id, request.Product);
        }
    }
}
