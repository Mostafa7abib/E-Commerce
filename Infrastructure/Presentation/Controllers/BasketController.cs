using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Absraction;
using Shared;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController(IServiceManager _serviceManager) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<BasketDto>> GetBasket(string id)
        {
            // Logic to get the basket
            var basket = await _serviceManager.BasketService.GetBasketAsync(id);
            return Ok(basket);  //200
        }
        [HttpPost]
        public async Task<ActionResult<BasketDto>> UpdateBasket(BasketDto basketDto)
        {
            var basket = await _serviceManager.BasketService.UpdateBasketAsync(basketDto);
            return Ok(basket); //200
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBasket(string id)
        {
            await _serviceManager.BasketService.DeleteBasketAsync(id);
            return NoContent(); //200
        }
    }
}
