using Microsoft.AspNetCore.Mvc;

namespace BeComfy.Services.Customers.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        public IActionResult GetAction()
            => Ok("BeComfy Customers Microservice");
    }
}