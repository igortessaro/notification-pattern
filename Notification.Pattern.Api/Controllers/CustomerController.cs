using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notification.Pattern.Api.Commands.Customer;
using System.Threading.Tasks;

namespace Notification.Pattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand customer)
        {
            Core.Notification result = await _mediator.Send(customer);

            return Ok(result);
        }
    }
}