using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ABC_Resturant.Model;
using ABC_Resturant.Database;
using System.Linq;

namespace ABC_Resturant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferController : ControllerBase
    {
        private readonly  dbContext _dbContext;

        public OfferController(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: api/Offer
        [HttpPost]
        [Route("AdminAdd")]
        public IActionResult CreateOffer([FromBody] Offer offer)
        {
            if (offer == null)
            {
                return BadRequest("Offer object cannot be null.");
            }

            _dbContext.Offers.Add(offer);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetAllOffers), new { id = offer.Id }, offer);
        }

        // GET: api/Offer
        [HttpGet]
        [Route("CustomerView")]
        public IActionResult GetAllOffers()
        {
            var offers = _dbContext.Offers
                                 .Include(o => o.Resturant)
                                 .ToList();

            return Ok(offers);
        }

        // PUT: api/Offer/{id}
        [HttpPut("AdminUpdate/{id}")]
        public IActionResult UpdateOffer(int id, [FromBody] Offer offer)
        {
            if (offer == null || offer.Id != id)
            {
                return BadRequest("Offer object is null or Id mismatch.");
            }

            var existingOffer = _dbContext.Offers.Find(id);
            if (existingOffer == null)
            {
                return NotFound("Offer not found.");
            }

            existingOffer.Name = offer.Name;
            existingOffer.Description = offer.Description;
            existingOffer.Discount = offer.Discount;
            existingOffer.StartDate = offer.StartDate;
            existingOffer.EndDate = offer.EndDate;
            existingOffer.Status = offer.Status;
            existingOffer.ResturantId = offer.ResturantId;

            _dbContext.Offers.Update(existingOffer);
            _dbContext.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Offer/{id}
        [HttpDelete("AdminDelete/{id}")]
        public IActionResult DeleteOffer(int id)
        {
            var offer = _dbContext.Offers.Find(id);
            if (offer == null)
            {
                return NotFound("Offer not found.");
            }

            _dbContext.Offers.Remove(offer);
            _dbContext.SaveChanges();

            return NoContent();
        }

        // GET: api/Offer/SearchByName/{name}
        [HttpGet("SearchByName/{name}")]
        public IActionResult SearchOfferByName(string name)
        {
            var offers = _dbContext.Offers
                                 .Include(o => o.Resturant)
                                 .Where(o => o.Name.Contains(name))
                                 .ToList();

            if (!offers.Any())
            {
                return NotFound("No offers found with the given name.");
            }

            return Ok(offers);
        }
    }
}
