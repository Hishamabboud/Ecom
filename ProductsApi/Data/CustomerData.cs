using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Data;

namespace DataAccess.Data;

public class CustomerData : ICustomerData
{
    private readonly ISqlDataAccess _db;

    public CustomerData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<Customer>> GetUsers() =>
        _db.LoadData<Customer, dynamic>("dbo.spUser_GetAll", new { });

    public async Task<Customer?> GetUser(int id)
    {
        var results = await _db.LoadData<Customer, dynamic>(
            "dbo.spUser_Get",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task CreateCustomer(Customer customer) =>
        _db.SaveData("dbo.Customer_Create", new { customer.FName, customer.LName });

    public Task UpdateCustomer(Customer customer) =>
        _db.SaveData("dbo.Customer_Update", customer);

    public Task DeleteCustomer(int id) =>
        _db.SaveData("dbo.Customer_Delete", new { Id = id });
}
