using System;

namespace BeComfy.Services.Customers.Core.Exceptions
{
    public class CustomerDomainValidationException : DomainException
    {
        public CustomerDomainValidationException(string message)
            : base(message)
        {
            
        }
    }
}