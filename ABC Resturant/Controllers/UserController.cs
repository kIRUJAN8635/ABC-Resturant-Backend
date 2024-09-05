using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ABC_Resturant.Database;
using System.Collections.Generic;
using System.Linq;

namespace ABC_Restaurant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly dbContext _dbContext;

        public UserController(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _dbContext.Users
                                .Include(u => u.Admin)
                                .Include(u => u.Customer)
                                .Include(u => u.Staff)
                                .ToList();

            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }

            return Ok(users);
        }
    }
}
