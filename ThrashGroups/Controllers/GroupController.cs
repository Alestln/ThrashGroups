using Microsoft.AspNetCore.Mvc;
using ThrashGroups.Context;

namespace ThrashGroups.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class GroupController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public GroupController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var result = _context.Groups.ToList();
        
        return Ok(result);
    }
}