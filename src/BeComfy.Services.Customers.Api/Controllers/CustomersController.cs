using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow.Dispatcher;
using BeComfy.Services.Customers.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BeComfy.Services.Customers.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : BaseController
    {
        public CustomersController(IQueryDispatcher queryDispatcher) 
            : base(queryDispatcher)
        {

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] GetCustomer query)
            => Ok(await QueryAsync(query));
    }
}