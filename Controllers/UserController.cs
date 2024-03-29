using Microsoft.AspNetCore.Mvc;
using study_together_api.Entities;
using study_together_api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection;
using System.ComponentModel;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.OpenApi.Any;
using System.Globalization;
using study_together_api.Utilities;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

/// WARNING: Fat controller. Should be revised to use a Service
namespace study_together_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : DbControllerBase<UserController>    
    {
        public UserController(DataContext context) : base(context) {}

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var result = await _context.Users.ToListAsync();
            return Ok(result); // respond 200
        }

        private async Task<User?> PullUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var result = await PullUser(id);
            if (result is null)
                return NotFound("User record could not be located with id: " + id);
            return Ok(result);
        }

        [HttpGet("findByEmail")]
        public async Task<ActionResult> FindByEmail([FromQuery]string email)
        {
            var result = await _context.Users.Where(u => u.Email == email).SingleOrDefaultAsync();
            if (result is null)
                return NotFound("User record could not be located with email: " + email);
            return Ok(result);
        }

        [HttpGet("{id}/include")]
        public async Task<ActionResult<User>> GetByIdIncludePosts(int id, [FromQuery]bool includePosts = false, [FromQuery]bool includeFriends = false)
        {
            var query = _context.Users.Where(u => u.Id == id);
            if (includePosts) query = query.Include(u => u.Posts);
            if (includeFriends) query = query.Include(u => u.Friends).ThenInclude(f => f.FriendUser);
            User? user = await query.SingleOrDefaultAsync();
            if (user is null)
                return NotFound("User record could not be located");
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<object>> AddUser(string firstName, string lastName, Dictionary<string, dynamic>? props)
        {
            // Start with the required properties, `FirstName` + `LastName`
            var user = new User { FirstName = firstName, LastName = lastName };
            FillPropertyValues(user, props);
            // Add new user to DB context and save
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> EditUser(int id, Dictionary<string, dynamic> props)
        {
            var user = await PullUser(id);
            if (user is null)
                return NotFound("User record could not be located");
            FillPropertyValues(user, props);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUser(int id)
        {
            var user = await PullUser(id);
            if (user is null)
                return NotFound("User record could not be located");
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}