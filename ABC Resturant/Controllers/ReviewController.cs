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
    public class ReviewController : ControllerBase
    {
        private readonly dbContext _dbContext;

        public ReviewController(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: api/Review
        [HttpPost]
        [Route("CustomerAdd")]
        public async Task<IActionResult> CreateReview([FromBody] Review review)
        {
            if (review == null)
            {
                return BadRequest("Review object cannot be null.");
            }

            

            _dbContext.Reviews.Add(review);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReviewById), new { id = review.Id }, review);
        }

        // GET: api/Review
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _dbContext.Reviews
                                           .Include(r => r.Customer)
                                           .Include(r => r.Resturant)
                                           .ToListAsync();

            if (reviews == null || !reviews.Any())
            {
                return NotFound("No reviews found.");
            }

            return Ok(reviews);
        }

        // DELETE: api/Review/{id}
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _dbContext.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound("Review not found.");
            }

            _dbContext.Reviews.Remove(review);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Review/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var review = await _dbContext.Reviews
                                           .Include(r => r.Customer)
                                           .Include(r => r.Resturant)
                                           .FirstOrDefaultAsync(r => r.Id == id);

            if (review == null)
            {
                return NotFound("Review not found.");
            }

            return Ok(review);
        }
    }
}
