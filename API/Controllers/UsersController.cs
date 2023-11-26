using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // .../api/users
public class UsersController : ControllerBase
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    #region Sync methods

    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {
        var users = _context.Users.ToList();

        return users;
    }

    [HttpGet("{id}")] // .../api/users/id
    public ActionResult<AppUser> GetUser(int id)
    {
        var user = _context.Users.Find(id);

        return user;
    }

    [HttpGet("email")]
    public ActionResult GetEmail(string email)
    {
        return Ok(email);
    }

    #endregion

    #region Async methods

    [HttpGet("async")] // .../api/users/async
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersAsync()
    {
        var users = await _context.Users.ToListAsync();

        return users;
    }

    [HttpGet("async/{id}")] // .../api/users/async/id
    public async Task<ActionResult<AppUser>> GetUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);

        return user;
    }

    #endregion
}
