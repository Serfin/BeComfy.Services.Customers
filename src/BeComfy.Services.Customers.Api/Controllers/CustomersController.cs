using BeComfy.Services.Customers.Application.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BeComfy.Services.Customers.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController
    {
        [HttpPost]
        public IActionResult Post(CreateCustomer command)
        {
            return null;
        }
    }
}