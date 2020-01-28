using System;
using BeComfy.Common.CqrsFlow;
using BeComfy.Services.Customers.Application.Dto;

namespace BeComfy.Services.Customers.Application.Queries
{
    public class GetCustomer : IQuery<CustomerDto>
    {
        public Guid Id { get; set; }
    }
}