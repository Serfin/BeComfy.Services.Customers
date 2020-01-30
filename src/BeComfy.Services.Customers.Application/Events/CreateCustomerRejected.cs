using System;
using BeComfy.Common.CqrsFlow;
using Newtonsoft.Json;

namespace BeComfy.Services.Customers.Application.Events
{
    public class CreateCustomerRejected : IRejectedEvent
    {
        public Guid CustomerId { get; }
        public string Code { get; }
        public string Reason { get; }

        [JsonConstructor]
        public CreateCustomerRejected(Guid customerId, string code, string reason)
        {
            CustomerId = customerId;
            Code = code;
            Reason = reason;
        }
    }
}