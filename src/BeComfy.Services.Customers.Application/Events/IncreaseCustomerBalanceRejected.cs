using System;
using BeComfy.Common.CqrsFlow;
using Newtonsoft.Json;

namespace BeComfy.Services.Customers.Application.Events
{
    public class IncreaseCustomerBalanceRejected : IRejectedEvent
    {
        public Guid CustomerId { get; }
        public string Code { get; }
        public string Reason { get; }

        [JsonConstructor]
        public IncreaseCustomerBalanceRejected(Guid customerId, string code, string reason)
        {
            CustomerId = customerId;
            Code = code;
            Reason = reason;
        }
    }
}