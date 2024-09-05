using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ABC_Resturant.Model;
using ABC_Resturant.Database;
using System.Collections.Generic;
using System.Linq;

namespace ABC_Resturant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuerysController : ControllerBase
    {
        private readonly dbContext _dbContext;

        public QuerysController(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: api/Querys
        [HttpPost]
        [Route("CustomerAdd")]
        public IActionResult CreateQuery([FromBody] Querys query)
        {
            if (query == null)
            {
                return BadRequest("Query cannot be null.");
            }

            _dbContext.Queries.Add(query);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetAllQueries), new { id = query.Id }, query);
        }

        // GET: api/Querys
        [HttpGet]
        [Route("AdminView")]
        public IActionResult GetAllQueries()
        {
            var queries = _dbContext.Queries
                                  .Include(q => q.Customer)
                                  
                                  .ToList();

            if (queries == null || !queries.Any())
            {
                return NotFound("No queries found.");
            }

            return Ok(queries);
        }

        // DELETE: api/Querys/{id}
        [HttpDelete("AdminDelete/{id}")]
        public IActionResult DeleteQuery(int id)
        {
            var query = _dbContext.Queries.Find(id);
            if (query == null)
            {
                return NotFound("Query not found.");
            }

            _dbContext.Queries.Remove(query);
            _dbContext.SaveChanges();

            return Ok("Query deleted successfully.");
        }
    }
}
