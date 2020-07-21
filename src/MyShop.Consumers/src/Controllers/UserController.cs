using System;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyShop.Consumer.Application.QueryAndHandlers;

namespace MyShop.Basket.Controllers
{
    [Route("api/[Controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {         
            _mediator = mediator;
        }

        [HttpGet("get/{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetConsumerAsync(Guid id)
        {
            if (id != null)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(new GetConsumerQuery(id));

            if (response == null)
            {
                return NotFound($"User with id: {id} not found.");
            }

            return Ok(response);
        }

        [HttpGet("update")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateConsumerAsync(Guid id)
        {
            if (id != null)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(new GetConsumerQuery(id));

            if (response == null)
            {
                return NotFound($"User with id: {id} not found.");
            }

            return Ok(response);
        }
    }
}