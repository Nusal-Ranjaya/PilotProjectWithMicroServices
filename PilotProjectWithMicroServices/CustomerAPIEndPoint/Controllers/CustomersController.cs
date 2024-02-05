using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerDataLayer.CustomerAppDBContext;
using CustomerDataLayer.Entity;
using CustomerBusinessLogicLayer;

namespace CustomerAPIEndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServices _service;

        public CustomersController(ICustomerServices service)
        {
            _service=service;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReqResCustomer>>> GetReqResCustomers()
        {
            var customers =await _service.GetAllReqResCustomerAsync();
            return Ok(customers);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReqResCustomer>> GetInternalCustomer(Guid id)
        {
            var internalCustomer = await _service.GetReqResCustomerAsync(id);

            if (internalCustomer == null)
            {
                return NotFound();
            }

            return internalCustomer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInternalCustomer(Guid id, PostCustomer postCustomer)
        {
            var internalCustomer = _service.GetInternalCustomerAsync(id);
            if (internalCustomer == null)
            {
                return BadRequest();
            }

            _service.UpdateCustomerAsync(id,postCustomer);

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void PostInternalCustomer(PostCustomer PostCustomer)
        {
            _service.CreateCustomerAsync(PostCustomer);
            

           // return CreatedAtAction("GetInternalCustomer", new { id = PlCustomer.Id }, internalCustomer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInternalCustomer(Guid id)
        {
            var internalCustomer = await _service.GetInternalCustomerAsync(id);
            if (internalCustomer == null)
            {
                return NotFound();
            }

            _service.DeleteCustomerAsync(id);
            

            return NoContent();
        }
    }
}
