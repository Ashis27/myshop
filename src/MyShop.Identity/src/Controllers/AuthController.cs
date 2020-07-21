using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyShop.Identity.Application.CommandHandlers.LoginUser;
using MyShop.Identity.CommandHandlers.CreateUser;
using MyShop.Identity.Infrastructure.Interfaces;

namespace MyShop.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(CreateUserCommand command)
        {
            command = new CreateUserCommand("Ashis", "Mahapatra", "ashish.mahapatra1991@gmail.com", "Ashis@123",
                                            "User", "XYZ-09", "Bhubaneswar", "Odisha", "India", "768036");

            var response = await _mediator.Send(command);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> SignIn(LoginUserCommand command)
        {
            command = new LoginUserCommand("ashish.mahapatra1991@gmail.com", "Ashis@123",true);
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}