using System;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyShop.Basket.Application.CommandAndHandlers;
using MyShop.Basket.Application.Models;
using MyShop.Basket.Application.QueryAndHandlers;
using MyShop.Basket.Infrastructure.Services;

namespace MyShop.Basket.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IIdentityService _identityService;

        public BasketController(IMediator mediator, IIdentityService identityService)
        {
            _mediator = mediator;
            _identityService = identityService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BasketCommand), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBasketItemAsync(string Id)
        {
            var response = await _mediator.Send(new GetBasketItems(Id));

            return Ok(response);
        }

        [HttpPost("update")]
        [ProducesResponseType(typeof(BasketItemModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateItemToBasketAsync([FromBody]BasketItemModel basketItem)
        {
            var response = await _mediator.Send(new BasketCommand(basketItem.BuyerId, basketItem.BasketItems));

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task DeleteBasketByIdAsync(string id)
        {
            await _mediator.Send(new DeleteBasketCommand(id));
        }

        [Route("checkout")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CheckoutAsync([FromBody]BasketCheckoutModel basketCheckout, [FromHeader(Name = "x-requestid")] string requestId)
        {
            var userId = _identityService.GetUserIdentity();

            if (userId != basketCheckout.BuyerId)
            {
                return NotFound($"User does not exist with id: {userId}");
            }

            basketCheckout.UserName = _identityService.GetUserName();

            basketCheckout.RequestId = (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty) ?
                guid : basketCheckout.RequestId;

            bool response = await _mediator.Send(new BasketCheckoutCommand(basketCheckout.BuyerId, 
                basketCheckout.Address, basketCheckout.PaymentMethod, basketCheckout.UserName, basketCheckout.RequestId));

            if (!response)
            {
                return BadRequest();
            }

            return Accepted();
        }
    }
}