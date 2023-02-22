namespace Catalog.Database
{
    public interface ICatalogDAL
    {
        Task<int> AddProduct(Product product);
        Task<List<Product>> GetAllProducts();
        Task<Product?> GetProduct(int id);
        Task<int> UpdateProduct(int Id,Product product);
        Task<int> Delete(int productId);
    }
}