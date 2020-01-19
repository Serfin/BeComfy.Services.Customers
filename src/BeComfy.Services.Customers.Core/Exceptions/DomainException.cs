using System;

namespace BeComfy.Services.Customers.Core.Exceptions
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string message) : base(message)
        {
            
        }
    }
}