using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeComfy.Services.Customers.Core.Entities;

namespace BeComfy.Services.Customers.Core.Repositories
{
    public interface ICustomersRepository
    {
        Task AddAsync(Customer customer);
        Task<IEnumerable<Customer>> BrowseAsync(int pageSize, int page);
        Task<Customer> GetAsync(Guid id);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Guid id);
    }
}