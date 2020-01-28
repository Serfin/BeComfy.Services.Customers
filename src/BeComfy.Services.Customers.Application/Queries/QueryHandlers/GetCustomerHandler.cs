using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow.Handlers;
using BeComfy.Services.Customers.Application.Dto;
using BeComfy.Services.Customers.Core.Repositories;

namespace BeComfy.Services.Customers.Application.Queries.QueryHandlers
{
    public class GetCustomerHandler : IQueryHandler<GetCustomer, CustomerDto>
    {
        private readonly ICustomersRepository _customersRepository;

        public GetCustomerHandler(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<CustomerDto> HandleAsync(GetCustomer query)
        {
            var customer = await _customersRepository.GetAsync(query.Id);

            return customer is null 
                ? null 
                : new CustomerDto
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    SecondName = customer.SecondName,
                    Surname = customer.Surname,
                    Age = customer.Age,
                    Address = customer.Address,
                    Balance = customer.Balance
                };
        }
    }
}