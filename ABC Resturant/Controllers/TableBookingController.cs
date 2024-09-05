using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ABC_Resturant.Model;
using ABC_Resturant.Database;
using System.Linq;
using System.Threading.Tasks;

namespace ABC_Resturant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableBookingController : ControllerBase
    {
        private readonly dbContext _dbContext;

        public TableBookingController(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: api/TableBooking
        [HttpPost]
        public async Task<IActionResult> CreateTableBooking([FromBody] TableBooking tableBooking)
        {
            if (tableBooking == null)
            {
                return BadRequest("TableBooking object cannot be null.");
            }

            // Validate input data if necessary
            if (string.IsNullOrEmpty(tableBooking.Type) || string.IsNullOrEmpty(tableBooking.NumberOfTable))
            {
                return BadRequest("Type and NumberOfTable are required.");
            }

            _dbContext.TableBookings.Add(tableBooking);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTableBookingById), new { id = tableBooking.Id }, tableBooking);
        }

        // GET: api/TableBooking
        [HttpGet]
        public async Task<IActionResult> GetAllTableBookings()
        {
            var tableBookings = await _dbContext.TableBookings.Include(t => t.Customer).ToListAsync();
            return Ok(tableBookings);
        }

        // GET: api/TableBooking/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableBookingById(int id)
        {
            var tableBooking = await _dbContext.TableBookings.Include(t => t.Customer).FirstOrDefaultAsync(t => t.Id == id);

            if (tableBooking == null)
            {
                return NotFound("TableBooking not found.");
            }

            return Ok(tableBooking);
        }

        // DELETE: api/TableBooking/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTableBooking(int id)
        {
            var tableBooking = await _dbContext.TableBookings.FindAsync(id);

            if (tableBooking == null)
            {
                return NotFound("TableBooking not found.");
            }

            _dbContext.TableBookings.Remove(tableBooking);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
