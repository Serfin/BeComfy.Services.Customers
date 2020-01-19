using Microsoft.AspNetCore.Mvc;

namespace BeComfy.Services.Customers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
            => Ok("BeComfy Customers Microservice");
    }
}