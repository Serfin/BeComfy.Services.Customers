using System;

namespace BeComfy.Services.Customers.Core.Exceptions
{
    public class CustomerDomainValidationException : DomainException
    {
        public CustomerDomainValidationException(Guid id)
            : base($"Id: {id} cannot be empty or null")
        {
            
        }

        public CustomerDomainValidationException(string propertyName,  string input)
            : base($"Property {propertyName} cannot be empty or null -> value = {input}")
        {
            
        }

        public CustomerDomainValidationException(string propertyName, int input)
            : base($"Property {propertyName} cannot be less or equal to 0 or null -> value = {input}")
        {
            
        }

        public CustomerDomainValidationException(string propertyName, decimal input)
            : base($"Property {propertyName} cannot be less or equal to 0 or null -> value = {input}")
        {
            
        }
    }
}