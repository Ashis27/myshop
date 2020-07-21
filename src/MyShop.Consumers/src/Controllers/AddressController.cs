using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyShop.Consumer.Application.Commands.Address;

namespace MyShop.Consumer.Controllers
{
    [Route("api/[controler]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [Authorize(Roles = "User")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddUserAdress(AddressCommand command)
        {
            bool response = await _mediator.Send(command);

            if (!response)
            {
                return NotFound($"Consumer with given id: {command.UserId} not found!");
            }

            return Ok(response);
        }
    }
}