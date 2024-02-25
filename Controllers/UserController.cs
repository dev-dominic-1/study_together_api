using Microsoft.AspNetCore.Mvc;
using study_together_api.Entities;
using study_together_api.Data;
using Microsoft.EntityFrameworkCore;

/// WARNING: Fat controller. Should be revised to use a Service
namespace study_together_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var result = await _context.Users.Include(u => u.Posts).ToListAsync();
            return Ok(result); // respond 200
        }
    }
}