using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ABC_Resturant.Model;
using ABC_Resturant.Database;
using System.Linq;

namespace ABC_Resturant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacilityController : ControllerBase
    {
        private readonly dbContext _dbContext;

        public FacilityController(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: api/Facility
        [HttpPost]
        [Route("AdminAdd")]
        public IActionResult CreateFacility([FromBody] Facility facility)
        {
            if (facility == null)
            {
                return BadRequest("Facility object cannot be null.");
            }

            _dbContext.Facilities.Add(facility);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetAllFacilities), new { id = facility.Id }, facility);
        }

        // PUT: api/Facility/{id}
        [HttpPut("Adminupdate/{id}")]
        public IActionResult UpdateFacility(int id, [FromBody] Facility facility)
        {
            if (facility == null || facility.Id != id)
            {
                return BadRequest("Facility object is null or Id mismatch.");
            }

            var existingFacility = _dbContext.Facilities.Find(id);
            if (existingFacility == null)
            {
                return NotFound("Facility not found.");
            }

            existingFacility.Name = facility.Name;
            existingFacility.Description = facility.Description;
            existingFacility.ImageUrl = facility.ImageUrl;
            existingFacility.Status = facility.Status;
            existingFacility.ResturantId = facility.ResturantId;

            _dbContext.Facilities.Update(existingFacility);
            _dbContext.SaveChanges();

            return NoContent();
        }

        // GET: api/Facility
        [HttpGet]
        [Route("CustomerView")]
        public IActionResult GetAllFacilities()
        {
            var facilities = _dbContext.Facilities
                                     .Include(f => f.Resturant)
                                     .ToList();

            return Ok(facilities);
        }

        // DELETE: api/Facility/{id}
        [HttpDelete("AdminDelete/{id}")]
        public IActionResult DeleteFacility(int id)
        {
            var facility = _dbContext.Facilities.Find(id);
            if (facility == null)
            {
                return NotFound("Facility not found.");
            }

            _dbContext.Facilities.Remove(facility);
            _dbContext.SaveChanges();

            return NoContent();
        }

        // GET: api/Facility/SearchByName/{name}
        [HttpGet("SearchByName/{name}")]
        public IActionResult SearchFacilityByName(string name)
        {
            var facilities = _dbContext.Facilities
                                     .Include(f => f.Resturant)
                                     .Where(f => f.Name.Contains(name))
                                     .ToList();

            if (!facilities.Any())
            {
                return NotFound("No facilities found with the given name.");
            }

            return Ok(facilities);
        }
    }
}
