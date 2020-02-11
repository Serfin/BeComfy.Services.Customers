using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeComfy.Services.Customers.Core.Entities;
using BeComfy.Services.Customers.Core.Repositories;
using BeComfy.Services.Customers.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace BeComfy.Services.Customers.Infrastructure.Repositories
{
    public class CustomersRepository// : ICustomersRepository
    {
        private readonly CustomersContext _context;

        public CustomersRepository(CustomersContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> BrowseAsync(int pageSize, int page)
            => await _context.Customers
                .OrderBy(x => x.FirstName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        
        public async Task DeleteAsync(Guid id)
        {
            var customer = await GetAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetAsync(Guid id)
            => await _context.Customers.FindAsync(id);

        public async Task UpdateAsync(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}