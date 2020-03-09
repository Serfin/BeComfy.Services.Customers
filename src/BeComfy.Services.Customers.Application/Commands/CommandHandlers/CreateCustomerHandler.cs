using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow.Handlers;
using BeComfy.Common.RabbitMq;
using BeComfy.Services.Customers.Application.Events;
using BeComfy.Services.Customers.Core.Entities;
using BeComfy.Services.Customers.Core.Repositories;

namespace BeComfy.Services.Customers.Application.Commands.CommandHandlers
{
    public class CreateCustomerHandler : ICommandHandler<CreateCustomer>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IBusPublisher _busPublisher;

        public CreateCustomerHandler(ICustomersRepository customersRepository, IBusPublisher busPublisher)
        {
            _customersRepository = customersRepository;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(CreateCustomer command, ICorrelationContext context)
        {
            var customer = new Customer(command.Id, command.FirstName, command.SecondName, 
                command.Surname, command.Age, command.Address);

            await _customersRepository.AddAsync(customer);
            await _busPublisher.PublishAsync(new CustomerCreated(command.Id), context);
        }
        
    }
}