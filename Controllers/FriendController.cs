using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using study_together_api.Data;
using study_together_api.Entities;

namespace study_together_api.Controllers;

[Route("api/[Controller]")]
 public class FriendController : DbControllerBase<FriendController>
 {
    public FriendController(DataContext context) : base(context) {}

    [HttpGet]
    public async Task<IActionResult> GetFriends()
    {
        return Ok(await _context.Friends.Include(f => f.User).Include(f => f.FriendUser).ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> AddFriend(int userId, int friendUserId)
    {
        Friend friend = new Friend{ UserId = userId, FriendUserId = friendUserId };
        _context.Friends.Add(friend);
        await _context.SaveChangesAsync();
        return Ok(friend);
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveFriend(int userId, int friendUserId)
    {
        Friend friend = await _context.Friends.Where(f => f.UserId == userId && f.FriendUserId == friendUserId).SingleAsync();
        if (friend is null)
            return NotFound("Friend record could not be located");
        _context.Friends.Remove(friend);
        await _context.SaveChangesAsync();
        return Ok(friend);
    }

 }