using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BeComfy.Services.Customers.Core.Entities;

namespace BeComfy.Services.Customers.Core.Repositories
{
    public interface ICustomersRepository
    {
        Task AddAsync(Customer customer);
        Task<IEnumerable<Customer>> BrowseAsync(int pageSize, int page);
        Task<IEnumerable<Customer>> BrowseAsync(int pageSize, int page, 
            Expression<Func<Customer, bool>> predicate);
        Task<Customer> GetAsync(Guid id);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Guid id);
    }
}