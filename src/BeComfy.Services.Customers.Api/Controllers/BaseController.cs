using System.Threading.Tasks;
using BeComfy.Common.CqrsFlow;
using BeComfy.Common.CqrsFlow.Dispatcher;
using Microsoft.AspNetCore.Mvc;

namespace BeComfy.Services.Customers.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public BaseController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        protected async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
            => await _queryDispatcher.QueryAsync<TResult>(query);
    }
}