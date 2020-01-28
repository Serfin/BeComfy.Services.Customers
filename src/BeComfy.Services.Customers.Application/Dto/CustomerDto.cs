using System;

namespace BeComfy.Services.Customers.Application.Dto
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public decimal Balance { get; set; }
    }
}