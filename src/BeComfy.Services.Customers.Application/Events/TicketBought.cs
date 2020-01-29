using System;
using BeComfy.Common.CqrsFlow;
using BeComfy.Common.Messages;
using Newtonsoft.Json;

namespace BeComfy.Services.Customers.Application.Events
{
    [MessageNamespace("tickets")]
    public class TicketBought : IEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        public decimal TotalPrice { get; }

        [JsonConstructor]
        public TicketBought(Guid id, Guid customerId, decimal totalPrice)
        {
            Id = id;
            CustomerId = customerId;
            TotalPrice = totalPrice;
        }
    }
}