using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Database
{
    public class CatalogDAL : ICatalogDAL
    {
        private readonly DatabaseContext _DBContext;

        public CatalogDAL(DatabaseContext dBContext)
        {
            _DBContext = dBContext;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _DBContext.Products.ToListAsync();
        }


        public async Task<Product?> GetProduct(int id)
        {
            return await _DBContext.Products.FindAsync(id);
        }

        public async Task<int> AddProduct(Product product)
        {
            try
            {
                _DBContext.Products.Add(product);
                 await _DBContext.SaveChangesAsync();
                return StatusCodes.Status201Created;
            }
            catch (Exception)
            {
                return StatusCodes.Status500InternalServerError;
            }
        }

        public async Task<int> UpdateProduct(int Id, Product product)
        {
            try{

                if (Id != product.ProductId)
                    return StatusCodes.Status400BadRequest;

                _DBContext.Products.Update(product);
                 await _DBContext.SaveChangesAsync();
                return StatusCodes.Status200OK;
            }
            catch (Exception)
            {
                return StatusCodes.Status500InternalServerError;
            }
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _DBContext.Products.FindAsync(productId);
            if (product != null)
            {
                 _DBContext.Products.Remove(product);
                 await _DBContext.SaveChangesAsync();
               return StatusCodes.Status200OK;
            }
            else {
                return StatusCodes.Status404NotFound;

            }

        }

    }
}
