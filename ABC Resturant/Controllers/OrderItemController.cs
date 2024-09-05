using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ABC_Resturant.Model;
using ABC_Resturant.Database;
using System.Linq;

namespace ABC_Resturant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly dbContext _dbContext;

        public OrderItemController(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: api/OrderItem
        [HttpPost]
        [Route("CustomerAdd")]
        public IActionResult CreateOrderItem([FromBody] OrderItem orderItem)
        {
            if (orderItem == null)
            {
                return BadRequest("OrderItem object cannot be null.");
            }

            _dbContext.OrderItems.Add(orderItem);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetAllOrderItems), new { id = orderItem.Id }, orderItem);
        }

        // GET: api/OrderItem
        [HttpGet]
        [Route("AdminView")]
        public IActionResult GetAllOrderItems()
        {
            var orderItems = _dbContext.OrderItems
                                     .Include(oi => oi.Order)
                                     .Include(oi => oi.Menu)
                                     .ToList();

            return Ok(orderItems);
        }

        // DELETE: api/OrderItem/{id}
        [HttpDelete("CustomerDelete/{id}")]
        public IActionResult DeleteOrderItem(int id)
        {
            var orderItem = _dbContext.OrderItems.Find(id);
            if (orderItem == null)
            {
                return NotFound("OrderItem not found.");
            }

            _dbContext.OrderItems.Remove(orderItem);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
