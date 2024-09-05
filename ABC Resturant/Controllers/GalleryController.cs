using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ABC_Resturant.Model;
using ABC_Resturant.Database;
using System.Linq;


namespace ABC_Resturant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GalleryController : ControllerBase
    {
        private readonly dbContext _dbContext;

        public GalleryController(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: api/Gallery
        [HttpPost]
        [Route("AdminAdd")]
        public IActionResult CreateGallery([FromBody] Gallery gallery)
        {
            if (gallery == null)
            {
                return BadRequest("Gallery object cannot be null.");
            }

            _dbContext.Galleries.Add(gallery);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetAllGalleries), new { id = gallery.Id }, gallery);
        }

        // GET: api/Gallery
        [HttpGet]
        [Route("CustomerView")]
        public IActionResult GetAllGalleries()
        {
            var galleries = _dbContext.Galleries.Include(g => g.Resturant).ToList();
            return Ok(galleries);
        }

        // DELETE: api/Gallery/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteGallery(int id)
        {
            var gallery = _dbContext.Galleries.Find(id);
            if (gallery == null)
            {
                return NotFound("Gallery not found.");
            }

            _dbContext.Galleries.Remove(gallery);
            _dbContext.SaveChanges();

            return Ok("Gallery deleted successfully.");
        }
    }
}
