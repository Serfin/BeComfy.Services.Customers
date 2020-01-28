using System;
using BeComfy.Common.CqrsFlow;
using Newtonsoft.Json;

namespace BeComfy.Services.Customers.Application.Commands
{
    public class CreateCustomer : ICommand
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string SecondName { get; }
        public string Surname { get; }
        public int Age { get; }
        public string Address { get; }
    
        [JsonConstructor]
        public CreateCustomer(Guid id, string firstName, string secondName, string surname, 
            int age, string address)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            Surname = surname;
            Age = age;
            Address = address;
        }
    }
}