using System;
using System.Threading.Tasks;
using BeComfy.Services.Customers.Core.Entities;

namespace BeComfy.Services.Customers.Core.Repositories
{
    public interface ICustomersRepository
    {
        Task AddAsync(Customer customer);
        Task<Customer> GetAsync(Guid id);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Customer customer);
    }
}