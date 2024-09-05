using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ABC_Resturant.Model;
using ABC_Resturant.Database;
using System.Linq;

namespace ABC_Resturant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly dbContext _dbContext;

        public PaymentController(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: api/Payment
        [HttpPost]
        [Route("CustomerAdd")]
        public IActionResult CreatePayment([FromBody] Payment payment)
        {
            if (payment == null)
            {
                return BadRequest("Payment object cannot be null.");
            }

            _dbContext.Payments.Add(payment);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetPayment), new { id = payment.Id }, payment);
        }

        // GET: api/Payment/{id}
        [HttpGet("AdminView/{id}")]
        public IActionResult GetPayment(int id)
        {
            var payment = _dbContext.Payments.Include(p => p.Order).FirstOrDefault(p => p.Id == id);

            if (payment == null)
            {
                return NotFound("Payment not found.");
            }

            return Ok(payment);
        }
    }
}
