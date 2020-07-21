using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyShop.APIGateway.Controllers
{

    [ApiController]
    [Route("api/v1/[Controller]")]
    public class BasketController : ControllerBase
    {
        public BasketController()
        {

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasketItemAsync(string Id)
        {
            return null;
        }

        public class BasketData
        {
        }
    }
}