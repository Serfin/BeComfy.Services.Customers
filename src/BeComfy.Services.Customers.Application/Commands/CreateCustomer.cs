using System;
using BeComfy.Common.CqrsFlow;
using Newtonsoft.Json;

namespace BeComfy.Services.Customers.Application.Commands
{
    public class CreateCustomer : ICommand
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    
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