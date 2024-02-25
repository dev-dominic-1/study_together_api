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
            var result = await _context.Users.ToListAsync();
            return Ok(result); // respond 200
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int Id)
        {
            var result = await _context.Users
                .Include(u => u.Posts)
                .Where(u => u.Id == Id)
                .SingleOrDefaultAsync();
            if (result == null) {
                return NotFound();
            }
            return Ok(result);
        }
    }
}