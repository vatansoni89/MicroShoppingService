using CustomerIdentityWebApi.Database;
using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public interface ICustomerDAL
{
    Task<int> AddCustomer(Customer customer);
    Task<List<Customer>> GetAllCustomers();
  //  Task<Product?> GetProduct(int id);
    Task<int> UpdateCustomer(int Id, Customer customer);
    Task<int> DeleteCustomer(int Id);
}
