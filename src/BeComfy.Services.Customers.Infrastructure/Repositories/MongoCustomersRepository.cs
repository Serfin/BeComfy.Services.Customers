using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BeComfy.Common.Mongo;
using BeComfy.Services.Customers.Core.Entities;
using BeComfy.Services.Customers.Core.Repositories;

namespace BeComfy.Services.Customers.Infrastructure.Repositories
{
    public class MongoCustomersRepository : ICustomersRepository
    {
        private readonly IMongoRepository<Customer> _collection;

        public MongoCustomersRepository(IMongoRepository<Customer> collection)
        {
            _collection = collection;
        }
        public async Task AddAsync(Customer entity)
            => await _collection.AddAsync(entity);

        public async Task<IEnumerable<Customer>> BrowseAsync(int pageSize, int page)
            => await _collection.BrowseAsync(pageSize, page);

        public async Task<IEnumerable<Customer>> BrowseAsync(int pageSize, int page, 
            Expression<Func<Customer, bool>> predicate)
                => await _collection.BrowseAsync(pageSize, page, predicate);

        public async Task DeleteAsync(Guid id)
            => await _collection.DeleteAsync(id);

        public async Task<Customer> GetAsync(Guid id)
            => await _collection.GetAsync(x => x.Id == id);

        public async Task UpdateAsync(Customer entity)
            => await _collection.UpdateAsync(entity);
    }
}