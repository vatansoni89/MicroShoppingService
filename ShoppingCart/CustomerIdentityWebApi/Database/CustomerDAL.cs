using CustomerIdentityWebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class CustomerDAL : ICustomerDAL
{
    private readonly AppDbContext _dbContext;

    public CustomerDAL(AppDbContext dBContext)
    {
        _dbContext = dBContext;
    }

    public async Task<List<Customer>> GetAllCustomers()
    {
        return await _dbContext.Customers.ToListAsync();
    }


    //public async Task<Product?> GetProduct(int id)
    //{
    //    return await _DBContext.Products.FindAsync(id);
    //}

    public async Task<int> AddCustomer(Customer customer)
    {
        try
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return StatusCodes.Status201Created;
        }
        catch (Exception)
        {
            return StatusCodes.Status500InternalServerError;
        }
    }

    public async Task<int> UpdateCustomer(int Id, Customer customer)
    {
        try
        {

            if (Id != customer.CustomerId)
                return StatusCodes.Status400BadRequest;

            _dbContext.Customers.Update(customer);
            await _dbContext.SaveChangesAsync();
            return StatusCodes.Status200OK;
        }
        catch (Exception)
        {
            return StatusCodes.Status500InternalServerError;
        }
    }

    public async Task<int> DeleteCustomer(int Id)
    {
        var customer = await _dbContext.Customers.FindAsync(Id);
        if (customer != null)
        {
            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
            return StatusCodes.Status200OK;
        }
        else
        {
            return StatusCodes.Status404NotFound;

        }

    }

}
