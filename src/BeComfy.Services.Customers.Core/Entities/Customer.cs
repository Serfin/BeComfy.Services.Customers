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
            Id = id; // USE ID FROM JWT
            SetFirstName(firstName);
            SetSecondName(secondName);
            SetSurname(surname);
            SetAddress(address);
            SetAge(age);
            Balance = default(decimal);
        }

        private void SetFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new CustomerDomainValidationException("Customer first name cannot be null or empty");
            }

            FirstName = firstName;
        }

        private void SetSecondName(string secondName)
        {
            SecondName = secondName;
        }

        private void SetSurname(string surname)
        {
            // if (string.IsNullOrEmpty(surname))
            // {
            //     throw new CustomerDomainValidationException("Customer surname cannot be null or empty");
            // }

            Surname = surname;
        }

        private void SetAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new CustomerDomainValidationException("Customer address name cannot be null or empty");
            }

            Address = address;
        }

        private void SetAge(int age)
        {
            if (age <= 0)
            {
                throw new CustomerDomainValidationException("Customer age cannot be less or equal to 0 -> Value = " + age.ToString());
            }

            Age = age;
        }
    }
}