using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CartDataAccessLayer.CartAppDbContext;
using CartDataAccessLayer.Entity;
using CartBusinessLogicLayer;

namespace CartAPIEndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartServices _services;

        public CartsController(ICartServices services)
        {
            _services=services;
        }

        // GET: api/Carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> Getcarts()
        {
            var carts = await _services.GetAllCartsAsync();
            return Ok(carts);
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(Guid id)
        {
            var cart = await _services.GetCartAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // POST: api/Carts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(PostCart postCart)
        {
           var check = await _services.CreateCartAsync(postCart);

            if (check) 
            {
                return CreatedAtAction("GetCart", new { id = postCart.CusId }, postCart);
            }

            return NotFound();
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(Guid id)
        {
            var cart = await _services.GetCartAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _services.RemoveCartAsync(id);
            return NoContent();
        }
    }
}
