using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow.Handlers;
using BeComfy.Common.RabbitMq;
using BeComfy.Common.Types.Exceptions;
using BeComfy.Services.Customers.Core.Repositories;

namespace BeComfy.Services.Customers.Application.Events.EventHandlers
{
    public class TicketBoughtHandler : IEventHandler<TicketBought>
    {
        private readonly ICustomersRepository _customersRepository;

        public TicketBoughtHandler(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task HandleAsync(TicketBought @event, ICorrelationContext context)
        {
            var customer = await _customersRepository.GetAsync(@event.CustomerId);

            if (customer is null)
            {
                throw new BeComfyException("cannot_decrease_balance", $"Customer with id: {@event.CustomerId} does not exist");
            }

            customer.DecreaseBalance(@event.TotalPrice);
            await _customersRepository.UpdateAsync(customer);
        }
    }
}