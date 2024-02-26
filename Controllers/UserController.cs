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

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var result = await _context.Users
                .Include(u => u.Posts)
                .Where(u => u.Id == id)
                .SingleOrDefaultAsync();
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        private async Task<User?> PullUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<object>> AddUser(string firstName, string lastName, Dictionary<string, dynamic>? props)
        {
            // Start with the required properties, `FirstName` + `LastName`
            var user = new User { FirstName = firstName, LastName = lastName };
            // Instantiate a Utility instance of `User` to set properties using Reflection
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