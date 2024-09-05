using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ABC_Resturant.Model;
using ABC_Resturant.Database;
using System.Linq;

namespace ABC_Resturant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly dbContext _dbContext;

        public OrderController(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: api/Order
        [HttpPost]
        [Route("CustomerAdd")]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Order object cannot be null.");
            }

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetAllOrders), new { id = order.Id }, order);
        }

        // GET: api/Order
        [HttpGet]
        [Route("AdminView")]
        public IActionResult GetAllOrders()
        {
            var orders = _dbContext.Orders.Include(o => o.TableBooking).ToList();
            return Ok(orders);
        }

        // DELETE: api/Order/{id}
        [HttpDelete("CustomerDelete/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _dbContext.Orders.Find(id);
            if (order == null)
            {
                return NotFound("Order not found.");
            }

            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();

            return NoContent();
        }

        // PUT: api/Order/{id}
        [HttpPut("CustomerUpdate/{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] Order updatedOrder)
        {
            if (id != updatedOrder.Id)
            {
                return BadRequest("Order ID mismatch.");
            }

            var order = _dbContext.Orders.Find(id);
            if (order == null)
            {
                return NotFound("Order not found.");
            }

            order.Date = updatedOrder.Date;
            order.Amount = updatedOrder.Amount;
            order.TableBookingID = updatedOrder.TableBookingID;

            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();

            return NoContent();
        }

        // GET: api/Order/TableBooking/{tableBookingId}
        [HttpGet("TableBooking/{tableBookingId}")]
        public IActionResult SearchByTableBookingId(int tableBookingId)
        {
            var orders = _dbContext.Orders.Include(o => o.TableBooking)
                                        .Where(o => o.TableBookingID == tableBookingId)
                                        .ToList();

            if (orders == null || !orders.Any())
            {
                return NotFound("No orders found for the given Table Booking ID.");
            }

            return Ok(orders);
        }
    }
}
