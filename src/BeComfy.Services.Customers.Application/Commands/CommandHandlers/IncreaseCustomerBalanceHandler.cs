using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow.Handlers;
using BeComfy.Common.RabbitMq;
using BeComfy.Common.Types.Exceptions;
using BeComfy.Services.Customers.Core.Repositories;

namespace BeComfy.Services.Customers.Application.Commands.CommandHandlers
{
    public class IncreaseCustomerBalanceHandler : ICommandHandler<IncreaseCustomerBalance>
    {
        private readonly ICustomersRepository _customersRepository;

        public IncreaseCustomerBalanceHandler(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task HandleAsync(IncreaseCustomerBalance command, ICorrelationContext context)
        {
            var customer = await _customersRepository.GetAsync(command.CustomerId);

            if (customer is null)
            {
                throw new BeComfyException("cannot_increase_balance", $"Customer with id: {command.CustomerId} does not exist");
            }

            customer.IncreaseBalance(command.AmountToAdd);
            await _customersRepository.UpdateAsync(customer);
        }
    }
}