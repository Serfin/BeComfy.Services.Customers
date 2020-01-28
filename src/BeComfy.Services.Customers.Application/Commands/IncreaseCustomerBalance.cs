using System;
using BeComfy.Common.CqrsFlow;
using Newtonsoft.Json;

namespace BeComfy.Services.Customers.Application.Commands
{
    public class IncreaseCustomerBalance : ICommand
    {
        public Guid CustomerId { get; }
        public decimal AmountToAdd { get; }

        [JsonConstructor]
        public IncreaseCustomerBalance(Guid customerId, decimal amountToAdd)
        {
            CustomerId = customerId;
            AmountToAdd = amountToAdd;
        }
    }
}