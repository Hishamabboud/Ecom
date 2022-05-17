using DataAccess.Models;
namespace DataAccess.Data;
public interface ICustomerData
{
    Task DeleteCustomer(int id);
    Task<Customer?> GetUser(int id);
    Task<IEnumerable<Customer>> GetUsers();
    Task CreateCustomer(Customer customer);
    Task UpdateCustomer(Customer customer);
}