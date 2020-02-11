using System;
using BeComfy.Common.Mongo;
using BeComfy.Common.Types.Exceptions;

namespace BeComfy.Services.Customers.Core.Entities
{
    public class Customer : IEntity
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string Surname { get; private set; }
        public int Age { get; private set; }
        public string Address { get; private set; }
        public decimal Balance { get; private set; }

        // TODO : Add createdAt and updatedAt properties 

        public Customer(Guid id, string firstName, string secondName, string surname,
            int age, string address)
        {
            SetCustomerId(id);
            SetFirstName(firstName);
            SetSecondName(secondName);
            SetSurname(surname);
            SetAddress(address);
            SetAge(age);
            Balance = default(decimal);
        }

        private void SetCustomerId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new BeComfyException("cannot_create_customer", $"Invalid customer id: '{id}'");
            }

            Id = id;
        }

        private void SetFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new BeComfyException("cannot_create_customer", "Customer first name cannot be null or empty");
            }

            FirstName = firstName;
        }

        private void SetSecondName(string secondName)
        {
            if (string.IsNullOrEmpty(secondName))
            {
                throw new BeComfyException("cannot_create_customer", "Customer second name cannot be null or empty");
            }
        }

        private void SetSurname(string surname)
        {
            if (surname.Length < 0)
            {
                throw new BeComfyException("cannot_create_customer", "Customer surname length cannot be less than 0");
            }

            Surname = surname;
        }

        private void SetAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new BeComfyException("cannot_create_customer", "Customer address name cannot be null or empty");
            }

            Address = address;
        }

        private void SetAge(int age)
        {
            if (age <= 0)
            {
                throw new BeComfyException("cannot_create_customer", "Customer age cannot be less or equal to 0 -> Value = " + age.ToString());
            }

            Age = age;
        }

        public void IncreaseBalance(decimal balance)
        {
            if (balance <= 0)
            {
                throw new BeComfyException("cannot_create_customer", $"Cannot increase balance with value -> {balance}");
            }

            Balance += balance;
        }

        public void DecreaseBalance(decimal balance)
        {
            if (balance <= 0)
            {
                throw new BeComfyException("cannot_create_customer", $"Cannot decrease balance with value -> {balance}");
            }

            Balance -= balance;
        }
    }
}