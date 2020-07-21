using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DShop.Common.Types;
using System.Xml.XPath;
using MyShop.Catalog.Application.Dtos;
using MyShop.Catalog.Application.Queries;
using MediatR;
using System.Threading;
using MyShop.Catalog.Application.Commands;
using Microsoft.AspNetCore.Authorization;

namespace MyShop.Catalog.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("items")]
        [ProducesResponseType(typeof(PaginatedResultBase<CatalogDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCatalogItemsAsync([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0, [FromQuery] string sortOrder = null, [FromQuery] string orderBy = null)
        {
            var response = await _mediator.Send(new GetCatalogItems(pageIndex, pageSize, orderBy, sortOrder, null));

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("item/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CatalogDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetCatalogItemByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(new GetCatalogItem(id));

            if (response != null)
            {
                return Ok(response);
            }

            return NotFound((new { Message = $"Item with id {id} not found." }));
        }


        [HttpPost("create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddCatalogItemAsync([FromBody]CatalogItemDto catalog)
        {
            var command = new CatalogItemCommand(catalog.Name, catalog.Description, catalog.Price,
                catalog.PictureFileName, catalog.CatalogBrandId, catalog.CatalogTypeId, catalog.AvailableStock);

            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut("update")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateProductAsync(UpdateCatalogItemCommand command)
        {
            var catalogItem = await _mediator.Send(new GetCatalogItem(command.Id));

            if (catalogItem == null)
            {
                return NotFound((new { Message = $"Item with id {command.Id} not found." }));
            }

            command = new UpdateCatalogItemCommand(command.Id, command.Catalog);
            await _mediator.Send(command);

            return Ok();

        }

        [HttpDelete("delete/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var catalogItem = await _mediator.Send(new GetCatalogItem(id));

            if (catalogItem == null)
            {
                return NotFound((new { Message = $"Item with id {id} not found." }));
            }

            await _mediator.Send(new DeleteCatalogItemCommand(id));

            return Ok();
        }

    }
}