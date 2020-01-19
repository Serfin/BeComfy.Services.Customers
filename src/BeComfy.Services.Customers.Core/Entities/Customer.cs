using System;
using BeComfy.Services.Customers.Core.Exceptions;

namespace BeComfy.Services.Customers.Core.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string Surname { get; private set; }
        public int Age { get; private set; }
        public string Address { get; private set; }
        public decimal Balance { get; private set; }

        public Customer(Guid id, string firstName, string secondName, string surname,
            int age, string address)
        {
            Id = id;
            SetValue(FirstName, firstName);
            SetValue(SecondName, secondName);
            SetValue(Surname, surname);
            SetValue(Address, address);
            SetValue(Age, age);
            Balance = default(decimal);
        }

        private void SetValue(string propertyName, string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new CustomerDomainValidationException(nameof(propertyName), input);
            }

            propertyName = input;
        }

        private void SetValue(int propertyName, int input)
        {
            if (input < 0)
            {
                throw new CustomerDomainValidationException(nameof(input), input);
            }

            propertyName = input;
        }
    }
}